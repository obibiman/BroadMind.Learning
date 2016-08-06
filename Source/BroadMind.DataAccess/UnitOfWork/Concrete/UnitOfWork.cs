using BroadMind.Common.Domain;
using BroadMind.Common.Domain.Admin;
using BroadMind.DataAccess.Context;
using BroadMind.DataAccess.Repo.Concrete;
using BroadMind.DataAccess.Repo.Interfaces;
using BroadMind.DataAccess.UnitOfWork.Interfaces;

namespace BroadMind.DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CollegeContext _context;

        public UnitOfWork(CollegeContext context)
        {
            _context = context;
            AddressRepository = new AddressRepository(_context);
            CourseRepository = new CourseRepository(_context);
            EnrollmentRepository = new EnrollmentRepository(_context);
            MajorRepository = new MajorRepository(_context);
            StudentRepository = new StudentRepository(_context);
            TelephoneRepository = new TelephoneRepository(_context);
            DepartmentRepository = new DepartmentRepository(_context);
            StateRepository = new StateRepository(_context);
            FinancialAidRepository = new FinancialAidRepository(_context);
            SemesterRepository = new SemesterRepository(_context);

            Complete();
        }

        public IRepository<Address> AddressRepository { get; }
        public IRepository<Course> CourseRepository { get; }
        public IRepository<Enrollment> EnrollmentRepository { get; }
        public IRepository<Major> MajorRepository { get; }
        public IRepository<Student> StudentRepository { get; }
        public IRepository<Telephone> TelephoneRepository { get; }
        public IRepository<Department> DepartmentRepository { get; }
        public IRepository<State> StateRepository { get; }
        public IRepository<FinancialAid> FinancialAidRepository { get; }
        public IRepository<Semester> SemesterRepository { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}