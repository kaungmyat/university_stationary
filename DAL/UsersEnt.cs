using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    //Author - Kaung Myat
    public class UsersEnt
    {
        LOGIC_UniversityEntities ContextDB;

        public UsersEnt()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public void createUser(User usr)
        {
            ContextDB.Users.AddObject(usr);
            ContextDB.SaveChanges();
        }

        public List<User> getAllEmp()
        {
            var q = from u in ContextDB.Users
                    select u;

            return q.ToList<User>();
        }

        public List<User> getEmp(User usr)
        {
            var q = from u in ContextDB.Users
                    where (u.Emp_ID == usr.Emp_ID || usr.Emp_ID == null)
                    && (u.Emp_Name == usr.Emp_Name || usr.Emp_Name == null)
                    && (u.Dept_ID == usr.Dept_ID || usr.Dept_ID == null)
                    && (u.Email == usr.Email || usr.Email == null)
                    && (u.Password == usr.Password || usr.Password == null)
                    && (u.Phone == usr.Phone || usr.Phone == null)
                    && (u.DOB == usr.DOB || usr.DOB == null)
                    && (u.Role == usr.Role || usr.Role == null)
                    select u;

            return q.ToList<User>();
        }

        public User getUser(User usr)
        {
            var q = from u in ContextDB.Users
                    where u.Emp_ID == usr.Emp_ID
                    select u;

            return q.First();
        }

        public bool updateEmp(User usr)
        {
            try
            {
                User u = getUser(usr);
                u.Emp_ID = usr.Emp_ID == null ? u.Emp_ID : usr.Emp_ID;
                u.Emp_Name = usr.Emp_Name == null ? u.Emp_Name : usr.Emp_Name;
                u.Dept_ID = usr.Dept_ID == null ? u.Dept_ID : usr.Dept_ID;
                u.Email = usr.Email == null ? u.Email : usr.Email;
                u.Password = usr.Password == null ? u.Password : usr.Password;
                u.Phone = usr.Phone == null ? u.Phone : usr.Phone;
                u.DOB = usr.DOB == null ? u.DOB : usr.DOB;
                usr.Role = usr.Role == null ? u.Role : usr.Role;

                ContextDB.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteEmp(User usr)
        {
            if (usr.Equals(null))
            {
                return false;
            }

            try
            {
                ContextDB.Users.DeleteObject(usr);
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
