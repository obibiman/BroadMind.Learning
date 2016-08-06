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
    public class StateRepository : IRepository<State>
    {
        private readonly CollegeContext _context;

        public StateRepository(CollegeContext context)
        {
            _context = context;
        }

        public State Get(Expression<Func<State, bool>> predicate)
        {
            return _context.States.Where(predicate).SingleOrDefault();
        }

        public State GetById(int Id)
        {
            return _context.States.SingleOrDefault(y => y.StateId == Id);
        }

        public IEnumerable<State> GetAll(Expression<Func<State, bool>> predicate = null)
        {
            IEnumerable<State> states = new List<State>();
            if (predicate != null)
            {
                states = _context.States.OrderByDescending(y => y.StateId).Where(predicate).ToList();
            }
            else
            {
                states = _context.States.OrderByDescending(y => y.StateId);
            }
            return states;
        }

        public void Insert(State entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.StateSequence,
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
            entity.StateId = data.Result;
            _context.States.Add(entity);
        }

        public void Update(State entity)
        {
            var existingEntity = GetById(entity.StateId);
            if (existingEntity == null)
            {
                return;
            }
            entity.ModifiedDate = DateTime.Now;
            _context.States.AddOrUpdate(entity);
        }

        public void Delete(State entity)
        {
            _context.States.Remove(entity);
        }

        public long Count()
        {
            return _context.States.Count();
        }

        public void AddRange(IEnumerable<State> entities)
        {
            foreach (var stateData in entities)
            {
                var inputValue = new SqlParameter
                {
                    ParameterName = "@SequenceName",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Value = SequenceIdentifier.StateSequence,
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

                stateData.ModifiedBy = null;
                stateData.CreatedDate = DateTime.Now;
                stateData.ModifiedDate = null;
                stateData.StateId = data.Result;
                _context.States.Add(stateData);
            }
        }

        public void RemoveRange(IEnumerable<State> entities)
        {
            foreach (var stateData in entities)
            {
                var itemToRemove = _context.States.SingleOrDefault(y => y.StateCode == stateData.StateCode);
                _context.States.Remove(itemToRemove);
            }
        }

        public State GetByStateCode(string stateCode)
        {
            return _context.States.SingleOrDefault(y => y.StateCode == stateCode);
        }

        public void Add(State entity)
        {
            var inputValue = new SqlParameter
            {
                ParameterName = "@SequenceName",
                SqlDbType = SqlDbType.NVarChar,
                Size = 50,
                Value = SequenceIdentifier.StateSequence,
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

            entity.StateId = data.Result;
            _context.States.Add(entity);
        }
    }
}