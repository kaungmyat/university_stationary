using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Data;

namespace Logic_University_Stationary.DeptRep
{
    public partial class DeptRepRequisition : System.Web.UI.Page
    {
        EmployeeRequisitionControl empCtrl = new EmployeeRequisitionControl();
        List<Stationary_Catalogue> mylist = new List<Stationary_Catalogue>();
        LoginController logControl = new LoginController();
        List<string> desc = new List<string>();
        List<string> itm_code = new List<string>();
        static string ItemCode;
        static List<field> data1 = new List<field>();
        User ur = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
           

            string emp_Id =Convert.ToString( Session["Emp_ID"]);
             User u = new User();
             u.Emp_ID = emp_Id;
             ur=logControl.getUser(u);
             lblName.Text = ur.Emp_Name;
            if (!IsPostBack)
            {
                List<string> list = new List<string>();
                list = empCtrl.getItemsCategory();
                DropDownList1.DataSource = list;
                DropDownList1.DataBind();

            }

            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            this.itemDetailsGrid.DataSource = null;

        }

        public class field
        {
            public string itemCode { get; set; }
            public string description { get; set; }
            public string quantity { get; set; }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            field s = new field();           
            s.description = DropDownList2.SelectedItem.Text;
            List<Stationary_Catalogue> Codelist = empCtrl.getItemCode(s.description);
            ItemCode = Codelist.First().Item_Code.ToString();
            s.itemCode = ItemCode;
            s.quantity = txtQuantity.Text;
            data1.Add(s);
            itemDetailsGrid.DataSource = data1;
            itemDetailsGrid.DataBind();
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           Requisition req = new Requisition();

           req.Req_Form_No = empCtrl.generateID(ur.Dept_ID);
           req.Request_Date = DateTime.Now;
           req.Emp_ID = ur.Emp_ID;
           req.Approval_Status = 1;
           req.Approval_By =null;
           req.Approval_Date = null;
           req.Req_Status = null;
           req.Notification = false;
           req.Prior = false;
           empCtrl.submitRequisition(req);
           foreach (GridViewRow row in itemDetailsGrid.Rows)
           {
               Requisition_Detail rd = new Requisition_Detail();
               rd.Req_Form_No = req.Req_Form_No;
               rd.Item_Code = row.Cells[1].Text;
               rd.Description = row.Cells[2].Text;
               rd.Qty = Convert.ToInt32((row.Cells[3]).Text);
               empCtrl.submitRequisitionDetails(rd);
           }

           this.itemDetailsGrid.DataSource = null;
           User u = new User();
           u.Emp_ID = ur.Emp_ID;
           empCtrl.sendEmailToDeptHead(u);

           ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Already Submitted.');window.location='Rep_welcome.aspx';", true); 
           
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in itemDetailsGrid.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("selChkBox");
                if (chk.Checked)
                {
                    for (int i = 0; i < data1.Count; i++)
                    {
                        if (data1[i].itemCode == row.Cells[1].Text)
                        {
                            data1.RemoveAt(i);
                            itemDetailsGrid.DataSource = data1;
                            itemDetailsGrid.DataBind();
                        }
                    }
                   
                }
            }
            
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            data1 = new List<field>();
            itemDetailsGrid.DataSource = data1;
            itemDetailsGrid.DataBind();
        }

        protected void txtCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemName = DropDownList1.SelectedValue.ToString();
            mylist = empCtrl.getItemDescription(itemName);

            foreach (var val in mylist)
            {
                desc.Add(val.Description);
            }
            DropDownList2.DataSource = desc;
            DropDownList2.DataBind();
        }

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemDesc = DropDownList2.SelectedValue.ToString();
            List<Stationary_Catalogue>Codelist= empCtrl.getItemCode(itemDesc);
            ItemCode = Codelist.First().Item_Code.ToString();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}