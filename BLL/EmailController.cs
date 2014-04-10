using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

using DAL;

namespace BLL
{
    public class EmailController
    {
        //Liau Kwong Weng
        public EmailController()
        {

        }

        public bool emailSupplier(string email)
        {
            try
            {

                MailMessage mailMessage = new MailMessage();
                mailMessage.IsBodyHtml = true;

                mailMessage.To.Add(email);
                mailMessage.From = new MailAddress("StoreClerk@LogicUniversity.edu.sg");
                mailMessage.CC.Add("venkatlogicuni@gmail.com");
                mailMessage.Subject = "Purchase Order";
                mailMessage.Body =  "Purchase Order";
                //  SmtpClient smtpClient = new SmtpClient("mail.singnet.com.sg");
                SmtpClient smtpClient = new SmtpClient("lynx.iss.nus.edu.sg");
                smtpClient.Send(mailMessage);
                // Response.Write("E-mail sent!");
                return true;
            }
            catch (Exception ex)
            {
                // Response.Write("Could not send the e-mail - error: " + ex.Message);

                System.Diagnostics.Debug.WriteLine("Error = " + ex);
                return false;
            }


        }



    }
}
