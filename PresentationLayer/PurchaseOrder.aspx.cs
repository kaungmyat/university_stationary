using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Net.Mail;


using BLL;
using DAL;

namespace PL.Clerk
{
    //Author - Liau Kwong Weng
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        PurchaseOrderController purchaseOrderController = new PurchaseOrderController();
        String Purchase_Order = "Purchase_Order";
        // List<Supplier> supplier;
        Supplier supplier = new Supplier();
        decimal sum = 0;
        EmailController emailController;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Stationary_Catalogue> itms = new List<Stationary_Catalogue>();
            List<StockCard> stockCard = new List<StockCard>();

            stockCard = purchaseOrderController.getAllStockCard();

            foreach (StockCard s in stockCard)
            {
                lblSupplier1.Text = s.first_Supplier;
                
            }

            if (!IsPostBack)
            {
                //lblItemCode.Text = (string)(Session["itemCode"]);

                itms = (List<Stationary_Catalogue>)Session["itemCode"];

                if (RadioButton1.Checked)
                {
                    supplier = purchaseOrderController.getSupplier(lblSupplier1.Text).First();

                    //foreach (Supplier s in supplier)
                    //{
                    lblAddress.Text = supplier.Address;
                    //}
                }

            }


            foreach (StockCard s in stockCard)
            {
               // lblSupplier1.Text = s.first_Supplier;
                lblSupplier2.Text = s.second_Supplier;
                lblSupplier3.Text = s.third_Supplier;

            }

            if (IsPostBack)
            {
                if (RadioButton1.Checked)
                {
                    supplier = purchaseOrderController.getSupplier(lblSupplier1.Text).First();

                    //foreach (Supplier s in supplier)
                    //{
                    lblAddress.Text = supplier.Address;
                    //}
                }

                if (RadioButton2.Checked)
                {
                    supplier = purchaseOrderController.getSupplier(lblSupplier2.Text).First();

                    
                    lblAddress.Text = supplier.Address;
                    //}
                }

                if (RadioButton3.Checked)
                {
                    supplier = purchaseOrderController.getSupplier(lblSupplier3.Text).First();

                    lblAddress.Text = supplier.Address;
                    //}
                }
            }

            List<view_PurchaseOrderForm> purchaseOrder = new List<view_PurchaseOrderForm>();
            purchaseOrder = purchaseOrderController.getPurchaseOrder(itms);

            if (!IsPostBack)
            {
                lblPONumber.Text = purchaseOrderController.getID(Purchase_Order);
                PurOrderGridView.DataSource = purchaseOrder;
                PurOrderGridView.DataBind();
            }
            for (int i = 0; i < PurOrderGridView.Rows.Count; i++)
            {
                sum += Convert.ToDecimal(PurOrderGridView.Rows[i].Cells[4].Text);
            }

            lblTotal.Text = Convert.ToString(sum);
            lblEmpName.Text = "Login Name";
            lblTodayDate.Text = DateTime.Now.ToString();


        }


        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                int currentPO = (Convert.ToInt32(lblPONumber.Text));
                int maxPO = Convert.ToInt32(purchaseOrderController.checkMaxPO());

                if (lblDate.Text == "")
                {
                    if (currentPO == maxPO)
                    {
                        lblError.Text = "PO has already been generated";
                    }
                }
                else
                {
                    Purchase_Order po = new Purchase_Order();
                    po.Supplier_ID = supplier.Supplier_ID;
                    po.Purchase_Order_No = lblPONumber.Text;
                    po.Deliver_To = txtAttn.Text;
                    lblDate.Text = Calendar1.SelectedDate.ToShortDateString();
                    DateTime dt = DateTime.Parse(lblDate.Text);
                    po.Expected_Date = dt;
                    po.Order_By = null;
                    po.Approve_By = null;
                    po.Approve_Date = DateTime.Now;
                    po.Receive_Flag = false;

                    purchaseOrderController.createPurchaseOrder(po);

                    List<Purchase_Order_Detail> pod = new List<Purchase_Order_Detail>();

                    foreach (GridViewRow row in PurOrderGridView.Rows)
                    {
                        Purchase_Order_Detail poDetail = new Purchase_Order_Detail(); //have to keep this initialising here for 
                        poDetail.Purchase_Order_No = lblPONumber.Text;

                        poDetail.Item_Code = row.Cells[0].Text;

                        System.Diagnostics.Debug.WriteLine("foreach poDetail.Item_Code = " + poDetail.Item_Code);

                        poDetail.Description = row.Cells[1].Text;
                        poDetail.Qty = Convert.ToInt32(row.Cells[2].Text);
                        poDetail.Price = Convert.ToDecimal(row.Cells[3].Text);
                        poDetail.Amount = Convert.ToDecimal(row.Cells[4].Text);
                        pod.Add(poDetail);
                    }


                    purchaseOrderController.createPruchaseOrderDetail(pod);
                    lblError.Text = "Succcessfully generate the PO";

                    purchaseOrderController.update_GenID(Purchase_Order);
                    if (emailSupplier(supplier.Email))
                    {
                        lblEmailStatus.Text = "Email sent to supplier";

                    }

                    else
                    {
                        lblEmailStatus.Text = "Incorrect Email address, email not sent";
                    }

                }
            }

            catch (Exception error)
            {
                
                lblError.Text = error.ToString();
            }


        }

        protected void Calendar_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Purchase_Order po = new Purchase_Order();
            string calendarText = Calendar1.SelectedDate.ToShortDateString();
            Boolean flag = false;
            DateTime dt = DateTime.Parse(calendarText);

            if (purchaseOrderController.validateDate(dt))
            {
                lblDate.Text = calendarText;
                po.Expected_Date = dt;
                flag = true;
                lblDateError.Text = "";
            }

            else
            {
                lblDate.Text = "";
                flag = false;
                lblDateError.Text = "Invalid date, date cannot be less than today's date nor more than 30 days";
            }

         
            Calendar1.Visible = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListOfItemsBelowReorderLevel.aspx");
        }

        protected void btn_Print_Click(object sender, EventArgs e)
        {

        }

        private string GridViewToHtml(GridView gv)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
          
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv.RenderControl(hw);
            return sw.ToString();
        }


        public bool emailSupplier(string email)
        {
            try
            {

                MailMessage mailMessage = new MailMessage();
                mailMessage.IsBodyHtml = true;

                mailMessage.To.Add(email);
                mailMessage.From = new MailAddress("StoreClerk@LogicUniversity.edu.sg");
                mailMessage.CC.Add("venkatlogicuni@gmail.com");
                mailMessage.Subject = "Purchase Order";
                mailMessage.Body = "Dear Supplier, Please supply the following items by " + lblDate.Text + "/n" + GridViewToHtml(PurOrderGridView) + " /n best regards /n" + "Login name"; 
                
                SmtpClient smtpClient = new SmtpClient("lynx.iss.nus.edu.sg");
                smtpClient.Send(mailMessage);
                
                return true;
            }
            catch (Exception ex)
            {
                

                System.Diagnostics.Debug.WriteLine("Error = " + ex);
                return false;
            }


        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

      
        
    }
}