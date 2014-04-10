using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class PurchaseOrderDetailEnt
    {
        LOGIC_UniversityEntities ContextDB;

        public PurchaseOrderDetailEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public void createPurchaseOrderDetail(List<Purchase_Order_Detail> pod)
        {
            foreach (Purchase_Order_Detail poDetail in pod)
            {
                ContextDB.Purchase_Order_Detail.AddObject(poDetail);
                ContextDB.SaveChanges();
            }
        }
        public List<Purchase_Order_Detail> getAllPurchaseOrderDetail()
        {
            var q = from pod in ContextDB.Purchase_Order_Detail
                    select pod;

            return q.ToList<Purchase_Order_Detail>();
        }

        public List<Purchase_Order_Detail> getPurchaseOrderDetail(Purchase_Order_Detail para)
        {
            var q = from p in ContextDB.Purchase_Order_Detail
                    where (p.Item_Code == para.Item_Code || para.Item_Code == null)
                    && (p.Description == para.Description || para.Description == null)
                    && (p.Qty == para.Qty || para.Qty == null)
                    && (p.Price == para.Price || para.Price == null)
                    && (p.Amount == para.Amount || para.Amount == null)
                    select p;

            return q.ToList<Purchase_Order_Detail>();
        }

        public bool updatePurchaseOrderDetail(Purchase_Order_Detail upd)
        {
            try
            {
                Purchase_Order_Detail p = new Purchase_Order_Detail();
                p.Item_Code = upd.Item_Code == null ? p.Item_Code : upd.Item_Code;
                p.Description = upd.Description == null ? p.Description : upd.Description;
                p.Qty = upd.Qty == null ? p.Qty : upd.Qty;
                p.Price = upd.Price == null ? p.Price : upd.Price;
                p.Amount = upd.Amount == null ? p.Amount : upd.Amount;

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deletePurchaseOrderDetail(Purchase_Order_Detail del)
        {
            try
            {
                ContextDB.Purchase_Order_Detail.DeleteObject(del);
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
