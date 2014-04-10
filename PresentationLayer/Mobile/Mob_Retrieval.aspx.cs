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
    public partial class Mob_Retrieval : System.Web.UI.Page
    {
        EntityBrokerClerk eb = new EntityBrokerClerk();
        DALUtilities d = new DALUtilities();
        List<string> rNolist = new List<string>();
        List<string> itemCodelist = new List<string>();
        List<string> dept_itemCodelist = new List<string>();
        List<string> deptID = new List<string>();
        List<int> RetriBalList = new List<int>();
        List<int> ReqQtyList = new List<int>();
        List<string> outSlist = new List<string>();
        List<int> outSQtylist = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            checkBal();
            getDeptItemData();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            rNolist = (List<string>)Session["ReqNoList"];

            foreach (string rN in rNolist)
            {

                Disbursement newD = new Disbursement();
                string newDisId = d.Generate_ID("Disbursement");
                newD.Disbursement_ID = newDisId;
                newD.Req_Form_No = rN;
                newD.Dept_ID = rN.Substring(0, 3);
                newD.Date = DateTime.Now;
                newD.Disburse_Status = 1;

                eb.insertDis(newD);//--------------eb
                d.update_GenID("Disbursement");
                eb.updateApproval_Status(rN);//----------------eb

                List<Requisition_Detail> rdli = new List<Requisition_Detail>();
                rdli = eb.getItemCodeFromReq(rN);//--------------eb

                foreach (Requisition_Detail rd in rdli)
                {
                    Disbursement_Detail newDD = new Disbursement_Detail();
                    newDD.Disbursement_ID = newDisId;
                    newDD.Item_Code = rd.Item_Code;
                    newDD.Qty_Required = rd.Qty;

                    int retri_Qty = 0;
                    foreach (GridViewRow row in GridView2.Rows)
                    {
                        if ((row.Cells[1].Text.ToString() == rN) && (row.Cells[0].Text.ToString() == rd.Item_Code))
                        {
                            retri_Qty = int.Parse(row.Cells[3].Text.ToString());
                        }
                        else retri_Qty = 0;
                    }
                    newDD.Qty_Retrieved = retri_Qty;
                    newDD.Qty_Disbursed = retri_Qty;
                    eb.insertDisD(newDD);//-------------eb

                    StockCard_Detail newSD = new StockCard_Detail();
                    string newTranId = d.Generate_ID("StockCard_Detail");
                    newSD.StockCard_ID = eb.getSCIDFromItemCode(rd.Item_Code);//-------------eb
                    newSD.Tran_ID = newTranId;
                    newSD.Emp_ID = (string) Session["Emp_ID"];
                    newSD.Date = DateTime.Now;
                    newSD.Dept_Supplier = rN.Substring(0, 3);
                    newSD.Qty = -retri_Qty;
                    newSD.Balance = eb.getBalance_From_ItemCode(rd.Item_Code) - retri_Qty;

                    eb.insertStock_Detail(newSD);//-----------------eb
                    d.update_GenID("StockCard_Detail");
                }
            }
            BtnSubmit.Enabled = false;
        }


        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string selectedItemCode = GridView1.SelectedRow.Cells[1].Text;
        }

        public void checkBal()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {

                string itemCode = row.Cells[1].Text.ToString();
                dept_itemCodelist.Add(itemCode);

                int qty = int.Parse(row.Cells[2].Text.ToString());
                ReqQtyList.Add(qty);
                int bal = eb.getBalance_From_ItemCode(itemCode);//--------eb                              
                RetriBalList.Add(bal);

                if (bal < qty)
                {
                    row.Cells[3].Text = bal.ToString();
                }
                else
                {
                    bal = bal - qty;
                }
            }
        }

        public void getDeptItemData()
        {

            foreach (string itemC in dept_itemCodelist)
            {
                int totalBal = eb.getBalance_From_ItemCode(itemC);

                foreach (GridViewRow row in GridView2.Rows)
                {
                    string itemCode = row.Cells[0].Text.ToString();
                    string reqNlist = row.Cells[1].Text.ToString();

                    if (itemCode == itemC)
                    {
                        int qty = int.Parse(row.Cells[2].Text.ToString());

                        if (totalBal < qty)
                        {
                            row.Cells[3].Text = totalBal.ToString();
                            outSlist.Add(itemCode);
                            outSQtylist.Add(qty - totalBal);
                        }
                        else
                        {
                            totalBal = totalBal - qty;
                        }
                    }
                }
            }
        }
    }
}