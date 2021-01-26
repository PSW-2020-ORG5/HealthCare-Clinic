using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace APIGateway.EmailService
{
    public class EmailService
    {
        public string Message { get; set; }
        public string ReceiverMail { get; set;}
        public string SenderMail { get; set;}


        public EmailService()
        {
            
        }

        public EmailService(string message, string receiverMail, string senderMail)
        {
            Message = message;
            ReceiverMail = receiverMail;
            SenderMail = senderMail;
        }


        public static void SendEmail(string messageString, string receiver)
        {
            try
            {
                messageString = "<h1>" + messageString + "</h1>";
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("pswtim24@gmail.com");
                message.To.Add(new MailAddress(receiver));
                message.Subject = "Notification about new tender";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = messageString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("pswtim24@gmail.com", "pswtim24firma5"); //moramo uneti nasu neku mail adresu pass
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                

            }
            catch (Exception) { }
        }



    }
}
