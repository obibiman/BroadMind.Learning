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
using BroadMind.Common.Domain;
using BroadMind.RESTFul.WebAPIServices.Models;

namespace BroadMind.RESTFul.WebAPIServices.Controllers
{
    /// <summary>
    ///     FinancialAidController
    /// </summary>
    [EnableCors("*", "*", "*")]
    public class FinancialAidController : ApiController
    {
        private readonly IFinancialAidService _financialAidService;

        /// <summary>
        ///     FinancialAidController
        /// </summary>
        public FinancialAidController()
        {
        }

        /// <summary>
        ///     FinancialAidController
        /// </summary>
        /// <param name="financialAidService"></param>
        public FinancialAidController(IFinancialAidService financialAidService)
        {
            _financialAidService = financialAidService;
        }

        // GET: api/FinancialAidModel
        /// <summary>
        ///     GetFinancialAids
        /// </summary>
        /// <returns>IEnumerable&lt;FinancialAidModel&gt;</returns>
        [HttpGet]
        [Route("v1/FinancialAid/GetFinancialAids", Name = "GetFinancialAids")]
        public IEnumerable<FinancialAidModel> GetFinancialAids()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FinancialAid, FinancialAidModel>());
            var mapper = config.CreateMapper();

            var financialAids = _financialAidService.GetAll();
            var financialAidListModels = mapper.Map<IEnumerable<FinancialAid>, List<FinancialAidModel>>(financialAids);
            return financialAidListModels;
        }

        // GET: api/FinancialAidModel/5
        /// <summary>
        ///     GetFinancialAid
        /// </summary>
        /// <param name="financialAidId"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        [Route("v1/FinancialAid/GetFinancialAid/{financialAidId}", Name = "GetFinancialAid")]
        public IHttpActionResult GetFinancialAid(int financialAidId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FinancialAid, FinancialAidModel>());
            var mapper = config.CreateMapper();

            var financialAid = _financialAidService.GetById(financialAidId);
            var transformedFinancialAid = mapper.Map<FinancialAid, FinancialAidModel>(financialAid);
            if (transformedFinancialAid == null)
            {
                return BadRequest("No FinancialAids found");
            }
            return Ok(transformedFinancialAid);
        }

        // POST: api/FinancialAidModel
        /// <summary>
        ///     PostFinancialAid
        /// </summary>
        /// <param name="financialAidModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/FinancialAid/PostFinancialAid", Name = "PostFinancialAid")]
        public HttpResponseMessage PostFinancialAid(FinancialAidModel financialAidModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FinancialAidModel, FinancialAid>());
            var mapper = config.CreateMapper();
            var transformedFinancialAid = mapper.Map<FinancialAidModel, FinancialAid>(financialAidModel);
            _financialAidService.Add(transformedFinancialAid);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location =
                new Uri(Url.Link("GetFinancialAid", new {transformedFinancialAid.FinancialAidId}));
            return response;
        }


        // POST: api/FinancialAidModel
        /// <summary>
        ///     PostFinancialAids
        /// </summary>
        /// <param name="financialAidModels"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/FinancialAid/PostFinancialAids", Name = "PostFinancialAids")]
        public HttpResponseMessage PostFinancialAids(List<FinancialAidModel> financialAidModels)
        {
            var financialAids = financialAidModels.Select(stateModel => new FinancialAid
            {
                FinancialAidId = stateModel.FinancialAidId,
                FirstName = stateModel.FirstName,
                LastName = stateModel.LastName,
                Amount = stateModel.Amount,
                Classification = stateModel.Classification,
                MiddleName = stateModel.MiddleName,
                OnTrack = stateModel.OnTrack
            }).ToList();
            _financialAidService.AddRange(financialAids);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        // PUT: api/FinancialAidModel/5
        /// <summary>
        ///     Put
        /// </summary>
        /// <param name="financialAidId"></param>
        /// <param name="financialAidModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPut]
        [Route("v1/FinancialAid/PutFinancialAid/{financialAidId}", Name = "PutFinancialAid")]
        public HttpResponseMessage Put(int financialAidId, FinancialAidModel financialAidModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FinancialAidModel, FinancialAid>());
            var mapper = config.CreateMapper();
            var transformedFinancialAid = mapper.Map<FinancialAidModel, FinancialAid>(financialAidModel);
            transformedFinancialAid.FinancialAidId = financialAidId;
            _financialAidService.Update(transformedFinancialAid);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location =
                new Uri(Url.Link("GetFinancialAid", new {transformedFinancialAid.FinancialAidId}));
            return response;
        }

        // DELETE: v1/FinancialAid/DeleteFinancialAids
        /// <summary>
        ///     DeleteFinancialAids
        /// </summary>
        /// <param name="financialAidModels"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/FinancialAid/DeleteFinancialAids", Name = "DeleteFinancialAids")]
        public HttpResponseMessage DeleteFinancialAids(List<FinancialAidModel> financialAidModels)
        {
            var financialAids = financialAidModels.Select(model => new FinancialAid
            {
                FinancialAidId = model.FinancialAidId,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Amount = model.Amount,
                OnTrack = model.OnTrack,
                Classification = model.Classification
            }).ToList();

            _financialAidService.RemoveRange(financialAids);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }

        // DELETE: api/FinancialAidModel/5
        /// <summary>
        ///     DeleteFinancialAid
        /// </summary>
        /// <param name="financialAidId"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/FinancialAid/DeleteFinancialAid/{financialAidId}", Name = "DeleteFinancialAid")]
        public HttpResponseMessage DeleteFinancialAid(int financialAidId)
        {
            var financialAid = _financialAidService.GetById(financialAidId);
            _financialAidService.Delete(financialAid);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}