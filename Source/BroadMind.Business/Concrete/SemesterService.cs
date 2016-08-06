using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain;
using BroadMind.DataAccess.UnitOfWork.Interfaces;

namespace BroadMind.Business.Concrete
{
    public class SemesterService : ISemesterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SemesterService()
        {
        }

        public SemesterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Semester entity)
        {
            _unitOfWork.SemesterRepository.Insert(entity);
            SaveChanges();
        }

        public IEnumerable<Semester> GetAll(Expression<Func<Semester, bool>> predicate = null)
        {
            return _unitOfWork.SemesterRepository.GetAll(predicate);
        }

        public Semester GetById(int Id)
        {
            return _unitOfWork.SemesterRepository.GetById(Id);
        }

        public void Update(Semester entity)
        {
            _unitOfWork.SemesterRepository.Update(entity);
            SaveChanges();
        }

        public void Delete(Semester entity)
        {
            _unitOfWork.SemesterRepository.Delete(entity);
            SaveChanges();
        }

        public long Count()
        {
            return _unitOfWork.SemesterRepository.Count();
        }

        public void AddRange(IEnumerable<Semester> entities)
        {
            _unitOfWork.SemesterRepository.AddRange(entities);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<Semester> entities)
        {
            _unitOfWork.SemesterRepository.RemoveRange(entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Complete();
        }
    }
}