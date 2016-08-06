using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain;
using BroadMind.DataAccess.UnitOfWork.Interfaces;

namespace BroadMind.Business.Concrete
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnrollmentService()
        {
        }

        public EnrollmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Enrollment entity)
        {
            _unitOfWork.EnrollmentRepository.Insert(entity);
            SaveChanges();
        }

        public IEnumerable<Enrollment> GetAll(Expression<Func<Enrollment, bool>> predicate = null)
        {
            return _unitOfWork.EnrollmentRepository.GetAll(predicate);
        }

        public Enrollment GetById(int Id)
        {
            return _unitOfWork.EnrollmentRepository.GetById(Id);
        }

        public void Update(Enrollment entity)
        {
            _unitOfWork.EnrollmentRepository.Update(entity);
            SaveChanges();
        }

        public void Delete(Enrollment entity)
        {
            _unitOfWork.EnrollmentRepository.Delete(entity);
            SaveChanges();
        }

        public long Count()
        {
            return _unitOfWork.EnrollmentRepository.Count();
        }

        public void AddRange(IEnumerable<Enrollment> entities)
        {
            _unitOfWork.EnrollmentRepository.AddRange(entities);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<Enrollment> entities)
        {
            _unitOfWork.EnrollmentRepository.RemoveRange(entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Complete();
        }
    }
}