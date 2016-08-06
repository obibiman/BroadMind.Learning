using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using BroadMind.Common.Domain.Admin;
using BroadMind.DataAccess.Context;
using BroadMind.DataAccess.Repo.Interfaces;

namespace BroadMind.DataAccess.Repo.Concrete
{
    public class MajorRepository : IRepository<Major>
    {
        private readonly CollegeContext _context;

        public MajorRepository(CollegeContext context)
        {
            _context = context;
        }

        public Major Get(Expression<Func<Major, bool>> predicate)
        {
            return _context.Majors.Where(predicate).SingleOrDefault();
        }

        public Major GetById(int Id)
        {
            return _context.Majors.SingleOrDefault(y => y.MajorId == Id);
        }

        public IEnumerable<Major> GetAll(Expression<Func<Major, bool>> predicate = null)
        {
            IEnumerable<Major> Majors = new List<Major>();
            if (predicate != null)
            {
                Majors = _context.Majors.Where(predicate).ToList();
            }
            else
            {
                Majors = _context.Majors;
            }
            return Majors;
        }

        public void Insert(Major entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.MajorSequence,
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

            entity.MajorId = data.Result;
            _context.Majors.Add(entity);
        }

        public void Update(Major entity)
        {
            var existingEntity = GetById(entity.MajorId);
            if (existingEntity == null)
            {
                return;
            }
            _context.Majors.AddOrUpdate(entity);
        }

        public void Delete(Major entity)
        {
            _context.Majors.Remove(entity);
        }

        public long Count()
        {
            return _context.Majors.Count();
        }

        public void AddRange(IEnumerable<Major> entities)
        {
            _context.Majors.AddRange(entities);
        }

        public void RemoveRange(IEnumerable<Major> entities)
        {
            _context.Majors.RemoveRange(entities);
        }

        public void Add(Major entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.MajorSequence,
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

            entity.MajorId = data.Result;
            _context.Majors.Add(entity);
        }
    }
}