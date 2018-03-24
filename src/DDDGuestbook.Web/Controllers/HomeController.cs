using System;
using DDDGuestbook.Core.Entities;
using DDDGuestbook.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DDDGuestbook.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var guestbook=new GuestBook(){ Name="My Guestbook" };
            guestbook.Entries.Add(new GuestBookEntry(){ EmailAddress="suneeth@abc.com",Message="Hi!",DateTimeCreated=DateTime.UtcNow.AddHours(-2)});
            guestbook.Entries.Add(new GuestBookEntry(){ EmailAddress="mark@abc.com",Message="Hi!",DateTimeCreated=DateTime.UtcNow.AddHours(-2)});
            guestbook.Entries.Add(new GuestBookEntry(){ EmailAddress="stev@abc.com",Message="Hi!",DateTimeCreated=DateTime.UtcNow.AddHours(-2)});

           var viewModel= new HomePageViewModel();
           viewModel.GuestbookName=guestbook.Name;
           viewModel.PreviousEntries.AddRange(guestbook.Entries);

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
