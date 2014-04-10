using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Data.Objects.SqlClient;
using System.Data.SqlClient;

namespace DAL
{
    //Author - Kaung Myat
    public class NotificationMsg
    {
        LOGIC_UniversityEntities ContextDB;

        public NotificationMsg()
        {
            ContextDB = new LOGIC_UniversityEntities();
        }

        public int countMailBox(string empID)
        {
            var q = from c in ContextDB.Requisitions
                    where c.Emp_ID == empID && (SqlFunctions.DatePart("wk", c.Request_Date) == SqlFunctions.DatePart("wk", DateTime.Today))
                    select c;

            return q.Count();
        }

        public bool sendAuthUserNotification(string fEmail, string toEmail , string subject, string msgBody)
        {
            try
            {
                string hostname = Dns.GetHostName();
                IPAddress[] addressLst = Dns.GetHostAddresses(hostname);
                string ipAdd = addressLst[1].ToString();

                MailMessage mailMessage = new MailMessage();
                mailMessage.IsBodyHtml = true;

                StringBuilder strb = new StringBuilder();
                strb.Append("&lt;html><head><title>Confirm Adjustment Items</title></head><body>");
                strb.Append("&lt;p>This is msg from clerk information Adjusted Item Quantity. You can check from this link <a href='" + ipAdd + "/Mobile/showNoti.aspx'>click here!</a>");
                strb.Append("&lt;/p></body></html>");

                mailMessage.To.Add(toEmail);
                mailMessage.From = new MailAddress(fEmail);
                //mailMessage.CC.Add("michael_liau@hotmail.com");
                mailMessage.Subject = subject;
                mailMessage.Body = strb.ToString();
                //  SmtpClient smtpClient = new SmtpClient("mail.singnet.com.sg");
                SmtpClient smtpClient = new SmtpClient("lynx.iss.nus.edu.sg");
                smtpClient.Send(mailMessage);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool sendSingleNotification(User usr, string subject, string msgBody)    // send mail from employee to dept head
        {
            try
            {
                string fromEmail = (from u in ContextDB.Users
                              where u.Emp_ID == usr.Emp_ID
                              select u.Email).SingleOrDefault();

                String hID = (from u in ContextDB.Users
                        join d in ContextDB.Departments on u.Dept_ID equals d.Dept_ID 
                        where u.Emp_ID == usr.Emp_ID 
                        select d.Head_ID).SingleOrDefault();

                String toEmail = (from u in ContextDB.Users
                                  where u.Emp_ID == hID
                                  select u.Email).SingleOrDefault();

                return sendAuthUserNotification(fromEmail, toEmail, subject, msgBody);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool sendMultiNotification(User usr, string subject, string msgBody)
        {
            try
            {
                String fromEmail = (from u in ContextDB.Users
                                    where u.Emp_ID == usr.Emp_ID
                                    select new { u.Email }).ToString();

                List<String> lstToEmail = (from u in ContextDB.Users
                                  join d in ContextDB.Departments on u.Dept_ID equals d.Dept_ID
                                  select u.Email).ToList<String>();

                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(lstToEmail.First());
                mailMessage.From = new MailAddress(fromEmail);
                //mailMessage.CC.Add("michael_liau@hotmail.com");
                mailMessage.Subject = subject;
                mailMessage.Body = msgBody;
                //  SmtpClient smtpClient = new SmtpClient("mail.singnet.com.sg");
                
                for (int i = 1; i < lstToEmail.Count; i++)
                {
                    mailMessage.CC.Add(lstToEmail[i]);
                }

                SmtpClient smtpClient = new SmtpClient("lynx.iss.nus.edu.sg");
                smtpClient.Send(mailMessage);


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
    }
}
