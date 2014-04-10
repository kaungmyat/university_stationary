using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    //Author - ZhangNa
    public class EntityBroker
    {
        LOGIC_UniversityEntities entity = new LOGIC_UniversityEntities();

        //get Requisition Form
        public IQueryable getRequisitionForm()
        {
            var v = from rm in entity.Requisitions
                    where rm.Approval_Status == 1
                    join rdm in entity.Requisition_Detail on rm.Req_Form_No equals rdm.Req_Form_No
                    select new {
                        RequisitionFormNo = rm.Req_Form_No,
                        ItemCode = rdm.Item_Code,
                        Description = rdm.Description,
                        Quantity = rdm.Qty,
                        Prior = rm.Prior,
                        Approval_Status = rm.Approval_Status
                    };
            return v;
        }

        //for auto check stockItem balance
        public IQueryable getBalance_From_ItemCode(string itemCode)
        {
            var v = from scm in entity.StockCards
                    where scm.Item_Code == itemCode
                    join scd in entity.StockCard_Detail on scm.StockCard_ID equals scd.StockCard_ID
                    select scd.Balance;
            return v;
            //var scdm = entity.StockCard_Detail.Where(x => x.StockCard_ID == scm.StockCard_ID).SingleOrDefault();
            //return (Int32)scdm.Balance;
        }

        //setPrior
        public void setPriorByRequisitionFormNo(string Requisition_FormNo) {
            Requisition rm = entity.Requisitions.Where(x => x.Req_Form_No == Requisition_FormNo).First();
            rm.Prior = true;
            entity.SaveChanges();
        }

        //get disbursement list
        public IQueryable getDisbursementList()
        {
            var v = from dm in entity.Disbursements
                    join dept in entity.Departments on dm.Dept_ID equals dept.Dept_ID
                    where dm.Disburse_Status == 1
                    select new {
                        RequisitionFormNo = dm.Req_Form_No,
                        DepartmentName = dept.Dept_Name,
                        DisbursementNumber = dm.Disbursement_ID
                    };
            return v;
        }

        //get disbursement Detail list
        public IQueryable getDisbursementDetail(string disbursement_ID) {
            var v = from dm in entity.Disbursements
                    where dm.Disburse_Status == 1 && dm.Disbursement_ID == disbursement_ID
                    join ddm in entity.Disbursement_Detail on dm.Disbursement_ID equals ddm.Disbursement_ID
                    join sc in entity.Stationary_Catalogue on ddm.Item_Code equals sc.Item_Code
                    select new
                    {
                        ItemCode = ddm.Item_Code,
                        StationaryDescription = sc.Description,
                        RequestedQuantity = ddm.Qty_Required,
                        RetrievedQuantity = ddm.Qty_Retrieved,
                        DisbursedQuantity = ddm.Qty_Disbursed
                    };
            return v;
        }

        public string getCollectionPoint(string dept)
        {
            var v = entity.Departments.Where(x => x.Dept_Name == dept).FirstOrDefault();
            return v.Collection_Point;
        }

        public DateTime getDisbursementDate(string disbursementID)
        {
            var disburseDate = entity.Disbursements.Where(x => x.Disbursement_ID == disbursementID).SingleOrDefault();
            return (DateTime)disburseDate.Date;
        }



        //click submit update_status at disbursement List Details biz logic(Qty_R - Qty_D = 0) need here
        public int updateDisbursementStatus_1to2(string disbursement_ID) {
            var row = entity.Disbursements.Where(x => x.Disbursement_ID == disbursement_ID).SingleOrDefault();//string can ==??
            row.Disburse_Status = 2;
            int i = entity.SaveChanges();
            return i;
        }

        //click submit update_status at disbursement List Details biz logic(Qty_R - Qty_D > 0) need here
        public int updateDisbursementStatus_1to3(string disbursement_ID)
        {
            var row = entity.Disbursements.Where(x => x.Disbursement_ID == disbursement_ID).SingleOrDefault();//string can ==??
            row.Disburse_Status = 3;
            int i = entity.SaveChanges();
            return i;
        }

        //public int update

        //click submit update_disbursedQty at disbursement List Details(use foreach loop in biz layer)
        public int updateQty_Disbursed(int qty_Disbursed, string disbursementID, string itemcode) {
            var row = entity.Disbursement_Detail.Where(x => x.Disbursement_ID == disbursementID && x.Item_Code==itemcode).SingleOrDefault();
            row.Qty_Disbursed = qty_Disbursed;
            int i = entity.SaveChanges();
            return i;
        }

        //for disbursementList to get Department Name using req_Form_No.???
        public string getDeptName_From_ReqFormNo(string reqFormNo)
        {
            var deptm = entity.Departments.Where(x => x.Dept_ID == reqFormNo.Substring(0, 3)).SingleOrDefault();
            return deptm.Dept_Name;
        }

        //get retrieval_dept form
        public IQueryable getRetrievalDeptForm()
        {
            //var v = from ddm in entity.Disbursements.GroupBy(p => p.Dept_ID)
            var v = from dm in entity.Disbursements
                    join ddm in entity.Disbursement_Detail on dm.Disbursement_ID equals ddm.Disbursement_ID
                    join dept in entity.Departments on dm.Dept_ID equals dept.Dept_ID
                    select new { 
                        DeptName = dept.Dept_Name,
                        Needed = ddm.Qty_Required,
                        Actual = ddm.Qty_Retrieved
                    };
            return v;
        }

        //get retrieval_item form
        public IQueryable getRetrievalItemForm()
        {
            var v = from rdm in entity.Requisition_Detail //group rdm by rdm.Item_Code into r
                    join ddm in entity.Disbursement_Detail on rdm.Item_Code equals ddm.Item_Code
                    join sc in entity.Stationary_Catalogue on rdm.Item_Code equals sc.Item_Code
                    select new {
                        StationeryDescription = sc.Description,
                        Needed = ddm.Qty_Required,
                        Retrieved = ddm.Qty_Retrieved
                    };
            return v;
        }

        //update requisition status after click 'Submit' btn at Retrieval Form UI
        public int updateApproval_Status(string reqNo) {
            var rmRow = entity.Requisitions.Where(x => x.Req_Form_No == reqNo).SingleOrDefault();
            rmRow.Req_Status = true;
            rmRow.Approval_Status = 4;
            int i = entity.SaveChanges();
            return i;
        }

        //insert/create new row to disbursement when click 'Submit' at retrieval UI
        public int insertDisbursement(string reqNo) {
            var disbursement = new Disbursement {
                Req_Form_No = reqNo,
                Dept_ID = reqNo.Substring(0,3),
                Date = DateTime.Today,
                Disburse_Status = 1
            };
            entity.Disbursements.AddObject(disbursement);
     
            int i = entity.SaveChanges();
            return i;
        }
        //insert/create new row to disbursement detail when click 'Submit at retrieval UI
        public int insertDisbursementDetail(Requisition_Detail rdm)
        {
            var disbursement_Detail = new Disbursement_Detail
            {
                Item_Code = rdm.Item_Code,
                Qty_Required = rdm.Qty,
            };
            entity.Disbursement_Detail.AddObject(disbursement_Detail);

            int i = entity.SaveChanges();
            return i;
        }

        public int insertDisbursementDetail(Disbursement_Detail ddm)//should be update
        {
            var disbursement_Detail = new Disbursement_Detail
            {
                Item_Code = ddm.Item_Code,
                Qty_Required = ddm.Qty_Required - ddm.Qty_Disbursed,
            };
            entity.Disbursement_Detail.AddObject(disbursement_Detail);

            int i = entity.SaveChanges();
            return i;
        }

        //view OutStanding Requisition
        public IQueryable getOutStandingList() {
            var osList = from os in entity.Disbursements
                         where os.Disburse_Status == 3
                         join ddm in entity.Disbursement_Detail on os.Disbursement_ID equals ddm.Disbursement_ID
                         join sc in entity.Stationary_Catalogue on ddm.Item_Code equals sc.Item_Code
                         select new { 
                             ItemDescription = sc.Description,
                             OutstandingQuangtity = ddm.Qty_Required - ddm.Qty_Disbursed,
                             DisbursementFormNumber = os.Disbursement_ID
                         };
            return osList;
        }
        /*public IQueryable fulfillOutStanding(string itemCode){
            var rmRow = entity.Disbursement_Detail.Where(x => x.Item_Code == itemCode).SingleOrDefault();
            var rms = from ddm in entity.Disbursement_Detail
                      where ddm.Item_Code == itemCode
                      select ddm;
            rmRow.Req_Status = true;
            rmRow.Approval_Status = 4;
            int i = entity.SaveChanges();
            return i; 
        }*/

        public IQueryable getStockCardItem(string itemCode) {
            var v = from sc in entity.StockCards 
                    where sc.Item_Code == itemCode
                    join scd in entity.StockCard_Detail on sc.StockCard_ID equals scd.StockCard_ID
                    join scm in entity.Stationary_Catalogue on sc.Item_Code equals scm.Item_Code
                    select new { 
                        ItemCode = itemCode,
                        Description = scm.Description,
                        UOM = scm.UOM,
                        FirstSupplier = sc.first_Supplier,
                        SecondSupplier = sc.second_Supplier,
                        ThirdSupplier = sc.third_Supplier           
                    };
            return v;
        }

        public IQueryable getStockCardItemRecord(string itemCode)
        {
            var v = from sc in entity.StockCards
                    where sc.Item_Code == itemCode
                    join scd in entity.StockCard_Detail on sc.StockCard_ID equals scd.StockCard_ID
                    select new
                    {
                        Date = scd.Date,
                        Description = scd.Dept_Supplier,
                        Oty = scd.Qty,
                        Balance = scd.Balance
                    };
            return v;
        }
        //update stock card by item code
        public int updateStock(string itemCode) {
            var rmRow = entity.StockCards.Where(x => x.Item_Code == itemCode).SingleOrDefault();
            int i = entity.SaveChanges();
            return i;
        }
        //update stock card detail by Tran_ID(one item has many record)
        public int updateStockRecord(string tranID) {
            var rmRow = entity.StockCard_Detail.Where(x => x.Tran_ID == tranID).SingleOrDefault();
            int i = entity.SaveChanges();
            return i;
        }

    }
    
}