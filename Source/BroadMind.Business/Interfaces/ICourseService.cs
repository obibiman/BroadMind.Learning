using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Common.Domain.Admin;

namespace BroadMind.Business.Interfaces
{
    public interface ICourseService
    {
        void Add(Course entity);
        IEnumerable<Course> GetAll(Expression<Func<Course, bool>> predicate = null);
        Course GetById(int Id);
        void Update(Course entity);
        void Delete(Course entity);
        long Count();
        void AddRange(IEnumerable<Course> entities);
        void RemoveRange(IEnumerable<Course> entities);
        void SaveChanges();
    }
}