using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.Data;

namespace Logic_University_Stationary.Employee
{
    public partial class EmployeeRequisition : System.Web.UI.Page
    {
        EmployeeRequisitionControl empCtrl = new EmployeeRequisitionControl();
        List<Stationary_Catalogue> mylist = new List<Stationary_Catalogue>();
        LoginController logControl = new LoginController();
        List<string> desc = new List<string>();
        List<string> itm_code = new List<string>();
        static string ItemCode;
        static List<fields> data = new List<fields>();
        User ur = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
           

            //if (!IsPostBack)
            //{
                string emp_Id = Convert.ToString(Session["Emp_ID"]);
                User u = new User();
                u.Emp_ID = emp_Id;
                ur = logControl.getUser(u);
                lblName.Text = ur.Emp_Name;
              
                if (!IsPostBack)
                {
                    List<string> list = null;
                    list = empCtrl.getItemsCategory();
                    ddlCategory.DataSource = list;
                    ddlCategory.DataBind();

                }

                lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                this.itemDetailsGrid.DataSource = null;
         
        }

        public class fields
        {
            public string itemCode { get; set; }
            public string description { get; set; }
            public string quantity { get; set; } 
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            fields s = new fields();
           
            s.description = ddlDescription.SelectedItem.Text;          
            List<Stationary_Catalogue> Codelist = empCtrl.getItemCode(s.description);
            ItemCode = Codelist.First().Item_Code.ToString();
            s.itemCode = ItemCode;
            s.quantity = txtQuantity.Text;
            data.Add(s);
            itemDetailsGrid.DataSource = data;
            itemDetailsGrid.DataBind();
            btnSubmit.Enabled = true;

            
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
           data = new List<fields>();
           lblStatus.Text = "The Requisition was submitted successfully";
           ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Record saved successfully.');window.location='Emp-Welcom.aspx';", true); 
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in itemDetailsGrid.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("selChkBox");
                if (chk.Checked)
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (data[i].itemCode == row.Cells[1].Text)
                        {
                            data.RemoveAt(i);
                        }
                    }
                   
                }
            }
            itemDetailsGrid.DataSource = data;
            itemDetailsGrid.DataBind();
            lblStatus.Text = "The Requisition was deleted successfully";
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            data = new List<fields>();
            itemDetailsGrid.DataSource = data;
            itemDetailsGrid.DataBind();
        }

        protected void txtCancel_Click(object sender, EventArgs e)
        {
            data = new List<fields>();
            Response.Redirect("Emp-Welcom.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemName = ddlCategory.SelectedValue.ToString();
            mylist = empCtrl.getItemDescription(itemName);

            foreach (var val in mylist)
            {
                desc.Add(val.Description);
            }
            ddlDescription.DataSource = desc;
            ddlDescription.DataBind();
        }

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemDesc = ddlDescription.SelectedValue.ToString();
            List<Stationary_Catalogue>Codelist= empCtrl.getItemCode(itemDesc);
            ItemCode = Codelist.First().Item_Code.ToString();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}