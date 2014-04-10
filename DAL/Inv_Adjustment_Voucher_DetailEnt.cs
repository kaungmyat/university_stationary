using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class Inv_Adjustment_Voucher_DetailEnt
    {
        LOGIC_UniversityEntities ContextDB;
        
        public Inv_Adjustment_Voucher_DetailEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public void createInvAdjVocDetail(Inventory_Adjustment_Voucher_Detail invAVD)
        {
            ContextDB.Inventory_Adjustment_Voucher_Detail.AddObject(invAVD);
            ContextDB.SaveChanges();

        }

        //public List<Inventory_Adjustment_Voucher_Detail> getAllInvAVD()
        //{
        //    var q = from i in ContextDB.Inventory_Adjustment_Voucher_Detail
        //            select i;

        //    return q.ToList<Inventory_Adjustment_Voucher_Detail>();
        //}

        public List<Inventory_Adjustment_Voucher_Detail> getInvAVD(Inventory_Adjustment_Voucher_Detail invAVD)
        {
            var q = from i in ContextDB.Inventory_Adjustment_Voucher_Detail
                    where (i.Voucher_ID == invAVD.Voucher_ID || invAVD.Voucher_ID == null)
                    && (i.Item_Code == invAVD.Voucher_ID || invAVD.Voucher_ID == null)
                    && (i.Qty_Adjust == invAVD.Qty_Adjust || invAVD.Qty_Adjust == null)
                    && (i.Reason == invAVD.Reason || invAVD.Reason == null)
                    && (i.Status == invAVD.Status || invAVD.Status == null)
                    select i;

            return q.ToList<Inventory_Adjustment_Voucher_Detail>();
        }

        public Inventory_Adjustment_Voucher_Detail getInvAVDByID(string vocID, string itemCode)
        {
            var q = from i in ContextDB.Inventory_Adjustment_Voucher_Detail
                    where (i.Voucher_ID == vocID || vocID == null)
                    && (i.Item_Code == itemCode || itemCode == null)
                    select i;

            return q.First();
        }

        public bool updateInvAVD(Inventory_Adjustment_Voucher_Detail invAVD)
        {
            try
            {
                Inventory_Adjustment_Voucher_Detail updInvAV = getInvAVDByID(invAVD.Voucher_ID, invAVD.Item_Code);
                updInvAV.Item_Code = invAVD.Item_Code == null ? updInvAV.Item_Code : invAVD.Item_Code;
                updInvAV.Qty_Adjust = invAVD.Qty_Adjust == null ? updInvAV.Qty_Adjust : invAVD.Qty_Adjust;
                updInvAV.Reason = invAVD.Reason == null ? updInvAV.Reason : invAVD.Reason;
                updInvAV.Status = invAVD.Status == null ? updInvAV.Status : invAVD.Status;
                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteInvAVD(Inventory_Adjustment_Voucher_Detail invAVD)
        {
            try
            {
                ContextDB.Inventory_Adjustment_Voucher_Detail.DeleteObject(invAVD);
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
