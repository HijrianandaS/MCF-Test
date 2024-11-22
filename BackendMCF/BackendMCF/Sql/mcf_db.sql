USE [master]
GO
/****** Object:  Database [mcf_db]    Script Date: 20/11/2024 21:45:08 ******/
CREATE DATABASE [mcf_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mcf_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\mcf_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'mcf_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\mcf_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [mcf_db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mcf_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mcf_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [mcf_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [mcf_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [mcf_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [mcf_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [mcf_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [mcf_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mcf_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mcf_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mcf_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [mcf_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [mcf_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mcf_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [mcf_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mcf_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [mcf_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mcf_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mcf_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mcf_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mcf_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mcf_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [mcf_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mcf_db] SET RECOVERY FULL 
GO
ALTER DATABASE [mcf_db] SET  MULTI_USER 
GO
ALTER DATABASE [mcf_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mcf_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mcf_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mcf_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [mcf_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [mcf_db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'mcf_db', N'ON'
GO
ALTER DATABASE [mcf_db] SET QUERY_STORE = OFF
GO
USE [mcf_db]
GO
/****** Object:  Table [dbo].[ms_storage_location]    Script Date: 20/11/2024 21:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ms_storage_location](
	[location_id] [nvarchar](10) NOT NULL,
	[location_name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ms_storage_location] PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ms_user]    Script Date: 20/11/2024 21:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ms_user](
	[user_id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](20) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[is_active] [bit] NOT NULL,
 CONSTRAINT [PK_ms_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tr_bpkb]    Script Date: 20/11/2024 21:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tr_bpkb](
	[agreement_number] [nvarchar](100) NOT NULL,
	[bpkb_no] [nvarchar](100) NOT NULL,
	[branch_id] [nvarchar](10) NOT NULL,
	[bpkb_date] [datetime2](7) NOT NULL,
	[faktur_no] [nvarchar](100) NOT NULL,
	[faktur_date] [datetime2](7) NOT NULL,
	[location_id] [nvarchar](10) NOT NULL,
	[police_no] [nvarchar](20) NOT NULL,
	[bpkb_date_in] [datetime2](7) NOT NULL,
	[created_by] [nvarchar](20) NOT NULL,
	[created_on] [datetime2](7) NOT NULL,
	[last_updated_by] [nvarchar](20) NOT NULL,
	[last_updated_on] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_tr_bpkb] PRIMARY KEY CLUSTERED 
(
	[agreement_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ms_storage_location] ([location_id], [location_name]) VALUES (N'LOC001', N'Storage A')
INSERT [dbo].[ms_storage_location] ([location_id], [location_name]) VALUES (N'LOC002', N'Storage B')
INSERT [dbo].[ms_storage_location] ([location_id], [location_name]) VALUES (N'LOC003', N'Storage C')
INSERT [dbo].[ms_storage_location] ([location_id], [location_name]) VALUES (N'LOC004', N'Storage D')
GO
SET IDENTITY_INSERT [dbo].[ms_user] ON 

INSERT [dbo].[ms_user] ([user_id], [user_name], [password], [is_active]) VALUES (1, N'jhonUmiro', N'admin1*', 1)
INSERT [dbo].[ms_user] ([user_id], [user_name], [password], [is_active]) VALUES (2, N'trisNatan', N'admin2@', 1)
INSERT [dbo].[ms_user] ([user_id], [user_name], [password], [is_active]) VALUES (3, N'hugoRess', N'admin3#', 0)
SET IDENTITY_INSERT [dbo].[ms_user] OFF
GO
USE [master]
GO
ALTER DATABASE [mcf_db] SET  READ_WRITE 
GO
