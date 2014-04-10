using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
namespace Logic_University_Stationary.Mobile_Pages.mob_Clerk
{
    //Author - Nyo Mi Han
    public partial class mob_ChkNAdj_Stock_ID : System.Web.UI.Page
    {
        mob_CheckExistingStockAndAdjstment chkAdjStock = new mob_CheckExistingStockAndAdjstment();
        string userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userId = (string)Session["Emp_ID"];
                var itemCode = chkAdjStock.getItemCode();
                cboItemCode.DataSource = itemCode;
                cboItemCode.DataBind();
                DateTime time = DateTime.Now;
                string format = "MMM dd,yyyy";
                lbldate.Text = time.ToString(format);
            }
        }

        protected void cboItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<view_Check_Existing_Stock> itemInfo = chkAdjStock.getBalanceByItemCode(cboItemCode.SelectedItem.Text);
            string balQty = itemInfo.First().Balance.ToString();
            lblQty.Text = balQty;
        }

        protected void btnSendNoti_Click(object sender, EventArgs e)
        {
            String comment;
            DateTime issueDate= DateTime.Parse(lbldate.Text);

            comment = txtComment.Text;
            
            int adjQty= Convert.ToInt32(Request.Form["slider_Qty"]);
            if (radioPlus.Checked)
            {
                chkAdjStock.saveAdjustedInfo(userId, cboItemCode.SelectedItem.Text, adjQty, comment, issueDate);
            }

            else if (radioMinus.Checked)
            {
                chkAdjStock.saveAdjustedInfo(userId, cboItemCode.SelectedItem.Text, -adjQty, comment, issueDate);
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