using System.Collections.Generic;
using System.Linq;
using BroadMind.Common.Domain;
using BroadMind.RESTFul.WebAPIServices.Models;

namespace BroadMind.RESTFul.WebAPIServices.DataTranslate
{
    public class TransferAddressData
    {
        public static AddressModel ConvertAddressToModel(Address address)
        {
            var addressModel = new AddressModel
            {
                Address1 = address.Address1,
                Address2 = address.Address2,
                AddressId = address.AddressId,
                ModifiedBy = address.ModifiedBy,
                ModifiedDate = address.ModifiedDate,
                CreatedDate = address.CreatedDate,
                City = address.City,
                StateCode = address.StateCode,
                ZipCode = address.ZipCode,
                Country = address.Country
            };
            return addressModel;
        }

        public static Address ConvertAddressModel(AddressModel addressModel)
        {
            var address = new Address
            {
                Address1 = addressModel.Address1,
                Address2 = addressModel.Address2,
                AddressId = addressModel.AddressId,
                City = addressModel.City,
                StateCode = addressModel.StateCode,
                ZipCode = addressModel.ZipCode,
                Country = addressModel.Country
            };
            return address;
        }

        public static IEnumerable<AddressModel> ConvertAddressesToModels(IEnumerable<Address> addresses)
        {
            return addresses.Select(address => new AddressModel
            {
                Address1 = address.Address1,
                Address2 = address.Address2,
                AddressId = address.AddressId,
                City = address.City,
                StateCode = address.StateCode,
                ZipCode = address.ZipCode,
                Country = address.Country
            }).ToList();
        }

        public static IEnumerable<Address> ConvertModelsToAddresses(IEnumerable<AddressModel> addressModels)
        {
            return addressModels.Select(addressModel => new Address
            {
                Address1 = addressModel.Address1,
                Address2 = addressModel.Address2,
                AddressId = addressModel.AddressId,
                City = addressModel.City,
                StateCode = addressModel.StateCode,
                ZipCode = addressModel.ZipCode,
                Country = addressModel.Country
            }).ToList();
        }
    }
}