using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace Logic_University_Stationary.Mobile_Pages.mob_Clerk
{
    public partial class login : System.Web.UI.Page
    {
        LoginController loginController;
        string role;
        string Emp_ID = null;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            loginController = new LoginController();
            if (!IsPostBack)
            {
                
                role = null;
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (loginController.ValidateUser(txtUserName.Text.ToString(), txtPassword.Text.ToString()))
            {
               
                role = loginController.GetRole(txtUserName.Text);
                Emp_ID = txtUserName.Text;
                Session["Emp_ID"] = Emp_ID;
                
                Response.BufferOutput = true;

                switch (role)
                {
                    case "Clerk":
                        Response.Redirect("CheckAdjustStock.aspx");
                        break;

                    case "Supervisor":
                        Response.Redirect("mob_UpdateSupplier.aspx");
                        break;

                    case "Emp":
                        Response.Redirect("RequisitionStatus.aspx");
                        break;

                    case "DH":
                        Response.Redirect("delegateAuthority.aspx");
                        break;

                    case "DR":
                        Response.Redirect("updateCollectionPoint.aspx");
                        break;

                    default:
                        Response.Redirect("LoginUser.aspx");
                        break;
                }

            }

            else
            {

            }

            
        }
     }

        
}
