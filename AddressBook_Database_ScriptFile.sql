USE [master]
GO
/****** Object:  Database [Address_Book]    Script Date: 21-11-2023 16:04:48 ******/
CREATE DATABASE [Address_Book]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Address_Book', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Address_Book.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Address_Book_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Address_Book_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Address_Book].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Address_Book] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Address_Book] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Address_Book] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Address_Book] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Address_Book] SET ARITHABORT OFF 
GO
ALTER DATABASE [Address_Book] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Address_Book] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Address_Book] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Address_Book] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Address_Book] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Address_Book] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Address_Book] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Address_Book] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Address_Book] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Address_Book] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Address_Book] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Address_Book] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Address_Book] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Address_Book] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Address_Book] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Address_Book] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Address_Book] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Address_Book] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Address_Book] SET  MULTI_USER 
GO
ALTER DATABASE [Address_Book] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Address_Book] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Address_Book] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Address_Book] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [Address_Book]
GO
/****** Object:  Table [dbo].[LOC_Country]    Script Date: 21-11-2023 16:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOC_Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_LOC_City] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOC_State]    Script Date: 21-11-2023 16:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOC_State](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](50) NOT NULL,
	[StateCode] [nvarchar](50) NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
	[CountryID] [int] NULL,
 CONSTRAINT [PK_LOC_State] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LOC_Country] ON 

INSERT [dbo].[LOC_Country] ([CountryID], [CountryName], [Created], [Modified]) VALUES (1, N'India', CAST(N'2023-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[LOC_Country] ([CountryID], [CountryName], [Created], [Modified]) VALUES (2, N'Austrelia', CAST(N'2023-10-07T00:00:00.000' AS DateTime), CAST(N'2023-10-08T00:00:00.000' AS DateTime))
INSERT [dbo].[LOC_Country] ([CountryID], [CountryName], [Created], [Modified]) VALUES (3, N'Canada', CAST(N'2023-02-06T00:00:00.000' AS DateTime), CAST(N'2023-02-07T00:00:00.000' AS DateTime))
INSERT [dbo].[LOC_Country] ([CountryID], [CountryName], [Created], [Modified]) VALUES (6, N'France', CAST(N'2023-07-01T00:00:00.000' AS DateTime), CAST(N'2023-05-09T00:00:00.000' AS DateTime))
INSERT [dbo].[LOC_Country] ([CountryID], [CountryName], [Created], [Modified]) VALUES (1002, N'Pakistan', CAST(N'2023-09-06T00:00:00.000' AS DateTime), CAST(N'2023-05-08T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[LOC_Country] OFF
GO
SET IDENTITY_INSERT [dbo].[LOC_State] ON 

INSERT [dbo].[LOC_State] ([StateID], [StateName], [StateCode], [Created], [Modified], [CountryID]) VALUES (1005, N'Rajsthan', N'RJ', CAST(N'2023-06-09T00:00:00.000' AS DateTime), CAST(N'2023-06-09T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[LOC_State] ([StateID], [StateName], [StateCode], [Created], [Modified], [CountryID]) VALUES (1006, N'Gujarat', N'GJ', CAST(N'2023-07-09T00:00:00.000' AS DateTime), CAST(N'2023-07-09T00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[LOC_State] OFF
GO
ALTER TABLE [dbo].[LOC_State]  WITH CHECK ADD  CONSTRAINT [FK_LOC_State_LOC_State] FOREIGN KEY([CountryID])
REFERENCES [dbo].[LOC_Country] ([CountryID])
GO
ALTER TABLE [dbo].[LOC_State] CHECK CONSTRAINT [FK_LOC_State_LOC_State]
GO
/****** Object:  StoredProcedure [dbo].[PR_LOC_Country_Delete]    Script Date: 21-11-2023 16:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LOC_Country_Delete]
@CountryID	int
AS
DELETE FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryID] = @CountryID
GO
/****** Object:  StoredProcedure [dbo].[PR_LOC_Country_Insert]    Script Date: 21-11-2023 16:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LOC_Country_Insert]
@CountryName    Varchar(50),
@Created		DateTime,
@Modified		DateTime
AS
INSERT INTO [dbo].[LOC_Country]
(
	[CountryName],
	[Created],
	[Modified]
)
VALUES(
@CountryName,
@Created,	
@Modified	
)
GO
/****** Object:  StoredProcedure [dbo].[PR_LOC_Country_SelectAll]    Script Date: 21-11-2023 16:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LOC_Country_SelectAll]
AS
SELECT [dbo].[LOC_Country].[CountryID],
	[dbo].[LOC_Country].[CountryName],
	[dbo].[LOC_Country].[Created],
	[dbo].[LOC_Country].[Modified]
	FROM [dbo].[LOC_Country]
GO
/****** Object:  StoredProcedure [dbo].[PR_LOC_Country_SelectByPK]    Script Date: 21-11-2023 16:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LOC_Country_SelectByPK]
@CountryID		int
AS
SELECT [dbo].[LOC_Country].[CountryID],
	[dbo].[LOC_Country].[CountryName],
	[dbo].[LOC_Country].[Created],
	[dbo].[LOC_Country].[Modified]
	FROM [dbo].[LOC_Country]
WHERE [dbo].[LOC_Country].[CountryID] = @CountryID
GO
/****** Object:  StoredProcedure [dbo].[PR_LOC_Country_UpdateByPK]    Script Date: 21-11-2023 16:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LOC_Country_UpdateByPK]
@CountryId		int,
@CountryName    Varchar(50),
@Created		DateTime,
@Modified		DateTime
AS
UPDATE [dbo].[LOC_Country]
SET
	[CountryName] = @CountryName,
	[Created] = @Created,
	[Modified] = @Modified
WHERE [dbo].[LOC_Country].[CountryID] = @CountryId
GO
/****** Object:  StoredProcedure [dbo].[PR_LOC_State_Delete]    Script Date: 21-11-2023 16:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LOC_State_Delete]
@StateID	int
AS
DELETE FROM [dbo].[LOC_State]
WHERE [dbo].[LOC_State].[StateID] = @StateID
GO
/****** Object:  StoredProcedure [dbo].[PR_LOC_State_Insert]    Script Date: 21-11-2023 16:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LOC_State_Insert]
@StateName		Varchar(50),
@StateCode		Varchar(50),
@Created		DateTime,
@Modified		DateTime,
@CountryId		int
AS
INSERT INTO [dbo].[LOC_State]
(
	[StateName],
	[StateCode],
	[Created],
	[Modified],
	[CountryID]
)
VALUES(
@StateName,
@StateCode,	
@Created,	
@Modified,	
@CountryId	
)
GO
/****** Object:  StoredProcedure [dbo].[PR_LOC_State_SelectAll]    Script Date: 21-11-2023 16:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LOC_State_SelectAll]
AS
SELECT [dbo].[LOC_State].[StateID],
	[dbo].[LOC_State].[StateName],
	[dbo].[LOC_State].[StateCode],
	[dbo].[LOC_Country].[CountryName],
	[dbo].[LOC_State].[Created],
	[dbo].[LOC_State].[Modified]
	FROM [dbo].[LOC_State]
	INNER JOIN [dbo].[LOC_Country]
	ON [dbo].[LOC_State].[CountryID] = [dbo].[LOC_Country].[CountryID]
GO
/****** Object:  StoredProcedure [dbo].[PR_LOC_State_SelectByPK]    Script Date: 21-11-2023 16:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LOC_State_SelectByPK]
@StateID		int
AS
SELECT [dbo].[LOC_State].[StateID],
	[dbo].[LOC_State].[StateName],
	[dbo].[LOC_State].[StateCode],
	[dbo].[LOC_Country].[CountryName],
	[dbo].[LOC_State].[Created],
	[dbo].[LOC_State].[Modified]
	FROM [dbo].[LOC_State]
	INNER JOIN [dbo].[LOC_Country]
	ON [dbo].[LOC_State].[CountryID] = [dbo].[LOC_Country].[CountryID]
WHERE [dbo].[LOC_State].[StateID] = @StateID
GO
/****** Object:  StoredProcedure [dbo].[PR_LOC_State_UpdateByPK]    Script Date: 21-11-2023 16:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_LOC_State_UpdateByPK]
@StateID		int,
@StateName		Varchar(50),
@StateCode		Varchar(50),
@Created		DateTime,
@Modified		DateTime,
@CountryId		int
AS
UPDATE [dbo].[LOC_State]
SET
	[StateName] = @StateName,
	[StateCode] = @StateCode,
	[Created] = @Created,
	[Modified] = @Modified,
	[CountryID] = @CountryId
	WHERE [dbo].[LOC_State].[StateID] = @StateID
GO
USE [master]
GO
ALTER DATABASE [Address_Book] SET  READ_WRITE 
GO
