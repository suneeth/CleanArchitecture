using System;
using System.Linq;
using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.Interfaces;
using DDDGuestbook.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DDDGuestbook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<GuestBook> _guestbookRepository;

        public HomeController(IRepository<GuestBook> guestbookRepository)
        {
            _guestbookRepository=guestbookRepository;
        }
        public IActionResult Index()
        {

            if(!_guestbookRepository.List().Any())
            {
                var newGuestbook = new GuestBook(){ Name="My Guestbook" };
                newGuestbook.Entries.Add(new GuestBookEntry()
                {
                  EmailAddress="suneeth@abc.com",
                  Message="Hi!"
                });
                _guestbookRepository.Add(newGuestbook);
            }
          
           var guestbook=_guestbookRepository.GetById(1);
           var viewModel= new HomePageViewModel();

           viewModel.GuestbookName=guestbook.Name;
           viewModel.PreviousEntries.AddRange(guestbook.Entries);

            return View(viewModel);
        }

       
       [HttpPost]
        public IActionResult Index(HomePageViewModel viewModel)
        {
           if(ModelState.IsValid)
           {
               var guestbook=_guestbookRepository.GetById(1);
               guestbook.Entries.Add(viewModel.NewEntry);
               _guestbookRepository.Update(guestbook);

               viewModel.PreviousEntries.Clear();
               viewModel.PreviousEntries.AddRange(guestbook.Entries);
           }
           return View(viewModel);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
