using System.Collections.Generic;
using BroadMind.Common.Domain.Admin;
using BroadMind.RESTFul.WebAPIServices.Models.Admin;

namespace BroadMind.RESTFul.WebAPIServices.DataTranslate
{
    public class TransferCourseData
    {
        public static IEnumerable<Course> ConvertCourseModels(IEnumerable<CourseModel> courseModels)
        {
            var courses = new List<Course>();
            foreach (var courseModel in courseModels)
            {
                var course = new Course
                {
                    CourseId = courseModel.CourseId,
                    CourseName = courseModel.CourseName,
                    CreatedDate = courseModel.CreatedDate,
                    Credit = courseModel.Credit,
                    Students = TransferStudentData.ConvertStudentModels(courseModel.StudentModels),
                    Department = TransferDepartmentData.ConvertDepartmentModel(courseModel.DepartmentModel),
                    Description = courseModel.Description,
                    ModifiedBy = courseModel.ModifiedBy,
                    ModifiedDate = courseModel.ModifiedDate
                };
                courses.Add(course);
            }
            return courses;
        }


        public static ICollection<CourseModel> ConvertCourseToModels(IEnumerable<Course> courses)
        {
            var courseModels = new List<CourseModel>();
            foreach (var course in courses)
            {
                var courseModel = new CourseModel
                {
                    CourseId = course.CourseId,
                    CreatedDate = course.CreatedDate,
                    CourseName = course.CourseName,
                    Credit = course.Credit,
                    StudentModels = TransferStudentData.ConvertStudentsToModels(course.Students),
                    DepartmentModel = TransferDepartmentData.ConvertDepartmentToModel(course.Department),
                    Description = course.Description,
                    ModifiedDate = course.ModifiedDate,
                    ModifiedBy = course.ModifiedBy
                };
                courseModels.Add(courseModel);
            }
            return courseModels;
        }

        public static Course ConvertCourseModel(CourseModel courseModel)
        {
            var course = new Course
            {
                CourseId = courseModel.CourseId,
                CourseName = courseModel.CourseName,
                CreatedDate = courseModel.CreatedDate,
                Credit = courseModel.Credit,
                Students = TransferStudentData.ConvertStudentModels(courseModel.StudentModels),
                Department = TransferDepartmentData.ConvertDepartmentModel(courseModel.DepartmentModel),
                Description = courseModel.Description,
                ModifiedBy = courseModel.ModifiedBy,
                ModifiedDate = courseModel.ModifiedDate
            };
            return course;
        }

        public static CourseModel ConvertCourseToModel(Course course)
        {
            var courseModel = new CourseModel
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CreatedDate = course.CreatedDate,
                Credit = course.Credit,
                StudentModels = TransferStudentData.ConvertStudentsToModels(course.Students),
                DepartmentModel = TransferDepartmentData.ConvertDepartmentToModel(course.Department),
                Description = course.Description,
                ModifiedBy = course.ModifiedBy,
                ModifiedDate = course.ModifiedDate
            };
            return courseModel;
        }
    }
}