using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DDDGuestbook.Infrastructure.Data
{
    public class GuestbookRepository:EfRepository<GuestBook>,IGuestBookRepository
    {
        public GuestbookRepository(AppDbContext dbContext):base(dbContext)
        {
        }

       

        public override GuestBook GetById(int id)
        {
           return _dbContext.GuestBooks.Include(g=> g.Entries).FirstOrDefault(c=> c.Id==id);
        }

        public List<GuestBookEntry> ListEntries(ISpecification<GuestBookEntry> spec)
        {
            return _dbContext.GuestBookEntries
                      .Where(spec.Criteria)
                      .ToList();
        }

    }
}