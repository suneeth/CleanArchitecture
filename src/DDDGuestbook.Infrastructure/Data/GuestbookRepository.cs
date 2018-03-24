using DDDGuestbook.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DDDGuestbook.Infrastructure.Data
{
    public class GuestbookRepository:EfRepository<GuestBook>
    {
        public GuestbookRepository(AppDbContext dbContext):base(dbContext)
        {
        }

        public override GuestBook GetById(int id)
        {
           return _dbContext.GuestBooks.Include(g=> g.Entries).FirstOrDefault(c=> c.Id==id);
        }
    }
}