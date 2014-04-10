using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using DAL;

namespace PL.Clerk
{
    //Author - Liau Kwong Weng
    public partial class DisbursementListDetail : System.Web.UI.Page
    {

        DisbursementController disbursementController = new DisbursementController();

        string disbursementID;
        List<Boolean> statuscontainer = new List<Boolean>();
        bool flag1 = false;
        bool flag2 = false;
        bool qtyupdate = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                disbursementID = (string)(Session["DisbursementID"]);

                lblDate.Text = Convert.ToString(disbursementController.getDisbursementDate(disbursementID));
                lblDisbursementNum.Text = disbursementID;
                lblDept.Text = (string)(Session["deptName"]);
                lblCollectionPoint.Text = disbursementController.getCollectionPoint(lblDept.Text);

                IQueryable data = disbursementController.getDisbursementDetail(disbursementID);
                Session["DisbursementDetailData"] = data;

                disburseListDetailGridView.DataSource = data;
                disburseListDetailGridView.DataBind();

            }
        }


        protected void disburseListDetailGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = disburseListDetailGridView.Rows[index];
            }
        }

        protected void disburseListDetailGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            flag1 = true;

            disburseListDetailGridView.EditIndex = e.NewEditIndex;
            BindData();

        }

        protected void disburseListDetailGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            qtyupdate = true;
            int disbursedQuantity;
            try
            {
                if (int.TryParse(((TextBox)disburseListDetailGridView.Rows[e.RowIndex].FindControl("txtDisbursedQuantity")).Text, out disbursedQuantity))
                {
                    if (disbursedQuantity > 0)
                    {

                        string itemCode = ((Label)disburseListDetailGridView.Rows[e.RowIndex].FindControl("lblItemCode")).Text;


                        disbursementController.updateQty_Disbursed(disbursedQuantity, lblDisbursementNum.Text, itemCode);

                        disburseListDetailGridView.EditIndex = -1;
                        IQueryable data = disbursementController.getDisbursementDetail(lblDisbursementNum.Text);
                        Session["DisbursementDetailData"] = data;
                        lblStatus.Text = "Update Successful";
                        disburseListDetailGridView.DataSource = data;
                        disburseListDetailGridView.DataBind();
                        flag2 = true;
                        qtyupdate = false;

                    }
                    else
                    {
                        lblStatus.Text = "Please key in positive numbers only";
                    }

                }
                else
                {
                    lblStatus.Text = "Please key in numbers only";
                }
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
                lblStatus.Text = "Unsuccessful update";
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //  int row;             
            Boolean status = false;
            disbursementID = (string)(Session["DisbursementID"]);
            try
            {
                {
                    for (int row = 0; row < disburseListDetailGridView.Rows.Count; row++)
                    {
                        if (((Label)disburseListDetailGridView.Rows[row].FindControl("lblRequestedQuantity")).Text != ((Label)disburseListDetailGridView.Rows[row].FindControl("lblDisbursedQuantity")).Text)
                        {
                            status = false;
                            statuscontainer.Add(status);
                        }
                        else
                        {
                            status = true;

                        }

                    }


                    if (statuscontainer != null)
                    {
                        disbursementController.updateDisbursementStatus_1to3(disbursementID);
                        lblStatus.Text = "Submit Successful";
                        btnSubmit.Enabled = false;
                    }

                    else
                    {
                        disbursementController.updateDisbursementStatus_1to2(disbursementID);
                        lblStatus.Text = "Submit Successful";
                        btnSubmit.Enabled = false;
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());

                lblStatus.Text = "Unsuccessful submit";
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisbusementListAllDepartment.aspx");
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void BindData()
        {
            disburseListDetailGridView.DataSource = Session["DisbursementDetailData"];
            disburseListDetailGridView.DataBind();
        }
    }
}
