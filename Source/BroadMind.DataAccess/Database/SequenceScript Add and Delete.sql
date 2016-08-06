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

GO

var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Aberdeen\UmbrellaTree.School\BroadMind.DataAccess\Database\SequenceSelectionCreateStoredProcedureScript.sql"); 
Sql(File.ReadAllText(sqlFile));




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
GO

var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Aberdeen\UmbrellaTree.School\BroadMind.DataAccess\Database\SequenceSelectionDropStoredProcedureScript.sql"); 
Sql(File.ReadAllText(sqlFile));

