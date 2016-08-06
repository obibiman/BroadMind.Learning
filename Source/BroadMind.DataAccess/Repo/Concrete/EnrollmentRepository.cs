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
    public class EnrollmentRepository : IRepository<Enrollment>
    {
        private readonly CollegeContext _context;

        public EnrollmentRepository(CollegeContext context)
        {
            _context = context;
        }

        public Enrollment Get(Expression<Func<Enrollment, bool>> predicate)
        {
            return _context.Enrollments.Where(predicate).SingleOrDefault();
        }

        public Enrollment GetById(int Id)
        {
            return _context.Enrollments.SingleOrDefault(y => y.EnrollmentId == Id);
        }

        public IEnumerable<Enrollment> GetAll(Expression<Func<Enrollment, bool>> predicate = null)
        {
            IEnumerable<Enrollment> Enrollments = new List<Enrollment>();
            if (predicate != null)
            {
                Enrollments = _context.Enrollments.Where(predicate).ToList();
            }
            else
            {
                Enrollments = _context.Enrollments;
            }
            return Enrollments;
        }

        public void Insert(Enrollment entity)
        {
            _context.Enrollments.Add(entity);
        }

        public void Update(Enrollment entity)
        {
            var existingEntity = GetById(entity.EnrollmentId);
            if (existingEntity == null)
            {
                return;
            }
            _context.Enrollments.AddOrUpdate(entity);
        }

        public void Delete(Enrollment entity)
        {
            _context.Enrollments.Remove(entity);
        }

        public long Count()
        {
            return _context.Enrollments.Count();
        }

        public void AddRange(IEnumerable<Enrollment> entities)
        {
            _context.Enrollments.AddRange(entities);
        }

        public void RemoveRange(IEnumerable<Enrollment> entities)
        {
            _context.Enrollments.RemoveRange(entities);
        }

        public void Add(Enrollment entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.EnrollmentSequence,
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

            entity.EnrollmentId = data.Result;
            _context.Enrollments.Add(entity);
        }
    }
}