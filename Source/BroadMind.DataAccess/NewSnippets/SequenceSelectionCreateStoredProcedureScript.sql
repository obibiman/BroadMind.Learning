CREATE PROCEDURE [dbo].[sp_CollegeWebAPISequence]
@SequenceName nvarchar(50),  
@SequenceValue INT OUTPUT
AS  

IF @SequenceName IS NULL
   BEGIN
       PRINT 'ERROR: You must specify a sequence name to execute.'
       RETURN(1)
   END
ELSE
	BEGIN
		IF @SequenceName = 'AddressSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.AddressSequence;
		IF @SequenceName = 'StateSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.StateSequence;		
		IF @SequenceName = 'CourseSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.CourseSequence;		
		IF @SequenceName = 'DepartmentSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.DepartmentSequence;	
		IF @SequenceName = 'EnrollmentSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.EnrollmentSequence;		
		IF @SequenceName = 'MajorSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.MajorSequence;	
		IF @SequenceName = 'StudentSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.StudentSequence;	
		IF @SequenceName = 'TelephoneSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.TelephoneSequence;	
		IF @SequenceName = 'FinancialAidSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.FinancialAidSequence;	
		IF @SequenceName = 'SemesterSequence'
			SELECT @SequenceValue = NEXT VALUE FOR dbo.SemesterSequence;	
			
	END
SELECT @SequenceValue