using System.Collections.Generic;
using DDDGuestbook.Core.Entities;

namespace DDDGuestbook.Web.ViewModels
{
    public class HomePageViewModel
    {
        public string GuestbookName { get; set; }

        public List<GuestBookEntry> PreviousEntries { get;  } =new List<GuestBookEntry>();

        public GuestBookEntry NewEntry { get; set; }
    }
}