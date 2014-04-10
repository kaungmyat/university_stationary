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
    public partial class listOfPendingReq : System.Web.UI.Page
    {
        ApproveRequisitionControl arControl = new ApproveRequisitionControl();
        EmployeeRequisitionControl approve = new EmployeeRequisitionControl();
        LoginController logControl = new LoginController();
        User ur = new User();
   
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string emp_Id = Convert.ToString(Session["Emp_ID"]);
            User u = new User();
            u.Emp_ID = emp_Id;
            
           ur = logControl.getUser(u);

            if (!IsPostBack)
            {
                gvReqList.DataSource = arControl.getPendingRequisitions(ur.Dept_ID);
                gvReqList.DataBind();
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            List<Requisition> RqList = new List<Requisition>();
            List<Requisition> RqrejList = new List<Requisition>();
            string EmpID = ur.Emp_ID;
            string DeptID = ur.Dept_ID;
            foreach (GridViewRow row in gvReqList.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked)
                {
                    Requisition req = new Requisition();
                    req.Req_Form_No = row.Cells[2].Text;
                    req.Approval_Status = 2;
                    RqList.Add(req);
                }
                else
                {
                    Requisition req = new Requisition();
                    req.Req_Form_No = row.Cells[2].Text;
                    RqrejList.Add(req);
                }
            }
            string Req_No = approve.generateID(DeptID);
            arControl.approveSelectedRequisitions(RqList, Req_No, EmpID, DeptID, RqrejList);
            if (RqrejList.Count() > 0)
            {
                Session["DepId"] = DeptID;
                Response.Redirect("rejectReq.aspx");
            }
        }

        protected void btnAppAll_Click(object sender, EventArgs e)
        {
            if (gvReqList.Rows.Count > 0)
            {
                String EmpID = ur.Emp_ID;
                string DeptID = ur.Dept_ID;
                string Req_No = approve.generateID(DeptID);
                arControl.approveRequisition(Req_No, DeptID, EmpID);
            }
            else
            {
                string sliderPopupFunction = @"<script>
                                            $(function () { 
                                                alert(""No requisition data have to approve!!!"");
                                         });
                                            </script>";

                ClientScript.RegisterStartupScript(typeof(Page), "key", sliderPopupFunction);
            }
        }

        protected void gvReqList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Details"))
            {
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Session["Employee Name"] = clickedRow.Cells[3].Text;
                Session["Form_No"] = clickedRow.Cells[2].Text;
                Response.Redirect("RequisitionDetail.aspx");
            }
        }

       
    }
}