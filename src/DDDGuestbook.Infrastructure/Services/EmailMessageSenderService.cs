using System.Net.Mail;
using DDDGuestbook.Core.Interfaces;

namespace DDDGuestbook.Infrastructure.Services
{
    public class EmailMessageSenderService : IMessageSender
    {
        public void SendGuestbookNotificationEmail(string toAddress, string messageBody)
        {
              var message = new MailMessage();
                    message.To.Add(new MailAddress(toAddress));
                    message.From = new MailAddress("donotreply@guestbook.com");
                    message.Subject = "New guestbook entry added";
                    message.Body = messageBody;

                    using (var client = new SmtpClient("localhost", 2500))
                    {
                        client.Send(message);
                    }
        }
    }
}