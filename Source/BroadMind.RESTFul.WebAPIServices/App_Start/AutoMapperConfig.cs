using AutoMapper;
using BroadMind.Common.Domain;
using BroadMind.Common.Domain.Admin;
using BroadMind.RESTFul.WebAPIServices.Models;
using BroadMind.RESTFul.WebAPIServices.Models.Admin;

namespace BroadMind.RESTFul.WebAPIServices
{
    public  class AutoMapperConfiguration
    {
        public static void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<State, StateModel>()
                    .ForMember(y => y.StateId, x => x.MapFrom(y => y.StateId))
                    .ForMember(y => y.StateCode, x => x.MapFrom(y => y.StateCode))
                    .ForMember(y => y.StateName, x => x.MapFrom(y => y.StateName))
                    .ForMember(y => y.ModifiedBy, x => x.MapFrom(y => y.ModifiedBy))
                    .ForMember(y => y.ModifiedDate, x => x.MapFrom(y => y.ModifiedDate))
                    .ForMember(y => y.CreatedDate, x => x.MapFrom(y => y.CreatedDate));
                cfg.CreateMap<Student, StudentModel>();
                
                cfg.CreateMap<Course, CourseModel>();
                cfg.CreateMap<Department, DepartmentModel>();
                cfg.CreateMap<Semester, SemesterModel>();
                cfg.CreateMap<FinancialAid, FinancialAidModel>();
                cfg.CreateMap<Address, AddressModel>();
                cfg.CreateMap<Enrollment, EnrollmentModel>();
                cfg.CreateMap<Telephone, TelephoneModel>();
                cfg.CreateMap<Major, Major>();
            });

            IMapper mapper = config.CreateMapper();
            var state = new State();
            var dest = mapper.Map<State, StateModel>(state);
        }
    }
}