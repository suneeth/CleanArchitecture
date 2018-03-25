using System;
using System.Linq;
using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.Events;
using DDDGuestbook.Core.Interfaces;

namespace DDDGuestbook.Core.Handlers
{
    public class GuestBookNotificationHandler : IHandle<EntryAddedEvent>
    {
        private IRepository<GuestBook> _guestbookRepo;
        private IMessageSender _messageSender;

        public GuestBookNotificationHandler(IRepository<GuestBook> repository,IMessageSender messageSender)
        {
            _guestbookRepo=repository;
            _messageSender = messageSender;
        }
        public void Handle(EntryAddedEvent entryAddedEvent)
        {
             var guestBook = _guestbookRepo.GetById(entryAddedEvent.GuestBookId);

             var emailsToNotify = guestBook.Entries
                                  .Where(e=> e.DateTimeCreated > DateTimeOffset.UtcNow.AddDays(-1))
                                  .Select(e => e.EmailAddress);

               foreach (var emailAddress in emailsToNotify)
                {
                    string messageBody = $"{entryAddedEvent.Entry.EmailAddress} left a new message {entryAddedEvent.Entry.Message}.";
                   _messageSender.SendGuestbookNotificationEmail(emailAddress,messageBody);
                }

        }
    }
}