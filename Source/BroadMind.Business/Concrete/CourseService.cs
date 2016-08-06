using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain.Admin;
using BroadMind.DataAccess.UnitOfWork.Interfaces;

namespace BroadMind.Business.Concrete
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService()
        {
        }

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Course entity)
        {
            _unitOfWork.CourseRepository.Insert(entity);
            SaveChanges();
        }

        public IEnumerable<Course> GetAll(Expression<Func<Course, bool>> predicate = null)
        {
            return _unitOfWork.CourseRepository.GetAll(predicate);
        }

        public Course GetById(int Id)
        {
            return _unitOfWork.CourseRepository.GetById(Id);
        }

        public void Update(Course entity)
        {
            _unitOfWork.CourseRepository.Update(entity);
            SaveChanges();
        }

        public void Delete(Course entity)
        {
            _unitOfWork.CourseRepository.Delete(entity);
            SaveChanges();
        }

        public long Count()
        {
            return _unitOfWork.CourseRepository.Count();
        }

        public void AddRange(IEnumerable<Course> entities)
        {
            _unitOfWork.CourseRepository.AddRange(entities);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<Course> entities)
        {
            _unitOfWork.CourseRepository.RemoveRange(entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Complete();
        }
    }
}