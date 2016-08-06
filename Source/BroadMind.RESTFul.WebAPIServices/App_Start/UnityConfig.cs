using System.Web.Http;
using BroadMind.Business.Concrete;
using BroadMind.Business.Interfaces;
using BroadMind.DataAccess.UnitOfWork.Concrete;
using BroadMind.DataAccess.UnitOfWork.Interfaces;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace BroadMind.RESTFul.WebAPIServices
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container
                .RegisterType<IUnitOfWork, UnitOfWork>()
                .RegisterType<ICourseService, CourseService>()
                .RegisterType<IDepartmentService, DepartmentService>()
                .RegisterType<IMajorService, MajorService>()
                .RegisterType<IStateService, StateService>()
                .RegisterType<IAddressService, AddressService>()
                .RegisterType<IEnrollmentService, EnrollmentService>()
                .RegisterType<IStudentService, StudentService>()
                .RegisterType<ITelephoneService, TelephoneService>()
                .RegisterType<IFinancialAidService, FinancialAidService>()
                .RegisterType<ISemesterService, SemesterService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}