USE [master]
GO
/****** Object:  Database [restaurant_db]    Script Date: 10.6.2025 г. 9:31:22 ******/
CREATE DATABASE [restaurant_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'restaurant_db', FILENAME = N'D:\CodeWeek2023\SQL Server 2022 Developer\MSSQL16.MSSQLSERVER\MSSQL\DATA\restaurant_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'restaurant_db_log', FILENAME = N'D:\CodeWeek2023\SQL Server 2022 Developer\MSSQL16.MSSQLSERVER\MSSQL\DATA\restaurant_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [restaurant_db] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [restaurant_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [restaurant_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [restaurant_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [restaurant_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [restaurant_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [restaurant_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [restaurant_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [restaurant_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [restaurant_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [restaurant_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [restaurant_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [restaurant_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [restaurant_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [restaurant_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [restaurant_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [restaurant_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [restaurant_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [restaurant_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [restaurant_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [restaurant_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [restaurant_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [restaurant_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [restaurant_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [restaurant_db] SET RECOVERY FULL 
GO
ALTER DATABASE [restaurant_db] SET  MULTI_USER 
GO
ALTER DATABASE [restaurant_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [restaurant_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [restaurant_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [restaurant_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [restaurant_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [restaurant_db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'restaurant_db', N'ON'
GO
ALTER DATABASE [restaurant_db] SET QUERY_STORE = ON
GO
ALTER DATABASE [restaurant_db] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [restaurant_db]
GO
/****** Object:  Table [dbo].[operating_hours]    Script Date: 10.6.2025 г. 9:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[operating_hours](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[day_of_week] [varchar](50) NOT NULL,
	[start_time] [time](7) NOT NULL,
	[end_time] [time](7) NOT NULL,
	[table_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reservations]    Script Date: 10.6.2025 г. 9:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reservations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[phone_number] [varchar](20) NOT NULL,
	[table_id] [int] NULL,
	[created_at] [datetime] NULL,
	[operating_hours_id] [int] NULL,
	[reservation_date] [date] NOT NULL,
	[canceled_at] [datetime] NULL,
	[notes] [text] NULL,
	[verification_code] [varchar](50) NULL,
	[verified_by_user] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[restaurant_tables]    Script Date: 10.6.2025 г. 9:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[restaurant_tables](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[number] [int] NOT NULL,
	[type] [varchar](50) NOT NULL,
	[description] [text] NULL,
	[created_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[special_occasion]    Script Date: 10.6.2025 г. 9:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[special_occasion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[table_id] [int] NULL,
	[start_time] [datetime] NOT NULL,
	[end_time] [datetime] NOT NULL,
	[description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 10.6.2025 г. 9:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[role] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[operating_hours] ON 
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (1, N'Monday', CAST(N'09:00:00' AS Time), CAST(N'11:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2, N'Monday', CAST(N'11:00:00' AS Time), CAST(N'13:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (3, N'Monday', CAST(N'13:00:00' AS Time), CAST(N'15:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (4, N'Monday', CAST(N'15:00:00' AS Time), CAST(N'17:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (5, N'Monday', CAST(N'17:00:00' AS Time), CAST(N'19:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (6, N'Monday', CAST(N'19:00:00' AS Time), CAST(N'21:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (7, N'Tuesday', CAST(N'09:00:00' AS Time), CAST(N'11:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (8, N'Tuesday', CAST(N'11:00:00' AS Time), CAST(N'13:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (9, N'Tuesday', CAST(N'13:00:00' AS Time), CAST(N'15:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (10, N'Tuesday', CAST(N'15:00:00' AS Time), CAST(N'17:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (11, N'Tuesday', CAST(N'17:00:00' AS Time), CAST(N'19:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (12, N'Tuesday', CAST(N'19:00:00' AS Time), CAST(N'21:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (13, N'Wednesday', CAST(N'09:00:00' AS Time), CAST(N'11:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (14, N'Wednesday', CAST(N'11:00:00' AS Time), CAST(N'13:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (15, N'Wednesday', CAST(N'13:00:00' AS Time), CAST(N'15:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (16, N'Wednesday', CAST(N'15:00:00' AS Time), CAST(N'17:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (17, N'Wednesday', CAST(N'17:00:00' AS Time), CAST(N'19:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (18, N'Wednesday', CAST(N'19:00:00' AS Time), CAST(N'21:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (19, N'Thursday', CAST(N'09:00:00' AS Time), CAST(N'11:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (20, N'Thursday', CAST(N'11:00:00' AS Time), CAST(N'13:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (21, N'Thursday', CAST(N'13:00:00' AS Time), CAST(N'15:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (22, N'Thursday', CAST(N'15:00:00' AS Time), CAST(N'17:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (23, N'Thursday', CAST(N'17:00:00' AS Time), CAST(N'19:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (24, N'Thursday', CAST(N'19:00:00' AS Time), CAST(N'21:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (25, N'Friday', CAST(N'09:00:00' AS Time), CAST(N'11:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (26, N'Friday', CAST(N'11:00:00' AS Time), CAST(N'13:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (27, N'Friday', CAST(N'13:00:00' AS Time), CAST(N'15:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (28, N'Friday', CAST(N'15:00:00' AS Time), CAST(N'17:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (29, N'Friday', CAST(N'17:00:00' AS Time), CAST(N'19:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (30, N'Friday', CAST(N'19:00:00' AS Time), CAST(N'21:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (31, N'Saturday', CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (32, N'Saturday', CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (33, N'Saturday', CAST(N'14:00:00' AS Time), CAST(N'16:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (34, N'Saturday', CAST(N'16:00:00' AS Time), CAST(N'18:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (35, N'Saturday', CAST(N'17:00:00' AS Time), CAST(N'19:00:00' AS Time), 1)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (36, N'Monday', CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), 7)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (37, N'Monday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 7)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (39, N'Monday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 11)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (40, N'Monday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 12)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (41, N'Monday', CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), 7)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (43, N'Monday', CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), 11)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (44, N'Monday', CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), 12)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (45, N'Monday', CAST(N'19:00:00' AS Time), CAST(N'20:00:00' AS Time), 7)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (46, N'Monday', CAST(N'19:00:00' AS Time), CAST(N'20:00:00' AS Time), 10)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (47, N'Monday', CAST(N'19:00:00' AS Time), CAST(N'20:00:00' AS Time), 11)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (48, N'Monday', CAST(N'19:00:00' AS Time), CAST(N'20:00:00' AS Time), 12)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (49, N'Tuesday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 7)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (50, N'Tuesday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 10)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (51, N'Tuesday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 11)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (52, N'Tuesday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 12)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (53, N'Tuesday', CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), 7)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (54, N'Tuesday', CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), 10)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (55, N'Tuesday', CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), 11)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (56, N'Tuesday', CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), 12)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (57, N'Tuesday', CAST(N'19:00:00' AS Time), CAST(N'20:00:00' AS Time), 7)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (58, N'Tuesday', CAST(N'19:00:00' AS Time), CAST(N'20:00:00' AS Time), 10)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (59, N'Tuesday', CAST(N'19:00:00' AS Time), CAST(N'20:00:00' AS Time), 11)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (60, N'Tuesday', CAST(N'19:00:00' AS Time), CAST(N'20:00:00' AS Time), 12)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (61, N'Friday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 7)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (62, N'Friday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 10)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (63, N'Friday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 11)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (64, N'Friday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 12)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (65, N'Friday', CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), 7)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (66, N'Friday', CAST(N'15:00:00' AS Time), CAST(N'16:00:00' AS Time), 10)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (1036, N'Sunday', CAST(N'00:12:00' AS Time), CAST(N'01:00:00' AS Time), 3)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (1037, N'Sunday', CAST(N'00:12:00' AS Time), CAST(N'01:00:00' AS Time), 7)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (1038, N'Sunday', CAST(N'03:30:00' AS Time), CAST(N'04:00:00' AS Time), 3)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (1039, N'Sunday', CAST(N'03:30:00' AS Time), CAST(N'04:00:00' AS Time), 7)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (1040, N'Monday', CAST(N'00:12:00' AS Time), CAST(N'01:00:00' AS Time), 3)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (1041, N'Monday', CAST(N'00:12:00' AS Time), CAST(N'01:00:00' AS Time), 7)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (1043, N'Monday', CAST(N'03:31:00' AS Time), CAST(N'04:01:00' AS Time), 7)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2036, N'Sunday', CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), 1008)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2037, N'Sunday', CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), 4004)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2038, N'Sunday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 1008)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2039, N'Sunday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 4004)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2040, N'Sunday', CAST(N'21:00:00' AS Time), CAST(N'22:00:00' AS Time), 1008)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2041, N'Sunday', CAST(N'21:00:00' AS Time), CAST(N'22:00:00' AS Time), 4004)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2042, N'Friday', CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), 1008)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2043, N'Friday', CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), 4004)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2044, N'Friday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 1008)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2045, N'Friday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 4004)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2046, N'Friday', CAST(N'21:00:00' AS Time), CAST(N'22:00:00' AS Time), 1008)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2047, N'Friday', CAST(N'21:00:00' AS Time), CAST(N'22:00:00' AS Time), 4004)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2048, N'Saturday', CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), 1008)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2049, N'Saturday', CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), 4004)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2050, N'Saturday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 1008)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2051, N'Saturday', CAST(N'12:00:00' AS Time), CAST(N'12:30:00' AS Time), 4004)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2052, N'Saturday', CAST(N'21:00:00' AS Time), CAST(N'22:00:00' AS Time), 1008)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2053, N'Saturday', CAST(N'21:00:00' AS Time), CAST(N'22:00:00' AS Time), 4004)
GO
INSERT [dbo].[operating_hours] ([id], [day_of_week], [start_time], [end_time], [table_id]) VALUES (2054, N'Thursday', CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), 1005)
GO
SET IDENTITY_INSERT [dbo].[operating_hours] OFF
GO
SET IDENTITY_INSERT [dbo].[reservations] ON 
GO
INSERT [dbo].[reservations] ([id], [name], [email], [phone_number], [table_id], [created_at], [operating_hours_id], [reservation_date], [canceled_at], [notes], [verification_code], [verified_by_user]) VALUES (1009, N'Mitkoto', N'mitko@example.com', N'352567890', 1, CAST(N'2025-05-08T00:24:15.470' AS DateTime), 1, CAST(N'2025-06-08' AS Date), NULL, N'Birthday dinner', N'ABC123', 1)
GO
INSERT [dbo].[reservations] ([id], [name], [email], [phone_number], [table_id], [created_at], [operating_hours_id], [reservation_date], [canceled_at], [notes], [verification_code], [verified_by_user]) VALUES (1010, N'Bob Meow', N'bosssb@example.com', N'+325235', 2, CAST(N'2025-05-08T00:24:15.470' AS DateTime), 2, CAST(N'2025-05-19' AS Date), NULL, NULL, N'XYZ789', 1)
GO
INSERT [dbo].[reservations] ([id], [name], [email], [phone_number], [table_id], [created_at], [operating_hours_id], [reservation_date], [canceled_at], [notes], [verification_code], [verified_by_user]) VALUES (1011, N'Mitkoto', N'mmmmmalice@example.com', N'352567890', 1, CAST(N'2025-05-08T01:40:31.373' AS DateTime), 1, CAST(N'2025-04-08' AS Date), NULL, N'Birthday dinner', N'ABC123', 0)
GO
INSERT [dbo].[reservations] ([id], [name], [email], [phone_number], [table_id], [created_at], [operating_hours_id], [reservation_date], [canceled_at], [notes], [verification_code], [verified_by_user]) VALUES (1013, N'Mitkoto', N'mmmmmalice@example.com', N'352567890', 1, CAST(N'2025-05-08T01:41:22.730' AS DateTime), 1, CAST(N'2025-04-08' AS Date), CAST(N'2025-05-08T00:00:00.000' AS DateTime), N'Birthday dinner', N'ABC123', 0)
GO
INSERT [dbo].[reservations] ([id], [name], [email], [phone_number], [table_id], [created_at], [operating_hours_id], [reservation_date], [canceled_at], [notes], [verification_code], [verified_by_user]) VALUES (1014, N'Bob Meow', N'bosssb@example.com', N'+325235', 2, CAST(N'2025-05-08T01:41:22.730' AS DateTime), 2, CAST(N'2025-02-22' AS Date), CAST(N'2025-04-01T00:00:00.000' AS DateTime), NULL, N'XYZ789', 1)
GO
INSERT [dbo].[reservations] ([id], [name], [email], [phone_number], [table_id], [created_at], [operating_hours_id], [reservation_date], [canceled_at], [notes], [verification_code], [verified_by_user]) VALUES (1015, N'Todor', N'nnazifov44@gmail.com', N'567890', 7, CAST(N'2025-05-08T09:50:01.543' AS DateTime), 37, CAST(N'2025-05-12' AS Date), NULL, N'asdfghjk', N'KskzPWEV', 1)
GO
INSERT [dbo].[reservations] ([id], [name], [email], [phone_number], [table_id], [created_at], [operating_hours_id], [reservation_date], [canceled_at], [notes], [verification_code], [verified_by_user]) VALUES (2003, N'ToshkoY', N'todoryanakiev395@gmail.com', N'0879130205', 7, CAST(N'2025-05-10T12:05:15.993' AS DateTime), 36, CAST(N'2025-05-12' AS Date), NULL, N'Mau', N'Dw0Z9N9A', 1)
GO
INSERT [dbo].[reservations] ([id], [name], [email], [phone_number], [table_id], [created_at], [operating_hours_id], [reservation_date], [canceled_at], [notes], [verification_code], [verified_by_user]) VALUES (2004, N'mrjthrg', N'todoryanakiev395@gmail.com', N'857738', 7, CAST(N'2025-05-10T12:08:40.497' AS DateTime), 36, CAST(N'2025-05-05' AS Date), NULL, N'mrhergf', N'sORTv90e', 1)
GO
INSERT [dbo].[reservations] ([id], [name], [email], [phone_number], [table_id], [created_at], [operating_hours_id], [reservation_date], [canceled_at], [notes], [verification_code], [verified_by_user]) VALUES (3003, N'Nersan', N'nnazifov44@gmail.com', N'6969696969', 7, CAST(N'2025-06-02T08:34:01.227' AS DateTime), 49, CAST(N'2025-06-03' AS Date), NULL, N'Ти си мазен гей', N'5l1DBdtS', 0)
GO
INSERT [dbo].[reservations] ([id], [name], [email], [phone_number], [table_id], [created_at], [operating_hours_id], [reservation_date], [canceled_at], [notes], [verification_code], [verified_by_user]) VALUES (3004, N'Toshko', N'todoryanakiev395@gmail.com', N'508694536', 7, CAST(N'2025-06-02T08:35:47.383' AS DateTime), 61, CAST(N'2025-06-13' AS Date), NULL, N'lyktrue5yte', N'RgSU9WqA', 1)
GO
INSERT [dbo].[reservations] ([id], [name], [email], [phone_number], [table_id], [created_at], [operating_hours_id], [reservation_date], [canceled_at], [notes], [verification_code], [verified_by_user]) VALUES (3005, N'Mtko', N'todoryanakiev395@gmail.com', N'936843564', 7, CAST(N'2025-06-02T08:41:43.340' AS DateTime), 37, CAST(N'2025-06-02' AS Date), NULL, N'yjthrgagrhtjdryftyjrhtgd', N'AIhCrwP6', 1)
GO
INSERT [dbo].[reservations] ([id], [name], [email], [phone_number], [table_id], [created_at], [operating_hours_id], [reservation_date], [canceled_at], [notes], [verification_code], [verified_by_user]) VALUES (3006, N'Toshko2', N'todoryanakiev395@gmail.com', N'85696756', 7, CAST(N'2025-06-02T08:42:25.973' AS DateTime), 41, CAST(N'2025-06-02' AS Date), NULL, N'luri75durxthrjytf7kt seetj', N'tYHFaT9d', 0)
GO
INSERT [dbo].[reservations] ([id], [name], [email], [phone_number], [table_id], [created_at], [operating_hours_id], [reservation_date], [canceled_at], [notes], [verification_code], [verified_by_user]) VALUES (3009, N'Nersan1', N'todoryanakiev395@gmail.com', N'76854765', 7, CAST(N'2025-06-02T09:12:19.147' AS DateTime), 36, CAST(N'2025-06-02' AS Date), NULL, N'ryxdctfyubhi', N'pUgtN6L0', 1)
GO
SET IDENTITY_INSERT [dbo].[reservations] OFF
GO
SET IDENTITY_INSERT [dbo].[restaurant_tables] ON 
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (1, 1, N'standard', N'Near the window', CAST(N'2025-04-07T08:28:11.407' AS DateTime), CAST(N'2025-05-09T13:59:57.127' AS DateTime))
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (2, 699, N'Standard', N'Private roomhgs', CAST(N'2025-04-07T08:28:11.407' AS DateTime), CAST(N'2025-05-09T23:08:57.853' AS DateTime))
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (3, 3, N'Outdoor', N'Garden view', CAST(N'2025-04-07T08:28:11.407' AS DateTime), NULL)
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (7, 0, N'Outdoor', N'gastg', CAST(N'2025-05-03T15:51:11.407' AS DateTime), NULL)
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (10, 5, N'vip', N'gastg', CAST(N'2025-05-03T15:57:45.263' AS DateTime), NULL)
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (11, 6, N'vip', N'gastg', CAST(N'2025-05-03T15:57:51.667' AS DateTime), NULL)
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (12, 7, N'vip', N'gastg', CAST(N'2025-05-03T15:57:59.307' AS DateTime), NULL)
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (1005, 69, N'standard', N'', CAST(N'2025-05-08T03:11:53.747' AS DateTime), NULL)
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (1006, 97, N'vip', N'very vip ', CAST(N'2025-05-08T03:16:04.837' AS DateTime), NULL)
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (1007, 345, N'outdoor', N'mfdhsgf', CAST(N'2025-05-08T09:28:28.560' AS DateTime), NULL)
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (1008, 54, N'outdoor', N'dfghjk', CAST(N'2025-05-08T09:48:01.120' AS DateTime), NULL)
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (2004, 666, N'Outdoor', N'Standard table', CAST(N'2025-05-10T01:56:30.873' AS DateTime), CAST(N'2025-06-10T00:12:16.650' AS DateTime))
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (3004, 32121, N'Outdoor', N'аааааа', CAST(N'2025-06-02T09:14:58.920' AS DateTime), CAST(N'2025-06-02T09:15:25.150' AS DateTime))
GO
INSERT [dbo].[restaurant_tables] ([id], [number], [type], [description], [created_at], [deleted_at]) VALUES (4004, 2635, N'standard', N'', CAST(N'2025-06-10T00:12:27.377' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[restaurant_tables] OFF
GO
SET IDENTITY_INSERT [dbo].[special_occasion] ON 
GO
INSERT [dbo].[special_occasion] ([id], [table_id], [start_time], [end_time], [description]) VALUES (4, 3, CAST(N'2025-05-24T10:01:20.727' AS DateTime), CAST(N'2025-05-24T21:01:20.713' AS DateTime), N'почивка преди банкети')
GO
INSERT [dbo].[special_occasion] ([id], [table_id], [start_time], [end_time], [description]) VALUES (5, 2004, CAST(N'2025-05-12T01:56:56.433' AS DateTime), CAST(N'2025-05-13T01:56:56.433' AS DateTime), N'rest')
GO
INSERT [dbo].[special_occasion] ([id], [table_id], [start_time], [end_time], [description]) VALUES (6, 12, CAST(N'2025-05-11T02:25:43.920' AS DateTime), CAST(N'2025-05-11T22:25:43.917' AS DateTime), N'meoqww')
GO
INSERT [dbo].[special_occasion] ([id], [table_id], [start_time], [end_time], [description]) VALUES (7, 12, CAST(N'2025-05-13T15:30:48.957' AS DateTime), CAST(N'2025-05-13T19:45:48.947' AS DateTime), N'Ей така')
GO
INSERT [dbo].[special_occasion] ([id], [table_id], [start_time], [end_time], [description]) VALUES (8, 7, CAST(N'2025-05-13T15:12:55.217' AS DateTime), CAST(N'2025-05-13T19:44:55.207' AS DateTime), N'ей така')
GO
INSERT [dbo].[special_occasion] ([id], [table_id], [start_time], [end_time], [description]) VALUES (1003, 7, CAST(N'2025-06-09T08:46:02.723' AS DateTime), CAST(N'2025-06-09T22:46:02.713' AS DateTime), N'ПОЧИВКА')
GO
INSERT [dbo].[special_occasion] ([id], [table_id], [start_time], [end_time], [description]) VALUES (1004, 7, CAST(N'2025-06-02T09:16:31.557' AS DateTime), CAST(N'2025-06-02T23:16:31.543' AS DateTime), N'rstrdfy')
GO
INSERT [dbo].[special_occasion] ([id], [table_id], [start_time], [end_time], [description]) VALUES (2003, 7, CAST(N'2025-06-10T00:14:20.520' AS DateTime), CAST(N'2025-06-10T00:22:20.503' AS DateTime), N'')
GO
SET IDENTITY_INSERT [dbo].[special_occasion] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 
GO
INSERT [dbo].[users] ([id], [username], [password], [role]) VALUES (1, N'Todor', N'pass123', N'admin')
GO
INSERT [dbo].[users] ([id], [username], [password], [role]) VALUES (2, N'Nadezhda', N'pass123', N'admin')
GO
INSERT [dbo].[users] ([id], [username], [password], [role]) VALUES (3, N'Sofia', N'pass123', N'admin')
GO
INSERT [dbo].[users] ([id], [username], [password], [role]) VALUES (1005, N'Toshko', N'vZTc2ib8y05o1qMfm1qsC1ca4mbYImIOkB736+OhHU8=', N'Admin')
GO
INSERT [dbo].[users] ([id], [username], [password], [role]) VALUES (2004, N'Mecho', N'vZTc2ib8y05o1qMfm1qsC1ca4mbYImIOkB736+OhHU8=', N'Admin')
GO
INSERT [dbo].[users] ([id], [username], [password], [role]) VALUES (2005, N'Nadezhda1', N'XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=', N'Admin')
GO
INSERT [dbo].[users] ([id], [username], [password], [role]) VALUES (3004, N'Toshko22', N'vZTc2ib8y05o1qMfm1qsC1ca4mbYImIOkB736+OhHU8=', N'Admin')
GO
SET IDENTITY_INSERT [dbo].[users] OFF
GO
/****** Object:  Index [UQ__restaura__FD291E416CFBB508]    Script Date: 10.6.2025 г. 9:31:23 ******/
ALTER TABLE [dbo].[restaurant_tables] ADD UNIQUE NONCLUSTERED 
(
	[number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__users__F3DBC572174D544A]    Script Date: 10.6.2025 г. 9:31:23 ******/
ALTER TABLE [dbo].[users] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[reservations] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[reservations] ADD  DEFAULT ((0)) FOR [verified_by_user]
GO
ALTER TABLE [dbo].[restaurant_tables] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[operating_hours]  WITH CHECK ADD FOREIGN KEY([table_id])
REFERENCES [dbo].[restaurant_tables] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[reservations]  WITH CHECK ADD FOREIGN KEY([operating_hours_id])
REFERENCES [dbo].[operating_hours] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[reservations]  WITH CHECK ADD FOREIGN KEY([table_id])
REFERENCES [dbo].[restaurant_tables] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[special_occasion]  WITH CHECK ADD FOREIGN KEY([table_id])
REFERENCES [dbo].[restaurant_tables] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[operating_hours]  WITH CHECK ADD CHECK  (([day_of_week]='Sunday' OR [day_of_week]='Saturday' OR [day_of_week]='Friday' OR [day_of_week]='Thursday' OR [day_of_week]='Wednesday' OR [day_of_week]='Tuesday' OR [day_of_week]='Monday'))
GO
ALTER TABLE [dbo].[restaurant_tables]  WITH CHECK ADD CHECK  (([type]='outdoor' OR [type]='vip' OR [type]='standard'))
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD CHECK  (([role]='customer' OR [role]='staff' OR [role]='admin'))
GO
USE [master]
GO
ALTER DATABASE [restaurant_db] SET  READ_WRITE 
GO
