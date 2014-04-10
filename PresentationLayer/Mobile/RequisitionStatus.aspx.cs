using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
namespace Logic_University_Stationary.Mobile
{
    //Author - Nyo Mi Han
    public partial class RequisitionStatus : System.Web.UI.Page
    {
        static List<view_RequisitionDisbursementStatus> list;
        protected void Page_Load(object sender, EventArgs e)
        {
            RequisitionAndDisbursementStatus reqAndDisbStut = new RequisitionAndDisbursementStatus();

            string userId = (string)Session["Emp_ID"];
            if (!IsPostBack)
            {
                list = reqAndDisbStut.getReqDisbStatus(userId, 1, 2);
                lblEmpName.Text = getUserName(userId);

                gvDisbStatus.DataSource = list;

                gvDisbStatus.DataBind();

                for (int i = 0; i < list.Count; i++)
                {


                    switch (list[i].Approval_Status)
                    {
                        case 0: gvDisbStatus.Rows[i].Cells[1].Text = "Reject";
                            break;
                        case 1: gvDisbStatus.Rows[i].Cells[1].Text = "Pending";
                            break;

                        case 2: gvDisbStatus.Rows[i].Cells[1].Text = "Approve";
                            break;

                        case 3: gvDisbStatus.Rows[i].Cells[1].Text = "Approve";
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

       

        protected void gvDisbStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
            RequisitionAndDisbursementStatus reqDisStatus = new RequisitionAndDisbursementStatus();

           string formNo = clickedRow.Cells[0].Text;
           
            var reqDate = reqDisStatus.getReqDate(formNo);
           
            lblFrmNo.Text = "This Form No " + clickedRow.Cells[0].Text +" detail is requested on "+
                reqDate.Request_Date.ToString();
            
            var detail = reqDisStatus.getStatusDetail(formNo);
           
                gvDetails.DataSource = detail;
                gvDetails.DataBind();
                
        }

        protected void gvDisbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }    
}