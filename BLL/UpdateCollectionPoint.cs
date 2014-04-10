using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    //Author - Nyo Mi Han
   public class UpdateCollectionPoint
    {

       DepartmentEnt depEntity = new DepartmentEnt();
       Department dept = new Department();
       UsersEnt userEnt = new UsersEnt();
        public void updateCollectionPoint(String collectionPoint, String userId)
        {

                
                dept.Representative_ID = userId;
                Department deptCode = depEntity.getDepartment(dept).First();
                dept.Dept_ID = deptCode.Dept_ID;
                dept.Dept_Name = deptCode.Dept_Name;
                dept.Representative_Name = deptCode.Representative_Name;
                dept.Collection_Point = collectionPoint;
                depEntity.updateDepartment(dept);

        }

        public String getDeptRepEmail(String userId)
        {
            String deptRepEmail;
            User user = new User();
            user.Emp_ID = userId;
            var repInfo = userEnt.getEmp(user).First();
            deptRepEmail = repInfo.Email;
            return deptRepEmail;
        }

        public List<User> getClerkEmail()
        {
            User user = new User();
            user.Role="Clerk";
            UsersEnt userEnt = new UsersEnt();
            List<User> clerkList= userEnt.getEmp(user);
            return clerkList;
        }

        public void emailNoti(String deptRepEmail)
        {
            String clerkEmail, subject, msgBody;
            subject="Updated Collection Point!";
            msgBody=dept.Dept_Name + " updated collection point to "+ dept.Collection_Point;
            NotificationMsg emailEnt = new NotificationMsg();
            List<User> clerks = getClerkEmail();
            for (int i = 0; i < clerks.Count; i++)
            {
                clerkEmail = clerks[i].Email;
                emailEnt.sendAuthUserNotification(deptRepEmail, clerkEmail, subject, msgBody);
            }
        }
    }
}
