using System;
using System.Linq.Expressions;
using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.Interfaces;

namespace DDDGuestbook.Core.Specification
{
    public class GuestBookNotificationPolicy : ISpecification<GuestBookEntry>
    {
        private int _entryId;

        public GuestBookNotificationPolicy(int entryId)
        {
            _entryId = entryId;
        }
        public Expression<Func<GuestBookEntry, bool>> Criteria => e=> e.DateTimeCreated > DateTimeOffset.UtcNow.AddDays(-1) && e.Id!=_entryId ;// e.GuestBookId == entry.GuestBookId;

    }
}