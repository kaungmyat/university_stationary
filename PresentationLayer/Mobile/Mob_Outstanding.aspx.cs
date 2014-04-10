using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace Logic_University_Stationary.Mobile
{
    //Author - ZhangNa
    public partial class Mob_Outstanding : System.Web.UI.Page
    {
        ClerkE eb = new ClerkE();
        DALUtilities d = new DALUtilities();
        List<string> disIdlist = new List<string>();
        List<string> disIdUniq = new List<string>();
        List<string> itemCodeList = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                Label2.Text = "There is no outstanding record.";
            }
            else checkItemBal();
        }

        protected void btnFulfil_Click(object sender, EventArgs e)
        {
            foreach (string disNU in disIdUniq)
            {

                Disbursement newDis = new Disbursement();
                string newDisID = d.Generate_ID("Disbursement");
                newDis.Disbursement_ID = newDisID;
                newDis.Req_Form_No = eb.getReqNo_From_DisID(disNU);//-------------eb
                newDis.Dept_ID = eb.getDeptIdFromDisId(disNU);//--------------eb
                newDis.Date = DateTime.Now;
                newDis.Disburse_Status = 1;
                eb.insertDis(newDis);//-------------eb

                d.update_GenID("Disbursement");

                List<Disbursement_Detail> ddli = new List<Disbursement_Detail>();
                ddli = eb.getDDItemFromDisN(disNU);//-------------eb

                foreach (Disbursement_Detail dd in ddli)
                {
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        string itemC = row.Cells[1].Text.ToString();

                        if (dd.Item_Code == itemC)
                        {
                            Disbursement_Detail newDD = new Disbursement_Detail();
                            newDD.Disbursement_ID = newDisID;
                            newDD.Item_Code = itemC;
                            newDD.Qty_Required = dd.Qty_Required - dd.Qty_Disbursed;
                            newDD.Qty_Retrieved = dd.Qty_Required - dd.Qty_Disbursed;
                            newDD.Qty_Disbursed = dd.Qty_Required - dd.Qty_Disbursed;
                            eb.insertDisD(newDD);//--------eb
                            eb.updateQty_Disbursed(disNU, itemC);//----------eb

                            StockCard_Detail newSD = new StockCard_Detail();
                            string newTranId = d.Generate_ID("StockCard_Detail");
                            newSD.StockCard_ID = eb.getSCIDFromItemCode(dd.Item_Code);//-------------eb
                            newSD.Tran_ID = newTranId;
                            newSD.Emp_ID = (string) Session["Emp_ID"];
                            newSD.Date = DateTime.Now;
                            newSD.Dept_Supplier = eb.getDeptIdFromDisId(disNU);
                            newSD.Qty = -(dd.Qty_Required - dd.Qty_Disbursed); 
                            newSD.Balance = eb.getBalance_From_ItemCode(dd.Item_Code) - (dd.Qty_Required - dd.Qty_Disbursed);

                            eb.insertStock_Detail(newSD);//-----------------eb
                            d.update_GenID("StockCard_Detail");
                        }
                    }
                }

                if (!eb.checkOutS(disNU))//----------eb
                {
                    eb.updateDisburse_Status3to2(disNU);//-----------eb
                }
            }
            btnFulfil.Enabled = false;
            if (disIdUniq != null)
            {
                Label2.Text = "Successful";
            }
        }

        public void checkItemBal()
        {

            foreach (GridViewRow row in GridView1.Rows)
            {

                string disId = row.Cells[0].Text.ToString();

                if (!disIdlist.Contains(disId))///!!!
                {
                    disIdlist.Add(disId);
                }

                string itemCode = row.Cells[1].Text.ToString();
                int bal = eb.getBalance_From_ItemCode(itemCode);//--------------eb
                int osQty = int.Parse(row.Cells[2].Text.ToString());

                if (osQty < bal)
                {//!!!!

                    if (!disIdUniq.Contains(disId))
                    {
                        disIdUniq.Add(disId);
                    }

                    row.BackColor = System.Drawing.Color.LightGreen;
                }
                else if ((bal < osQty) && (bal > 0))
                {

                    row.BackColor = System.Drawing.Color.LightBlue;
                }
                else if (bal == 0)
                {

                    row.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }
    }
}