namespace DDDGuestbook.Core.Interfaces
{
    public interface IMessageSender
    {
         void SendGuestbookNotificationEmail(string toAddress,string messageBody);
    }
}