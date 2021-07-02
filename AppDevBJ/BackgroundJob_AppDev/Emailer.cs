using BackgroundJob_AppDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJob_AppDev
{
    public class Emailer
    {
        Admin _admin;
        public Emailer(Admin admin)
        {
            _admin = admin;
        }
        public bool SendEmailGmail(string recipient, string EmailSubject,string messageBody)
        {
            try
            {
                Admin admin = new Admin();

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(_admin.AdminEmail);
                message.To.Add(new MailAddress(recipient));
                message.Subject = EmailSubject;
                message.Body = messageBody;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_admin.AdminEmail, _admin.AdminPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);

                return true;
            }
            
            catch (Exception ex)
            {
                return false;
                //https://accounts.google.com/DisplayUnlockCaptcha
            }
        }
    }
}
