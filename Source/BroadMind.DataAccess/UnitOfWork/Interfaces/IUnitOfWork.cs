using System;
using BroadMind.Common.Domain;
using BroadMind.Common.Domain.Admin;
using BroadMind.DataAccess.Repo.Interfaces;

namespace BroadMind.DataAccess.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Address> AddressRepository { get; }
        IRepository<Course> CourseRepository { get; }
        IRepository<Enrollment> EnrollmentRepository { get; }
        IRepository<Major> MajorRepository { get; }
        IRepository<Student> StudentRepository { get; }
        IRepository<Semester> SemesterRepository { get; }
        IRepository<Telephone> TelephoneRepository { get; }
        IRepository<Department> DepartmentRepository { get; }
        IRepository<State> StateRepository { get; }
        IRepository<FinancialAid> FinancialAidRepository { get; }
        int Complete();
    }
}