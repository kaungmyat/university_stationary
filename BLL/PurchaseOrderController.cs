using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL;

namespace BLL
{
    public class PurchaseOrderController
    {
        PurchaseOrderEnt purchaseOrderEnt;
        PurchaseOrderDetailEnt purchaseOrderDetailEnt;
        StockCardEnt stockCardEnt;
        SupplierEnt supplierEnt;
        DALUtilities dALUtilities;

        public PurchaseOrderController()
        {
            purchaseOrderEnt = new PurchaseOrderEnt();
            purchaseOrderDetailEnt = new PurchaseOrderDetailEnt();
            stockCardEnt = new StockCardEnt();
            supplierEnt = new SupplierEnt();
            dALUtilities = new DALUtilities();
        }

        public void createPurchaseOrder(Purchase_Order po)
        {
            purchaseOrderEnt.createPurchaseOrder(po);
        }

        //public void createPruchaseOrderDetail(Purchase_Order_Detail po)
        public void createPruchaseOrderDetail(List<Purchase_Order_Detail> po)
        {
            purchaseOrderDetailEnt.createPurchaseOrderDetail(po);
        }

        public List<view_ReorderItems> getReorderItemsList()
        {
            return purchaseOrderEnt.getReorderItems();
        }

        public List<StockCard> getAllStockCard()
        {
           // List<PurchaseOrderEnt> listPurchaseOrderEnt = 
          //  return purchaseOrderEnt.getAllStockCard();
            return stockCardEnt.getAllStockCard();
        }

        public List<Supplier> getSupplier(String supplierID)
        {
            Supplier s = new Supplier();
            s.Supplier_ID = supplierID;
            return supplierEnt.getSupplier(s);
        }

        public List<view_PurchaseOrderForm> getPurchaseOrder(List<Stationary_Catalogue> itms)
        {
            return purchaseOrderEnt.getPurchaseOrderForm(itms);
        }

        public string getID(string tableName)
        {

            return dALUtilities.Generate_ID(tableName);
        }

        public bool update_GenID(string Purchase_Order)
        {
            return dALUtilities.update_GenID(Purchase_Order);
        }

         public string checkMaxPO()
        {
            return supplierEnt.getMaxPO();
        }
        public bool validateDate(DateTime deliverydate)
        {
            Boolean status = false;
            DateTime TodayDate = DateTime.Today;
            TimeSpan timeSpan = deliverydate - TodayDate;

            if (timeSpan.Days < 0 || timeSpan.Days > 30)
            {
                status = false;
                return status;
            }

            else
            {
                status = true;
                return status;
            }
        }
    }
}
