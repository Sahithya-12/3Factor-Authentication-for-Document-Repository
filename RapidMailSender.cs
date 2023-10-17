using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.IO;
using System.Net.Mime;
using System.Configuration;
namespace MultiFaceRec
{
    class RapidMailSender
    {
        public static void Send(string Id , string otp )
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("mailserviceforproject@gmail.com", "narmxqsexchxkara");
            smtp.EnableSsl = true;

            MailAddress _from = new MailAddress(Id);
            MailAddress _to = new MailAddress(Id);

            MailMessage mail = new MailMessage(_from, _to);
            mail.Subject = "Strong room security code";

            string body = "Your OTP to login :" + otp;

            mail.Body = body; //  string.Format("<font size=3> Dear customer : Units consumed {0} for meterno {1} , please pay {2}/-Rs  before due date to avoid disconnection </font>", units, meterno, amount);

            mail.IsBodyHtml = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
