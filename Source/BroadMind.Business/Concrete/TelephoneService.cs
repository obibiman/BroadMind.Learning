using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain;
using BroadMind.DataAccess.UnitOfWork.Interfaces;

namespace BroadMind.Business.Concrete
{
    public class TelephoneService : ITelephoneService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TelephoneService()
        {
        }

        public TelephoneService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Telephone entity)
        {
            _unitOfWork.TelephoneRepository.Insert(entity);
            SaveChanges();
        }

        public IEnumerable<Telephone> GetAll(Expression<Func<Telephone, bool>> predicate = null)
        {
            return _unitOfWork.TelephoneRepository.GetAll(predicate);
        }

        public Telephone GetById(int Id)
        {
            return _unitOfWork.TelephoneRepository.GetById(Id);
        }

        public void Update(Telephone entity)
        {
            _unitOfWork.TelephoneRepository.Update(entity);
            SaveChanges();
        }

        public void Delete(Telephone entity)
        {
            _unitOfWork.TelephoneRepository.Delete(entity);
            SaveChanges();
        }

        public long Count()
        {
            return _unitOfWork.TelephoneRepository.Count();
        }

        public void AddRange(IEnumerable<Telephone> entities)
        {
            _unitOfWork.TelephoneRepository.AddRange(entities);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<Telephone> entities)
        {
            _unitOfWork.TelephoneRepository.RemoveRange(entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Complete();
        }
    }
}