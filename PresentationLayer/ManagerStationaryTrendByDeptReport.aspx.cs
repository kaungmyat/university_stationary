using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PresentationLayer
{
    public partial class ManagerStationaryTrendByDeptReport : System.Web.UI.Page
    {
        ReportControl control = new ReportControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            string deptId = Convert.ToString(Session["DeptID"]);
            int month = Convert.ToInt16(Session["Month"]);
            int Comp = Convert.ToInt16(Session["Compare"]);

            ClerkStationaryTrendByDeptCrystalReport cr = new ClerkStationaryTrendByDeptCrystalReport();
            cr.SetDataSource(control.getClerkReportByDept(month, Comp, deptId));
            CrystalReportViewer1.ReportSource = cr;
            CrystalReportViewer1.DataBind();
        }
    }
}