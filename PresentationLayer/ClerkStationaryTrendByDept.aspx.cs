using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;


namespace PresentationLayer
{
    public partial class ClerkStationaryTrendByDept : System.Web.UI.Page
    {
        int cmp = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btngenerate_Click(object sender, EventArgs e)
        {
            ReportControl control = new ReportControl();
            String deptid = ddldeptID.SelectedValue;
            String month = ddlmonth.Text;
            int monthno = control.checkReportMonth(month);

            Session["Month"] = monthno;
            Session["DeptID"] = deptid;
            Session["Compare"] = cmp;

            Response.Redirect("~/ClerkStationaryTrendByDeptReport.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ClerkStationaryTrendByDept.aspx");
        }

        protected void compare2Month_CheckedChanged(object sender, EventArgs e)
        {
            cmp = 2;
        }
    }
}