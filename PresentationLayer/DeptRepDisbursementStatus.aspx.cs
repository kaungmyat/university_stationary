using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
namespace Logic_University_Stationary.DeptRep
{
    public partial class DeptRepDisbursementStatus : System.Web.UI.Page
    {
        RequisitionAndDisbursementStatus reqAndDisbStut = new RequisitionAndDisbursementStatus();

        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Convert.ToString(Session["Emp_ID"]);
            if (!IsPostBack)
            {
                List<view_RequisitionDisbursementStatus> list = reqAndDisbStut.getReqDisbStatus(userId,1,2);
                lblEmpName.Text = getUserName(userId);

                gvDisbStatus.DataSource = list;
                
                gvDisbStatus.DataBind();

                for (int i = 0; i < list.Count; i++)
                {


                    switch (list[i].Approval_Status)
                    {
                        case 0: gvDisbStatus.Rows[i].Cells[1].Text = "Rejected";
                            break;
                        case 1: gvDisbStatus.Rows[i].Cells[1].Text = "Pending";
                            break;

                        case 2: gvDisbStatus.Rows[i].Cells[1].Text = "Approved";
                            break;

                        case 3: gvDisbStatus.Rows[i].Cells[1].Text = "Approved";
                            break;

                        default: break;
                    }
                   
                }

            }
            
           
        }


        public String getUserName(String userId)
        {
            RequisitionAndDisbursementStatus reqDisStut = new RequisitionAndDisbursementStatus();
            return reqDisStut.getEmpName(userId);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Response.Redirect("Rep_welcome.aspx");
        }

       
    }
}