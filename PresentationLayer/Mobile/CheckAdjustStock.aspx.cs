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
    public partial class CheckAdjustStock : System.Web.UI.Page
    {
        
        mob_CheckExistingStockAndAdjstment chkAdjStock = new mob_CheckExistingStockAndAdjstment();
        static string itemCode, userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userId = (string) Session["Emp_ID"];
                var chkInfo = chkAdjStock.getCataloge();
                cbo_Cat.DataSource = chkInfo;
                cbo_Cat.DataBind();

                DateTime time = DateTime.Now;
                string format = "MMM dd,yyyy";
                lbldate.Text = time.ToString(format);
            }

            
        }



        protected void cbo_Cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemName = chkAdjStock.getItemName(cbo_Cat.SelectedItem.Text);

            cbo_Item.DataValueField = "Description";
            cbo_Item.DataTextField = "Description";
            cbo_Item.DataSource = itemName;
            cbo_Item.DataBind();

        }

        protected void cbo_Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<view_Check_Existing_Stock> itemInfo = chkAdjStock.getUnitQtyByName(cbo_Item.SelectedItem.Text, cbo_Cat.SelectedItem.Text);
            String balQty = itemInfo.First().Balance.ToString();
            lblQty.Text = balQty;
            itemCode = itemInfo.First().Item_Code.ToString();
        }

        protected void btnSendNoti_Click(object sender, EventArgs e)
        {
            
            String comment;
            DateTime issueDate= DateTime.Parse(lbldate.Text);

            comment = txtComment.Text;
            
            int adjQty= Convert.ToInt32(Request.Form["slider_Qty"]);
            if (radioPlus.Checked)
            {
                chkAdjStock.saveAdjustedInfo(userId, itemCode, adjQty, comment, issueDate);
            }

            else if (radioMinus.Checked)
            {
                chkAdjStock.saveAdjustedInfo(userId, itemCode, -adjQty, comment, issueDate);
            }

            string sliderPopupFunction = @"<script>
                                            $(function () { 
                                                alert(""Notification have already sent..."");
                                         });
                                            </script>";

            ClientScript.RegisterStartupScript(typeof(Page), "key", sliderPopupFunction);
        }

     
       
    }
}