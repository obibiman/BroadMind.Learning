using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain;
using BroadMind.RESTFul.WebAPIServices.DataTranslate;
using BroadMind.RESTFul.WebAPIServices.Models;

namespace BroadMind.RESTFul.WebAPIServices.Controllers
{
    /// <summary>
    ///     AddressController
    /// </summary>
    [EnableCors("*", "*", "*")]
    public class AddressController : ApiController
    {
        private readonly IAddressService _addressService;

        /// <summary>
        ///     AddressController
        /// </summary>
        public AddressController()
        {
        }

        /// <summary>
        ///     AddressController
        /// </summary>
        /// <param name="addressService"></param>
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        // GET: api/AddressModel
        /// <summary>
        ///     GetAddresses
        /// </summary>
        /// <returns>IEnumerable&lt;AddressModel&gt;</returns>
        [HttpGet]
        [Route("v1/Address/GetAddresses", Name = "GetAddresses")]
        public IEnumerable<AddressModel> GetAddresses()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Address, AddressModel>());
            var mapper = config.CreateMapper();

            var addresss = _addressService.GetAll();

            var addressListModels = mapper.Map<IEnumerable<Address>, List<AddressModel>>(addresss);
            //var addressListModels = TransferAddressData.ConvertAddressesToModels(addresss);
            return addressListModels;
        }

        // GET: api/AddressModel/5
        /// <summary>
        ///     GetAddress
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        [Route("v1/Address/GetAddress/{addressId}", Name = "GetAddress")]
        public IHttpActionResult GetAddress(int addressId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Address, AddressModel>());
            var mapper = config.CreateMapper();

            var address = _addressService.GetById(addressId);
            var transformedAddress = mapper.Map<Address, AddressModel>(address);
            if (transformedAddress == null)
            {
                return BadRequest("No Address found");
            }
            return Ok(transformedAddress);
        }

        // POST: api/AddressModel
        /// <summary>
        ///     PostAddress
        /// </summary>
        /// <param name="addressModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/Address/PostAddress", Name = "PostAddress")]
        public HttpResponseMessage PostAddress(AddressModel addressModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddressModel, Address>());
            var mapper = config.CreateMapper();
            var transformedAddress = mapper.Map<AddressModel, Address>(addressModel);
            _addressService.Add(transformedAddress);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetAddress", new {transformedAddress.AddressId}));
            return response;
        }

        // POST: api/AddressModel
        /// <summary>
        ///     PostAddress
        /// </summary>
        /// <param name="addressModels"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/Address/PostAddresses", Name = "PostAddresses")]
        public HttpResponseMessage PostAddresses(IEnumerable<AddressModel> addressModels)
        {
            var addresses = new List<Address>();

            var addressess = TransferAddressData.ConvertModelsToAddresses(addressModels);
            foreach (var addressModel in addressModels)
            {
                var address = new Address
                {
                    Address1 = addressModel.Address1,
                    Address2 = addressModel.Address2,
                    AddressId = addressModel.AddressId,
                    City = addressModel.City,
                    StateCode = addressModel.StateCode,
                    ZipCode = addressModel.ZipCode,
                    CreatedDate = addressModel.CreatedDate,
                    ModifiedBy = addressModel.ModifiedBy,
                    ModifiedDate = addressModel.ModifiedDate
                };
                addresses.Add(address);
            }

            _addressService.AddRange(addresses);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }

        // PUT: api/AddressModel/5
        /// <summary>
        ///     PutAddress
        /// </summary>
        /// <param name="addressId"></param>
        /// <param name="addressModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPut]
        [Route("v1/Address/PutAddress/{addressId}", Name = "PutAddress")]
        public HttpResponseMessage PutAddress(int addressId, AddressModel addressModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddressModel, Address>());
            var mapper = config.CreateMapper();
            var transformedAddress = mapper.Map<AddressModel, Address>(addressModel);
            transformedAddress.AddressId = addressId;
            _addressService.Update(transformedAddress);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetAddress", new {transformedAddress.AddressId}));
            return response;
        }

        // DELETE: api/AddressModel/5
        /// <summary>
        ///     DeleteAddress
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/Address/DeleteAddress/{addressId}", Name = "DeleteAddress")]
        public HttpResponseMessage DeleteAddress(int addressId)
        {
            var address = _addressService.GetById(addressId);
            _addressService.Delete(address);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }

        // DELETE: api/AddressModel/5
        /// <summary>
        ///     DeleteAddresses
        /// </summary>
        /// <param name="addressModels"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/Address/DeleteAddresses", Name = "DeleteAddresses")]
        public HttpResponseMessage DeleteAddresses(List<AddressModel> addressModels)
        {
            var addresses = new List<Address>();

            var addressssss = TransferAddressData.ConvertModelsToAddresses(addressModels);
            foreach (var addressModel in addressModels)
            {
                var address = new Address
                {
                    AddressId = addressModel.AddressId,
                    Address1 = addressModel.Address1,
                    Address2 = addressModel.Address2,
                    City = addressModel.City,
                    StateCode = addressModel.StateCode,
                    ZipCode = addressModel.ZipCode,
                    ModifiedBy = addressModel.ModifiedBy,
                    ModifiedDate = addressModel.ModifiedDate,
                    CreatedDate = addressModel.CreatedDate
                };
                addresses.Add(address);
            }
            _addressService.RemoveRange(addresses);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}