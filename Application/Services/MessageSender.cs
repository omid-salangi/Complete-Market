using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
namespace Application.Services
{
    public class MessageSender : IMessageSender
    {
        public Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false)
        {
            SmtpClient client = new SmtpClient();

            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential()
            {
                UserName = "testfordeveloper123@gmail.com",
                Password = "0938006omid.com"
            };

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("testfordeveloper123@gmail.com","omid salangi");
            MailAddress emto = new MailAddress(toEmail);

            msg.To.Add(emto);
            msg.Subject = subject;
            msg.Body = message;
            msg.Priority = MailPriority.High;

            
            client.Send(msg);
            
            

            return Task.CompletedTask;
        }
    }
}
