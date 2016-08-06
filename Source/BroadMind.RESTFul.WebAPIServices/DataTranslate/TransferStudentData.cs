using System.Collections.Generic;
using BroadMind.Common.Domain;
using BroadMind.Common.Domain.Admin;
using BroadMind.Common.Enumerate;
using BroadMind.RESTFul.WebAPIServices.Models;

namespace BroadMind.RESTFul.WebAPIServices.DataTranslate
{
    public class TransferStudentData
    {
        public static Student ConvertStudentModel(StudentModel studentModel)
        {
            var student = new Student
            {
                StudentId = studentModel.StudentId,
                AccruedCredit = studentModel.HoursAccrued,
                Address = TransferAddressData.ConvertAddressModel(studentModel.AddressModel),
                DateOfBirth = studentModel.DateOfBirth,
                Email = studentModel.Email,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                MiddleName = studentModel.MiddleName,
                Enrollments = TransferEnrollmentData.ConvertEnrollmentModels(studentModel.EnrollmentModels),
                Courses = (ICollection<Course>) TransferCourseData.ConvertCourseModels(studentModel.CourseModels),
                FullName = studentModel.FullName,
                Gender = (Gender) studentModel.Gender,
                InitialEnrollmentDate = studentModel.InitialEnrollmentDate,
                Semesters = TransferSemesterData.ConvertSemesterModels(studentModel.SemesterModels),
                Major = TransferMajorData.ConvertMajorModel(studentModel.MajorModel),
                Telephones = TransferTelephoneData.ConvertTelephoneModels(studentModel.TelephoneModels)
            };

            return student;
        }

        public static StudentModel ConvertStudentToModel(Student student)
        {
            var studentModel = new StudentModel
            {
                StudentId = student.StudentId,
                AccruedCredit = student.AccruedCredit,
                AddressModel = TransferAddressData.ConvertAddressToModel(student.Address),
                DateOfBirth = student.DateOfBirth,
                Email = student.Email,
                FirstName = student.FirstName,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                EnrollmentModels = TransferEnrollmentData.ConvertEnrollmentsToModels(student.Enrollments),
                CourseModels = TransferCourseData.ConvertCourseToModels(student.Courses),
                FullName = student.FullName,
                Gender = (Enumerate.Gender) student.Gender,
                InitialEnrollmentDate = student.InitialEnrollmentDate,
                SemesterModels = TransferSemesterData.ConvertSemestersToModels(student.Semesters),
                MajorModel = TransferMajorData.ConvertMajorToModel(student.Major),
                TelephoneModels = TransferTelephoneData.ConvertTelephonesToModels(student.Telephones)
            };
            return studentModel;
        }

        public static ICollection<StudentModel> ConvertStudentsToModels(IEnumerable<Student> students)
        {
            var studentModels = new List<StudentModel>();
            foreach (var student in students)
            {
                var sm = ConvertStudentToModel(student);
                studentModels.Add(sm);
            }
            return studentModels;
        }

        public static ICollection<Student> ConvertStudentModels(ICollection<StudentModel> studentsModels)
        {
            var students = new List<Student>();
            foreach (var studentModel in studentsModels)
            {
                var student = new Student
                {
                    StudentId = studentModel.StudentId,
                    AccruedCredit = studentModel.HoursAccrued,
                    Address = TransferAddressData.ConvertAddressModel(studentModel.AddressModel),
                    DateOfBirth = studentModel.DateOfBirth,
                    Email = studentModel.Email,
                    FirstName = studentModel.FirstName,
                    LastName = studentModel.LastName,
                    MiddleName = studentModel.MiddleName,
                    Enrollments = TransferEnrollmentData.ConvertEnrollmentModels(studentModel.EnrollmentModels),
                    Courses = (ICollection<Course>) TransferCourseData.ConvertCourseModels(studentModel.CourseModels),
                    FullName = studentModel.FullName,
                    Gender = (Gender) studentModel.Gender,
                    InitialEnrollmentDate = studentModel.InitialEnrollmentDate,
                    Semesters = TransferSemesterData.ConvertSemesterModels(studentModel.SemesterModels),
                    Major = TransferMajorData.ConvertMajorModel(studentModel.MajorModel),
                    Telephones = TransferTelephoneData.ConvertTelephoneModels(studentModel.TelephoneModels)
                };

                students.Add(student);
            }
            return students;
        }
    }
}