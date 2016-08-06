using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Common.Domain.Admin;

namespace BroadMind.Business.Interfaces
{
    public interface IStateService
    {
        void Add(State entity);
        IEnumerable<State> GetAll(Expression<Func<State, bool>> predicate = null);
        State GetById(int Id);
        State GetByStateCode(string stateCode);
        void Update(State entity);
        void Delete(State entity);
        long Count();
        void AddRange(IEnumerable<State> entities);
        void RemoveRange(IEnumerable<State> entities);
        void SaveChanges();
    }
}