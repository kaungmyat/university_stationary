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
    public partial class mob_UpdateSuppliers : System.Web.UI.Page
    {
        mob_UpdateSuppliersController updSupplier = new mob_UpdateSuppliersController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var supList = updSupplier.getSupplierID();
                ddlSup.DataValueField = "Supplier_ID";
                ddlSup.DataTextField = "Supplier_ID";
                ddlSup.DataSource = supList;
                ddlSup.DataBind();
            }
           
        }

        public Boolean IsEmptyDataInput()
        {

            if (string.IsNullOrEmpty(txtSupName.Text) && string.IsNullOrEmpty(txtContact.Text) && string.IsNullOrEmpty(txtPhone.Text) && string.IsNullOrEmpty(txtFax.Text) && string.IsNullOrEmpty(txtAddress.Text) && string.IsNullOrEmpty(txtEmail.Text))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            if (!IsEmptyDataInput())
            {

                updSupplier.updateSupplier(ddlSup.SelectedItem.Text, txtSupName.Text, txtContact.Text, txtPhone.Text, txtFax.Text, txtAddress.Text, txtEmail.Text);

                string sliderPopupFunction = @"<script>
                                            $(function () { 
                                                alert(""Successfully updated supplier inforation..."");
                                         });
                                            </script>";

                ClientScript.RegisterStartupScript(typeof(Page), "key", sliderPopupFunction);
            }
            else
            {
                string sliderPopupFunction = @"<script>
                                            $(function () { 
                                                alert(""Can not empty one of supplier value!!!"");
                                         });
                                            </script>";

                ClientScript.RegisterStartupScript(typeof(Page), "key", sliderPopupFunction);
            }

           
        }

        protected void ddlSup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Supplier supInfo = updSupplier.findSupplier(ddlSup.SelectedItem.Text);
            txtSupName.Text = supInfo.Supplier_Name;
            txtContact.Text = supInfo.Context_Name;
            txtPhone.Text = supInfo.Phone_No;
            txtFax.Text = supInfo.Fax_No;
            txtAddress.Text = supInfo.Address;
            txtEmail.Text = supInfo.Email;
        }

        
    }
}