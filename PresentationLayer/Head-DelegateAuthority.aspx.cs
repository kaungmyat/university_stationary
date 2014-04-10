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
    //Author -Nyo Me Han
    public partial class Head_DelegateAuthority : System.Web.UI.Page
    {
        String toEmpName, userId, deptId;
        DateTime fromDate, toDate;
        DelegateAuthority delAuth = new DelegateAuthority();
        Boolean flag;
       
        protected void Page_Load(object sender, EventArgs e)
        {
           
            userId = Convert.ToString(Session["Emp_ID"]);
            if (!IsPostBack)
            {
               
                
                deptId = delAuth.getDeptID(userId);
                var emp = delAuth.getEmpNames(deptId);

                lblDeptName.Text = deptId;
                ddlEmpName.DataValueField = "Emp_ID";
                ddlEmpName.DataTextField = "Emp_Name";
                ddlEmpName.DataSource = emp;
                ddlEmpName.DataBind();
            }
        }

        public Boolean IsInputDataEmpty()
        {
          if (string.IsNullOrEmpty(ddlEmpName.SelectedItem.ToString()) || string.IsNullOrEmpty(txtFromdate.Text) || string.IsNullOrEmpty(txtTodate.Text))
            {
                flag = true;
            }

            else
            {
                flag = false;
            }
            return flag;
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
           
           
            if (!flag)
            {
                toEmpName = ddlEmpName.SelectedItem.ToString();
             
                string date = (string) txtFromdate.Text;
                date = Utilities.aspDateTimeFormat(date);
                fromDate =DateTime.Parse(date);
                    
               
                string date1 =(string) txtTodate.Text;
                date1 = Utilities.aspDateTimeFormat(date1);
                toDate = DateTime.Parse(date1);

                delAuth.delegateAuthority(toEmpName, fromDate, toDate);
                
                delAuth.emailNotification(toEmpName, userId, "Delegate Authority!", "I delegated my autority to you.");

                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Successfully saved');window.location='Head-welcome.aspx';", true); 
            }
        }

        protected void Image2_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Image3_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtFromdate.Text = "";
            txtTodate.Text = "";
        }

       
    }
}