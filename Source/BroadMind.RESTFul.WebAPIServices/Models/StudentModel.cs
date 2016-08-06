using System;
using System.Collections.Generic;
using BroadMind.RESTFul.WebAPIServices.Enumerate;
using BroadMind.RESTFul.WebAPIServices.Models.Admin;

namespace BroadMind.RESTFul.WebAPIServices.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? AccruedCredit { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime InitialEnrollmentDate { get; set; }
        public MajorModel MajorModel { get; set; }
        public ICollection<TelephoneModel> TelephoneModels { get; set; }
        public ICollection<EnrollmentModel> EnrollmentModels { get; set; }
        public ICollection<SemesterModel> SemesterModels { get; set; }
        public ICollection<CourseModel> CourseModels { get; set; }
        public int HoursAccrued { get; set; }
        public AddressModel AddressModel { get; set; }

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