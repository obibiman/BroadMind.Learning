using System.Collections.Generic;
using BroadMind.Common.Domain;
using BroadMind.Common.Enumerate;
using BroadMind.RESTFul.WebAPIServices.Models;

namespace BroadMind.RESTFul.WebAPIServices.DataTranslate
{
    public class TransferTelephoneData
    {
        public static ICollection<Telephone> ConvertTelephoneModels(IEnumerable<TelephoneModel> telephoneModels)
        {
            var telephones = new List<Telephone>();
            foreach (var telephoneModel in telephoneModels)
            {
                var telephone = new Telephone
                {
                    TelephoneId = telephoneModel.TelephoneId,
                    AreaCode = telephoneModel.AreaCode,
                    Extension = telephoneModel.Extension,
                    LineNumber = telephoneModel.LineNumber,
                    Prefix = telephoneModel.Prefix,
                    PhoneType = (PhoneType) telephoneModel.PhoneType
                };
                telephone.TelephoneNumber = telephone.TelephoneNumber;
                telephone.Student = telephone.Student;
                telephones.Add(telephone);
            }
            return telephones;
        }

        public static ICollection<TelephoneModel> ConvertTelephonesToModels(ICollection<Telephone> telephones)
        {
            var telephoneModels = new List<TelephoneModel>();
            foreach (var telephone in telephones)
            {
                var telephoneModel = new TelephoneModel
                {
                    TelephoneId = telephone.TelephoneId,
                    AreaCode = telephone.AreaCode,
                    Prefix = telephone.Prefix,
                    PhoneType = (Enumerate.PhoneType) telephone.PhoneType,
                    Extension = telephone.Extension,
                    CreatedDate = telephone.CreatedDate,
                    ModifiedBy = telephone.ModifiedBy,
                    ModifiedDate = telephone.ModifiedDate,
                    StudentId = telephone.StudentId,
                    StudentModel = TransferStudentData.ConvertStudentToModel(telephone.Student)
                };
                telephoneModels.Add(telephoneModel);
            }
            return telephoneModels;
        }
    }
}