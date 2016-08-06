using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Common.Domain;

namespace BroadMind.Business.Interfaces
{
    public interface ISemesterService
    {
        void Add(Semester entity);
        IEnumerable<Semester> GetAll(Expression<Func<Semester, bool>> predicate = null);
        Semester GetById(int Id);
        void Update(Semester entity);
        void Delete(Semester entity);
        long Count();
        void AddRange(IEnumerable<Semester> entities);
        void RemoveRange(IEnumerable<Semester> entities);
        void SaveChanges();
    }
}