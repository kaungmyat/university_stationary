using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class TenderEnt
    {
        LOGIC_UniversityEntities ContextDB;

        public TenderEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public void createTender(Tender tnd)
        {
            ContextDB.Tenders.AddObject(tnd);
            ContextDB.SaveChanges();
        }

        public List<Tender> getAllTender()
        {
            var q = from t in ContextDB.Tenders
                    select t;

            return q.ToList<Tender>();

        }

        public List<Tender> getTender(Tender td)
        {
            var q = from t in ContextDB.Tenders
                    where (t.Supplier_ID == td.Supplier_ID || td.Supplier_ID == null)
                    && (t.Item_Code == td.Item_Code || td.Item_Code == null)
                    && (t.Price == td.Price || td.Price == null)
                    select t;

            return q.ToList<Tender>();
        }

        public Tender getTenderByID(string sid, string itemCode)
        {
            var q = from t in ContextDB.Tenders
                    where (t.Supplier_ID == sid || sid == null)
                    && (t.Item_Code == itemCode || itemCode == null)
                    select t;

            return q.First();
        }

        public bool updateTender(Tender td)
        {
            try
            {
                Tender t = getTenderByID(td.Supplier_ID, td.Item_Code);
                t.Price = td.Price == null ? t.Price : td.Price;

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteTender(Tender td)
        {
            try
            {
                ContextDB.Tenders.DeleteObject(td);
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
