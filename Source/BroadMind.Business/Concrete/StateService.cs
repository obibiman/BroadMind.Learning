using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain.Admin;
using BroadMind.DataAccess.UnitOfWork.Interfaces;

namespace BroadMind.Business.Concrete
{
    public class StateService : IStateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StateService()
        {
        }

        public StateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(State entity)
        {
            _unitOfWork.StateRepository.Insert(entity);
            SaveChanges();
        }

        public IEnumerable<State> GetAll(Expression<Func<State, bool>> predicate = null)
        {
            return _unitOfWork.StateRepository.GetAll(predicate);
        }

        public State GetById(int Id)
        {
            return _unitOfWork.StateRepository.GetById(Id);
        }

        public State GetByStateCode(string stateCode)
        {
            var statesList = _unitOfWork.StateRepository.GetAll();
            return statesList.SingleOrDefault(y => y.StateCode == stateCode);
        }

        public void Update(State entity)
        {
            _unitOfWork.StateRepository.Update(entity);
            SaveChanges();
        }

        public void Delete(State entity)
        {
            _unitOfWork.StateRepository.Delete(entity);
            SaveChanges();
        }

        public long Count()
        {
            return _unitOfWork.StateRepository.Count();
        }

        public void AddRange(IEnumerable<State> entities)
        {
            _unitOfWork.StateRepository.AddRange(entities);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<State> entities)
        {
            _unitOfWork.StateRepository.RemoveRange(entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Complete();
        }
    }
}