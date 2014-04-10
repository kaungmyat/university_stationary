using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class DepartmentEnt
    {
        LOGIC_UniversityEntities ContextDB;

        public DepartmentEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public void createDepartment(Department d)
        {
            ContextDB.Departments.AddObject(d);
            ContextDB.SaveChanges();
        }

        public List<Department> getAllDepartment()
        {
            var q = from d in ContextDB.Departments
                    select d;

            return q.ToList<Department>();
        }

        public List<Department> getDepartment(Department d)
        {
            var q = from dept in ContextDB.Departments
                    where (dept.Dept_ID == d.Dept_ID || d.Dept_ID == null)
                    && (dept.Dept_Name == d.Dept_Name || d.Dept_Name == null)
                    && (dept.Contact_ID == d.Contact_ID || d.Contact_ID == null)
                    && (dept.Contact_Name == d.Contact_Name || d.Contact_Name == null)
                    && (dept.Phone == d.Phone || d.Phone == null)
                    && (dept.Fax_No == d.Fax_No || d.Fax_No == null)
                    && (dept.Head_ID == d.Head_ID || d.Head_ID == null)
                    && (dept.Head_Name == d.Head_Name || d.Head_Name == null)
                    && (dept.Collection_Point == d.Collection_Point || d.Collection_Point == null)
                    && (dept.Representative_ID == d.Representative_ID || d.Representative_ID == null)
                    && (dept.Representative_Name == d.Representative_Name || d.Representative_Name == null)
                    select dept;

            return q.ToList<Department>();
        }

        
            public IQueryable getReportData() 
             { 
                var query = from sc in ContextDB.Stationary_Catalogue join rd in ContextDB.Requisition_Detail
                       on sc.Item_Code equals rd.Item_Code join r in ContextDB.Requisitions
                       on rd.Req_Form_No equals r.Req_Form_No 
                       where ( r.Request_Date.Value.Month ==8 || r.Request_Date.Value.Month ==9 || r.Request_Date.Value.Month==10)
                      // where r.Emp_ID == "Emp02" && r.Request_Date.Value.Month == 8
                       group new {rd,sc} by new { sc.Category,r.Request_Date.Value.Month} into g 
                       select new { 
                           Item = g.Key.Category,
                           Quantity = g.Sum(x => x.rd.Qty).Value,
                           Month=g.Key.Month
                       }; 

             return query; }


        public Department getDepartmentByID(string depID)
        {
            var q = from d in ContextDB.Departments
                    where d.Representative_ID == depID
                    select d;

            return q.First();
        }

        public Department getDeptByID(string did)
        {
            var q = from de in ContextDB.Departments
                    where de.Dept_ID == did
                    select de;

            return q.First();
        }

        public bool updateDepartment(Department d)
        {
            try
            {
                Department dept = getDepartmentByID(d.Representative_ID);

                dept.Dept_Name = d.Dept_Name == null ? dept.Dept_Name : d.Dept_Name;
                dept.Contact_ID = d.Contact_ID == null ? dept.Contact_ID : d.Contact_ID;
                dept.Contact_Name = d.Contact_Name == null ? dept.Contact_Name : d.Contact_Name;
                dept.Phone = d.Phone == null ? dept.Phone : d.Phone;
                dept.Fax_No = d.Fax_No == null ? dept.Fax_No : d.Fax_No;
                dept.Head_ID = d.Head_ID == null ? dept.Head_ID : d.Head_ID;
                dept.Head_Name = d.Head_Name == null ? dept.Head_Name : d.Head_Name;
                dept.Collection_Point = d.Collection_Point == null ? dept.Collection_Point : d.Collection_Point;
                dept.Representative_ID = d.Representative_ID == null ? dept.Representative_ID : d.Representative_ID;
                dept.Representative_Name = d.Representative_Name == null ? dept.Representative_Name : d.Representative_Name;

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteDepartment(Department d)
        {
            try
            {
                ContextDB.Departments.DeleteObject(d);
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
