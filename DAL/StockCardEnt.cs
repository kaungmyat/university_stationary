using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class StockCardEnt
    {
        LOGIC_UniversityEntities ContextDB;
        DALUtilities dalUtl;

        public StockCardEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
            dalUtl = new DALUtilities();
        }

        public void createStockCard(StockCard sc)
        {
            ContextDB.StockCards.AddObject(sc);
            ContextDB.SaveChanges();
            dalUtl.Increament_GenID(3);
        }

        public List<StockCard> getAllStockCard()
        {
            var q = from sc in ContextDB.StockCards
                    select sc;

            return q.ToList<StockCard>();

        }

        public List<StockCard> getStockCard(StockCard sc)
        {
            var q = from s in ContextDB.StockCards
                    where (s.StockCard_ID == sc.StockCard_ID || sc.StockCard_ID == null)
                    && (s.Item_Code == sc.Item_Code || sc.Item_Code == null)
                    && (s.first_Supplier == sc.first_Supplier || sc.first_Supplier == null)
                    && (s.second_Supplier == sc.second_Supplier || sc.second_Supplier == null)
                    && (s.third_Supplier == sc.third_Supplier || sc.third_Supplier == null)
                    select s;

            return q.ToList<StockCard>();
        }

        public bool updateStockCard(StockCard sc)
        {
            try
            {
                StockCard s =  (StockCard)getStockCard(sc).First();
                s.Item_Code = sc.Item_Code == null ? s.Item_Code : sc.Item_Code;
                s.first_Supplier = sc.first_Supplier == null ? s.first_Supplier : sc.first_Supplier;
                s.second_Supplier = sc.second_Supplier == null ? s.second_Supplier : sc.second_Supplier;
                s.third_Supplier = sc.third_Supplier == null ? s.third_Supplier : sc.third_Supplier;

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteStockCard(StockCard sc)
        {
            try
            {
                ContextDB.StockCards.DeleteObject(sc);
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
