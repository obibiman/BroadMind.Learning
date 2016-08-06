using System.Collections.Generic;
using BroadMind.Common.Domain;
using BroadMind.RESTFul.WebAPIServices.Models;

namespace BroadMind.RESTFul.WebAPIServices.DataTranslate
{
    public class TransferSemesterData
    {
        public static ICollection<SemesterModel> ConvertSemestersToModels(ICollection<Semester> semesters)
        {
            var lst = new List<SemesterModel>();
            foreach (var semester in semesters)
            {
                var semesterModel = new SemesterModel
                {
                    SemesterId = semester.SemesterId,
                    AcademicYear = semester.AcademicYear,
                    CalendarYear = semester.CalendarYear,
                    StudentId = semester.StudentId,
                    SemesterName = semester.SemesterName,
                    Student = TransferStudentData.ConvertStudentToModel(semester.Student),
                    CreatedDate = semester.CreatedDate,
                    ModifiedBy = semester.ModifiedBy,
                    ModifiedDate = semester.ModifiedDate
                };
                lst.Add(semesterModel);
            }
            return lst;
        }

        public static ICollection<Semester> ConvertSemesterModels(IEnumerable<SemesterModel> semesterModels)
        {
            var sm = new List<Semester>();
            foreach (var semesterModel in semesterModels)
            {
                var semester = new Semester
                {
                    SemesterId = semesterModel.SemesterId,
                    AcademicYear = semesterModel.AcademicYear,
                    CalendarYear = semesterModel.CalendarYear,
                    StudentId = semesterModel.StudentId,
                    SemesterName = semesterModel.SemesterName,
                    Student = TransferStudentData.ConvertStudentModel(semesterModel.Student),
                    CreatedDate = semesterModel.CreatedDate,
                    ModifiedBy = semesterModel.ModifiedBy,
                    ModifiedDate = semesterModel.ModifiedDate
                };
                semester.StudentId = semesterModel.StudentId;
                sm.Add(semester);
            }
            return sm;
        }
    }
}