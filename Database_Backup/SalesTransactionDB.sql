USE [master]
GO
/****** Object:  Database [SalesTransactionDB]    Script Date: 9/7/2020 3:17:33 PM ******/
CREATE DATABASE [SalesTransactionDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SalesTransactionDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SalesTransactionDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SalesTransactionDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SalesTransactionDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SalesTransactionDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SalesTransactionDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SalesTransactionDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SalesTransactionDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SalesTransactionDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SalesTransactionDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SalesTransactionDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SalesTransactionDB] SET  MULTI_USER 
GO
ALTER DATABASE [SalesTransactionDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SalesTransactionDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SalesTransactionDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SalesTransactionDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SalesTransactionDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SalesTransactionDB] SET QUERY_STORE = OFF
GO
USE [SalesTransactionDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SalesTransactionDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9/7/2020 3:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EngagedCustomers]    Script Date: 9/7/2020 3:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EngagedCustomers](
	[CustomerId] [int] NULL,
	[SalesId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 9/7/2020 3:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SalesMasterId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 9/7/2020 3:17:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 9/7/2020 3:17:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesDetails]    Script Date: 9/7/2020 3:17:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SalesId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_SalesDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesMaster]    Script Date: 9/7/2020 3:17:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_SalesMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/7/2020 3:17:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[IsSystemAccount] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPassword]    Script Date: 9/7/2020 3:17:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPassword](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UserPassword] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Firstname], [Lastname], [Address], [PhoneNumber], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DeletedBy], [DeletedDate]) VALUES (8, N'Sam', N'Shrestha', N'Kirtipur', N'9875098733', 2, CAST(N'2020-09-07T14:47:02.200' AS DateTime), 2, CAST(N'2020-09-07T14:47:30.343' AS DateTime), NULL, NULL)
INSERT [dbo].[Customer] ([Id], [Firstname], [Lastname], [Address], [PhoneNumber], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DeletedBy], [DeletedDate]) VALUES (9, N'Dean', N'Shrestha', N'Jawalakhel, Lalitpur', N'9984738495', 2, CAST(N'2020-09-07T14:50:14.797' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[Customer] ([Id], [Firstname], [Lastname], [Address], [PhoneNumber], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DeletedBy], [DeletedDate]) VALUES (10, N'Bobby', N'Maharjan', N'Khokana, Lalitpur', N'9875069327', 2, CAST(N'2020-09-07T14:50:43.800' AS DateTime), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
INSERT [dbo].[EngagedCustomers] ([CustomerId], [SalesId]) VALUES (10, 15)
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([Id], [SalesMasterId], [CreatedBy], [CreatedDate]) VALUES (1, 14, 2, CAST(N'2020-09-07T15:01:29.660' AS DateTime))
SET IDENTITY_INSERT [dbo].[Invoice] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Rate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DeletedBy], [DeletedDate]) VALUES (22, N'wai-wai', CAST(20.00 AS Decimal(18, 2)), 2, CAST(N'2020-09-07T14:51:20.920' AS DateTime), 2, CAST(N'2020-09-07T14:51:33.917' AS DateTime), NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Rate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DeletedBy], [DeletedDate]) VALUES (23, N'apple', CAST(350.00 AS Decimal(18, 2)), 2, CAST(N'2020-09-07T14:53:14.907' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Rate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DeletedBy], [DeletedDate]) VALUES (24, N'digestive biscuit', CAST(80.00 AS Decimal(18, 2)), 2, CAST(N'2020-09-07T14:53:34.560' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Rate], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DeletedBy], [DeletedDate]) VALUES (25, N'real juice', CAST(30.00 AS Decimal(18, 2)), 2, CAST(N'2020-09-07T14:53:49.040' AS DateTime), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'user')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[SalesDetails] ON 

INSERT [dbo].[SalesDetails] ([Id], [SalesId], [ProductId], [Quantity], [Rate], [Amount]) VALUES (10, 14, 23, 2, CAST(350.00 AS Decimal(18, 2)), CAST(700.00 AS Decimal(18, 2)))
INSERT [dbo].[SalesDetails] ([Id], [SalesId], [ProductId], [Quantity], [Rate], [Amount]) VALUES (11, 14, 22, 1, CAST(20.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[SalesDetails] ([Id], [SalesId], [ProductId], [Quantity], [Rate], [Amount]) VALUES (12, 15, 25, 1, CAST(30.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(18, 2)))
INSERT [dbo].[SalesDetails] ([Id], [SalesId], [ProductId], [Quantity], [Rate], [Amount]) VALUES (13, 15, 24, 1, CAST(80.00 AS Decimal(18, 2)), CAST(80.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[SalesDetails] OFF
SET IDENTITY_INSERT [dbo].[SalesMaster] ON 

INSERT [dbo].[SalesMaster] ([Id], [CustomerId], [TotalAmount], [IsPaid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DeletedBy], [DeletedDate]) VALUES (14, 9, CAST(720.00 AS Decimal(18, 2)), 1, 2, CAST(N'2020-09-07T15:00:51.230' AS DateTime), 2, CAST(N'2020-09-07T15:01:19.840' AS DateTime), NULL, NULL)
INSERT [dbo].[SalesMaster] ([Id], [CustomerId], [TotalAmount], [IsPaid], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DeletedBy], [DeletedDate]) VALUES (15, 10, CAST(110.00 AS Decimal(18, 2)), 0, 2, CAST(N'2020-09-07T15:01:42.940' AS DateTime), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SalesMaster] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [RoleId], [IsSystemAccount], [CreatedDate], [DeletedDate]) VALUES (1, N'admin', 1, 1, CAST(N'2020-09-03T20:33:02.383' AS DateTime), NULL)
INSERT [dbo].[User] ([Id], [Username], [RoleId], [IsSystemAccount], [CreatedDate], [DeletedDate]) VALUES (2, N'suva', 2, 0, CAST(N'2020-09-03T20:35:16.383' AS DateTime), NULL)
INSERT [dbo].[User] ([Id], [Username], [RoleId], [IsSystemAccount], [CreatedDate], [DeletedDate]) VALUES (3, N'ratna', 2, 0, CAST(N'2020-09-07T10:51:52.590' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_SalesMaster] FOREIGN KEY([SalesMasterId])
REFERENCES [dbo].[SalesMaster] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_SalesMaster]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_User]
GO
ALTER TABLE [dbo].[SalesDetails]  WITH CHECK ADD  CONSTRAINT [FK_SalesDetails_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[SalesDetails] CHECK CONSTRAINT [FK_SalesDetails_Product]
GO
ALTER TABLE [dbo].[SalesDetails]  WITH CHECK ADD  CONSTRAINT [FK_SalesDetails_SalesMaster] FOREIGN KEY([SalesId])
REFERENCES [dbo].[SalesMaster] ([Id])
GO
ALTER TABLE [dbo].[SalesDetails] CHECK CONSTRAINT [FK_SalesDetails_SalesMaster]
GO
ALTER TABLE [dbo].[SalesMaster]  WITH CHECK ADD  CONSTRAINT [FK_SalesMaster_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[SalesMaster] CHECK CONSTRAINT [FK_SalesMaster_Customer]
GO
ALTER TABLE [dbo].[SalesMaster]  WITH CHECK ADD  CONSTRAINT [FK_SalesMaster_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SalesMaster] CHECK CONSTRAINT [FK_SalesMaster_User]
GO
ALTER TABLE [dbo].[SalesMaster]  WITH CHECK ADD  CONSTRAINT [FK_SalesMaster_User1] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SalesMaster] CHECK CONSTRAINT [FK_SalesMaster_User1]
GO
ALTER TABLE [dbo].[SalesMaster]  WITH CHECK ADD  CONSTRAINT [FK_SalesMaster_User2] FOREIGN KEY([DeletedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SalesMaster] CHECK CONSTRAINT [FK_SalesMaster_User2]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[UserPassword]  WITH CHECK ADD  CONSTRAINT [FK_UserPassword_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserPassword] CHECK CONSTRAINT [FK_UserPassword_User]
GO
/****** Object:  StoredProcedure [dbo].[AddCustomer]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCustomer]
(
   @Firstname NVARCHAR(50),  
   @Lastname NVARCHAR(50),  
   @Address NVARCHAR(50),
   @PhoneNumber NVARCHAR(50),
   @CreatedBy INT
)   
AS   
BEGIN  
	SET NOCOUNT ON;  
	INSERT INTO [dbo].[Customer] 
	(
		[Firstname]
	   ,[Lastname]
	   ,[Address]
	   ,[PhoneNumber]
	   ,[CreatedBy]
	   ,[CreatedDate]
	)  
	VALUES
	(
		@Firstname
	   ,@Lastname
	   ,@Address
	   ,@PhoneNumber
	   ,@CreatedBy
	   ,GETDATE()
	 )  
END 
GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProduct]
(
   @Name nvarchar(50),  
   @Rate DECIMAL(18,2),  
   @CreatedBy int
)   
AS   
BEGIN  
	SET NOCOUNT ON;  
	INSERT INTO [dbo].[Product] 
	(
		[Name]
	   ,[Rate]
	   ,[CreatedBy]
	   ,[CreatedDate]
	)  
	VALUES
	(
		@Name
	   ,@Rate
	   ,@CreatedBy
	   ,GETDATE()
	 )  
END 
GO
/****** Object:  StoredProcedure [dbo].[AddSalesDetails]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddSalesDetails]
(
	@SalesId INT,
	@ProductId INT,
	@Quantity INT,
	@Rate DECIMAL(18,2)
)
AS
BEGIN
	INSERT INTO [SalesDetails] (SalesId, ProductId, Quantity, Rate, Amount)
	VALUES (@SalesId, @ProductId, @Quantity, @Rate, @Quantity * @Rate)
END
GO
/****** Object:  StoredProcedure [dbo].[AddSalesMaster]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddSalesMaster]
(
	@Id INT OUTPUT,
	@Customerid INT,
	@TotalAmount DECIMAL(18,2),
	@IsPaid BIT,
	@CreatedBy INT
)
AS
BEGIN
	DECLARE @IDTable TABLE
	(
		InsertedID INT
	)
	INSERT INTO [SalesMaster] (CustomerId, TotalAmount, IsPaid, CreatedBy, CreatedDate)
	OUTPUT INSERTED.[Id] INTO @IDTable
	VALUES(@Customerid, @TotalAmount, @IsPaid, @CreatedBy, GETDATE())

	SELECT @Id = [InsertedID]
		FROM @IDTable


END
GO
/****** Object:  StoredProcedure [dbo].[AddSalesTransaction]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddSalesTransaction]
(
	@CustomerId int,
	@TotalAmount decimal(18,2),
	@IsPaid bit,
	@CreatedBy int,
	@Detailsjson nvarchar(max)
)
AS
BEGIN
	Begin Try
		Begin Transaction

		
		DECLARE @IdentityValue AS TABLE(ID INT);

		   INSERT INTO [SalesMaster] (CustomerId, TotalAmount, IsPaid, CreatedBy, CreatedDate)
		   OUTPUT Inserted.ID INTO @IdentityValue  
		   VALUES (@CustomerId, @TotalAmount, @IsPaid, @CreatedBy, GETDATE()) 
   
		   INSERT INTO [SalesDetails] (SalesId, ProductId, Quantity, Rate, Amount)
		   SELECT (SELECT ID FROM @IdentityValue), ProductId, Quantity, Rate, Amount 
		   FROM OPENJSON(@Detailsjson)
		   WITH (ProductId int, Quantity int, Rate decimal(18,2), Amount decimal(18,2))

		   INSERT INTO [EngagedCustomers] (CustomerId, SalesId)
		   VALUES (@CustomerId, (SELECT ID FROM @IdentityValue))

		   Commit Transaction
	End Try
	Begin Catch
		DECLARE @ErrorMessage NVARCHAR(2048),
        @ErrorSeverity INT,
        @ErrorState INT
		SELECT
		@ErrorMessage =ERROR_MESSAGE(),
		@ErrorSeverity =ERROR_SEVERITY(),
		@ErrorState =ERROR_STATE()
 
		RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState)

		Rollback Transaction
	End Catch
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
(
   @Username nvarchar(50),  
   @RoleId DECIMAL(18,2),  
   @IsSystemAccount int
)   
AS   
BEGIN  
	SET NOCOUNT ON;  
	INSERT INTO [dbo].[User] 
	(
		[Username]
	   ,[RoleId]
	   ,[IsSystemAccount]
	   ,[CreatedDate]
	)  
	VALUES
	(
		@Username
	   ,@RoleId
	   ,@IsSystemAccount
	   ,GETDATE()
	 )  
END 
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomer]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCustomer]
(
	@Id int,
	@DeletedBy int
)   
AS  
BEGIN  
	SET NOCOUNT ON;  
	UPDATE [Customer]
	SET DeletedBy = @DeletedBy
	   ,DeletedDate = GETDATE()
	WHERE Id = @Id
END  
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProduct]
(
	@Id int,
	@DeletedBy int
)   
AS  
BEGIN  
	SET NOCOUNT ON;  
	UPDATE [Product]
	SET DeletedBy = @DeletedBy
	   ,DeletedDate = GETDATE()
	WHERE Id = @Id
END  
GO
/****** Object:  StoredProcedure [dbo].[DeleteSales]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSales]
(
	@Id int,
	@DeletedBy int
)   
AS  
BEGIN  
	SET NOCOUNT ON;  
	UPDATE [SalesMaster]
	SET DeletedBy = @DeletedBy
	   ,DeletedDate = GETDATE()
	WHERE Id = @Id
END  
GO
/****** Object:  StoredProcedure [dbo].[GetAllCustomers]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCustomers]
(
	@isWithoutSales BIT
)
AS  
BEGIN 
	SET NOCOUNT ON; 
	if (@isWithoutSales = 1)
		BEGIN
			SELECT c.*
			FROM Customer c
			WHERE NOT EXISTS ( SELECT CustomerId
                   FROM EngagedCustomers ec
                   WHERE c.Id = ec.CustomerId
                 ) AND c.DeletedDate IS NULL
		END
	ELSE
		BEGIN
			SELECT *
			FROM [Customer]
			WHERE DeletedDate IS NULL
			ORDER BY CreatedDate DESC
		END 
END  
GO
/****** Object:  StoredProcedure [dbo].[GetAllProducts]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllProducts]
AS  
BEGIN  
	SET NOCOUNT ON;  
	SELECT [Id],
		   [Name],
		   [Rate],
		   [CreatedBy],
		   [CreatedDate],
		   [ModifiedBy],
		   [ModifiedDate],
		   [DeletedBy],
		   [DeletedDate]
	FROM [Product]
	WHERE DeletedDate IS NULL
	ORDER BY CreatedDate DESC
END  
GO
/****** Object:  StoredProcedure [dbo].[GetAllSales]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllSales]
AS  
BEGIN  
	SET NOCOUNT ON;  
	SELECT S.*, (C.[Firstname] + ' ' + C.[Lastname]) AS [CustomerName]
	FROM [SalesMaster] S
	INNER JOIN [Customer] C
	ON S.CustomerId = C.Id
	WHERE S.DeletedDate IS NULL
	ORDER BY S.CreatedDate DESC
END  
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS  
BEGIN  
	SET NOCOUNT ON;  
	SELECT * 
	FROM [User]
	WHERE DeletedDate IS NULL AND IsSystemAccount = 0
END  
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerById]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomerById]
(
  @Id int
)    
AS    
BEGIN  
	SET NOCOUNT ON;  
	SELECT * from [Customer] where Id=@Id
END  
GO
/****** Object:  StoredProcedure [dbo].[GetInvoiceById]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetInvoiceById]
(
	@SalesId INT
)
AS
BEGIN
	SELECT P.[Name] [Product], SD.[Quantity], SD.[Rate], SD.[Amount]
	FROM [SalesDetails] SD
	INNER JOIN [SalesMaster] SM
	ON SD.SalesId = SM.Id
	INNER JOIN [Invoice] I
	ON I.SalesMasterId = SM.Id
	INNER JOIN [Product] P
	ON p.Id = SD.ProductId
	WHERE I.SalesMasterId = @SalesId
END
GO
/****** Object:  StoredProcedure [dbo].[GetProductById]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductById]
(
  @Id int
)    
AS    
BEGIN  
	SET NOCOUNT ON;  
	SELECT * from [Product] where Id=@Id
END  
GO
/****** Object:  StoredProcedure [dbo].[GetSalesById]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSalesById]
(
  @Id int
)    
AS    
BEGIN  
	SET NOCOUNT ON;  
	SELECT * from [SalesMaster] where Id=@Id
END  
GO
/****** Object:  StoredProcedure [dbo].[GetSalesTransactionById]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSalesTransactionById]
(
  @Id int
)    
AS    
BEGIN  
	SET NOCOUNT ON;  

	SELECT S.*, C.Firstname + ' ' + C.Lastname AS [CustomerName] 
	FROM [SalesMaster] S
	INNER JOIN [Customer] C
	ON S.CustomerId = C.Id
	WHERE S.Id = @Id

	SELECT SD.Id, SalesId, ProductId, Quantity, SD.Rate, Amount, P.Name
	FROM [SalesMaster] SM
	INNER JOIN [SalesDetails] SD
	on SM.Id = SD.SalesId
	INNER JOIN [Product] P
	ON P.Id = SD.ProductId
	WHERE SD.SalesId = @Id
END  
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserById]
(
  @Id int
)    
AS    
BEGIN  
	SET NOCOUNT ON;  
	SELECT * from [User] where Id=@Id
END  
GO
/****** Object:  StoredProcedure [dbo].[GetUserByUsername]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByUsername]
(
  @Username NVARCHAR(50)
)    
AS    
BEGIN  
	SET NOCOUNT ON;  
	SELECT u.*, r.[Name] as RoleName from [User] u
	inner join [Role] r
	on u.RoleId = r.Id 
	WHERE Username = @Username
END  
GO
/****** Object:  StoredProcedure [dbo].[PayInvoice]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PayInvoice]
(
	@SalesId INT,
	@CreatedBy INT
)
AS
BEGIN
	Begin Try
		Begin Transaction

			INSERT INTO [Invoice] (SalesMasterId, CreatedBy, CreatedDate)
			VALUES (@SalesId, @CreatedBy, GETDATE())

			UPDATE [SalesMaster]
			SET [IsPaid] = 1 
			WHERE Id = @SalesId

			DELETE [EngagedCustomers]
			WHERE SalesId = @SalesId

		Commit Transaction
	End Try
	Begin Catch
		DECLARE @ErrorMessage NVARCHAR(2048),
        @ErrorSeverity INT,
        @ErrorState INT
		SELECT
		@ErrorMessage =ERROR_MESSAGE(),
		@ErrorSeverity =ERROR_SEVERITY(),
		@ErrorState =ERROR_STATE()
 
		RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState)

		Rollback Transaction
	End Catch

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCustomer]
(
  @Id INT,
  @Firstname NVARCHAR(50),
  @Lastname NVARCHAR(50),
  @Address NVARCHAR(50),
  @PhoneNumber NVARCHAR(50),
  @ModifiedBy INT
)
AS  
BEGIN  
	SET NOCOUNT ON;  
	UPDATE [Customer] SET 
	[Firstname]=@Firstname, [Lastname]=@Lastname, [Address]=@Address, [PhoneNumber]=@PhoneNumber,
	[ModifiedBy]=@ModifiedBy, [ModifiedDate]=GETDATE() 
	WHERE Id=@Id     
END  
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProduct]
(
  @Id INT,
  @Name NVARCHAR(50),
  @Rate DECIMAL(18,2),
  @ModifiedBy INT
)
AS  
BEGIN  
	SET NOCOUNT ON;  
	UPDATE [Product] SET [Name]=@Name,[Rate]=@Rate,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=GETDATE() WHERE Id=@Id     
END  
GO
/****** Object:  StoredProcedure [dbo].[UpdateSalesTransaction]    Script Date: 9/7/2020 3:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateSalesTransaction]
(
	@Id int,
	@CustomerId int,
	@TotalAmount decimal(18,2),
	@ModifiedBy int,
	@Detailsjson nvarchar(max)
)
AS
BEGIN
	Begin Try
		Begin Transaction

		   UPDATE [SalesMaster]
		   SET [CustomerId] = @CustomerId, [TotalAmount] = @TotalAmount, ModifiedBy = @ModifiedBy, ModifiedDate = GETDATE()
		   WHERE Id = @Id

		   DELETE [SalesDetails]
		   WHERE SalesId = @Id
   
		   INSERT INTO [SalesDetails] (SalesId, ProductId, Quantity, Rate, Amount)
		   SELECT @Id, ProductId, Quantity, Rate, Amount 
		   FROM OPENJSON(@Detailsjson)
		   WITH (ProductId int, Quantity int, Rate decimal(18,2), Amount decimal(18,2))

		   Commit Transaction
	End Try
	Begin Catch
		DECLARE @ErrorMessage NVARCHAR(2048),
        @ErrorSeverity INT,
        @ErrorState INT
		SELECT
		@ErrorMessage =ERROR_MESSAGE(),
		@ErrorSeverity =ERROR_SEVERITY(),
		@ErrorState =ERROR_STATE()
 
		RAISERROR (@ErrorMessage, @ErrorSeverity,@ErrorState)

		Rollback Transaction
	End Catch
END
GO
USE [master]
GO
ALTER DATABASE [SalesTransactionDB] SET  READ_WRITE 
GO
