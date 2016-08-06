using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using BroadMind.Common.Domain;
using BroadMind.DataAccess.Context;
using BroadMind.DataAccess.Repo.Interfaces;

namespace BroadMind.DataAccess.Repo.Concrete
{
    public class AddressRepository : IRepository<Address>
    {
        private readonly CollegeContext _context;

        public AddressRepository()
        {
        }

        public AddressRepository(CollegeContext context)
        {
            _context = context;
        }

        public Address Get(Expression<Func<Address, bool>> predicate)
        {
            return _context.Addresses.Where(predicate).SingleOrDefault();
        }

        public Address GetById(int Id)
        {
            return _context.Addresses.SingleOrDefault(y => y.AddressId == Id);
        }

        public IEnumerable<Address> GetAll(Expression<Func<Address, bool>> predicate = null)
        {
            IEnumerable<Address> addresses = new List<Address>();
            if (predicate != null)
            {
                addresses = _context.Addresses.OrderByDescending(y => y.AddressId).Where(predicate).ToList();
            }
            else
            {
                addresses = _context.Addresses.OrderByDescending(y => y.AddressId);
            }
            return addresses;
        }

        public void Insert(Address entity)
        {
            _context.Addresses.Add(entity);
        }

        public void Update(Address entity)
        {
            var existingEntity = GetById(entity.AddressId);
            if (existingEntity == null)
            {
                return;
            }
            _context.Addresses.AddOrUpdate(entity);
        }

        public void Delete(Address entity)
        {
            _context.Addresses.Remove(entity);
        }

        public long Count()
        {
            return _context.Addresses.Count();
        }

        public void AddRange(IEnumerable<Address> entities)
        {
            foreach (var entity in entities)
            {
                var inputValue = new SqlParameter
                {
                    ParameterName = "@SequenceName",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Value = SequenceIdentifier.AddressSequence,
                    Direction = ParameterDirection.Input
                };
                var outParam = new SqlParameter
                {
                    ParameterName = "@SequenceValue",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                var returnCode = new SqlParameter
                {
                    ParameterName = "@SequenceOutput",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var data = _context.Database
                    .SqlQuery<int>("exec @SequenceOutput = sp_CollegeWebAPISequence @SequenceName, @SequenceValue OUT",
                        returnCode, inputValue, outParam)
                    .FirstOrDefaultAsync();

                entity.AddressId = data.Result;
                _context.Addresses.Add(entity);
            }
        }

        public void RemoveRange(IEnumerable<Address> entities)
        {
            foreach (var entity in entities)
            {
                var itemToRemove = _context.Addresses.SingleOrDefault(y => y.AddressId == entity.AddressId);
                _context.Addresses.Remove(itemToRemove);
            }
        }

        public void Add(Address entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.AddressSequence,
                Direction = ParameterDirection.Input
            };
            var outParam = new SqlParameter
            {
                ParameterName = "@SequenceValue",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            var returnCode = new SqlParameter
            {
                ParameterName = "@SequenceOutput",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            var data = _context.Database
                .SqlQuery<int>("exec @SequenceOutput = sp_CollegeWebAPISequence @SequenceName, @SequenceValue OUT",
                    returnCode, inputValue, outParam)
                .FirstOrDefaultAsync();

            entity.AddressId = data.Result;
            _context.Addresses.Add(entity);
        }
    }
}