using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Common.Domain;

namespace BroadMind.Business.Interfaces
{
    public interface IFinancialAidService
    {
        void Add(FinancialAid entity);
        IEnumerable<FinancialAid> GetAll(Expression<Func<FinancialAid, bool>> predicate = null);
        FinancialAid GetById(int Id);
        void Update(FinancialAid entity);
        void Delete(FinancialAid entity);
        long Count();
        void AddRange(IEnumerable<FinancialAid> entities);
        void RemoveRange(IEnumerable<FinancialAid> entities);
        void SaveChanges();
    }
}