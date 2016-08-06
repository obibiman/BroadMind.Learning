using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using BroadMind.Common.Domain.Admin;
using BroadMind.DataAccess.Context;
using BroadMind.DataAccess.Repo.Interfaces;

namespace BroadMind.DataAccess.Repo.Concrete
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly CollegeContext _context;

        public CourseRepository(CollegeContext context)
        {
            _context = context;
        }

        public Course Get(Expression<Func<Course, bool>> predicate)
        {
            return _context.Courses.Where(predicate).SingleOrDefault();
        }

        public Course GetById(int Id)
        {
            return _context.Courses.SingleOrDefault(y => y.CourseId == Id);
        }

        public IEnumerable<Course> GetAll(Expression<Func<Course, bool>> predicate = null)
        {
            IEnumerable<Course> courses = new List<Course>();
            if (predicate != null)
            {
                courses = _context.Courses.Where(predicate).ToList().OrderBy(y => y.CourseName);
            }
            else
            {
                //courses = _context.Courses.OrderBy(y => y.CourseName);
                courses = _context.Courses.Include(y => y.Students).OrderBy(y => y.CourseName).ToList();
                courses = courses.Where(y => y.Students.Count > 0);
            }
            return courses;
        }

        public void Insert(Course entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.CourseSequence,
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

            entity.CourseId = data.Result;
            _context.Courses.Add(entity);
        }

        public void Update(Course entity)
        {
            var existingEntity = GetById(entity.CourseId);
            if (existingEntity == null)
            {
                return;
            }
            _context.Courses.AddOrUpdate(entity);
        }

        public void Delete(Course entity)
        {
            _context.Courses.Remove(entity);
        }

        public long Count()
        {
            return _context.Courses.Count();
        }

        public void AddRange(IEnumerable<Course> entities)
        {
            foreach (var entity in entities)
            {
                var inputValue = new SqlParameter
                {
                    ParameterName = "@SequenceName",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Value = SequenceIdentifier.CourseSequence,
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

                entity.CourseId = data.Result;
                _context.Courses.Add(entity);
            }
        }

        public void RemoveRange(IEnumerable<Course> entities)
        {
            foreach (var entity in entities)
            {
                var itemToRemove = _context.Courses.SingleOrDefault(y => y.CourseId == entity.CourseId);
                _context.Courses.Remove(itemToRemove);
            }
        }

        public IEnumerable<Course> GetAllWithStudents(Expression<Func<Course, bool>> predicate = null)
        {
            IEnumerable<Course> courses = new List<Course>();
            if (predicate != null)
            {
                //courses = _context.Courses.Where(predicate).ToList().OrderBy(y => y.CourseName);
                courses = _context.Courses.Include(y => y.Students).Where(predicate).ToList().OrderBy(y => y.CourseName);
            }
            else
            {
                courses = _context.Courses.OrderBy(y => y.CourseName);
                //courses = _context.Courses.Include(y => y.Students).OrderBy(y=>y.CourseName).ToList();
            }
            return courses;
        }

        public void Add(Course entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.CourseSequence,
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

            entity.CourseId = data.Result;
            _context.Courses.Add(entity);
        }
    }
}