using System;
using System.Threading.Tasks;
using DDDGuestbook.Core.Entities;
using DDDGuestbook.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DDDGuestbook.Web.Filters
{
    public class VerifyGuestbookExistsAttribute : TypeFilterAttribute
    {
        public VerifyGuestbookExistsAttribute() : base(typeof(VerifyGuestbookExistsImplAttribute))
        {

        }


        private class VerifyGuestbookExistsImplAttribute:IAsyncActionFilter
        {
            private IRepository<GuestBook> _guestBookRepo;

            public VerifyGuestbookExistsImplAttribute(IRepository<GuestBook> guestbookRepo)
            {
                _guestBookRepo=guestbookRepo;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if(context.ActionArguments.ContainsKey("id"))
                {
                    var id = context.ActionArguments["id"] as int?;
                   if(id.HasValue)
                   {
                       if(_guestBookRepo.GetById(id.Value)==null)
                       {
                           context.Result = new NotFoundObjectResult(id.Value);
                           return;
                       }
                   }
                }
                await next();
            }
        }
    }
}