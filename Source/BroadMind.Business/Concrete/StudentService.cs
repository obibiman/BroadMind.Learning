using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain;
using BroadMind.DataAccess.UnitOfWork.Interfaces;

namespace BroadMind.Business.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService()
        {
        }

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Student entity)
        {
            _unitOfWork.StudentRepository.Insert(entity);
            SaveChanges();
        }

        public IEnumerable<Student> GetAll(Expression<Func<Student, bool>> predicate = null)
        {
            return _unitOfWork.StudentRepository.GetAll(predicate);
        }

        public Student GetById(int Id)
        {
            return _unitOfWork.StudentRepository.GetById(Id);
        }

        public void Update(Student entity)
        {
            _unitOfWork.StudentRepository.Update(entity);
            SaveChanges();
        }

        public void Delete(Student entity)
        {
            _unitOfWork.StudentRepository.Delete(entity);
            SaveChanges();
        }

        public long Count()
        {
            return _unitOfWork.StudentRepository.Count();
        }

        public void AddRange(IEnumerable<Student> entities)
        {
            _unitOfWork.StudentRepository.AddRange(entities);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<Student> entities)
        {
            _unitOfWork.StudentRepository.RemoveRange(entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Complete();
        }
    }
}