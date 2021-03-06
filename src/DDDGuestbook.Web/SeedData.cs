﻿using DDDGuestbook.Core.Entities;
using DDDGuestbook.Infrastructure.Data;

namespace DDDGuestbook.Web
{
    public static class SeedData
    {
        public static void PopulateTestData(AppDbContext dbContext)
        {
            var toDos = dbContext.ToDoItems;
            foreach (var item in toDos)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();
            dbContext.ToDoItems.Add(new ToDoItem()
            {
                Title = "Test Item 1",
                Description = "Test Description One"
            });
            dbContext.ToDoItems.Add(new ToDoItem()
            {
                Title = "Test Item 2",
                Description = "Test Description Two"
            });

             var guestbook = new GuestBook ();
            dbContext.GuestBooks.Add(guestbook);
            guestbook.Entries.Add (new GuestBookEntry()
            {
              EmailAddress = "test@test.com",
              Message = "Test message"
            });

            dbContext.SaveChanges();
        }


    }
}
