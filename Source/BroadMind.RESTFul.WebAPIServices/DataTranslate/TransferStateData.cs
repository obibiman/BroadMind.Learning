using System;
using BroadMind.Common.Domain.Admin;
using BroadMind.RESTFul.WebAPIServices.Models.Admin;

namespace BroadMind.RESTFul.WebAPIServices.DataTranslate
{
    public class TransferStateData
    {
        public static StateModel ConvertStateToModel(State state)
        {
            var sm = new StateModel();
            try
            {
                var stateModel = new StateModel
                {
                    StateId = state.StateId,
                    StateCode = state.StateCode,
                    StateName = state.StateName,
                    CreatedDate = state.CreatedDate,
                    ModifiedBy = state.ModifiedBy,
                    ModifiedDate = state.ModifiedDate
                };
                sm = stateModel;
            }
            catch (Exception exep)
            {
                Console.WriteLine("An exception has occurred {0}", exep);
                throw;
            }
            return sm;
        }

        public static State ConvertStateModel(StateModel stateModel)
        {
            var state = new State
            {
                StateId = stateModel.StateId,
                StateCode = stateModel.StateCode,
                StateName = stateModel.StateName,
                CreatedDate = stateModel.CreatedDate,
                ModifiedBy = stateModel.ModifiedBy,
                ModifiedDate = stateModel.ModifiedDate
            };
            return state;
        }

        //{

        //public static State ConvertState(StateModel stateModel)
        //    var state = new State
        //    {
        //        StateId = stateModel.StateId,
        //        StateCode = stateModel.StateCode,
        //        StateName = stateModel.StateName,
        //        CreatedDate = stateModel.CreatedDate,
        //        ModifiedDate = stateModel.ModifiedDate,
        //        ModifiedBy = stateModel.ModifiedBy
        //    };
        //    return state;
        //}
    }
}