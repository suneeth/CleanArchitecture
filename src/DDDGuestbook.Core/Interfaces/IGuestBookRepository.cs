using System.Collections.Generic;
using DDDGuestbook.Core.Entities;

namespace DDDGuestbook.Core.Interfaces
{
    public interface IGuestBookRepository:IRepository<GuestBook>
    {
         List<GuestBookEntry> ListEntries(ISpecification<GuestBookEntry> spec);
    }
}