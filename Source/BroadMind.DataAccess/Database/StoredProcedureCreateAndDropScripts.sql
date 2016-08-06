var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Sandbox\Ulo.Akwukwo.Okporo\Akwukwo.SqlServer.DataAccess\Database\SequenceSelectionCreateStoredProcedureScript.sql"); 
Sql(File.ReadAllText(sqlFile));

var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"C:\Sandbox\Ulo.Akwukwo.Okporo\Akwukwo.SqlServer.DataAccess\Database\SequenceSelectionDropStoredProcedureScript.sql"); 
Sql(File.ReadAllText(sqlFile));