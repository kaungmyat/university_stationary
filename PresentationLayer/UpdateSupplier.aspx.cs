using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace Logic_University_Stationary
{
    public partial class UpdateSupplier : System.Web.UI.Page
    {
        Supplier sup = new Supplier();
        UpdateSuppliers supplier = new UpdateSuppliers();
          
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlSupplier.DataSource = supplier.getSupplierData();
                ddlSupplier.DataBind();
               // sup.Supplier_ID = ddlSupplier.Text;
                supplier.getSingleSupplierData(sup);
                txtName.Text = supplier.getSingleSupplierData(sup).Supplier_Name;
                txtContactName.Text = supplier.getSingleSupplierData(sup).Context_Name;
                txtPhone.Text = supplier.getSingleSupplierData(sup).Phone_No;
                txtFax.Text = supplier.getSingleSupplierData(sup).Fax_No;
                txtAddress.Text = supplier.getSingleSupplierData(sup).Address;
                txtEmail.Text = supplier.getSingleSupplierData(sup).Email;

            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           

            string supplierID = ddlSupplier.SelectedItem.Text;
            SupplierController sc = new SupplierController();
            Supplier sp = new Supplier();

            sp.Supplier_ID = ddlSupplier.SelectedItem.Text;
            sp.Supplier_Name = txtName.Text;
            sp.Context_Name = txtContactName.Text;
            sp.Phone_No = Convert.ToString( txtPhone.Text);
            sp.Fax_No = Convert.ToString( txtFax.Text);
            sp.Address = txtAddress.Text;
            sp.Email = txtAddress.Text;
            sc.update(sp);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Already updated.');window.location='Manager_welcome.aspx.aspx';", true); 
        }

    

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            Supplier sup1 = new Supplier();
            sup1.Supplier_ID = ddlSupplier.SelectedItem.Text;
            supplier.getSingleSupplierData(sup1);
            
            
            txtName.Text = supplier.getSingleSupplierData(sup1).Supplier_Name;
            txtContactName.Text = supplier.getSingleSupplierData(sup1).Context_Name;
            txtPhone.Text = supplier.getSingleSupplierData(sup1).Phone_No;
            txtFax.Text = supplier.getSingleSupplierData(sup1).Fax_No;
            txtAddress.Text = supplier.getSingleSupplierData(sup1).Address;
            txtEmail.Text = supplier.getSingleSupplierData(sup1).Email;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager_welcome.aspx");
        }
    }
}