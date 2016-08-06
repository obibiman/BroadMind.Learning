using System;
using System.Collections.Generic;
using BroadMind.Common.Base;
using BroadMind.Common.Domain.Admin;
using BroadMind.Common.Enumerate;

namespace BroadMind.Common.Domain
{
    public class Student : CommonBase
    {
        public Student()
        {
            Semesters = new List<Semester>();
            Telephones = new List<Telephone>();
            Enrollments = new List<Enrollment>();
            Courses = new List<Course>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public virtual Gender Gender { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime InitialEnrollmentDate { get; set; }
        public virtual Major Major { get; set; }
        public virtual ICollection<Semester> Semesters { get; set; }
        public virtual ICollection<Telephone> Telephones { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public int? AccruedCredit { get; set; }
        public virtual Address Address { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
            set
            {
                var names = value.Split(new[] {" "},
                    StringSplitOptions.RemoveEmptyEntries);
                FirstName = names[0];
                LastName = names[1];
            }
        }
    }
}