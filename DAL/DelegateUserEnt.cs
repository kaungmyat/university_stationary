using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class DelegateUserEnt
    {
        LOGIC_UniversityEntities ContextDB;

        public DelegateUserEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public void createDelegateUser(Delegate_User delUsr)            //<<C>>
        {
            ContextDB.Delegate_User.AddObject(delUsr);
            ContextDB.SaveChanges();
        }

        public List<Delegate_User> getAllDelegateUser()                 //<<R>>
        {
            var query = from delUsr in ContextDB.Delegate_User
                        select delUsr;

            return query.ToList<Delegate_User>();
        }
        //>>>>>>>>>>>>>>>Rajna<<<<<<<<<<<
        public bool checkDelegatedUser(string EmpID, DateTime date)
        {
            var query = from u in ContextDB.Delegate_User
                        where (u.Emp_ID == EmpID)
                            && (date >= u.FromDate && date < u.ToDate)
                        select u;
            if (query.Count() > 0)
                return true;
            else
                return false;
        }
         //>>>>>>>>>>>>>>>>>>>>
        public Delegate_User getDelegateUser(Delegate_User usr)
        {
            var relUsr = from u in ContextDB.Delegate_User
                         where (u.Del_ID == usr.Del_ID || usr.Del_ID == null)
                         && (u.Emp_ID == usr.Emp_ID || usr.Emp_ID == null)
                         && (u.FromDate == usr.FromDate || usr.FromDate == null)
                         && (u.ToDate == usr.ToDate || usr.ToDate == null)
                         select u;

            return relUsr.First();

        }

        public bool updateDelUser(Delegate_User updUsr)                 //<<U>>
        {
            try
            {
                Delegate_User usr = getDelegateUser(updUsr);
                usr.FromDate = updUsr.FromDate;
                usr.ToDate = updUsr.ToDate;

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteDelUser(Delegate_User delUsr)                 //<<D>>
        {
            try
            {
                ContextDB.Delegate_User.DeleteObject(delUsr);
                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
