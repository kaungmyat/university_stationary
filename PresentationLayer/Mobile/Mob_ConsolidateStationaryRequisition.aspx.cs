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
    //Author - ZhangNa
    public partial class Mob_ConsolidateStationaryRequisition : System.Web.UI.Page
    {
        EntityBrokerClerk eb = new EntityBrokerClerk();
        List<string> reqNolist = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                Label2.Text = "There is no  record.";
            }
        }

        protected void btnNextStep_Click(object sender, EventArgs e)
        {
            this.setPrior();
            Session["ReqNoList"] = reqNolist;
            Response.Redirect("Mob_Retrieval.aspx");
            btnNextStep.Enabled = false;
        }

        public void setPrior()
        {

            foreach (GridViewRow r in GridView1.Rows)
            {
                CheckBox chtext = (CheckBox)r.FindControl("CheckB");
                string reqNo = r.Cells[0].Text.ToString();

                if (!reqNolist.Contains(reqNo))
                {
                    reqNolist.Add(reqNo);
                }

                if (chtext.Checked)
                {
                    eb.setPriorByReqFormNo(reqNo);//-----------eb
                }
            }
        }
    }
}