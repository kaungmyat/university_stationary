using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class ClerkE
    {
        //Author - ZhangNa
        EntityBrokerClerk eb = new EntityBrokerClerk();
        public int getBalance_From_ItemCode(string itemCode) { return eb.getBalance_From_ItemCode(itemCode); }
        public int checkItemAvail(string itemCode, int qty) { return eb.checkItemAvail(itemCode,qty); }
        public void setPriorByReqFormNo(string Req_FormNo) { eb.setPriorByReqFormNo(Req_FormNo); }
        public IQueryable getRetrievalDeptForm(string itemCode) { return eb.getRetrievalDeptForm(itemCode); }
        public int updateApproval_Status(string reqNo) { return eb.updateApproval_Status(reqNo); }
        public int insertDisbursement(string reqNo, string newDisID) { return eb.insertDisbursement(reqNo,newDisID); }
        public int insertDisbursementDetail(string reqNo, string itemCode, string newDisID,int reqQty, int retiQty) { return eb.insertDisbursementDetail(reqNo, itemCode, newDisID,reqQty,retiQty); }
        public int insertDis(Disbursement newDis) { return eb.insertDis(newDis); }//
        public int insertDisD(Disbursement_Detail newDisD) { return eb.insertDisD(newDisD); }//
        public List<Requisition_Detail> getItemCodeFromReq(string reqNo) { return eb.getItemCodeFromReq(reqNo); }//
        public List<Disbursement_Detail> getDDItemFromDisN(string disN) { return eb.getDDItemFromDisN(disN); }
        public IQueryable getOutStandingList() { return eb.getOutStandingList(); }
        public void fulfillInsertDis(string disNo) { eb.fulfillInsertDis(disNo); }
        public int fulfillOutStanding(string reqNo, string itemCode) { return eb.fulfillOutStanding(reqNo,itemCode); }
        public string getReqNo_From_DisID(string disID) { return eb.getReqNo_From_DisID(disID); }
        public int updateDisburse_Status3to2(string disID) { return eb.updateDisburse_Status3to2(disID); }
        public IQueryable getStockCardItem(string itemCode) { return eb.getStockCardItem(itemCode); }
        public IQueryable getAllStockCardItem() { return eb.getAllStockCardItem(); }
        public IQueryable getStockCardItemRecord(string itemCode) { return eb.getStockCardItemRecord(itemCode); }
        public int insertStock_Detail(StockCard_Detail newSD) { return eb.insertStock_Detail(newSD); }//
        public string getSCIDFromItemCode(string itemCode) { return eb.getSCIDFromItemCode(itemCode); }
        public string getDeptIdFromDisId(string disId) { return eb.getDeptIdFromDisId(disId); }
        public bool checkOutS(string disN) { return eb.checkOutS(disN); }
        public void updateQty_Disbursed(string disN, string itemCode) { eb.updateQty_Disbursed(disN,itemCode); }

    }
}
