using System.Collections.Generic;
using DDDGuestbook.Core.Events;
using DDDGuestbook.Core.SharedKernel;

namespace DDDGuestbook.Core.Entities
{
    public class GuestBook:BaseEntity
    {
        public string Name { get; set; }
        public List<GuestBookEntry> Entries { get; }=new List<GuestBookEntry>();
        
        public GuestBook()
        {
            
        }
        public void AddEntry(GuestBookEntry entry)
        {
            Entries.Add(entry);
            Events.Add(new EntryAddedEvent(entry,Id));
        }

    }
}