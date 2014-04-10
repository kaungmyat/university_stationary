using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace Logic_University_Stationary
{
    public partial class HeadRejectRequisition : System.Web.UI.Page
    {
        List<Requisition> rejList = new List<Requisition>();
        ApproveRequisitionControl arControl = new ApproveRequisitionControl();
        EmployeeRequisitionControl erControl = new EmployeeRequisitionControl();
        string reasone;
        protected void Page_Load(object sender, EventArgs e)
        {
            String DeptId = (string)Session["DeptID"];
            lblPageHeader.Text = "List of Rejected Requisition";
            //rejList = (List<Requisition>)Session["RejectList"];
            gvRejectedRequest.DataSource = arControl.getRejectedList( DeptId);
            gvRejectedRequest.DataBind();
        }


        protected void btnOk_Click(object sender, EventArgs e)
        {
            reasone = txtReasone.Text;
           
            foreach (GridViewRow row in gvRejectedRequest.Rows)
            {
                Requisition req = new Requisition();
                req.Req_Form_No = row.Cells[0].Text;
                req.Approval_Status = 0;
                req.Rej_Comment = reasone;
                erControl.updateRejectedRequisition(req);
            }
            Response.Redirect("Head-welcome.aspx");
        }

        protected void txtReasone_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = true;
        }
    }
}