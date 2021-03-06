USE [master]
GO
/****** Object:  Database [NoteBook]    Script Date: 19-May-18 1:14:15 PM ******/
CREATE DATABASE [NoteBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NoteBook', FILENAME = N'D:\SQLDB\MSSQL12.MSSQLSERVER\MSSQL\DATA\NoteBook.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NoteBook_log', FILENAME = N'D:\SQLDB\MSSQL12.MSSQLSERVER\MSSQL\DATA\NoteBook_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NoteBook] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NoteBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NoteBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NoteBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NoteBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NoteBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NoteBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [NoteBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NoteBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NoteBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NoteBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NoteBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NoteBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NoteBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NoteBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NoteBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NoteBook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NoteBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NoteBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NoteBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NoteBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NoteBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NoteBook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NoteBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NoteBook] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NoteBook] SET  MULTI_USER 
GO
ALTER DATABASE [NoteBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NoteBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NoteBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NoteBook] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [NoteBook] SET DELAYED_DURABILITY = DISABLED 
GO
USE [NoteBook]
GO
/****** Object:  Table [dbo].[NoteBookId]    Script Date: 19-May-18 1:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoteBookId](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nchar](15) NOT NULL,
	[FirstName] [nchar](15) NOT NULL,
	[YearOfBirth] [int] NOT NULL,
	[PhoneNumber] [nchar](12) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[AddNote]    Script Date: 19-May-18 1:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddNote]
	@FirstName nvarchar(15),
	@LastName nvarchar(15),
	@YearOfBirth int,
	@PhoneNumber nvarchar(12),
	@Id int out
AS
BEGIN
	 INSERT INTO NoteBookId(FirstName, LastName, YearOfBirth, PhoneNumber)
		VALUES(@FirstName, @LastName, @YearOfBirth, @PhoneNumber)

		SET @Id = SCOPE_IDENTITY();
END

GO
/****** Object:  StoredProcedure [dbo].[EditNote]    Script Date: 19-May-18 1:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditNote]
	@FirstName nvarchar(15),
	@LastName nvarchar(15),
	@YearOfBirth int,
	@PhoneNumber nvarchar(12),
	@Id int
AS
BEGIN
	 Update NoteBookId 
	Set FirstName = @FirstName, 
		LastName = @LastName, 
		YearOfBirth = @YearOfBirth, 
		PhoneNumber = @PhoneNumber 
		Where Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllByLastName]    Script Date: 19-May-18 1:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllByLastName]
	@LastName nvarchar(15)
AS
BEGIN
	 SELECT N.Id, 
	   N.FirstName,
	   N.LastName,
	   N.YearOfBirth,
	   N.PhoneNumber
		FROM dbo.NoteBookId N
		WHERE LastName = @LastName;
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllByName]    Script Date: 19-May-18 1:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllByName]
	@FirstName nvarchar(15)
AS
BEGIN
	 SELECT N.Id, 
	   N.FirstName,
	   N.LastName,
	   N.YearOfBirth,
	   N.PhoneNumber
		FROM dbo.NoteBookId N
		WHERE FirstName = @FirstName;
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllByPhone]    Script Date: 19-May-18 1:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllByPhone]
	@PhoneNum nvarchar(12)
AS
BEGIN
	 SELECT N.Id, 
	   N.FirstName,
	   N.LastName,
	   N.YearOfBirth,
	   N.PhoneNumber
		FROM dbo.NoteBookId N
		WHERE PhoneNumber = @PhoneNum;
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllNotes]    Script Date: 19-May-18 1:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllNotes]
	
AS
BEGIN
	 SELECT N.Id, 
	   N.FirstName,
	   N.LastName,
	   N.YearOfBirth,
	   N.PhoneNumber
		FROM dbo.NoteBookId N
END

GO
/****** Object:  StoredProcedure [dbo].[GetById]    Script Date: 19-May-18 1:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetById]
	@Id int
AS
BEGIN
	 Select * From NoteBookId Where Id = @Id;
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveNote]    Script Date: 19-May-18 1:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveNote]
	@Id int
AS
BEGIN
	 DELETE FROM NoteBookId
		WHERE Id = @Id;
END

GO
/****** Object:  StoredProcedure [dbo].[SortByLastName]    Script Date: 19-May-18 1:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SortByLastName]
	
AS
BEGIN
	SELECT * FROM NoteBookId ORDER BY LastName;
END

GO
/****** Object:  StoredProcedure [dbo].[SortByYear]    Script Date: 19-May-18 1:14:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SortByYear]
	
AS
BEGIN
	SELECT * FROM NoteBookId ORDER BY YearOfBirth;
END

GO
USE [master]
GO
ALTER DATABASE [NoteBook] SET  READ_WRITE 
GO
