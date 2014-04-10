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
    public partial class showNoti : System.Web.UI.Page
    {
        mob_adjNotiApprove adjApp = new mob_adjNotiApprove();
        string userId;
        DateTime date = DateTime.Now;
        static List<Inventory_Adjustment_Voucher_Detail> adjList;
        protected void Page_Load(object sender, EventArgs e)
        {
             userId = (string)Session["Emp_ID"];
            if (!IsPostBack)
            {
                adjList = adjApp.getAdjustedVoc();
                gvAdjVoc.DataSource = adjList;
                gvAdjVoc.DataBind();
            }
            lblDate.Text =  date.ToString();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            String vocId, itemCode;
            int adjQty;
            for (int i = 0; i < adjList.Count; i++)
            {
                vocId = adjList[i].Voucher_ID;
                itemCode = adjList[i].Item_Code;
                adjQty = (int) adjList[i].Qty_Adjust;
                adjApp.updateStock(vocId, itemCode, adjQty, userId, date);
                adjApp.updateInvAdjStatus(vocId, itemCode);
            }
        }

    }
}