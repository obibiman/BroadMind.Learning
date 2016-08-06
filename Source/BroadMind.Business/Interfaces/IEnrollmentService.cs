using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Common.Domain;

namespace BroadMind.Business.Interfaces
{
    public interface IEnrollmentService
    {
        void Add(Enrollment entity);
        IEnumerable<Enrollment> GetAll(Expression<Func<Enrollment, bool>> predicate = null);
        Enrollment GetById(int Id);
        void Update(Enrollment entity);
        void Delete(Enrollment entity);
        long Count();
        void AddRange(IEnumerable<Enrollment> entities);
        void RemoveRange(IEnumerable<Enrollment> entities);
        void SaveChanges();
    }
}