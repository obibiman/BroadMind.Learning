using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain;
using BroadMind.DataAccess.UnitOfWork.Interfaces;

namespace BroadMind.Business.Concrete
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressService()
        {
        }

        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Address entity)
        {
            _unitOfWork.AddressRepository.Insert(entity);
            SaveChanges();
        }

        public IEnumerable<Address> GetAll(Expression<Func<Address, bool>> predicate = null)
        {
            return _unitOfWork.AddressRepository.GetAll(predicate);
        }

        public Address GetById(int Id)
        {
            return _unitOfWork.AddressRepository.GetById(Id);
        }

        public void Update(Address entity)
        {
            _unitOfWork.AddressRepository.Update(entity);
            SaveChanges();
        }

        public void Delete(Address entity)
        {
            _unitOfWork.AddressRepository.Delete(entity);
            SaveChanges();
        }

        public long Count()
        {
            return _unitOfWork.AddressRepository.Count();
        }

        public void AddRange(IEnumerable<Address> entities)
        {
            _unitOfWork.AddressRepository.AddRange(entities);
            SaveChanges();
        }

        public void RemoveRange(IEnumerable<Address> entities)
        {
            _unitOfWork.AddressRepository.RemoveRange(entities);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.Complete();
        }
    }
}