using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;



namespace BLL
{
   
   public  class DepartmentHeadControl
    {
        DepartmentEnt ent = new DepartmentEnt();
        public IQueryable getReportData()
        {
            return ent.getReportData() ;
        }


    }
}
