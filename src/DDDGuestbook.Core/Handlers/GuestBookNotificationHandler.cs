using System;
using System.Linq;
using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.Events;
using DDDGuestbook.Core.Interfaces;
using DDDGuestbook.Core.Specification;

namespace DDDGuestbook.Core.Handlers
{
    public class GuestBookNotificationHandler : IHandle<EntryAddedEvent>
    {
        private IGuestBookRepository _guestbookRepo;
        private IMessageSender _messageSender;
        private ISpecification<GuestBookEntry> _policy;

        public GuestBookNotificationHandler(IGuestBookRepository repository,IMessageSender messageSender)
        {
            _guestbookRepo=repository;
            _messageSender = messageSender;
           
        }
        public void Handle(EntryAddedEvent entryAddedEvent)
        {
             var guestBook = _guestbookRepo.GetById(entryAddedEvent.GuestBookId);
              _policy = new GuestBookNotificationPolicy(entryAddedEvent.GuestBookId);

             var emailsToNotify = _guestbookRepo.ListEntries(_policy).Select(e => e.EmailAddress);
               

               foreach (var emailAddress in emailsToNotify)
                {
                    string messageBody = $"{entryAddedEvent.Entry.EmailAddress} left a new message {entryAddedEvent.Entry.Message}.";
                   _messageSender.SendGuestbookNotificationEmail(emailAddress,messageBody);
                }

        }
    }
}