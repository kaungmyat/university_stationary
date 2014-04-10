using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class ClerkLogic
    {
        //Author - ZhangNa & Liau Kwong Weng
        EntityBroker eb = new EntityBroker();
        public IQueryable getRequisitionForm() { var v = eb.getRequisitionForm(); return v; }
        public IQueryable getBalance_From_ItemCode(string itemCode) { var v = eb.getBalance_From_ItemCode(itemCode); return v; }
        public void setPriorByRequisitionFormNo() { }

        public IQueryable getDisbursementList() 
        { 
            var v = eb.getDisbursementList(); 
            return v; 
        }

        public IQueryable getDisbursementDetail(string disbursementID) { var v = eb.getDisbursementDetail(disbursementID); return v; }

        public int updateDisbursementStatus_1to2(string disbursement_ID) { int i = eb.updateDisbursementStatus_1to2(disbursement_ID); return i; }
        public int updateDisbursementStatus_1to3(string disbursement_ID) { int i = eb.updateDisbursementStatus_1to3(disbursement_ID); return i; }
        public int updateQty_Disbursed(int qty_Disbursed, string disbursementID, string itemcode) { int i = eb.updateQty_Disbursed(qty_Disbursed,  disbursementID,  itemcode); return i; }
        public string getDeptName_From_ReqFormNo(string reqFormNo) { string deptN = eb.getDeptName_From_ReqFormNo(reqFormNo); return deptN; }
        public IQueryable getRetrievalDeptForm() { var v = eb.getRetrievalDeptForm(); return v; }
        public IQueryable getRetrievalItemForm() { var v = eb.getRetrievalItemForm(); return v; }
        public int updateApproval_Status(string reqNo) { int i = eb.updateApproval_Status(reqNo); return i; }
        public int insertDisbursement(string reqNo) { int i = eb.insertDisbursement(reqNo); return i; }
        public int insertDisbursementDetail(Requisition_Detail rdm) { int i = eb.insertDisbursementDetail(rdm); return i; }
        public int insertDisbursementDetail(Disbursement_Detail ddm) { int i = eb.insertDisbursementDetail(ddm); return i; }//update
        public IQueryable getOutStandingList() { var v = eb.getOutStandingList(); return v; }
        public IQueryable getStockCardItem(string itemCode) { var v = eb.getStockCardItem(itemCode); return v; }
        public IQueryable getStockCardItemRecord(string itemCode) { var v = eb.getStockCardItemRecord(itemCode); return v; }
        public int updateStock(string itemCode) { int i = eb.updateStock(itemCode); return i; }
        public int updateStockRecord(string tranID) { int i = eb.updateStockRecord(tranID); return i; }

        public DateTime getDisbursementDate(string disbursementID)
        {
            return eb.getDisbursementDate(disbursementID);
        }

        public string getCollectionPoint(string dept)
        {

            return eb.getCollectionPoint(dept);
        }

    }
}
