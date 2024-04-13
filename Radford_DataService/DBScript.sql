USE [master]
GO

/****** Object:  Database [RadfordHr]    Script Date: 4/13/2024 9:11:00 PM ******/
CREATE DATABASE [RadfordHr] 

USE [RadfordHr]
GO

CREATE TABLE [dbo].[Staff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StaffType] [varchar](8) NOT NULL,
	[Title] [varchar](4) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](150) NOT NULL,
	[MiddleInitial] [varchar](5) NULL,
	[HomePhone] [varchar](15) NULL,
	[CellPhone] [varchar](15) NULL,
	[OfficeExtension] [varchar](10) NULL,
	[IRDNumber] [varchar](20) NULL,
	[Status] [varchar](8) NOT NULL,
	[ManagerId] [int] NULL,
 CONSTRAINT [PK_Staff_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Manager] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Staff] ([Id])
GO

ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Manager]
GO

ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [CK_Staff_StaffType] CHECK  (([StaffType]='Manager' OR [StaffType]='Employee'))
GO

ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [CK_Staff_StaffType]
GO

ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [CK_Staff_Status] CHECK  (([Status]='Pending' OR [Status]='Inactive' OR [Status]='Active'))
GO

ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [CK_Staff_Status]
GO

ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [CK_Staff_Title] CHECK  (([Title]='Sir' OR [Title]='Miss' OR [Title]='Mrs' OR [Title]='Mr'))
GO

ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [CK_Staff_Title]
GO

CREATE PROCEDURE [dbo].[GetStaff]
AS
BEGIN	
    SELECT Id, StaffType, Title, FirstName, LastName, MiddleInitial, HomePhone, CellPhone, OfficeExtension, IRDNumber, [Status], ManagerId
    FROM Staff;
END

GO

CREATE PROCEDURE [dbo].[UpsertStaff]
    @Id INT OUTPUT,
    @StaffType VARCHAR(8),
    @Title VARCHAR(4),
    @FirstName VARCHAR(100),
    @LastName VARCHAR(150),
    @MiddleInitial VARCHAR(5) = NULL,
    @HomePhone VARCHAR(15) = NULL,
    @CellPhone VARCHAR(15) = NULL,
    @OfficeExtension VARCHAR(10) = NULL,
    @IRDNumber VARCHAR(20) = NULL,
    @Status VARCHAR(8),
    @ManagerId INT = NULL
AS
BEGIN
    IF @Id IS NULL
    BEGIN
        -- Insert new record
        INSERT INTO Staff (StaffType, Title, FirstName, LastName, MiddleInitial, HomePhone, CellPhone, OfficeExtension, IRDNumber, [Status], ManagerId)
        VALUES (@StaffType, @Title, @FirstName, @LastName, @MiddleInitial, @HomePhone, @CellPhone, @OfficeExtension, @IRDNumber, @Status, @ManagerId);

		SET @Id = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        -- Update existing record
        UPDATE Staff
        SET StaffType = @StaffType,
            Title = @Title,
            FirstName = @FirstName,
            LastName = @LastName,
            MiddleInitial = @MiddleInitial,
            HomePhone = @HomePhone,
            CellPhone = @CellPhone,
            OfficeExtension = @OfficeExtension,
            IRDNumber = @IRDNumber,
            [Status] = @Status,
            ManagerId = @ManagerId
        WHERE Id = @Id;
    END
END