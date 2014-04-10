using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.SqlClient;
using System.Data.SqlClient;

namespace DAL
{
    //Author - Kaung Myat
    public class RequisitionEnt
    {
        LOGIC_UniversityEntities ContextDB;
        DALUtilities dalUtl;

        public RequisitionEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
            dalUtl = new DALUtilities();
        }

        public void createRequisition(Requisition req)
        {
            ContextDB.Requisitions.AddObject(req);
            ContextDB.SaveChanges();
            dalUtl.Increament_GenID(1);

        }

        public List<view_RequisitionDisbursementStatus> getRequisitionDisbursementStatus(string empID, int approvestatus1, int approvestatus2)
        {
            var d_status = new int[] { 0, 1, 2, 3 };
            var q = from vr in ContextDB.view_RequisitionDisbursementStatus
                    where vr.Emp_ID == empID && d_status.Contains((int)vr.Approval_Status)

                    select vr;
            //select new
            //{
            //    Req_Form_No = vr.Req_Form_No,
            //    Approval_Status = vr.Approval_Status,
            //    Disb_Date = vr.Date,
            //    Disb_Status = vr.Disburse_Status
            //}.ToString();

            return q.ToList<view_RequisitionDisbursementStatus>();
        }

        public view_RequisitionDisbursementStatus getReqStatusByFrmNo(string frmNo)
        {
            var q = from vr in ContextDB.view_RequisitionDisbursementStatus
                    where vr.Req_Form_No == frmNo
                    select vr;
            return q.First();
        }

        public void bundleAllRequisitions(string reqFrmNo, string DeptID, string empID)
        {
            SqlParameter param1 = new SqlParameter("@Req_Frm_No", reqFrmNo);
            SqlParameter param2 = new SqlParameter("@deptID", DeptID);
            SqlParameter param3 = new SqlParameter("@EmpID", empID);
            ContextDB.ExecuteStoreCommand("BundleAllRequisitions @Req_Frm_No,@deptID, @EmpID", param1, param2, param3);
            ContextDB.SaveChanges();
            dalUtl.Increament_GenID(1);
        }

        public void bundleSelectedRequisition(List<Requisition> lstReqNo, string reqFrmNo, string empID, string deptID, List<Requisition> lstRej)
        {
            var q = from lr in lstReqNo
                    join rd in ContextDB.Requisition_Detail on lr.Req_Form_No equals rd.Req_Form_No
                    join s in ContextDB.Stationary_Catalogue on rd.Item_Code equals s.Item_Code
                    group rd by new { rd.Item_Code, s.Description } into g
                    select new Requisition_Detail
                    {
                        //Req_Form_No = g.Key.Req_Form_No,
                        Item_Code = g.Key.Item_Code,
                        Description = g.Key.Description,
                        Qty = g.Sum(rd => rd.Qty)
                    };

            RequisitionEnt reqE = new RequisitionEnt();
            Requisition req = new Requisition();
            req.Req_Form_No = reqFrmNo;
            req.Emp_ID = empID;
            req.Approval_Status = 3;
            req.Approval_Date = DateTime.Now;
            req.Approval_By = null;
            req.Req_Status = false;
            req.Notification = false;
            req.Prior = false;

            reqE.createRequisition(req);

            foreach (var val in q)
            {
                Requisition_Detail rd = new Requisition_Detail();
                rd.Req_Form_No = reqFrmNo;
                rd.Item_Code = val.Item_Code;
                rd.Description = val.Description;
                rd.Qty = val.Qty;

                RequisitionDetailEnt rdE = new RequisitionDetailEnt();
                rdE.createReqDetail(rd);

            }

            foreach (var val in lstReqNo)
            {
                Requisition reqt = (Requisition)val;
                reqt.Approval_Status = 2;

                updateRequisition(reqt);

            }
            foreach (var val in lstRej)
            {
                Requisition reqt = (Requisition)val;
                reqt.Approval_Status = 0;

                updateRequisition(reqt);

            }

        }
        //>>>>>>>>>>>>>>Rajna
        public IQueryable getRejectedListForHead(string DeptID)
        {
            var query = from r in ContextDB.Requisitions
                        join us in ContextDB.Users
                        on new { r.Emp_ID } equals new { us.Emp_ID }
                        where r.Approval_Status == 0 && us.Dept_ID == DeptID && r.Rej_Comment ==null
                        select new
                        {
                            Form_No = r.Req_Form_No,
                            Emp_Name = us.Emp_Name,
                            Status = "Rejected",
                            Req_Date = r.Request_Date
                        };
            return query;
        }
        //>>>>>>>>>
        public List<Requisition> getRequisitionForEmp(User user)
        {
            var query = from r in ContextDB.Requisitions
                        where r.Emp_ID == user.Emp_ID
                        select r;

            return query.ToList<Requisition>();
        }

        public IQueryable getPendingRequisition(string DeptID)
        {
            var query = from r in ContextDB.Requisitions
                        join us in ContextDB.Users
                        on new { r.Emp_ID } equals new { us.Emp_ID }
                        where r.Approval_Status == 1 && us.Dept_ID == DeptID
                        select new
                        {
                            Form_No = r.Req_Form_No,
                            Emp_Name = us.Emp_Name,
                            Status = "Pending",
                            Req_Date = r.Request_Date
                        };
            return query;
        }

        public List<Requisition> getRequisitionForDeptHead(User user)
        {
            var query = from r in ContextDB.Requisitions
                        join emp in ContextDB.Users on new { r.Emp_ID } equals new { emp.Emp_ID }
                        where emp.Dept_ID == user.Dept_ID
                        select r;

            return query.ToList<Requisition>();
        }

        public List<Requisition> getRequisitionForClerk()
        {
            var query = from r in ContextDB.Requisitions 
                        where r.Approval_Status == 3 &&
                        (SqlFunctions.DatePart("dw", r.Approval_Date) < 3 || SqlFunctions.DatePart("wk", r.Approval_Date) < SqlFunctions.DatePart("wk", DateTime.Today))
                        //SqlFunctions.DatePart("dw", r.Request_Date) < 3 || SqlFunctions.DatePart("wk", r.Request_Date) < SqlFunctions.DatePart("wk", DateTime.Today)//DateTime.Today
                        select r; 

            return query.ToList<Requisition>(); 
        } 

        public Requisition getRequisition(Requisition req) 
        {
            var query = from r in ContextDB.Requisitions
                        where r.Req_Form_No == req.Req_Form_No 
                        select r;

            return query.First();
        }

        public Requisition getRequisitionByID(string reqid)
        {
            var q = from r in ContextDB.Requisitions
                    where r.Req_Form_No == reqid
                    select r;

            return q.First();
        }


        public List<Requisition_Detail> getRequisitionDetailsByID(string reqid)
        {
            var query = from rd in ContextDB.Requisition_Detail
                        where rd.Req_Form_No == reqid
                        select rd;
            return query.ToList<Requisition_Detail>();

        }


        //public IQueryable getPendingRequisition(string DeptID)
        //{
        //    var query = from r in ContextDB.Requisitions
        //                join us in ContextDB.Users
        //                on new { r.Emp_ID } equals new { us.Emp_ID }
        //                where r.Approval_Status == 1 && us.Dept_ID == DeptID
        //                select new
        //                {
        //                    Form_No = r.Req_Form_No,
        //                    Emp_Name = us.Emp_Name,
        //                    Status = "Pending",
        //                    Req_Date = r.Request_Date
        //                };
        //    return query;
        //}

        public bool updateRequisition(Requisition req)
        {
            try
            {
                Requisition r = getRequisition(req);
                r.Approval_Status = req.Approval_Status == null? r.Approval_Status: req.Approval_Status;
                r.Request_Date = req.Request_Date == null?r.Request_Date : req.Request_Date;
                r.Approval_Date = req.Approval_Date == null? r.Approval_Date : req.Approval_Date;
                r.Approval_By = req.Approval_By == null? r.Approval_By : req.Approval_By;
                r.Req_Status = !req.Req_Status.HasValue ? r.Req_Status : req.Req_Status;
                r.Rej_Comment = req.Rej_Comment == null ? r.Rej_Comment : req.Rej_Comment;
                r.Notification = req.Notification == null? r.Notification : req.Notification; 
                r.Prior = !req.Prior.HasValue ? r.Prior : req.Prior; 

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteRequisition(Requisition req)
        {
            try{
                ContextDB.Requisitions.DeleteObject(req);
                ContextDB.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
