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
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly CollegeContext _context;

        public DepartmentRepository(CollegeContext context)
        {
            _context = context;
        }

        public Department Get(Expression<Func<Department, bool>> predicate)
        {
            return _context.Departments.Where(predicate).SingleOrDefault();
        }

        public Department GetById(int Id)
        {
            return _context.Departments.SingleOrDefault(y => y.DepartmentId == Id);
        }

        public IEnumerable<Department> GetAll(Expression<Func<Department, bool>> predicate = null)
        {
            IEnumerable<Department> departments = new List<Department>();
            if (predicate != null)
            {
                departments = _context.Departments.Where(predicate).ToList();
            }
            else
            {
                departments = _context.Departments;
            }
            var numRec = departments.Count();
            return departments;
        }

        public void Insert(Department entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.DepartmentSequence,
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

            entity.DepartmentId = data.Result;

            var existingParent = _context.Departments
                .Where(p => p.DepartmentId == entity.DepartmentId)
                .Include(p => p.Courses)
                .SingleOrDefault();
            _context.Departments.Add(entity);
        }

        //public void Edit(Department entity)
        //{
        //    var existingDepartment = _context.Departments
        //        .Where(p => p.DepartmentId == entity.DepartmentId)
        //        .Include(p => p.Courses)
        //        .SingleOrDefault();
        //    if (existingDepartment != null)
        //    {
        //        // Update Department
        //        _context.Entry(existingDepartment).CurrentValues.SetValues(entity);
        //        // Delete children
        //        foreach (var existingCourse in existingDepartment.Courses.ToList())
        //        {
        //            if (entity.Courses.All(c => c.CourseId != existingCourse.CourseId))
        //                _context.Courses.Remove(existingCourse);
        //        }
        //        // Update and Insert children
        //        foreach (var course in entity.Courses)
        //        {
        //            var existingCourse = existingDepartment.Courses
        //                .SingleOrDefault(c => c.CourseId == course.CourseId);

        //            if (existingCourse != null)
        //                // Update child
        //                _context.Entry(existingCourse).CurrentValues.SetValues(course);
        //            else
        //            {
        //                // Insert child
        //                var newChild = new Course
        //                {
        //                    CourseId =
        //                        _context.Database.SqlQuery<int>("SELECT NEXT VALUE FOR dbo.CourseSequence;")
        //                            .FirstOrDefaultAsync()
        //                            .Result,
        //                    CourseName = course.CourseName,
        //                    Description = course.Description,
        //                    CreatedDate = DateTime.Now,
        //                    Credit = course.Credit
        //                };
        //                existingDepartment.Courses.Add(newChild);
        //            }
        //        }
        //        _context.SaveChanges();
        //    }
        //    else //car doesn't exit.  add new record
        //    {
        //        _context.Departments.Add(entity);

        //        foreach (var course in entity.Courses)
        //        {
        //            _context.Courses.Add(course);
        //        }
        //    }
        //}

        //publix
        /*
        public void Update(UpdateParentModel model)
{
    var existingParent = _dbContext.Departments
        .Where(p => p.DepartmentId == entity.DepartmentId)
        .Include(p => p.Courses)
        .SingleOrDefault();

    if (existingParent != null)
    {
        // Update parent
        _dbContext.Entry(existingParent).CurrentValues.SetValues(model);

        // Delete children
        foreach (var existingChild in existingParent.Children.ToList())
        {
            if (!model.Children.Any(c => c.Id == existingChild.Id))
                _dbContext.Children.Remove(existingChild);
        }

        // Update and Insert children
        foreach (var childModel in model.Children)
        {
            var existingChild = existingParent.Children
                .Where(c => c.Id == childModel.Id)
                .SingleOrDefault();

            if (existingChild != null)
                // Update child
                _dbContext.Entry(existingChild).CurrentValues.SetValues(childModel);
            else
            {
                // Insert child
                var newChild = new Child
                {
                    Data = childModel.Data,
                    //...
                };
                existingParent.Children.Add(newChild);
            }
        }

        _dbContext.SaveChanges();
    }
}
    */

        public void Update(Department entity)
        {
            var existingEntity = GetById(entity.DepartmentId);
            if (existingEntity == null)
            {
                return;
            }
            _context.Departments.AddOrUpdate(entity);
        }

        public void Delete(Department entity)
        {
            _context.Departments.Remove(entity);
        }

        public long Count()
        {
            return _context.Departments.Count();
        }

        public void AddRange(IEnumerable<Department> entities)
        {
            _context.Departments.AddRange(entities);
        }

        public void RemoveRange(IEnumerable<Department> entities)
        {
            _context.Departments.RemoveRange(entities);
        }

        public void Add(Department entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.DepartmentSequence,
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

            entity.DepartmentId = data.Result;
            _context.Departments.Add(entity);
        }
    }
}