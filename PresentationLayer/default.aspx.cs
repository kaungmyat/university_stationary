using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;

            if (!context.Request.UserAgent.Contains("Windows"))
            {
                Response.Redirect("/Mobile/login.aspx");
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}