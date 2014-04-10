using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
   
   public class ReportControl
    {
       ReportEntity ent = new ReportEntity();
       public int checkReportMonth(string Month)
       {
          
           int mon;

           switch (Month)
           {
               case("January"):
                   mon = 1;
                   return mon;
                  

               case("February"):
                      mon = 2;
                   return mon;

               case ("March"):
                    mon = 3;
                   return mon;
                 

               case ("April"):
                    mon = 4;
                   return mon;
                  
               case("May"):
                    mon = 5;
                   return mon;
               case("June"):
                    mon = 6;
                   return mon;
                 
               case("July"):
                     mon = 7;
                   return mon;
                   

               case("August"):
                  mon = 8;
                   return mon;

               case ("September"):
                     mon = 9;
                   return mon;
                
               case ("October"):
                     mon = 10;
                   return mon;
                
               case ("November"):
                     mon = 11;
                   return mon;
                  
               case ("December"):
                   mon = 12;
                   return mon;
                  
               default:
                 return 2;
                  

           }


    
       }
        

        public IQueryable getReportData(int month,int comp,string DeptID)
        {
            return (ent.getReportData(month, comp, DeptID));
        }

        public IQueryable getClerkReportData(int month,int comp)
        {
            return (ent.getClerkReportData(month,comp));
        }

        public IQueryable getClerkReportByDept(int month,int comp,string DeptID)
        {
            return(ent.getClerkReportByDept(month , comp, DeptID));
        }
    }
}
