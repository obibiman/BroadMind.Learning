using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain.Admin;
using BroadMind.DataAccess.UnitOfWork.Interfaces;

namespace BroadMind.Business.Concrete
{
    public class MajorService : IMajorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MajorService()
        {
        }

        public MajorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Major entity)
        {
            _unitOfWork.MajorRepository.Insert(entity);
            SaveChanges();
        }

        public IEnumerable<Major> GetAll(Expression<Func<Major, bool>> predicate = null)
        {
            return _unitOfWork.MajorRepository.GetAll(predicate);
        }

        public Major GetById(int Id)
        {
            return _unitOfWork.MajorRepository.GetById(Id);
        }

        public void Update(Major entity)
        {
            _unitOfWork.MajorRepository.Update(entity);
            SaveChanges();
        }

        public void Delete(Major entity)
        {
            _unitOfWork.MajorRepository.Delete(entity);
            SaveChanges();
        }

        public long Count()
        {
            return _unitOfWork.MajorRepository.Count();
        }

        public void AddRange(IEnumerable<Major> entities)
        {
            _unitOfWork.MajorRepository.AddRange(entities);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<Major> entities)
        {
            _unitOfWork.MajorRepository.RemoveRange(entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Complete();
        }
    }
}