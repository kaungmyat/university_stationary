using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace BLL
{
    public class Utilities
    {
        public void sendNotificationToDeptHead(string text)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(text);
                mailMessage.From = new MailAddress("StoreClerk@LogicUniversity.edu.sg");
                mailMessage.CC.Add("michael_liau@hotmail.com");
                mailMessage.Subject = "ASP.NET e-mail test";
                mailMessage.Body = "Hello world,\n\nThis is an ASP.NET test e-mail! Textbox value = " + text;
                //  SmtpClient smtpClient = new SmtpClient("mail.singnet.com.sg");
                SmtpClient smtpClient = new SmtpClient("lynx.iss.nus.edu.sg");
                smtpClient.Send(mailMessage);
                // Response.Write("E-mail sent!");
            }
            catch (Exception ex)
            {
                // Response.Write("Could not send the e-mail - error: " + ex.Message);
            }
        }

        public void sendNotificationToEmployees()
        {
        }

        public void sendNotificationToClerk()
        {
        }

        public void SendNotificatonToDeptRep()
        {
        }

        public static string aspDateTimeFormat(string date)
        {
            string m, d, y;
            string[] dateArr = new string[3];
            int j = 0, start = 0;
            string tmp = date;
            
            int count = date.Split('/').Length;

            for(int i = 0; i<count - 1; i++)
            {
                start = tmp.IndexOf('/') + 1;
                dateArr[i] = tmp.Substring(j, tmp.IndexOf('/'));
                tmp = tmp.Substring(start, tmp.Length - start);
                //j = tmp.IndexOf('/') + 1;
            }

            dateArr[2] = tmp;

            d = dateArr[1];
            m = dateArr[0];
            y = dateArr[2];
            tmp = d + "/" + m + "/" + y;

            return tmp;
        }
    }
}
