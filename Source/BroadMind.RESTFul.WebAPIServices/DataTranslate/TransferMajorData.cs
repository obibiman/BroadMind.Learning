using BroadMind.Common.Domain.Admin;
using BroadMind.RESTFul.WebAPIServices.Models.Admin;

namespace BroadMind.RESTFul.WebAPIServices.DataTranslate
{
    public class TransferMajorData
    {
        public static MajorModel ConvertMajorToModel(Major major)
        {
            var majorModel = new MajorModel
            {
                MajorId = major.MajorId,
                MajorName = major.MajorName,
                MajorDescription = major.MajorDescription,
                ModifiedBy = major.ModifiedBy,
                ModifiedDate = major.ModifiedDate
            };
            return majorModel;
        }

        public static Major ConvertMajorModel(MajorModel majorModel)
        {
            var major = new Major
            {
                MajorId = majorModel.MajorId,
                MajorName = majorModel.MajorName,
                MajorDescription = majorModel.MajorDescription,
                ModifiedBy = majorModel.ModifiedBy,
                ModifiedDate = majorModel.ModifiedDate
            };
            return major;
        }
    }
}