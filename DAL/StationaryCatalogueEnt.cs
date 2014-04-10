using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class StationaryCatalogueEnt
    {
        LOGIC_UniversityEntities ContextDB;

        public StationaryCatalogueEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public void createStatCat(Stationary_Catalogue sc)
        {
            ContextDB.Stationary_Catalogue.AddObject(sc);
            ContextDB.SaveChanges();
        }

        public List<Stationary_Catalogue> getStatCat(Stationary_Catalogue sc)
        {
            var q = from s in ContextDB.Stationary_Catalogue
                    where (s.Item_Code == sc.Item_Code || sc.Item_Code == null)
                    && (s.Category == sc.Category || sc.Category == null)
                    && (s.Description == sc.Description || sc.Description == null)
                    && (s.Reorder_Level == sc.Reorder_Level || sc.Reorder_Level == null)
                    && (s.Reorder_Qty == sc.Reorder_Qty || sc.Reorder_Qty == null)
                    && (s.UOM == sc.UOM || sc.UOM == null)
                    select s;

            return q.ToList<Stationary_Catalogue>();
        }

        public List<string> getAllItemCode()
        {
            var q = from s in ContextDB.Stationary_Catalogue

                    select s.Item_Code;

            return q.ToList<string>();
        }

        public List<string> getStatCatGrpByCat()
        {
            var q = (from sc in ContextDB.Stationary_Catalogue
                     select sc.Category).Distinct();

            return q.ToList<string>();
        }

        public List<view_ReorderItems> getReorderItem()
        {
            var q = from vr in ContextDB.view_ReorderItems
                    select vr;

            return q.ToList<view_ReorderItems>();
        }


        public List<view_Check_Existing_Stock> getExistingStock(Stationary_Catalogue scatalogue)
        {
            var q = from vs in ContextDB.view_Check_Existing_Stock
                    where (vs.Category == scatalogue.Category || scatalogue.Description == null)
                   && (vs.Description == scatalogue.Description || scatalogue.Description == null)
                    select vs;


            return q.ToList<view_Check_Existing_Stock>();
        }


    }
}
