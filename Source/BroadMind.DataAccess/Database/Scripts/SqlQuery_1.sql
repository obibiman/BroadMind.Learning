﻿CREATE TABLE [dbo].[Address] (
    [AddressId] [int] NOT NULL,
    [Address1] [nvarchar](150) NOT NULL,
    [Adress2] [nvarchar](150),
    [City] [nvarchar](100) NOT NULL,
    [ZipCode] [nvarchar](10) NOT NULL,
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [ModifiedDate] [datetime],
    [ModifiedBy] [nvarchar](50),
    [StateCode] [nvarchar](2) NOT NULL,
    [Country] [nvarchar](25),
    CONSTRAINT [PK_dbo.Address] PRIMARY KEY ([AddressId])
)
CREATE TABLE [dbo].[Course] (
    [CourseId] [int] NOT NULL,
    [CourseName] [nvarchar](50) NOT NULL,
    [Description] [nvarchar](250) NOT NULL,
    [Credit] [int],
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [ModifiedDate] [datetime],
    [ModifiedBy] [nvarchar](50),
    [Department_DepartmentId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Course] PRIMARY KEY ([CourseId])
)
CREATE UNIQUE INDEX [IX_Course_CourseName] ON [dbo].[Course]([CourseName])
CREATE INDEX [IX_Department_DepartmentId] ON [dbo].[Course]([Department_DepartmentId])
CREATE TABLE [dbo].[Department] (
    [DepartmentId] [int] NOT NULL,
    [DepartmentCode] [nvarchar](10) NOT NULL,
    [DepartmentName] [nvarchar](50) NOT NULL,
    [DepartmentDescription] [nvarchar](250) NOT NULL,
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [ModifiedDate] [datetime],
    [ModifiedBy] [nvarchar](50),
    CONSTRAINT [PK_dbo.Department] PRIMARY KEY ([DepartmentId])
)
CREATE UNIQUE INDEX [IX_Department_DepartmentCode] ON [dbo].[Department]([DepartmentCode])
CREATE UNIQUE INDEX [IX_Department_DepartmentName] ON [dbo].[Department]([DepartmentName])
CREATE TABLE [dbo].[Student] (
    [StudentId] [int] NOT NULL,
    [FirstName] [nvarchar](50) NOT NULL,
    [MiddleName] [nvarchar](50) NOT NULL,
    [Gender] [int],
    [AccruedCredit] [int],
    [InitialEnrollmentDate] [datetime] NOT NULL,
    [DateOfBirth] [datetime] NOT NULL,
    [Email] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [ModifiedDate] [datetime],
    [ModifiedBy] [nvarchar](50),
    [LastName] [nvarchar](50) NOT NULL,
    [Address_AddressId] [int] NOT NULL,
    [Major_MajorId] [int],
    CONSTRAINT [PK_dbo.Student] PRIMARY KEY ([StudentId])
)
CREATE INDEX [IX_Address_AddressId] ON [dbo].[Student]([Address_AddressId])
CREATE INDEX [IX_Major_MajorId] ON [dbo].[Student]([Major_MajorId])
CREATE TABLE [dbo].[Enrollment] (
    [EnrollmentId] [int] NOT NULL,
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [ModifiedDate] [datetime],
    [ModifiedBy] [nvarchar](50),
    [Course_CourseId] [int],
    CONSTRAINT [PK_dbo.Enrollment] PRIMARY KEY ([EnrollmentId])
)
CREATE INDEX [IX_Course_CourseId] ON [dbo].[Enrollment]([Course_CourseId])
CREATE TABLE [dbo].[Major] (
    [MajorId] [int] NOT NULL,
    [MajorName] [nvarchar](50) NOT NULL,
    [MajorDescription] [nvarchar](200) NOT NULL,
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [ModifiedDate] [datetime],
    [ModifiedBy] [nvarchar](50),
    CONSTRAINT [PK_dbo.Major] PRIMARY KEY ([MajorId])
)
CREATE UNIQUE INDEX [IX_Major_MajorName] ON [dbo].[Major]([MajorName])
CREATE TABLE [dbo].[Semester] (
    [SemesterId] [int] NOT NULL,
    [AcademicYear] [nvarchar](20) NOT NULL,
    [CalendarYear] [nvarchar](20) NOT NULL,
    [SemesterName] [nvarchar](10) NOT NULL,
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [ModifiedDate] [datetime],
    [ModifiedBy] [nvarchar](50),
    [StudentId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Semester] PRIMARY KEY ([SemesterId])
)
CREATE UNIQUE INDEX [IX_Semester_AcademicYearCalendarYearSemesterNameStudentId] ON [dbo].[Semester]([AcademicYear], [CalendarYear], [SemesterName], [StudentId])
CREATE TABLE [dbo].[Telephone] (
    [TelephoneId] [int] NOT NULL,
    [AreaCode] [nvarchar](3) NOT NULL,
    [Prefix] [nvarchar](3) NOT NULL,
    [LineNumber] [nvarchar](4) NOT NULL,
    [Extension] [nvarchar](5),
    [PhoneType] [int] NOT NULL,
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [ModifiedDate] [datetime],
    [ModifiedBy] [nvarchar](50),
    [StudentId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Telephone] PRIMARY KEY ([TelephoneId])
)
CREATE UNIQUE INDEX [IX_Telephone_AreaCodePrefixLineNumber] ON [dbo].[Telephone]([AreaCode], [Prefix], [LineNumber])
CREATE INDEX [IX_StudentId] ON [dbo].[Telephone]([StudentId])
CREATE TABLE [dbo].[FinancialAid] (
    [FinancialAidId] [int] NOT NULL,
    [FirstName] [nvarchar](50) NOT NULL,
    [MiddleName] [nvarchar](50),
    [LastName] [nvarchar](50) NOT NULL,
    [Amount] [decimal](18, 2),
    [OnTrack] [bit],
    [Classification] [nvarchar](50),
    CONSTRAINT [PK_dbo.FinancialAid] PRIMARY KEY ([FinancialAidId])
)
CREATE TABLE [dbo].[State] (
    [StateId] [int] NOT NULL,
    [StateCode] [nvarchar](10) NOT NULL,
    [StateName] [nvarchar](50) NOT NULL,
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [ModifiedDate] [datetime],
    [ModifiedBy] [nvarchar](50),
    CONSTRAINT [PK_dbo.State] PRIMARY KEY ([StateId])
)
CREATE UNIQUE INDEX [IX_State_StateCodeStateName] ON [dbo].[State]([StateCode], [StateName])
CREATE TABLE [dbo].[StudentEnrollment] (
    [Student_StudentId] [int] NOT NULL,
    [Enrollment_EnrollmentId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.StudentEnrollment] PRIMARY KEY ([Student_StudentId], [Enrollment_EnrollmentId])
)
CREATE INDEX [IX_Student_StudentId] ON [dbo].[StudentEnrollment]([Student_StudentId])
CREATE INDEX [IX_Enrollment_EnrollmentId] ON [dbo].[StudentEnrollment]([Enrollment_EnrollmentId])
CREATE TABLE [dbo].[CourseStudent] (
    [Course_CourseId] [int] NOT NULL,
    [Student_StudentId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CourseStudent] PRIMARY KEY ([Course_CourseId], [Student_StudentId])
)
CREATE INDEX [IX_Course_CourseId] ON [dbo].[CourseStudent]([Course_CourseId])
CREATE INDEX [IX_Student_StudentId] ON [dbo].[CourseStudent]([Student_StudentId])
CREATE SEQUENCE [dbo].[StudentSequence] AS [int] START WITH 1000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 
CREATE SEQUENCE [dbo].[TelephoneSequence]  AS [int] START WITH 2000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 
CREATE SEQUENCE [dbo].[DepartmentSequence]  AS [int] START WITH 3000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 
CREATE SEQUENCE [dbo].[MajorSequence]  AS [int] START WITH 4000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 
CREATE SEQUENCE [dbo].[EnrollmentSequence]  AS [int] START WITH 5000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 
CREATE SEQUENCE [dbo].[AddressSequence]  AS [int] START WITH 6000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 
CREATE SEQUENCE [dbo].[CourseSequence]  AS [int] START WITH 7000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 
CREATE SEQUENCE [dbo].[StateSequence]  AS [int] START WITH 8000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 
CREATE SEQUENCE [dbo].[FinancialAidSequence]  AS [int] START WITH 9000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 
CREATE SEQUENCE [dbo].[SemesterSequence]  AS [int] START WITH 1000000 INCREMENT BY 1 MINVALUE -2147483648 MAXVALUE 2147483647 
GO

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
ALTER TABLE [dbo].[Course] ADD CONSTRAINT [FK_dbo.Course_dbo.Department_Department_DepartmentId] FOREIGN KEY ([Department_DepartmentId]) REFERENCES [dbo].[Department] ([DepartmentId]) ON DELETE CASCADE
ALTER TABLE [dbo].[Student] ADD CONSTRAINT [FK_dbo.Student_dbo.Address_Address_AddressId] FOREIGN KEY ([Address_AddressId]) REFERENCES [dbo].[Address] ([AddressId]) ON DELETE CASCADE
ALTER TABLE [dbo].[Student] ADD CONSTRAINT [FK_dbo.Student_dbo.Major_Major_MajorId] FOREIGN KEY ([Major_MajorId]) REFERENCES [dbo].[Major] ([MajorId])
ALTER TABLE [dbo].[Enrollment] ADD CONSTRAINT [FK_dbo.Enrollment_dbo.Course_Course_CourseId] FOREIGN KEY ([Course_CourseId]) REFERENCES [dbo].[Course] ([CourseId])
ALTER TABLE [dbo].[Semester] ADD CONSTRAINT [FK_dbo.Semester_dbo.Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([StudentId]) ON DELETE CASCADE
ALTER TABLE [dbo].[Telephone] ADD CONSTRAINT [FK_dbo.Telephone_dbo.Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([StudentId]) ON DELETE CASCADE
ALTER TABLE [dbo].[StudentEnrollment] ADD CONSTRAINT [FK_dbo.StudentEnrollment_dbo.Student_Student_StudentId] FOREIGN KEY ([Student_StudentId]) REFERENCES [dbo].[Student] ([StudentId]) ON DELETE CASCADE
ALTER TABLE [dbo].[StudentEnrollment] ADD CONSTRAINT [FK_dbo.StudentEnrollment_dbo.Enrollment_Enrollment_EnrollmentId] FOREIGN KEY ([Enrollment_EnrollmentId]) REFERENCES [dbo].[Enrollment] ([EnrollmentId]) ON DELETE CASCADE
ALTER TABLE [dbo].[CourseStudent] ADD CONSTRAINT [FK_dbo.CourseStudent_dbo.Course_Course_CourseId] FOREIGN KEY ([Course_CourseId]) REFERENCES [dbo].[Course] ([CourseId]) ON DELETE CASCADE
ALTER TABLE [dbo].[CourseStudent] ADD CONSTRAINT [FK_dbo.CourseStudent_dbo.Student_Student_StudentId] FOREIGN KEY ([Student_StudentId]) REFERENCES [dbo].[Student] ([StudentId]) ON DELETE CASCADE
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201607261440022_InitialDataLoad', N'BroadMind.DataAccess.Migrations.Configuration',  0x1F8B0800000000000400ED1D6B6FDCB8F17B81FE87C57E2C52AFEDF4806B60DFC171E283D1380EB2CEA1ED97052DD16BF5F4D893B4A98DA2BFAC1FFA93FA174AAD248AAFE16BF5F039C601392F450E87C399E17048CEFCEF3FFF3DF9F12189675F715E44597A3A3F3A389CCF701A646194AE4FE7DBF2EE8FDFCF7FFCE1F7BF3B791F260FB39FDB7AAFAB7AA4655A9CCEEFCB72F366B128827B9CA0E22089823C2BB2BBF220C892050AB3C5F1E1E19F1747470B4C40CC09ACD9ECE4F3362DA304EF7E909FE7591AE04DB945F15516E2B868CAC997E50EEAEC234A70B141013E9D93922C8BFF99E5BF1CBC43253A0B025C14070442891FCAF9EC2C8E10416A89E3BBF90CA56956A292A0FCE64B8197659EA5EBE58614A0F8E6718349BD3B1417B819CA9BAEBAEDA80E8FAB512DBA862DA8605B9459E208F0E87543A685D8DC8BD8734A4642C8F784E0E56335EA1D314FE767619813CACD67625F6FCEE3BCAAC791FA3C4B922C3D78472A46E941D3F6D54CAAF18AF20861A5EABF57B3F36D5C6E737C9AE26D99A3F8D5ECD3F6368E82BFE0C79BEC179C9EA6DB38665125C8926F5C0129FA94671B9C978F9FF11D3F80CB703E5BF0CD17627BDA5A6E5A8FF4322D5F1FCF671F092AE836C6942F18AA2CCB2CC73FE114E7A8C4E12754963827D3FA314BB18480BABBA3B637C28844BCE6B32BF4F001A7EBF29E08DE7744A02EA2071CB6250D065FD28848236954E65BACC0D0AAE7E31E7AD677744E984BD7C9E120C35B92B9C1E7A4BDA6EBE3213AFE7BB431747B34C880CF33A238731DA58FBFEB6336735C3139D1AF7488D5DF3744653BA34C347A741741C0ECDABED58DD8837F4F169D3AD42A4942EFBC82E5A52313F26F0D605A4559E3E0A327BB9663A8C9BAB7EAEFFD67DB9149DFE122C8A34DBDD46A646B18A1CE711895028DBF6D01253D7D445FA3F58EA7A4B9DAA0BC4C704A48F619C7BB2AC57DB4A98DBE46E2566CAD8B3C4B3E67316531E6E36A494A826ADC1954E306E56B5CDAE3B72CB7216957E8B0EBEA48B8B59F20CCE877155ED68A8D258FB772EB804CABE03A3C7C941CDF7A0C45D7F5388911D1753F91AE6DBB9F5AEB7EB32AB456255A0D65AB3F5B2D04EBCF568F79E9A946DB7929A9A6EDB4BAA941C24731314DC7D04A17515E4CA311AEA2308CA731FC3EA089C64CE628C439EDB692BCB648DFF03DE1EDB8775521EA68C23DD7776FA3BCBCDF5B395EA651E5707B9FE6591CEFD47E1F2AF72C08C838C217DBD949F153A79F42F137EA6645EB746A5FF82499A6E2775793D9623DB2B19881B548B2A86DD1EA58564F31AE9E4C35E6334839B68E2BF5AED03FB25C8B605343466DF70144AAFEEABCFFC1092EC8B2A3A719534B468B7E0451EB6AB8A2778363BCB927EBA11E3FB69A8C60F715C490A9B2D74EADE30C2F23A86B3EAD1DD4E1E1630AF1AD4771467DC3AB44EBF55488473711ABB656271DD2474938E41ABD7A573C14B2B866E894B697FC36BAD7DBC9B26B3FADECEE50F0115BDA700C89DD7536CDFEA5EAD9D29931CC41D873D756F6FE82C62EF07318348D27F618345878B90C98B6A39C6C0728C44914FC0DA35CCBF583303D8AC98E19E59374DE52DAA07086F1E05A7B86BE6DAD616147F4B147814C087917E3A5D2E846C24BA7D1D6D32A358A868F56E31A8FA2D68860188E665E0F21D79F727C173D8CDDEB8728C51FB7C92DD669D13F0DD1F3FB8712A785DE62EAE33ECBA78A79AA1E387F2B53FAA27F9FA2FEB5F6C1401A58E1A6F152C117518AD22042F159147A696116C0B48A98C5C447178BED9FF7C9D464C7437D1E8919D6BAA4BA534855060EA204C5F319598A82A8B914FEFD9CB02CAA70371EAE5CA737390A7E69C1BD257C8E516A5484312A0AA2820264D83E0FBA752C77AAD3DB51B36B3FF5613341C1EFA8B969388638DBDCDA1D6ADF447A9E449E9FFB520F4BD9366164AC3DE2BE2C2E62B4EEDE5FB8085D0572C775CD81798F2247464800C68F8420AC20F014BDC295A94C5D7F3141FF67146FC98F4389FA5CDD0B9CB0B58F640AD6B4D2D08F3159FB212105382D15B3DBC89E8E1F501ABA51F1AC283262B35464E18E38D85B4E7C87EFD37066BC32DA6D25DAB3902B429F6843284244E174FE07691C3AB0D488EDC0B297B078D047737135B84EDF116BB7C4B3B3A07E70748E8ACA3B272F0604098E620C75F444136F08406303AF0B7423A3E6BF3DC5A04B060C547A75E109104B3E298306A63936EB86C61E03DBD30C3E6F3332EFE1C181245BCE9CC21EC499E655794DA2178E519EF77990D68300F5E99F0941E11A462F83E62F6F30309B03C90166BBF3979A90535CF0300EBA3F2936A0A4A05977AC649A08628CE39CC0233BE4F32C2DC82A19A5A56CB947640FBD41B1892C4243C0E8076E985603A73D895FC8D252594F696922C3DE28D09E84393151CA830119879169BA553778A666419547ABC389390718940965CA8CCF8532257E0B6C285E5534D87EF24B9F1E0C4AF932A4EB6A020EB8DEE1552FED0989A8357E4ED64EBCC6F401BEB40FF952E0662B52343B47710815D8252EF93BAA95D3B7DB538A069E44061E06BD502A4168096B00D059DE2A20AC5D6E00D4DD5792A0D0E93080E06E33495058EBC50068B7F2AB603426816928DD71A83C16BA401A80B03E7D090AA3E20C605837B40A12EFB137CE11D90AAB6768E762119A33E221721CF76C86A9C7DF6586769D96FB4E8A3EC3E792BEB3D9693280387E17972E7EC016C490AE92CBA4D0EE25AD76930CF69D9069E800ED1F19388CEAD99B068A9B9232150C9B44CB6D2233024E576888016F0CCDDCB5074370E8C14C016E1BAD378EBECCA1DA2ADA91770FAA34EA17A687621769B18FF4A501BF7364A0B4EB476F0367561478F0C0AED2725FE94B04793BC842EAF0EE8D16ECC2081303DAE1D8EE717CC9A1D89A30A058DCF72688F4E0075C47D586B695A9EDB7864AC6B505393514680F4DA8494DBF9D2CEAC0574DC1C9028890757285369B285D3311B39A92D9B20E9775FEC7A57BF0A8A486B10838D28A1B00DA5399E5688D85AF15D142BC3BBAAFE274DDA26A053C0F1345356E0301986A6D67E21E419EB3D6866B5B547F37A2A60B1D760058221D492FC8282BD5BF1B3096CD06B9E5AC0A60866294C3F1A7C8E8B7492A158BBC688475A40475E401E95884D414DA03AA8341B140EA127B08CC11310B8629B687456335B19068A1C3A8DAD84BDCC0DA420738EC5130078BFD600F8F3F0E6601F25FDC21BE7D54C37BAB1CEFC9429013C90523C9A6E422E385DD4A15B4EABB3F45A0B6C42DF400D450C3514D782581A594E19ACC90EA9B0D32ACBADC1E1AF7948505C77D70E2F8DD236D81D977652F723391DCB03BFEFE6407766D58C88FAE31CCAB6CF41E9E59E1A8407610E56543FCE603559652F19B0F548DCC2AABBCC8DD4472A7D9B4F80A5DEB48769738B0256C98D12316DE30034F5E6058CCB55E161653ECC002CC7D598E0598727B68DDB55F1656576A0FA9BDF0C6C251C779D1416962BEB0409A220755C18674E11404FBC11E1E10D685850C5471D891F0415EB86D09FFE9459D4DA4CEF4AE5A5F8DC61C6AB92B355D6350C2B800139CA0690257BCF0D9687CD6F89EFB6331A54FDD82BB80762091DB10081C85D501158C7014EB5B57EC080B3418E5AF2F4C3F95ADA839FAF03616DB937A0F6B116C0A9A8B4C3C02CE5E04631CE8A0F1D106786B80FDE2C0AF5C08018E61B92F0E9E4B2E2E806ACCAED2DAA7C9FD229FBDCAA7F634CE5740BB4B30EE12AA690B119C7B5CCF525CF3645F07AF7B3BCF09282DB587D4BE8667E1B4650E7B39E6753BB79B63CA1D7662DD8B75CE48EC8A1DC6D73DE6E186D815BF288967A024F8AB6AFDE909EE8A9BBBAAD037877D36FCF36FDE71A37B5AAE87DA9F27A83FDF4DBF3EA5F69D35A7159B327B28F47D350B86163AC8B8F0E29A1373E1DB9391A4E69E669F8ED34AF1F8B84D95EDB4A7D9B26A56BED536C2E9E9549C790A2DC17265ED9705C38FCDF98B41AA636DEE3EB1DBF935D7D4EEA4BABAF0A43C58565C1E9689E57D3CB7D29FD4ED9ECEB4607D30065FB1F472280FA327DEFC72E601E91AB5E38150D7D0F2DC47414EE0D6B42531F5179D569A0B4F8EB30E5C12B744D3DD7A1E70D61517C7DDDDE6B4A9BD735C4155F096780FB2B4F211294B2CDD66DFD7F7AF45934C4918EDDE865D16557C0F1AA7C18112BD2910EEDABAAB12E11A038AC489AB34F7F67B91D79597DC5AA3EA260236CCB5F2E5B3DE18A47981E0CA1A4DB3FD5717EEC9812565E193951578BEE239FDDCBB8A09D6145B7DA21DFDDECC225DCC773448BB866A73D49E6D805BFD4F6A55029E0C4CA8E1CC0C203D4810ABD01D5153427FD30709CD6300731E6FE975405DA58A3C977D8DC2EA65C0F2B12871B2E3A883E5AFF1791CED36336D852B944677B828EBD043F3E3C3A36321FFF7D3C9C5BD288A900BE90627E4E6E76CF454D8514562BF34D334C175FA15E5C17D757026269A7606CCA5AFB681EB9AAD5A0DF3D01D5721273400B78FC87121F9BBEC2B729C0A980D0DE54872CA11BB4F8E141E5009D723DA2E9F3B5B0DF53B3DB6AE89A33D64B9BF6CCD3E922CE760EEE8244576B84C43FC703AFFD7AEED9BD9E55F57DC225A95BE9A5DE74455BF991DBD2286CB9734FA754B6ADE10C2CEFEADE113DFA4CDC0A47A491D93574EA0A4670AF5E72DB6A03F8F21A105070160281F1D567CA3A59F4F0E640F39ED3FE9B08FBCAA53093BC9AC92E215B48EE606D9F558D5D43988F7C77B789DA3495EDCA7F679CECAC339FBAF8778823B248FBCBB3E8229C52CB7A0946764F0BE20F329693DD63C654E560F38DA8CB1DE82A0C869EB0D8B4BC2DBD302FACC855E062C06D7EF8B8F15A74B6E368804C0C1FA50D08F77CAB9A1C23586D0D843C3428EFBA9927A7AED59BE35C1915C956E3C25341F80AB54516F47CD34E9C34652FE48276B9411D4A16D5028DDA4DAFCF4F0643D7381724F26E9637FF69AC5D1CB29ABC8CDE8C4D22D1A2B1612FB2E827DD1408D66EB5DE3B107632A323E8E392493307B0C49954772CC211DF7BFB77FE6EAC376C338FCDCBD56CD5D3FBE31E021C934C91EBDB49F90C2D149A6280EAB164CFDEEA47B3362AD125EEF99047228BC4D72EF8EB79C467228DC957CCFE7AADC3711A55A33B82A0629EFE4CBF66650752ADB20FD6944F8BDCC9489177FFBAEC9493D455CEEC3D098FBD00D6B2117E26DE47E88A8CC8B38B4CF5D7ADB326EF2411F96D6DC19B0D21BA4F58AC2A06F60AC17790F23594A45D82FC6A6E5FDE5506ADF43A9FD3CA73617F974FE56ED9561EB23AED5BE4BADD792ABF304AF40A7B00552009821AC01CD8D55976B3EBAEBA61E4C637B476868D7B14B12F56978109AE87D32458A6FF514C962464927C5BE1A724C27E495384A1BF3D3EDE2CCCC25591418A757D7A7F1B1E188E9CA4C7934B9777F6206A4313393F9E524F46226380ABBC3B567273682A367823DEA1F2E8EC041F6C945AD95819C019283C3A6996260B9A425F5E2070721D73DDDB0E6066DE4419F657C4C85627A51E727D9C3EA1680B1145F87CC7A387E8E434746B37AF93311ABA99E36EDA33A9E35C339CEBBE969E8C06CE7F0487544E6D36755661EB39E3AA53C9ED8F48122925A5F9319CCEC31BEAA1D71EEAD934C4FB9B4D16C982C0AA3E4901E73218323893A76F92453444FC83F4C1E5406879112408FC841BA50974F8F856C5E9DFBECBC067503A99859F8F22CF66DDA10024F78EB661326E049E9A669D96A7C1DE5CE58D36CD5DEF3911B287B893918C57955265FD7A55EAFE3349CCEC3DB8C4C7FED6177CBCBAE49CBAE02EE9CB2DD90B15DD5877B46775D4277550FF4A3013CBB01957A603FAA3A714D060FE7825741774B13AFCD12AFA490730E797D0A79551F7E19E68D09E6555DB9A7A08733D0AB194A110413E2562D5729EA6838D881C7841501907AADD80855840E7509845991065308C36757C0C11E1DA24E6728ED40A625A0D1FC934753FD0B678E060E5654C74D0CA6806257DB244C3B68C2DC87A88869280FD2701EE2371FA0139369A91106FFD95425B48727D61C46CF6FAE4CBE5319C2E0C468D36EDB11431D716B9F397D222469D661980A4A4FA2EC2165D0552EED234AB9ECDDD30C4F9716676F4617AC173EF14D7F0365FC509A916A138CEC3B54C98C125288EC3F58C063022FC786887E7B6B71A541A20841D8FFD061D5651728B087F9EE7FF052BC40FAED64511B734D01F929C505247BDD6D5A5DF8AC7FBDC345B4EE4054012F531C70BB5C5AE732BDCBDA7DB780515B45BC248A4B14569129F332BA4341493E57212AA3743D9FFD8CE26DB51A24B738BC4CAFB7E5665B9221E3E436E6C2C2579B765DFF270B09E793EBDD0BDDA28F211034A3EA8EEC75FA761BC521C5FB4271BB0D005179037EC2A4BC9ECB92FC1FAF1F29A48F92D443801AF25127C60D4E3671959CE13A5DA2AFD807B72F05FE80D72878FCD48477848198278227FBC9BB08AD7394140D8CAE3DF94978384C1E7EF83FC2CC405D0CCF0000 , N'6.1.3-40302')
