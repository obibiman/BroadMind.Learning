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
    public class TelephoneRepository : IRepository<Telephone>
    {
        private readonly CollegeContext _context;

        public TelephoneRepository(CollegeContext context)
        {
            _context = context;
        }

        public Telephone Get(Expression<Func<Telephone, bool>> predicate)
        {
            return _context.Telephones.Where(predicate).SingleOrDefault();
        }

        public Telephone GetById(int Id)
        {
            return _context.Telephones.SingleOrDefault(y => y.TelephoneId == Id);
        }

        public IEnumerable<Telephone> GetAll(Expression<Func<Telephone, bool>> predicate = null)
        {
            IEnumerable<Telephone> Telephones = new List<Telephone>();
            if (predicate != null)
            {
                Telephones = _context.Telephones.Where(predicate).ToList();
            }
            else
            {
                Telephones = _context.Telephones;
            }
            return Telephones;
        }

        public void Insert(Telephone entity)
        {
            _context.Telephones.Add(entity);
        }

        public void Update(Telephone entity)
        {
            var existingEntity = GetById(entity.TelephoneId);
            if (existingEntity == null)
            {
                return;
            }
            _context.Telephones.AddOrUpdate(entity);
        }

        public void Delete(Telephone entity)
        {
            _context.Telephones.Remove(entity);
        }

        public long Count()
        {
            return _context.Telephones.Count();
        }

        public void AddRange(IEnumerable<Telephone> entities)
        {
            _context.Telephones.AddRange(entities);
        }

        public void RemoveRange(IEnumerable<Telephone> entities)
        {
            _context.Telephones.RemoveRange(entities);
        }

        public void Add(Telephone entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.TelephoneSequence,
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

            entity.TelephoneId = data.Result;
            _context.Telephones.Add(entity);
        }
    }
}