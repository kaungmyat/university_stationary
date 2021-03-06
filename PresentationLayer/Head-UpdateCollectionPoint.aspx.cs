﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace Logic_University_Stationary
{
    //Author -Nyo Me Han
    public partial class Head_UpdateCollectionPoint : System.Web.UI.Page
    {
       
        UpdateCollectionPoint updCollection = new UpdateCollectionPoint();
        String userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            userId = Convert.ToString(Session["Emp_ID"]);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Head-welcome.aspx");
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            String collectionPoint;
            String repEmail;
            collectionPoint = ddlColPoint.SelectedItem.ToString();
            updCollection.updateCollectionPoint(collectionPoint, userId);
            repEmail = updCollection.getDeptRepEmail(userId);
            updCollection.emailNoti(repEmail);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Updated Collection Points.');window.location='Head-welcome.aspx';", true); 
        }
    }
}