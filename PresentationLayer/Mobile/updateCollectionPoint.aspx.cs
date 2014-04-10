using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace Logic_University_Stationary.Mobile
{
    //Author - Nyo Mi Han
    public partial class updateCollectionPoint : System.Web.UI.Page
    {
        UpdateCollectionPoint updCollection = new UpdateCollectionPoint();
        String userId;
        protected void Page_Load(object sender, EventArgs e)
        {
             userId = Convert.ToString(Session["Emp_ID"]);
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String collectionPoint;
            String repEmail;
            collectionPoint = ddlCollectionPoint.SelectedItem.ToString();
            updCollection.updateCollectionPoint(collectionPoint, userId);
            repEmail = updCollection.getDeptRepEmail(userId);
            updCollection.emailNoti(repEmail);
        }
    }
}