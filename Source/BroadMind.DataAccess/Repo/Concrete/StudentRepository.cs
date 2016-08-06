using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using BroadMind.Common.Domain;
using BroadMind.Common.Enumerate;
using BroadMind.DataAccess.Context;
using BroadMind.DataAccess.Repo.Interfaces;

namespace BroadMind.DataAccess.Repo.Concrete
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly CollegeContext _context;

        public StudentRepository(CollegeContext context)
        {
            _context = context;
        }

        public Student Get(Expression<Func<Student, bool>> predicate)
        {
            return _context.Students.Where(predicate).SingleOrDefault();
        }

        public Student GetById(int Id)
        {
            return _context.Students.SingleOrDefault(y => y.StudentId == Id);
        }

        public IEnumerable<Student> GetAll(Expression<Func<Student, bool>> predicate = null)
        {
            IEnumerable<Student> Students = new List<Student>();
            if (predicate != null)
            {
                Students = _context.Students.Where(predicate).ToList();
            }
            else
            {
                Students = _context.Students;
            }
            return Students;
        }

        public void Insert(Student entity)
        {
            _context.Students.Add(entity);
        }

        public void Update(Student entity)
        {
            var existingParent = _context.Students
                .Where(p => p.StudentId == entity.StudentId)
                .Include(q => q.Telephones)
                .SingleOrDefault();

            //update parent
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(entity);
            }

            // Delete children
            foreach (var existingChild in existingParent.Telephones)
            {
                if (entity.Telephones.All(c => c.TelephoneId != existingChild.TelephoneId))
                    _context.Telephones.Remove(existingChild);
            }

            // Update and Insert children
            foreach (var telephoneEntity in entity.Telephones)
            {
                var existingChild = existingParent.Telephones
                    .SingleOrDefault(c => c.TelephoneId == telephoneEntity.TelephoneId);

                if (existingChild != null)
                    // Update child
                    _context.Entry(existingChild).CurrentValues.SetValues(telephoneEntity);
                else
                {
                    // Insert child
                    var newChild = new Telephone
                    {
                        AreaCode = telephoneEntity.AreaCode,
                        Extension = telephoneEntity.Extension,
                        LineNumber = telephoneEntity.LineNumber,
                        Prefix = telephoneEntity.Prefix,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        ModifiedBy = string.Empty,
                        PhoneType = PhoneType.Mobile
                    };
                    //build sequence
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
                        .SqlQuery<int>(
                            "exec @SequenceOutput = sp_CollegeWebAPISequence @SequenceName, @SequenceValue OUT",
                            returnCode, inputValue, outParam)
                        .FirstOrDefaultAsync();

                    newChild.TelephoneId = data.Result; //get primary key from sequence
                    existingParent.Telephones.Add(newChild);
                }
            }
            _context.Students.AddOrUpdate(entity);
        }

        //public void Update(Student entity)
        //{
        //    var existingEntity = GetById(entity.StudentId);

        //    if (existingEntity == null)
        //    {
        //        return;
        //    }
        //    _context.Students.AddOrUpdate(entity);
        //}

        public void Delete(Student entity)
        {
            _context.Students.Remove(entity);
        }

        public long Count()
        {
            return _context.Students.Count();
        }

        public void AddRange(IEnumerable<Student> entities)
        {
            _context.Students.AddRange(entities);
        }

        public void RemoveRange(IEnumerable<Student> entities)
        {
            _context.Students.RemoveRange(entities);
        }

        public void Add(Student entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.StudentSequence,
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

            entity.StudentId = data.Result;
            _context.Students.Add(entity);
        }
    }
}