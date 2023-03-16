USE [master]
GO
/****** Object:  Database [PAB2]    Script Date: 14.03.2023 16:04:42 ******/
CREATE DATABASE [PAB2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PAB2', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PAB2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PAB2_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PAB2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PAB2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PAB2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PAB2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PAB2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PAB2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PAB2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PAB2] SET ARITHABORT OFF 
GO
ALTER DATABASE [PAB2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PAB2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PAB2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PAB2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PAB2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PAB2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PAB2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PAB2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PAB2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PAB2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PAB2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PAB2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PAB2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PAB2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PAB2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PAB2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PAB2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PAB2] SET RECOVERY FULL 
GO
ALTER DATABASE [PAB2] SET  MULTI_USER 
GO
ALTER DATABASE [PAB2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PAB2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PAB2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PAB2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PAB2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PAB2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PAB2', N'ON'
GO
ALTER DATABASE [PAB2] SET QUERY_STORE = OFF
GO
USE [PAB2]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 14.03.2023 16:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ID] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 14.03.2023 16:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[ID] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayerItem]    Script Date: 14.03.2023 16:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerItem](
	[PlayerID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shop]    Script Date: 14.03.2023 16:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shop](
	[ID] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Shop] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShopItem]    Script Date: 14.03.2023 16:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopItem](
	[ShopID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PlayerItem]  WITH CHECK ADD  CONSTRAINT [FK_PlayerItem_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlayerItem] CHECK CONSTRAINT [FK_PlayerItem_Item]
GO
ALTER TABLE [dbo].[PlayerItem]  WITH CHECK ADD  CONSTRAINT [FK_PlayerItem_Player] FOREIGN KEY([PlayerID])
REFERENCES [dbo].[Player] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlayerItem] CHECK CONSTRAINT [FK_PlayerItem_Player]
GO
ALTER TABLE [dbo].[ShopItem]  WITH CHECK ADD  CONSTRAINT [FK_ShopItem_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShopItem] CHECK CONSTRAINT [FK_ShopItem_Item]
GO
ALTER TABLE [dbo].[ShopItem]  WITH CHECK ADD  CONSTRAINT [FK_ShopItem_Shop] FOREIGN KEY([ShopID])
REFERENCES [dbo].[Shop] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShopItem] CHECK CONSTRAINT [FK_ShopItem_Shop]
GO
USE [master]
GO
ALTER DATABASE [PAB2] SET  READ_WRITE 
GO
