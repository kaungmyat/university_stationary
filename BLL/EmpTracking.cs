using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public static class EmpTracking
    {
        public static string CreateHash(string unHashed)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(unHashed);
            data = x.ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }


        public static bool MatchHash(string HashData, string HashUser)
        {
            HashUser = CreateHash(HashUser);
            if (HashUser == HashData)
                return true;
            else
                return false;

        }

        public static void encryptPassword(string empID)
        {
            UsersEnt usrE = new UsersEnt();
            User usr = new User();
            usr.Emp_ID = empID;

            usr = usrE.getEmp(usr).First();

            usr.Password = CreateHash(usr.Password);

            usrE.updateEmp(usr);

        }
    }
}
