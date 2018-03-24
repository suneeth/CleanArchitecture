using System.Collections.Generic;
using DDDGuestbook.Core.SharedKernel;

namespace DDDGuestbook.Core.Entities
{
    public class GuestBook:BaseEntity
    {
        public string Name { get; set; }
        public List<GuestBookEntry> Entries { get; }=new List<GuestBookEntry>();

    }
}