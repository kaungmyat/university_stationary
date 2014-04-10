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
    public partial class delegateAuthority : System.Web.UI.Page
    {
        static string fromDate, toDate, deptId;
        
        DelegateAuthority delAuth = new DelegateAuthority();
        string userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbtMail.Visible = false;
            userId = (string) Session["Emp_ID"];
            if (!IsPostBack)
            {

                lblAuthDate.Text = DateTime.Now.ToString();
                deptId = delAuth.getDeptID(userId);
                var emp = delAuth.getEmpNames(deptId);
                lblDeptName.Text = deptName();
                ddlEmpName.DataValueField = "Emp_ID";
                ddlEmpName.DataTextField = "Emp_Name";
                ddlEmpName.DataSource = emp;
                ddlEmpName.DataBind();
            }
        }

        public string deptName()
        {
            Department deptInfo= delAuth.getDeptName(deptId);
            return deptInfo.Dept_Name;

        }

        public Boolean IsInputDataEmpty()
        {
            if (string.IsNullOrEmpty(ddlEmpName.SelectedItem.ToString()) || string.IsNullOrEmpty(fromDate) || string.IsNullOrEmpty(toDate))
            {
                return true;
            }

            else
            {
                return false;
            }
           
        }

        protected void btnDelegate_Click(object sender, EventArgs e)
        {
            fromDate = hiddenFDate.Value;
            toDate = hiddenTDate.Value;

            if (!IsInputDataEmpty())
            {
                string toEmpName = ddlEmpName.SelectedItem.ToString();
                DateTime fDate = DateTime.Parse(fromDate);


                DateTime tDate = DateTime.Parse(toDate);

                delAuth.delegateAuthority(toEmpName, fDate, tDate);

                delAuth.emailNotification(toEmpName, userId, "Delegate Authority!", "I delegated my autority to you from " + fDate + " to " + toDate );

                string sliderPopupFunction = @"<script>
                                                        $(function () { 
                                                            alert(""Delegate user successful..."");
                                                        });
                                                        </script>";

                ClientScript.RegisterStartupScript(typeof(Page), "key", sliderPopupFunction);
               

            }
            
            
        }

        protected void lbtMail_Click(object sender, EventArgs e)
        {
            
                Response.Redirect("showNoti.aspx");
            
        }
    }
}