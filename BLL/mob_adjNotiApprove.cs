using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    //Author - Nyo Mi Han
    public class mob_adjNotiApprove
    {

        public List<Inventory_Adjustment_Voucher_Detail> getAdjustedVoc()
        {
            Inventory_Adjustment_Voucher_Detail invenAdjVocDetail=new Inventory_Adjustment_Voucher_Detail();
            Inv_Adjustment_Voucher_DetailEnt invenVocDetailEnt=new Inv_Adjustment_Voucher_DetailEnt();
            invenAdjVocDetail.Status = false;
            List<Inventory_Adjustment_Voucher_Detail> adjList = invenVocDetailEnt.getInvAVD(invenAdjVocDetail);
            return adjList;
        }

        public void updateInvAdjStatus(string vocID, string itemCode)
        {
            Inv_Adjustment_Voucher_DetailEnt invAdVoDE = new Inv_Adjustment_Voucher_DetailEnt();
            Inventory_Adjustment_Voucher_Detail inAdjDe = new Inventory_Adjustment_Voucher_Detail();
            inAdjDe.Voucher_ID = vocID;
            inAdjDe.Item_Code = itemCode;
            inAdjDe.Status = true;
            invAdVoDE.updateInvAVD(inAdjDe);
        }

        public void updateStock(string vocID, string itemCode, int adjQty, string userId, DateTime date)
        {

            StockCardDetailEnt stCardDetailEnt = new StockCardDetailEnt();
            StockCard_Detail stCardDetail = new StockCard_Detail();
            
            string stCardId = getStockCardID(itemCode);
            stCardDetail.StockCard_ID=stCardId;
            stCardDetail.Tran_ID= getTransactionID("StockCard_Detail");
            stCardDetail.Emp_ID=userId;
            stCardDetail.Date=date;
            stCardDetail.Dept_Supplier=stCardDetail.Dept_Supplier;
            stCardDetail.Qty=adjQty;
            stCardDetail.Balance= calculateBalance(stCardId, adjQty);
            stCardDetailEnt.createStockCardDetail(stCardDetail);
        }

        public string getStockCardID(string itemCode)
        {
            StockCardEnt stCardEnt = new StockCardEnt();
            StockCard stCard=new StockCard();
            stCard.Item_Code=itemCode;
            string stCardId = stCardEnt.getStockCard(stCard).First().StockCard_ID;
            return stCardId;
        }

        public int calculateBalance(string stCardId, int adjQty)
        {
            StockCardDetailEnt stCardDetailEnt1 = new StockCardDetailEnt();
            StockCard_Detail stCardDetail1 = new StockCard_Detail();

            stCardDetail1.StockCard_ID = stCardId;
            int bal= (int)stCardDetailEnt1.getStockCardDetail(stCardDetail1).First().Balance;
            int adjustedQty = bal + adjQty;
            return adjustedQty;
        }

        public string getTransactionID(string tableName)
        {
            DALUtilities dalUtil = new DALUtilities();
            return dalUtil.Generate_ID(tableName);
        }
    }
}