using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.SharedKernel;

namespace DDDGuestbook.Core.Events
{
    public class EntryAddedEvent:BaseDomainEvent
    {
        public int GuestBookId { get;  }

        public GuestBookEntry Entry { get;  }
        public EntryAddedEvent(GuestBookEntry entry,int guestBookId)
        {
            GuestBookId=guestBookId;
            Entry = entry;
        }
    }
}