using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    //Author - Nyo Mi Han
    public class DelegateAuthority
    {


        DelegateUserEnt delegateUser = new DelegateUserEnt();
        UsersEnt userEntity = new UsersEnt();


        public void emailNotification(String toEmpName, String fromUserID, String subject, String msgBody)
        {
            User toUser = new User();
            toUser.Emp_ID = getEmpId(toEmpName);
            UsersEnt usrE = new UsersEnt();
            toUser = usrE.getEmp(toUser).First();

            User fromUser = new User();
            fromUser.Emp_ID = fromUserID;
            fromUser = usrE.getEmp(fromUser).First();
            NotificationMsg notiMsg = new NotificationMsg();
            notiMsg.sendAuthUserNotification(fromUser.Email, toUser.Email, subject, msgBody);
        }

        public string getDeptID(String userID)
        {
            string deptId;
            User user = new User();
            user.Emp_ID = userID;
            User emp = userEntity.getEmp(user).First();
            deptId = emp.Dept_ID;
            return deptId;
        }

        public List<User> getEmpNames(String deptID)
        {
            User user = new User();
            user.Dept_ID = deptID;
            List<User> empNames = userEntity.getEmp(user);
            return empNames;

        }
        public String getEmpId(String empName)
        {
            User user = new User();
            user.Emp_Name = empName;
            User emp_ID = userEntity.getEmp(user).First();
            String empId = emp_ID.Emp_ID;
            return empId;
        }

        public void delegateAuthority(String empName, DateTime fDate, DateTime tDate)
        {

            Delegate_User delUsr = new Delegate_User();
            delUsr.Emp_ID = getEmpId(empName);
            delUsr.FromDate = fDate;
            delUsr.ToDate = tDate;
            delegateUser.createDelegateUser(delUsr);

        }

        public Department getDeptName(string deptId)
        {
            DepartmentEnt deptEnt = new DepartmentEnt();
            return deptEnt.getDeptByID(deptId);
        }
    }
}
