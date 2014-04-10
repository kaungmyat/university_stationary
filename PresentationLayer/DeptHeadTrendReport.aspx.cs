using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PresentationLayer
{
    public partial class DeptHeadTrendReport : System.Web.UI.Page
    {
        ReportControl control = new ReportControl();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            int month = Convert.ToInt16(Session["Month"]);
            int Comp = Convert.ToInt16( Session["Compare"]);
           
            ClerkCrystalReport cr = new ClerkCrystalReport();
            cr.SetDataSource(control.getClerkReportData(month,Comp));
            CrystalReportViewer1.ReportSource = cr;
            CrystalReportViewer1.DataBind();
        }
    }
} 