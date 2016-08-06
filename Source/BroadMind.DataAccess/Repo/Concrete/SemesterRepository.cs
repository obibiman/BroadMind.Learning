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
    public class SemesterRepository : IRepository<Semester>
    {
        private readonly CollegeContext _context;

        public SemesterRepository(CollegeContext context)
        {
            _context = context;
        }

        public Semester Get(Expression<Func<Semester, bool>> predicate)
        {
            return _context.Semesters.Where(predicate).SingleOrDefault();
        }

        public Semester GetById(int Id)
        {
            return _context.Semesters.SingleOrDefault(y => y.SemesterId == Id);
        }

        public IEnumerable<Semester> GetAll(Expression<Func<Semester, bool>> predicate = null)
        {
            IEnumerable<Semester> semesters = new List<Semester>();
            if (predicate != null)
            {
                semesters = _context.Semesters.OrderByDescending(y => y.SemesterId).Where(predicate).ToList();
            }
            else
            {
                semesters = _context.Semesters.OrderByDescending(y => y.SemesterId);
            }
            return semesters;
        }

        public void Insert(Semester entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.SemesterSequence,
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
            entity.CreatedDate = DateTime.Now;
            entity.SemesterId = data.Result;
            _context.Semesters.Add(entity);
        }

        public void Update(Semester entity)
        {
            var existingEntity = GetById(entity.SemesterId);
            if (existingEntity == null)
            {
                return;
            }
            entity.ModifiedDate = DateTime.Now;
            _context.Semesters.AddOrUpdate(entity);
        }

        public void Delete(Semester entity)
        {
            _context.Semesters.Remove(entity);
        }

        public long Count()
        {
            return _context.Semesters.Count();
        }

        public void AddRange(IEnumerable<Semester> entities)
        {
            foreach (var semesterData in entities)
            {
                var inputValue = new SqlParameter
                {
                    ParameterName = "@SequenceName",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Value = SequenceIdentifier.SemesterSequence,
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

                semesterData.ModifiedBy = null;
                semesterData.CreatedDate = DateTime.Now;
                semesterData.ModifiedDate = null;
                semesterData.SemesterId = data.Result;
                _context.Semesters.Add(semesterData);
            }
        }

        public void RemoveRange(IEnumerable<Semester> entities)
        {
            foreach (var semesterData in entities)
            {
                var itemToRemove = _context.Semesters.SingleOrDefault(y => y.SemesterId == semesterData.SemesterId);
                _context.Semesters.Remove(itemToRemove);
            }
        }

        public void Add(Semester entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.SemesterSequence,
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

            entity.SemesterId = data.Result;
            _context.Semesters.Add(entity);
        }
    }
}