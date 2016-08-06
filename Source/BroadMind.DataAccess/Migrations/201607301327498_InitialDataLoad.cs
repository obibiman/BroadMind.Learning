using System.IO;

namespace BroadMind.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDataLoad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false),
                        Address1 = c.String(nullable: false, maxLength: 150),
                        Adress2 = c.String(maxLength: 150),
                        City = c.String(nullable: false, maxLength: 100),
                        ZipCode = c.String(nullable: false, maxLength: 10),
                        CreatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        StateCode = c.String(nullable: false, maxLength: 2),
                        Country = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        CourseName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 250),
                        Credit = c.Int(),
                        CreatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        Department_DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Department", t => t.Department_DepartmentId, cascadeDelete: true)
                .Index(t => t.CourseName, unique: true, name: "IX_Course_CourseName")
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false),
                        DepartmentCode = c.String(nullable: false, maxLength: 10),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                        DepartmentDescription = c.String(nullable: false, maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .Index(t => t.DepartmentCode, unique: true, name: "IX_Department_DepartmentCode")
                .Index(t => t.DepartmentName, unique: true, name: "IX_Department_DepartmentName");
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(nullable: false, maxLength: 50),
                        Gender = c.Int(),
                        AccruedCredit = c.Int(),
                        InitialEnrollmentDate = c.DateTime(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Address_AddressId = c.Int(nullable: false),
                        Major_MajorId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Address", t => t.Address_AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Major", t => t.Major_MajorId)
                .Index(t => t.Address_AddressId)
                .Index(t => t.Major_MajorId);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        Course_CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentId)
                .ForeignKey("dbo.Course", t => t.Course_CourseId)
                .Index(t => t.Course_CourseId);
            
            CreateTable(
                "dbo.Major",
                c => new
                    {
                        MajorId = c.Int(nullable: false),
                        MajorName = c.String(nullable: false, maxLength: 50),
                        MajorDescription = c.String(nullable: false, maxLength: 200),
                        CreatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MajorId)
                .Index(t => t.MajorName, unique: true, name: "IX_Major_MajorName");
            
            CreateTable(
                "dbo.Semester",
                c => new
                    {
                        SemesterId = c.Int(nullable: false),
                        AcademicYear = c.String(nullable: false, maxLength: 20),
                        CalendarYear = c.String(nullable: false, maxLength: 20),
                        SemesterName = c.String(nullable: false, maxLength: 10),
                        CreatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SemesterId)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => new { t.AcademicYear, t.CalendarYear, t.SemesterName, t.StudentId }, unique: true, name: "IX_Semester_AcademicYearCalendarYearSemesterNameStudentId");
            
            CreateTable(
                "dbo.Telephone",
                c => new
                    {
                        TelephoneId = c.Int(nullable: false),
                        AreaCode = c.String(nullable: false, maxLength: 3),
                        Prefix = c.String(nullable: false, maxLength: 3),
                        LineNumber = c.String(nullable: false, maxLength: 4),
                        Extension = c.String(maxLength: 5),
                        PhoneType = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TelephoneId)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => new { t.AreaCode, t.Prefix, t.LineNumber }, unique: true, name: "IX_Telephone_AreaCodePrefixLineNumber")
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.FinancialAid",
                c => new
                    {
                        FinancialAidId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        OnTrack = c.Boolean(),
                        Classification = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.FinancialAidId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateId = c.Int(nullable: false),
                        StateCode = c.String(nullable: false, maxLength: 10),
                        StateName = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.StateId)
                .Index(t => new { t.StateCode, t.StateName }, unique: true, name: "IX_State_StateCodeStateName");
            
            CreateTable(
                "dbo.StudentEnrollment",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Enrollment_EnrollmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Enrollment_EnrollmentId })
                .ForeignKey("dbo.Student", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Enrollment", t => t.Enrollment_EnrollmentId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Enrollment_EnrollmentId);
            
            CreateTable(
                "dbo.CourseStudent",
                c => new
                    {
                        Course_CourseId = c.Int(nullable: false),
                        Student_StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_CourseId, t.Student_StudentId })
                .ForeignKey("dbo.Course", t => t.Course_CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.Student_StudentId, cascadeDelete: true)
                .Index(t => t.Course_CourseId)
                .Index(t => t.Student_StudentId);
            Sql("CREATE SEQUENCE [dbo].[StudentSequence] AS [int] START WITH 1000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 ");
            Sql("CREATE SEQUENCE [dbo].[TelephoneSequence]  AS [int] START WITH 2000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 ");
            Sql("CREATE SEQUENCE [dbo].[DepartmentSequence]  AS [int] START WITH 3000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 ");
            Sql("CREATE SEQUENCE [dbo].[MajorSequence]  AS [int] START WITH 4000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 ");
            Sql("CREATE SEQUENCE [dbo].[EnrollmentSequence]  AS [int] START WITH 5000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 ");
            Sql("CREATE SEQUENCE [dbo].[AddressSequence]  AS [int] START WITH 6000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 ");
            Sql("CREATE SEQUENCE [dbo].[CourseSequence]  AS [int] START WITH 7000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 ");
            Sql("CREATE SEQUENCE [dbo].[StateSequence]  AS [int] START WITH 8000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 ");
            Sql("CREATE SEQUENCE [dbo].[FinancialAidSequence]  AS [int] START WITH 9000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 ");
            Sql("CREATE SEQUENCE [dbo].[SemesterSequence]  AS [int] START WITH 1000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 ");

            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\AppsDev\DotNet\BroadMind.Learning\Source\BroadMind.DataAccess\NewSnippets\SequenceSelectionCreateStoredProcedureScript.sql");
            Sql(File.ReadAllText(sqlFile));

        }

        public override void Down()
        {
            DropForeignKey("dbo.CourseStudent", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.CourseStudent", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.Telephone", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Semester", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "Major_MajorId", "dbo.Major");
            DropForeignKey("dbo.StudentEnrollment", "Enrollment_EnrollmentId", "dbo.Enrollment");
            DropForeignKey("dbo.StudentEnrollment", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.Enrollment", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.Student", "Address_AddressId", "dbo.Address");
            DropForeignKey("dbo.Course", "Department_DepartmentId", "dbo.Department");
            DropIndex("dbo.CourseStudent", new[] { "Student_StudentId" });
            DropIndex("dbo.CourseStudent", new[] { "Course_CourseId" });
            DropIndex("dbo.StudentEnrollment", new[] { "Enrollment_EnrollmentId" });
            DropIndex("dbo.StudentEnrollment", new[] { "Student_StudentId" });
            DropIndex("dbo.State", "IX_State_StateCodeStateName");
            DropIndex("dbo.Telephone", new[] { "StudentId" });
            DropIndex("dbo.Telephone", "IX_Telephone_AreaCodePrefixLineNumber");
            DropIndex("dbo.Semester", "IX_Semester_AcademicYearCalendarYearSemesterNameStudentId");
            DropIndex("dbo.Major", "IX_Major_MajorName");
            DropIndex("dbo.Enrollment", new[] { "Course_CourseId" });
            DropIndex("dbo.Student", new[] { "Major_MajorId" });
            DropIndex("dbo.Student", new[] { "Address_AddressId" });
            DropIndex("dbo.Department", "IX_Department_DepartmentName");
            DropIndex("dbo.Department", "IX_Department_DepartmentCode");
            DropIndex("dbo.Course", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Course", "IX_Course_CourseName");
            DropTable("dbo.CourseStudent");
            DropTable("dbo.StudentEnrollment");
            DropTable("dbo.State");
            DropTable("dbo.FinancialAid");
            DropTable("dbo.Telephone");
            DropTable("dbo.Semester");
            DropTable("dbo.Major");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Student");
            DropTable("dbo.Department");
            DropTable("dbo.Course");
            DropTable("dbo.Address");

            Sql("DROP SEQUENCE [dbo].[StudentSequence] ");
            Sql("DROP SEQUENCE [dbo].[TelephoneSequence] ");
            Sql("DROP SEQUENCE [dbo].[DepartmentSequence] ");
            Sql("DROP SEQUENCE [dbo].[MajorSequence] ");
            Sql("DROP SEQUENCE [dbo].[EnrollmentSequence] ");
            Sql("DROP SEQUENCE [dbo].[AddressSequence] ");
            Sql("DROP SEQUENCE [dbo].[CourseSequence] ");
            Sql("DROP SEQUENCE [dbo].[StateSequence] ");
            Sql("DROP SEQUENCE [dbo].[FinancialAidSequence] ");
            Sql("DROP SEQUENCE [dbo].[SemesterSequence] ");

            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\AppsDev\DotNet\BroadMind.Learning\Source\BroadMind.DataAccess\NewSnippets\SequenceSelectionDropStoredProcedureScript.sql");
            Sql(File.ReadAllText(sqlFile));
        }
    }
}
