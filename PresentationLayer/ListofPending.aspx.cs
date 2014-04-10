using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
namespace Logic_University_Stationary.Head
{
    public partial class ListofPending : System.Web.UI.Page
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
                gvPendingRequisition.DataSource=arControl.getPendingRequisitions(ur.Dept_ID);
                gvPendingRequisition.DataBind();
            }

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            List<Requisition> RqList = new List<Requisition>();
            List<Requisition> RqrejList = new List<Requisition>();
            string EmpID = ur.Emp_ID;
            string DeptID = ur.Dept_ID;
            foreach (GridViewRow row in gvPendingRequisition.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("selChkBox");
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
                Session["DeptId"] = DeptID;
                Response.Redirect("HeadRejectRequisition.aspx");
            }

        }

        protected void btnApproveAll_Click(object sender, EventArgs e)
        {
            String EmpID = ur.Emp_ID;
            string DeptID = ur.Dept_ID;
            string Req_No= approve.generateID(DeptID);
            arControl.approveRequisition(Req_No, DeptID, EmpID);
        }

     
        protected void gvPendingRequisition_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Details"))
            {
                GridViewRow clickedRow = ((LinkButton)e.CommandSource).NamingContainer as GridViewRow;
                Session["Employee Name"]= clickedRow.Cells[3].Text;
                Session["Form_No"] = clickedRow.Cells[2].Text;
                Response.Redirect("RequisitionDetail.aspx");
            }
        }
    }
}