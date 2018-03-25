using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.Interfaces;
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
        public IActionResult GetById(int id)
        {
            var guestbook = _guestbookRepo.GetById(id);
            if(guestbook == null)
            {
                return NotFound(id);
            }
            return Ok(guestbook);
        }

        [HttpPost("{id:int}/NewEntry")]
        public IActionResult NewEntry(int id, [FromBody] GuestBookEntry entry)
        {
            var guestbook = _guestbookRepo.GetById(id);
            if(guestbook ==null)
            {
                return NotFound(id);
            }
            guestbook.AddEntry(entry);
            _guestbookRepo.Update(guestbook);

            return Ok(guestbook);
        }
    }
}