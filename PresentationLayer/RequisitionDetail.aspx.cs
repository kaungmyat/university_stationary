using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace Logic_University_Stationary.Head
{
    public partial class RequisitionDetail : System.Web.UI.Page
    {
        ApproveRequisitionControl arControl = new ApproveRequisitionControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lblReqNo.Text = Convert.ToString(Session["Form_No"]);
                lblEmpno.Text = Convert.ToString(Session["Employee Name"]);
                gvRequisitionDetails.DataSource = arControl.getRequisitionForEmployee(Convert.ToString(Session["Form_No"]));
                gvRequisitionDetails.DataBind();
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListofPending.aspx");
        }
    }
}