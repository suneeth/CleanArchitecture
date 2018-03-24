using System;
using DDDGuestbook.Core.SharedKernel;

namespace DDDGuestbook.Core.Entities
{
    public class GuestBookEntry:BaseEntity
    {
       public string EmailAddress { get; set; }
       public string Message   { get; set; }
       public DateTimeOffset DateTimeCreated { get; set; } = DateTime.UtcNow;
    }
}