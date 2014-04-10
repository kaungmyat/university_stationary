﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PresentationLayer
{
    public partial class ClerkStationaryTrend : System.Web.UI.Page
    {
        int cmp = 1;
        ReportControl control = new ReportControl();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btntableFormat_Click(object sender, EventArgs e)
        {
            string month = ddlMonth.Text;
            int MonthNo = control.checkReportMonth(month);
            
            Session["Month"] = MonthNo;
            Session["Compare"] = cmp;
            Response.Redirect("~/ClerkStationaryTrendReport.aspx");
        }

        protected void compare2Month_CheckedChanged(object sender, EventArgs e)
        {
            cmp = 2;
        }

        protected void txtCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClerkStationaryTrend.aspx");
        }
    }
}