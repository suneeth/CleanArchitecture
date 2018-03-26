using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.Interfaces;
using DDDGuestbook.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DDDGuestbook.Web.Api
{
    [Route("api/[controller]")]
    public class GuestBookController:Controller
    {
        private IRepository<GuestBook> _guestbookRepo;

        public GuestBookController(IRepository<GuestBook> guestbookRepo)
        {
            _guestbookRepo = guestbookRepo;
        }


        [HttpGet("{id:int}")]
        [VerifyGuestbookExists]
        public IActionResult GetById(int id)
        {
            var guestbook = _guestbookRepo.GetById(id);
          
            return Ok(guestbook);
        }

        [HttpPost("{id:int}/NewEntry")]
        [VerifyGuestbookExists]
        public IActionResult NewEntry(int id, [FromBody] GuestBookEntry entry)
        {
            var guestbook = _guestbookRepo.GetById(id);
           
            guestbook.AddEntry(entry);
            _guestbookRepo.Update(guestbook);

            return Ok(guestbook);
        }
    }
}