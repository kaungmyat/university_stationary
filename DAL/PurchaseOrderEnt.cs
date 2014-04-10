using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class PurchaseOrderEnt
    {
        LOGIC_UniversityEntities ContextDB;
        DALUtilities dalUtl;

        public PurchaseOrderEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
            dalUtl = new DALUtilities();
        }

        public void createPurchaseOrder(Purchase_Order po)
        {
            ContextDB.Purchase_Order.AddObject(po);
            ContextDB.SaveChanges();
           // dalUtl.Increament_GenID(2);
        }

        public List<view_PurchaseOrderForm> getPurchaseOrderForm(List<Stationary_Catalogue> lstItm)
        {
            var q = from i in lstItm 
                    join vp in ContextDB.view_PurchaseOrderForm on i.Item_Code equals vp.Item_Code 
                    select vp;

            return q.ToList<view_PurchaseOrderForm>();
        }

        public List<view_ReorderItems> getReorderItems()
        {
            var q = from ri in ContextDB.view_ReorderItems
                    select ri;

            return q.ToList<view_ReorderItems>();
        }

        public List<Purchase_Order> getAllPruchaseOrder()
        {
            var q = from p in ContextDB.Purchase_Order
                    select p;

            return q.ToList<Purchase_Order>();
        }

        public List<Purchase_Order> getPurchaseOrder(Purchase_Order po)
        {
            var q = from p in ContextDB.Purchase_Order
                    where (p.Supplier_ID == po.Supplier_ID || po.Supplier_ID == null)
                    && (p.Purchase_Order_No == po.Purchase_Order_No || po.Purchase_Order_No == null)
                    && (p.Deliver_To == po.Deliver_To || po.Deliver_To == null)
                    && (p.Expected_Date == po.Expected_Date || po.Expected_Date == null)
                    && (p.Order_By == po.Order_By || po.Order_By == null)
                    && (p.Approve_By == po.Approve_By || po.Approve_By == null)
                    && (p.Approve_Date == po.Approve_Date || po.Approve_Date == null)
                    && (p.Receive_Flag == po.Receive_Flag || po.Receive_Flag == null)
                    select p;

            return q.ToList<Purchase_Order>();
        }

        public bool updatePurchaseOrder(Purchase_Order po)
        {
            try
            {
                Purchase_Order p = new Purchase_Order();
                p.Supplier_ID = po.Supplier_ID == null ? p.Supplier_ID : po.Supplier_ID;
                p.Deliver_To = po.Deliver_To == null ? p.Deliver_To : po.Deliver_To;
                p.Expected_Date = po.Expected_Date == null ? p.Expected_Date : po.Expected_Date;
                p.Order_By = po.Order_By == null ? p.Order_By : po.Order_By;
                p.Approve_By = po.Approve_By == null ? p.Approve_By : po.Approve_By;
                p.Approve_Date = po.Approve_Date == null ? p.Approve_Date : po.Approve_Date;
                p.Receive_Flag = po.Receive_Flag == null ? p.Receive_Flag : po.Receive_Flag;

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deletePurchaseOrder(Purchase_Order po)
        {
            try
            {
                ContextDB.Purchase_Order.DeleteObject(po);
                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
