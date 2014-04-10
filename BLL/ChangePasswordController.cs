using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class ChangePasswordController
    {
        UsersEnt usrEnt;

        public ChangePasswordController()
        {
            usrEnt = new UsersEnt();
        }

        public bool changePassword(string empID, string newPwd)
        {
            try
            {
                User usr = new User();
                usr.Emp_ID = empID;
                usr.Password = newPwd;

                usrEnt.updateEmp(usr);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
