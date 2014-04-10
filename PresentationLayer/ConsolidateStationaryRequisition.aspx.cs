using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace Logic_University_Form.Clerk
{
    //Author - ZhangNa
    public partial class ConsolidateStationaryRequisition : System.Web.UI.Page
    {
       
        ClerkE eb = new ClerkE();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<string> setPrior() {
            List<string> reqNolist = new List<string>();
            foreach (GridViewRow r in GridView2.Rows)
            {
                CheckBox chtext = (CheckBox)r.FindControl("CheckB");
                string reqNo = r.Cells[0].Text.ToString();
                if (!reqNolist.Contains(reqNo)) {

                    reqNolist.Add(reqNo);
                }
                if (chtext.Checked)
                {
                    eb.setPriorByReqFormNo(reqNo);//-----------eb
                }
            }
            return reqNolist;
        }



        protected void lblnextstep_Click(object sender, EventArgs e)
        {
            Session["ReqNoList"] = this.setPrior();
            Response.Redirect("Retrieval.aspx");

        }

      
    }
}