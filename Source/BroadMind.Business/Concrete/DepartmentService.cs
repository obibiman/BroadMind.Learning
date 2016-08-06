using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain.Admin;
using BroadMind.DataAccess.UnitOfWork.Interfaces;

namespace BroadMind.Business.Concrete
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService()
        {
        }

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Department entity)
        {
            _unitOfWork.DepartmentRepository.Insert(entity);
            SaveChanges();
        }

        public IEnumerable<Department> GetAll(Expression<Func<Department, bool>> predicate = null)
        {
            return _unitOfWork.DepartmentRepository.GetAll(predicate);
        }

        public Department GetById(int Id)
        {
            return _unitOfWork.DepartmentRepository.GetById(Id);
        }

        public void Update(Department entity)
        {
            _unitOfWork.DepartmentRepository.Update(entity);
            SaveChanges();
        }

        public void Delete(Department entity)
        {
            _unitOfWork.DepartmentRepository.Delete(entity);
            SaveChanges();
        }

        public long Count()
        {
            return _unitOfWork.DepartmentRepository.Count();
        }

        public void AddRange(IEnumerable<Department> entities)
        {
            _unitOfWork.DepartmentRepository.AddRange(entities);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<Department> entities)
        {
            _unitOfWork.DepartmentRepository.RemoveRange(entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Complete();
        }
    }
}