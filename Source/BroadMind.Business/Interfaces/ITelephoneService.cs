using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Common.Domain;

namespace BroadMind.Business.Interfaces
{
    public interface ITelephoneService
    {
        void Add(Telephone entity);
        IEnumerable<Telephone> GetAll(Expression<Func<Telephone, bool>> predicate = null);
        Telephone GetById(int Id);
        void Update(Telephone entity);
        void Delete(Telephone entity);
        long Count();
        void AddRange(IEnumerable<Telephone> entities);
        void RemoveRange(IEnumerable<Telephone> entities);
        void SaveChanges();
    }
}