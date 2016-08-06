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
    public class FinancialAidRepository : IRepository<FinancialAid>
    {
        private readonly CollegeContext _context;

        public FinancialAidRepository(CollegeContext context)
        {
            _context = context;
        }

        public FinancialAid Get(Expression<Func<FinancialAid, bool>> predicate)
        {
            return _context.FinancialAids.Where(predicate).SingleOrDefault();
        }

        public FinancialAid GetById(int Id)
        {
            return _context.FinancialAids.SingleOrDefault(y => y.FinancialAidId == Id);
        }

        public IEnumerable<FinancialAid> GetAll(Expression<Func<FinancialAid, bool>> predicate = null)
        {
            IEnumerable<FinancialAid> states = new List<FinancialAid>();
            if (predicate != null)
            {
                states = _context.FinancialAids.OrderByDescending(y => y.FinancialAidId).Where(predicate).ToList();
            }
            else
            {
                states = _context.FinancialAids.OrderByDescending(y => y.FinancialAidId);
            }
            return states;
        }

        public void Insert(FinancialAid entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.FinancialAidSequence,
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
            entity.FinancialAidId = data.Result;

            _context.FinancialAids.AddOrUpdate(entity);
        }

        public void Update(FinancialAid entity)
        {
            var existingEntity = GetById(entity.FinancialAidId);
            if (existingEntity == null)
            {
                return;
            }
            _context.FinancialAids.AddOrUpdate(entity);
            //_context.SaveChanges();
        }

        public void Delete(FinancialAid entity)
        {
            _context.FinancialAids.Remove(entity);
        }

        public long Count()
        {
            return _context.FinancialAids.Count();
        }

        public void AddRange(IEnumerable<FinancialAid> entities)
        {
            foreach (var entity in entities)
            {
                var inputValue = new SqlParameter
                {
                    ParameterName = "@SequenceName",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Value = SequenceIdentifier.FinancialAidSequence,
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

                entity.FinancialAidId = data.Result;
                _context.FinancialAids.Add(entity);
            }
        }

        public void RemoveRange(IEnumerable<FinancialAid> entities)
        {
            foreach (var entity in entities)
            {
                var itemToRemove = _context.FinancialAids.SingleOrDefault(y => y.FinancialAidId == entity.FinancialAidId);
                _context.FinancialAids.Remove(itemToRemove);
            }
        }

        public void Add(FinancialAid entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.FinancialAidSequence,
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

            entity.FinancialAidId = data.Result;
            _context.FinancialAids.AddOrUpdate(entity);
        }
    }
}