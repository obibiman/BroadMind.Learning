using System.Collections.Generic;
using BroadMind.Common.Domain;
using BroadMind.RESTFul.WebAPIServices.Models;

namespace BroadMind.RESTFul.WebAPIServices.DataTranslate
{
    public class TransferEnrollmentData
    {
        public static ICollection<Enrollment> ConvertEnrollmentModels(IEnumerable<EnrollmentModel> enrollmentModels)
        {
            var enrollments = new List<Enrollment>();
            foreach (var enrollmentModel in enrollmentModels)
            {
                var enrollment = new Enrollment
                {
                    EnrollmentId = enrollmentModel.EnrollmentId,
                    Course = TransferCourseData.ConvertCourseModel(enrollmentModel.CourseModel),
                    Students = TransferStudentData.ConvertStudentModels(enrollmentModel.StudentsModel),
                    ModifiedBy = enrollmentModel.ModifiedBy,
                    //CourseId = enrollmentModel.CourseId,
                    ModifiedDate = enrollmentModel.ModifiedDate,
                    CreatedDate = enrollmentModel.CreatedDate
                };
                enrollments.Add(enrollment);
            }

            return enrollments;
        }

        public static ICollection<EnrollmentModel> ConvertEnrollmentsToModels(IEnumerable<Enrollment> enrollments)
        {
            var enrollmentModels = new List<EnrollmentModel>();
            foreach (var enrollment in enrollments)
            {
                var model = new EnrollmentModel
                {
                    EnrollmentId = enrollment.EnrollmentId,
                    ModifiedBy = enrollment.ModifiedBy,
                    CreatedDate = enrollment.CreatedDate,
                    //CourseId = enrollment.CourseId,
                    CourseModel =
                        enrollment.Course != null ? TransferCourseData.ConvertCourseToModel(enrollment.Course) : null,
                    StudentsModel =
                        enrollment.Students != null
                            ? TransferStudentData.ConvertStudentsToModels(enrollment.Students)
                            : null
                };
                enrollmentModels.Add(model);
            }
            return enrollmentModels;
        }
    }
}