using System;
using System.Linq.Expressions;
using DDDGuestbook.Core.SharedKernel;

namespace DDDGuestbook.Core.Interfaces
{
    public interface ISpecification<T> where T:class
    {
         Expression<Func<T,bool>> Criteria {get;}
    }
}