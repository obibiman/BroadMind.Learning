using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Common.Domain.Admin;

namespace BroadMind.Business.Interfaces
{
    public interface IDepartmentService
    {
        void Add(Department entity);
        IEnumerable<Department> GetAll(Expression<Func<Department, bool>> predicate = null);
        Department GetById(int Id);
        void Update(Department entity);
        void Delete(Department entity);
        long Count();
        void AddRange(IEnumerable<Department> entities);
        void RemoveRange(IEnumerable<Department> entities);
        void SaveChanges();
    }
}