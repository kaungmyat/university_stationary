using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class Inv_Adjustment_Voucher_Ent
    {
        LOGIC_UniversityEntities ContextDB;
        DALUtilities dalUtl;

        public Inv_Adjustment_Voucher_Ent()
        {
            ContextDB = new LOGIC_UniversityEntities();
            dalUtl = new DALUtilities();
        }

        public void createInvAdjVoc(Inventory_Adjustment_Voucher invAV)
        {
           
            ContextDB.Inventory_Adjustment_Voucher.AddObject(invAV);
            ContextDB.SaveChanges();

            dalUtl.update_GenID("Adjustment_Voucher");
            
        }

        public List<Inventory_Adjustment_Voucher> getAllInvAdjVoc()
        {
            var q = from i in ContextDB.Inventory_Adjustment_Voucher
                    select i;

            return q.ToList<Inventory_Adjustment_Voucher>();
        }

        public List<Inventory_Adjustment_Voucher> getInvAdjVoc(Inventory_Adjustment_Voucher invAV)
        {
            var q = from i in ContextDB.Inventory_Adjustment_Voucher
                    where (i.Voucher_ID == invAV.Voucher_ID || invAV.Voucher_ID == null)
                    && (i.Date_Issue == invAV.Date_Issue || invAV.Date_Issue == null)
                    && (i.AuthorizedBy_ID == invAV.AuthorizedBy_ID || invAV.AuthorizedBy_ID == null)
                    && (i.Authorized_By == invAV.Authorized_By || invAV.Authorized_By == null)
                    select i;

            return q.ToList<Inventory_Adjustment_Voucher>();
        }

        public Inventory_Adjustment_Voucher getInvAdjVocByID(string vocID)
        {
            var q = from i in ContextDB.Inventory_Adjustment_Voucher
                    where i.Voucher_ID == vocID
                    select i;

            return q.First();
        }

        public bool updateInvAdjVoc(Inventory_Adjustment_Voucher invAV)
        {
            try
            {
                Inventory_Adjustment_Voucher updIAV = getInvAdjVocByID(invAV.Voucher_ID);
                updIAV.Date_Issue = invAV.Date_Issue == null ? updIAV.Date_Issue : invAV.Date_Issue;
                updIAV.AuthorizedBy_ID = invAV.AuthorizedBy_ID == null ? updIAV.AuthorizedBy_ID : invAV.AuthorizedBy_ID;
                updIAV.Authorized_By = invAV.Authorized_By == null ? updIAV.Authorized_By : invAV.Authorized_By;

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteInvAdjVoc(Inventory_Adjustment_Voucher invAV)
        {
            try
            {
                ContextDB.Inventory_Adjustment_Voucher.DeleteObject(invAV);
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
