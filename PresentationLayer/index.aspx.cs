using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace Logic_University_Stationary
{
    public partial class index : System.Web.UI.Page
    {
        LoginController loginController;
        string role;
        string Emp_ID = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            loginController = new LoginController();
            role = null;
        }

        protected void btnSignin_Click1(object sender, EventArgs e)
        {
            if (loginController.ValidateUser(txtEmp_ID.Text, txtPassword.Text))
            {
                // lblStatus.Text = loginController.GetRole(txtEmp_ID.Text);
                role = loginController.GetRole(txtEmp_ID.Text);
                Emp_ID = txtEmp_ID.Text;
                Session["Emp_ID"] = Emp_ID;
                Response.BufferOutput = true;

                if (loginController.getDelegationSatus(Emp_ID, System.DateTime.Now))
                {
                    role = "DH";
                }

                switch (role)
                {
                    case "Clerk":
                        Response.Redirect("clerk-welcome.aspx");
                        break;

                    case "Sup":
                        Response.Redirect("SupervisorWelcome.aspx");
                        break;

                    case "Mgr":
                        Response.Redirect("Manager_welcome.aspx");
                        break;

                    case "Emp":
                        Response.Redirect("Emp-Welcom.aspx");
                        break;

                    case "DH":
                        Response.Redirect("Head-welcome.aspx");
                        break;

                    case "DR":
                        Response.Redirect("Rep_welcome.aspx");
                        break;

                    default:
                        Response.Redirect("Index.aspx");
                        break;
                }

            }

            else
            {
                lblStatus.Text = "<font color = red > Failed to Login ";
            }
        }

    
    }
}