using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Common.Domain;

namespace BroadMind.Business.Interfaces
{
    public interface IAddressService
    {
        void Add(Address entity);
        IEnumerable<Address> GetAll(Expression<Func<Address, bool>> predicate = null);
        Address GetById(int Id);
        void Update(Address entity);
        void Delete(Address entity);
        long Count();
        void AddRange(IEnumerable<Address> entities);
        void RemoveRange(IEnumerable<Address> entities);
        void SaveChanges();
    }
}