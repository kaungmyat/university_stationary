using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using DAL;

namespace Logic_University_Stationary.Clerk
{
    //Author - Liau Kwong Weng
    public partial class DistrubsementListAllDepartment : System.Web.UI.Page
    {
        ClerkLogic clerkLogic;

        protected void Page_Load(object sender, EventArgs e)
        {
            clerkLogic = new ClerkLogic();
            lblDate.Text = DateTime.Now.ToString();
            
            disburseListGridView.DataSource = clerkLogic.getDisbursementList();
            disburseListGridView.DataBind();
        }

        protected void disburseListGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void disburseListGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (disburseListGridView.SelectedRow != null)
            {
                Session["DisbursementID"] = disburseListGridView.SelectedRow.Cells[4].Text;
                Session["deptName"] = disburseListGridView.SelectedRow.Cells[3].Text;                
                Response.Redirect("DisbursementListDetail.aspx");
            }
        }
    }
}