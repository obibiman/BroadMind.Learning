using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain;
using BroadMind.DataAccess.UnitOfWork.Interfaces;

namespace BroadMind.Business.Concrete
{
    public class FinancialAidService : IFinancialAidService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinancialAidService()
        {
        }

        public FinancialAidService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(FinancialAid entity)
        {
            _unitOfWork.FinancialAidRepository.Insert(entity);
            SaveChanges();
        }

        public IEnumerable<FinancialAid> GetAll(Expression<Func<FinancialAid, bool>> predicate = null)
        {
            return _unitOfWork.FinancialAidRepository.GetAll(predicate);
        }

        public FinancialAid GetById(int Id)
        {
            return _unitOfWork.FinancialAidRepository.GetById(Id);
        }

        public void Update(FinancialAid entity)
        {
            _unitOfWork.FinancialAidRepository.Update(entity);
            SaveChanges();
        }

        public void Delete(FinancialAid entity)
        {
            _unitOfWork.FinancialAidRepository.Delete(entity);
            SaveChanges();
        }

        public long Count()
        {
            return _unitOfWork.FinancialAidRepository.Count();
        }

        public void AddRange(IEnumerable<FinancialAid> entities)
        {
            _unitOfWork.FinancialAidRepository.AddRange(entities);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<FinancialAid> entities)
        {
            _unitOfWork.FinancialAidRepository.RemoveRange(entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Complete();
        }
    }
}