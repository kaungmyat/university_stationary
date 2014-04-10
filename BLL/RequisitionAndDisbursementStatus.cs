using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    //Author - Nyo Mi Han
    public class RequisitionAndDisbursementStatus
    {

        public List<view_RequisitionDisbursementStatus> getReqDisbStatus(String empID, int num1, int num2)
        {
            RequisitionEnt reqDisbStatus = new RequisitionEnt();

            var reqDisInfo = reqDisbStatus.getRequisitionDisbursementStatus(empID, num1, num2);

            return reqDisInfo.ToList<view_RequisitionDisbursementStatus>();
        }

        public String getEmpName(String userId)
        {
            User user = new User();
            user.Emp_ID = userId;
            UsersEnt userEnt = new UsersEnt();
            var userInfo = userEnt.getEmp(user).First();
            user.Emp_Name = userInfo.Emp_Name;
            return user.Emp_Name;
        }
        public List<Requisition_Detail> getStatusDetail(string frmNo)
        {
            RequisitionDetailEnt reqDetailEnt = new RequisitionDetailEnt();
            Requisition_Detail reqDetail = new Requisition_Detail();
            reqDetail.Req_Form_No = frmNo;
            return reqDetailEnt.getReqDetail(reqDetail);
        }

        public view_RequisitionDisbursementStatus getReqDate(string fNo)
        {
            RequisitionEnt reqEnt = new RequisitionEnt();
            return reqEnt.getReqStatusByFrmNo(fNo);
        }
    }
}
