using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;


namespace PL.Clerk
{
    public partial class ListOfItemsBelowReorderLevel : System.Web.UI.Page
    {
        PurchaseOrderController purchaseOrderController;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                purchaseOrderController = new PurchaseOrderController();
               
                List<view_ReorderItems> data = new List<view_ReorderItems>();
                data = purchaseOrderController.getReorderItemsList();
                if (data.Count > 0)
                {
                    GridView1.DataSource = data;
                    GridView1.DataBind();
                }

                else
                {
                    lblStatus.Text = "No record found";
                }
            }

        }

        protected void btnGenereatePO_Click(object sender, EventArgs e)
        {
            List<Stationary_Catalogue> lstItems = new List<Stationary_Catalogue>();
            int count = 0;
            foreach (GridViewRow r in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)r.FindControl("selChkBox");
                if (chk.Checked)
                {
                    //lblCheck.Text += r.Cells[1].Text + "<br>";
                    Stationary_Catalogue item = new Stationary_Catalogue();
                    item.Item_Code = r.Cells[1].Text;
                    lstItems.Add(item);
                    count++;
                }

            }

            if (lstItems.Count > 0)
            {
                Session["itemCode"] = lstItems;

                Response.BufferOutput = true;
                Response.Redirect("PurchaseOrder.aspx");
            }

            else
                lblStatus2.Text = "No record selected";

        }

        

    }
}