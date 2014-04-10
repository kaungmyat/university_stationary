using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class StockCardDetailEnt
    {
        LOGIC_UniversityEntities ContextDB;

        public StockCardDetailEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public void createStockCardDetail(StockCard_Detail sd)
        {
            ContextDB.StockCard_Detail.AddObject(sd);
            ContextDB.SaveChanges();

        }

        public List<StockCard_Detail> getAllStockCardDetail()
        {
            var q = from sd in ContextDB.StockCard_Detail
                    select sd;

            return q.ToList<StockCard_Detail>();
        }

        public List<StockCard_Detail> getStockCardDetail(StockCard_Detail sd)
        {
            var q = from s in ContextDB.StockCard_Detail
                    where (s.StockCard_ID == sd.StockCard_ID || sd.StockCard_ID == null)
                    && (s.Tran_ID == sd.Tran_ID || sd.Tran_ID == null)
                    && (s.Emp_ID == sd.Emp_ID || sd.Emp_ID == null)
                    && (s.Date == sd.Date || sd.Date == null)
                    && (s.Dept_Supplier == sd.Dept_Supplier || sd.Dept_Supplier == null)
                    && (s.Qty == sd.Qty || sd.Qty == null)
                    && (s.Balance == sd.Balance || sd.Balance == null)
                    select s;

            return q.ToList<StockCard_Detail>();
        }
          
    }
}
