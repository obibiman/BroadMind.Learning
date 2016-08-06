using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Common.Domain.Admin;

namespace BroadMind.Business.Interfaces
{
    public interface IMajorService
    {
        void Add(Major entity);
        IEnumerable<Major> GetAll(Expression<Func<Major, bool>> predicate = null);
        Major GetById(int Id);
        void Update(Major entity);
        void Delete(Major entity);
        long Count();
        void AddRange(IEnumerable<Major> entities);
        void RemoveRange(IEnumerable<Major> entities);
        void SaveChanges();
    }
}