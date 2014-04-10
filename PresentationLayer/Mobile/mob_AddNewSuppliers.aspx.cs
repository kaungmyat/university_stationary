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
    public partial class mob_AddNewSuppliers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Boolean IsEmptyDataInput()
        {

            if (string.IsNullOrEmpty(txtSupId.Text) && string.IsNullOrEmpty(txtSupName.Text) && string.IsNullOrEmpty(txtContact.Text) && string.IsNullOrEmpty(txtPhone.Text) && string.IsNullOrEmpty(txtFax.Text) && string.IsNullOrEmpty(txtAddress.Text) && string.IsNullOrEmpty(txtEmail.Text))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mob_UpdateSuppliersController updSupplier = new mob_UpdateSuppliersController();
            if (!IsEmptyDataInput())
            {
                updSupplier.createSupplier(txtSupId.Text, txtSupName.Text, txtContact.Text, txtPhone.Text, txtFax.Text, txtAddress.Text, txtEmail.Text);
            }
        }
    }
}