using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain.Admin;
using BroadMind.RESTFul.WebAPIServices.Models.Admin;

namespace BroadMind.RESTFul.WebAPIServices.Controllers
{
    /// <summary>
    ///     StateController
    /// </summary>
    [EnableCors("*", "*", "*")]
    public class StateController : ApiController
    {
        private readonly IStateService _stateService;

        /// <summary>
        ///     StateController
        /// </summary>
        /// <param name="stateService"></param>
        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        /// <summary>
        ///     StateController
        /// </summary>
        public StateController()
        {
        }

        // GET: api/StateModel
        /// <summary>
        ///     Get
        /// </summary>
        /// <returns>IEnumerable&lt;StateModel&gt;</returns>
        [HttpGet]
        [Route("v1/State/GetStates", Name = "GetStates")]
        public IEnumerable<StateModel> GetStates()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<State, StateModel>());
            var mapper = config.CreateMapper();

            var states = _stateService.GetAll();
            var stateListModels = mapper.Map<IEnumerable<State>, List<StateModel>>(states);
            return stateListModels;
        }

        // GET: api/StateModel/5
        /// <summary>
        ///     Get
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        [Route("v1/State/GetState/{stateId}", Name = "GetState")]
        public IHttpActionResult GetState(int stateId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<State, StateModel>());
            var mapper = config.CreateMapper();

            var state = _stateService.GetById(stateId);
            var transformedState = mapper.Map<State, StateModel>(state);
            if (transformedState == null)
            {
                return BadRequest("No States found");
            }
            return Ok(transformedState);
        }

        // GET: api/StateModel/ststeCode
        /// <summary>
        ///     Get
        /// </summary>
        /// <param name="stateCode"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        [Route("v1/State/GetStateByStateCode/{stateCode}", Name = "GetStateByStateCode")]
        public IHttpActionResult GetStateByStateCode(string stateCode)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<State, StateModel>());
            var mapper = config.CreateMapper();

            var state = _stateService.GetByStateCode(stateCode);
            var transformedState = mapper.Map<State, StateModel>(state);
            if (transformedState == null)
            {
                return BadRequest("No States found");
            }
            return Ok(transformedState);
        }

        // POST: api/StateModel
        /// <summary>
        ///     Post
        /// </summary>
        /// <param name="stateModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/State/PostState", Name = "PostState")]
        public HttpResponseMessage PostState(StateModel stateModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StateModel, State>());
            var mapper = config.CreateMapper();
            var transformedState = mapper.Map<StateModel, State>(stateModel);
            _stateService.Add(transformedState);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetState", new {transformedState.StateId}));
            return response;
        }

        // POST: api/StateModel
        /// <summary>
        ///     PostStates
        /// </summary>
        /// <param name="stateModels"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/State/PostStates", Name = "PostStates")]
        public HttpResponseMessage PostStates(List<StateModel> stateModels)
        {
            var states = stateModels.Select(stateModel => new State
            {
                StateId = stateModel.StateId,
                StateCode = stateModel.StateCode,
                StateName = stateModel.StateName,
                CreatedDate = DateTime.Now,
                ModifiedBy = null,
                ModifiedDate = null
            }).ToList();

            var transformedStates = (IEnumerable<State>) states;
            _stateService.AddRange(transformedStates);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        // POST: api/StateModel
        /// <summary>
        ///     Post
        /// </summary>
        /// <param name="stateModels"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/State/DeleteStates", Name = "DeleteStates")]
        public HttpResponseMessage DeleteStates(List<StateModel> stateModels)
        {
            var states = new List<State>();
            foreach (var stateModel in stateModels)
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
                states.Add(state);
            }
            var transformedStates = (IEnumerable<State>) states;
            _stateService.RemoveRange(transformedStates);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }

        // PUT: api/StateModel/5
        /// <summary>
        ///     Put
        /// </summary>
        /// <param name="stateId"></param>
        /// <param name="stateModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPut]
        [Route("v1/State/PutState/{stateId}", Name = "PutState")]
        public HttpResponseMessage PutState(int stateId, StateModel stateModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StateModel, State>());
            var mapper = config.CreateMapper();
            var transformedState = mapper.Map<StateModel, State>(stateModel);
            transformedState.StateId = stateId;
            _stateService.Update(transformedState);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetState", new {transformedState.StateId}));
            return response;
        }

        // DELETE: api/StateModel/5
        /// <summary>
        ///     Delete
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/State/DeleteState/{stateId}", Name = "DeleteState")]
        public HttpResponseMessage DeleteState(int stateId)
        {
            var state = _stateService.GetById(stateId);
            _stateService.Delete(state);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}