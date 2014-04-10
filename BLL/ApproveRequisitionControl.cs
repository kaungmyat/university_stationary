using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
     public class ApproveRequisitionControl
    {
        RequisitionEnt rEnt = new RequisitionEnt();
       
         string RequisitionID = null;

         public String generateID(String department)
         {
             DALUtilities util = new DALUtilities();

             RequisitionID = department + "/" + util.Generate_ID("Requisition");

             return RequisitionID;

         }
        public object getPendingRequisitions(string DeptID)
        {
            return rEnt.getPendingRequisition(DeptID);
        }

        public IQueryable getRejectedList(string DeptID)
        {
            return rEnt.getRejectedListForHead(DeptID);
        }


        public List<Requisition_Detail> getRequisitionForEmployee(string req_No)
        {
            return rEnt.getRequisitionDetailsByID(req_No);
        }

        public void approveSelectedRequisitions(List<Requisition> req, string reqFrmNo, string empID, string dept_ID, List<Requisition> rej)
        {
            rEnt.bundleSelectedRequisition(req, reqFrmNo, empID,dept_ID,rej);
        }


      public void approveRequisition(string ReqFrm_No,string DeptID,string EmpID)
      {
          rEnt.bundleAllRequisitions(ReqFrm_No, DeptID, EmpID);
      }
    }
}
