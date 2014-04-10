using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Logic_University_Stationary.Mobile.mob_MasterPages
{
    public partial class Mob_Master_Page : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["Emp_ID"] = "Emp17";
            UsersEnt supE = new UsersEnt();
            User usr = new User();

            usr.Emp_ID = (string)Session["Emp_ID"];
            usr = supE.getEmp(usr).First();

            NotificationMsg nm = new NotificationMsg();
            int cntMsg = nm.countMailBox((string)Session["Emp_ID"]);

            int cntInbox = cntMsg;
            //int cntInbox = 2;

            param1.Value = Convert.ToString(cntInbox);
            param_Emp.Value = usr.Emp_Name;
            param_Role.Value = usr.Role;

        }
    }
}