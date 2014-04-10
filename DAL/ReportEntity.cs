using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
  public class ReportEntity
    {
        LOGIC_UniversityEntities ContextDB;
        public ReportEntity()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }
        public IQueryable getClerkReportByDept(int Month,int comp,string DeptID)
        {
            if (comp == 1)
            {
                var query = from sc in ContextDB.Stationary_Catalogue
                            join dd in ContextDB.Disbursement_Detail
                            on sc.Item_Code equals dd.Item_Code
                            join d in ContextDB.Disbursements
                            on dd.Disbursement_ID equals d.Disbursement_ID
                            where (d.Date.Value.Month == Month)
                            && d.Dept_ID == DeptID
                            group new { dd, sc } by new { sc.Category, d.Date.Value.Month } into g
                            select new
                            {
                                Item = g.Key.Category,
                                Quantity = g.Sum(x => x.dd.Qty_Required).Value,
                                Month = g.Key.Month
                            };
                return query;
            }

            else 
            {
                var query = from sc in ContextDB.Stationary_Catalogue
                            join dd in ContextDB.Disbursement_Detail
                            on sc.Item_Code equals dd.Item_Code
                            join d in ContextDB.Disbursements
                            on dd.Disbursement_ID equals d.Disbursement_ID
                            where (d.Date.Value.Month == (Month-1) || d.Date.Value.Month == Month)
                            && d.Dept_ID == DeptID
                            group new { dd, sc } by new { sc.Category, d.Date.Value.Month } into g
                            select new
                            {
                                Item = g.Key.Category,
                                Quantity = g.Sum(x => x.dd.Qty_Required).Value,
                                Month = g.Key.Month
                            };
                return query;

            }
        }

        public IQueryable getClerkReportData(int Month,int comp)
        {
            if (comp == 1)
            {
                var query = from sc in ContextDB.Stationary_Catalogue
                            join pod in ContextDB.Purchase_Order_Detail
                                on sc.Item_Code equals pod.Item_Code
                            join po in ContextDB.Purchase_Order
                                on pod.Purchase_Order_No equals po.Purchase_Order_No
                            where (po.Approve_Date.Value.Month == Month)
                            group new { pod, sc } by new { sc.Category, po.Approve_Date.Value.Month } into g
                            select new
                            {
                                item = g.Key.Category,
                                Quantity = g.Sum(x => x.pod.Qty).Value,
                                Month = g.Key.Month
                            };
                return query;
            }

            else
            {
                var query = from sc in ContextDB.Stationary_Catalogue
                            join pod in ContextDB.Purchase_Order_Detail
                                on sc.Item_Code equals pod.Item_Code
                            join po in ContextDB.Purchase_Order
                                on pod.Purchase_Order_No equals po.Purchase_Order_No
                            where (po.Approve_Date.Value.Month == (Month-1) || po.Approve_Date.Value.Month == Month)
                            group new { pod, sc } by new { sc.Category, po.Approve_Date.Value.Month } into g
                            select new
                            {
                                item = g.Key.Category,
                                Quantity = g.Sum(x => x.pod.Qty).Value,
                                Month = g.Key.Month
                            };
                return query;
            }
        }

        public IQueryable getReportData(int Month,int Comp,string DeptID)
        {
            if (Comp == 1)
            {
                var query = from sc in ContextDB.Stationary_Catalogue
                            join dd in ContextDB.Disbursement_Detail
                            on sc.Item_Code equals dd.Item_Code
                            join d in ContextDB.Disbursements
                            on dd.Disbursement_ID equals d.Disbursement_ID
                            where (d.Date.Value.Month == Month)
                            && d.Dept_ID == DeptID
                            group new { dd, sc } by new { sc.Category, d.Date.Value.Month } into g
                            select new
                            {
                                Item = g.Key.Category,
                                Quantity = g.Sum(x => x.dd.Qty_Required).Value,
                                Month = g.Key.Month
                            };
                return query;
            }
            else 
            {
                var query = from sc in ContextDB.Stationary_Catalogue
                            join dd in ContextDB.Disbursement_Detail
                            on sc.Item_Code equals dd.Item_Code
                            join d in ContextDB.Disbursements
                            on dd.Disbursement_ID equals d.Disbursement_ID
                            where (d.Date.Value.Month == (Month - 2) || d.Date.Value.Month == (Month-1) || d.Date.Value.Month == Month)
                            && d.Dept_ID == DeptID
                            group new { dd, sc } by new { sc.Category, d.Date.Value.Month } into g
                            select new
                            {
                                Item = g.Key.Category,
                                Quantity = g.Sum(x => x.dd.Qty_Required).Value,
                                Month = g.Key.Month
                            };
                return query;

            }
           

           
        }

    }
}
