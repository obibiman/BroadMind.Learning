using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using BroadMind.Common.Domain;
using BroadMind.Common.Domain.Admin;
using BroadMind.DataAccess.Mapping;

namespace BroadMind.DataAccess.Context
{
    public class CollegeContext : DbContext
    {
        public CollegeContext() : base("name=CollegeContext")
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Telephone> Telephones { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<FinancialAid> FinancialAids { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Telephones);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Semesters);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Courses);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments);

            modelBuilder.Entity<Enrollment>()
                .HasMany(s => s.Students);

            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.Course);

            modelBuilder.Entity<Department>()
                .HasMany(u => u.Courses);

            modelBuilder.Entity<Department>()
               .HasMany(u => u.Courses)
               .WithRequired()
               .HasForeignKey(h => h.DepartmentId);

            modelBuilder.Entity<Course>()
                .HasRequired(e => e.Department);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Telephones)
                .WithRequired(s => s.Student)
                .HasForeignKey(s => s.TelephoneId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Semesters)
                .WithRequired(s => s.Student)
                .HasForeignKey(s => s.SemesterId);

            modelBuilder.Entity<Course>()
                .HasMany(u => u.Students);

            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new CourseMap());
            modelBuilder.Configurations.Add(new EnrollmentMap());
            modelBuilder.Configurations.Add(new MajorMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new TelephoneMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new FinancialAidMap());
            modelBuilder.Configurations.Add(new SemesterMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}