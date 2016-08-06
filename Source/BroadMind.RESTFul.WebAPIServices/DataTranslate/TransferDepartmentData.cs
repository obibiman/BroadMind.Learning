using System.Collections.Generic;
using BroadMind.Common.Domain.Admin;
using BroadMind.RESTFul.WebAPIServices.Models.Admin;

namespace BroadMind.RESTFul.WebAPIServices.DataTranslate
{
    public class TransferDepartmentData
    {
        public static Department ConvertDepartmentModel(DepartmentModel departmentModel)
        {
            var department = new Department
            {
                DepartmentId = departmentModel.DepartmentId,
                DepartmentCode = departmentModel.DepartmentCode,
                DepartmentDescription = departmentModel.DepartmentDescription,
                DepartmentName = departmentModel.DepartmentName,
                Courses = (ICollection<Course>) TransferCourseData.ConvertCourseModels(departmentModel.CourseModels),
                CreatedDate = departmentModel.CreatedDate,
                ModifiedBy = departmentModel.ModifiedBy,
                ModifiedDate = departmentModel.ModifiedDate
            };
            return department;
        }

        public static IEnumerable<DepartmentModel> ConvertDepartmentsToModels(IEnumerable<Department> departments)
        {
            var departmentModels = new List<DepartmentModel>();
            foreach (var department in departments)
            {
                var departmentModel = new DepartmentModel
                {
                    DepartmentId = department.DepartmentId,
                    CreatedDate = department.CreatedDate,
                    DepartmentCode = department.DepartmentCode,
                    DepartmentName = department.DepartmentName,
                    DepartmentDescription = department.DepartmentDescription,
                    ModifiedBy = department.ModifiedBy,
                    ModifiedDate = department.ModifiedDate,
                    CourseModels = TransferCourseData.ConvertCourseToModels(department.Courses)
                };
                departmentModels.Add(departmentModel);
            }
            return departmentModels;
        }


        public static DepartmentModel ConvertDepartmentToModel(Department department)
        {
            var departmentModel = new DepartmentModel
            {
                DepartmentId = department.DepartmentId,
                CreatedDate = department.CreatedDate,
                DepartmentCode = department.DepartmentCode,
                DepartmentName = department.DepartmentName,
                DepartmentDescription = department.DepartmentDescription,
                ModifiedBy = department.ModifiedBy,
                ModifiedDate = department.ModifiedDate,
                CourseModels = TransferCourseData.ConvertCourseToModels(department.Courses)
            };
            return departmentModel;
        }

        public static IEnumerable<CourseModel> ConvertCoursesToModels(IEnumerable<Course> courses)
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
                    Description = course.Description,
                    ModifiedDate = course.ModifiedDate,
                    ModifiedBy = course.ModifiedBy
                };
                courseModels.Add(courseModel);
            }
            return courseModels;
        }
    }
}