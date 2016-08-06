CREATE View [dbo].[vw_GetStudentCourse]

AS  

SELECT c.CourseId, c.CourseName, s.StudentId, s.LastName, s.FirstName, s.MiddleName, s.AccruedCredit, c.Description
FROM     Course c INNER JOIN
                  CourseStudent cs ON c.CourseId = cs.Course_CourseId INNER JOIN
                  Student s ON cs.Student_StudentId = s.StudentId
				  WHERE c.CourseName= @CourseName