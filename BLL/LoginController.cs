using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL;

namespace BLL
{
    //Liau Kwong Weng
    public class LoginController
    {
        UsersEnt userEnt;
        Boolean status;
        string role;
        string name;
        User user = new User();

        public LoginController()
        {

            userEnt = new UsersEnt();
            status = false;
            role = null;
        }

        public User getUser(User u)
        {
          return  userEnt.getUser(u);
        }

        public bool ValidateUser(string emp_id, string password)
        {
            
            user.Emp_ID = emp_id;
            //user.Password = password;

            List<User> lstUsr = userEnt.getEmp(user);


            if (lstUsr.Count > 0)
            {
                foreach (var val in lstUsr)
                {
                    if (EmpTracking.MatchHash(val.Password, password))
                    //if(val.Password == password) 
                    {
                        status = true;
                       // System.Diagnostics.Debug.WriteLine("EmpTracking status = true");
                        System.Diagnostics.Debug.WriteLine("Emp role = " + val.Role);
                        role = val.Role;
                       // name = val.Emp_Name;
                       // session

                    }
                    
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("status = false");
                       // Console.WriteLine("status = false");
                        status = false;
                    }
                } //end foreach

                return status;
            }
            else
            {
                return false;
            } 
                      
        } //end of ValidateUser
     //>>>>Rajna>>>
        public bool getDelegationSatus(string empId, DateTime date)
        {
            DelegateUserEnt del = new DelegateUserEnt();
            return del.checkDelegatedUser(empId, date);
        }
        //>>>>>>>>>>>
        public string GetRole(string emp_id)
        {
            return role;
        }

        public string GetName(string emp_id)
        {
            user.Emp_ID = emp_id;
            List<User> lstUsr = userEnt.getEmp(user);
            foreach (var val in lstUsr)
                {
                   
                        System.Diagnostics.Debug.WriteLine("Emp name = " + val.Emp_Name);
                       // role = val.Role;
                        name = val.Emp_Name;
                       // session

                }
            return name;
        }
    }
}
