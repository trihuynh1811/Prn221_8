USE [master]
GO
CREATE DATABASE [HoaLan]
 CONTAINMENT = NONE
GO
ALTER DATABASE [HoaLan] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HoaLan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HoaLan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HoaLan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HoaLan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HoaLan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HoaLan] SET ARITHABORT OFF 
GO
ALTER DATABASE [HoaLan] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HoaLan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HoaLan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HoaLan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HoaLan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HoaLan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HoaLan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HoaLan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HoaLan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HoaLan] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HoaLan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HoaLan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HoaLan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HoaLan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HoaLan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HoaLan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HoaLan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HoaLan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HoaLan] SET  MULTI_USER 
GO
ALTER DATABASE [HoaLan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HoaLan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HoaLan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HoaLan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HoaLan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HoaLan] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HoaLan] SET QUERY_STORE = OFF
GO
USE [HoaLan]
GO
/****** Object:  Table [dbo].[auction]    Script Date: 2/23/2024 6:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[auction](
	[auction_id] [int] IDENTITY(1,1) NOT NULL,
	[auction_name] [varchar](255) NULL,
	[price] [real] NOT NULL,
	[status] [bit] NOT NULL,
	[order_id] [int] NULL,
	[product] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[auction_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[auction_detail]    Script Date: 2/23/2024 6:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[auction_detail](
	[auction_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[host_id] [int] NOT NULL,
	[winner_id] [int] NOT NULL,
	[auction] [int] NULL,
	[participant] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[auction_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_detail]    Script Date: 2/23/2024 6:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_detail](
	[order_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[quantity] [int] NOT NULL,
	[orders] [int] NULL,
	[product] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 2/23/2024 6:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[order_date] [date] NULL,
	[status] [bit] NOT NULL,
	[order_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 2/23/2024 6:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](1000) NULL,
	[image] [varchar](max) NULL,
	[price] [real] NOT NULL,
	[product_name] [varchar](255) NULL,
	[status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[report]    Script Date: 2/23/2024 6:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[report](
	[report_id] [int] IDENTITY(1,1) NOT NULL,
	[report_content] [varchar](255) NULL,
	[product] [int] NULL,
	[report_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[report_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 2/23/2024 6:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 2/23/2024 6:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[address] [varchar](255) NULL,
	[first_name] [varchar](255) NULL,
	[last_name] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[phone_number] [varchar](255) NULL,
	[status] [bit] NOT NULL,
	[user_email] [varchar](255) NULL,
	[user_name] [varchar](255) NULL,
	[role] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [UK_bvlmyhb2isivkfvtp5kv3tpl0]    Script Date: 2/23/2024 6:36:25 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UK_bvlmyhb2isivkfvtp5kv3tpl0] ON [dbo].[auction]
(
	[order_id] ASC
)
WHERE ([order_id] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[auction]  WITH CHECK ADD  CONSTRAINT [FK1w78eyenem7jaulsfmrhmt1mk] FOREIGN KEY([product])
REFERENCES [dbo].[product] ([product_id])
GO
ALTER TABLE [dbo].[auction] CHECK CONSTRAINT [FK1w78eyenem7jaulsfmrhmt1mk]
GO
ALTER TABLE [dbo].[auction]  WITH CHECK ADD  CONSTRAINT [FKiepn1ayfrf4b659sg16t9rmjr] FOREIGN KEY([order_id])
REFERENCES [dbo].[orders] ([order_id])
GO
ALTER TABLE [dbo].[auction] CHECK CONSTRAINT [FKiepn1ayfrf4b659sg16t9rmjr]
GO
ALTER TABLE [dbo].[auction_detail]  WITH CHECK ADD  CONSTRAINT [FK5dygb3k049gmjcquym4ddub04] FOREIGN KEY([auction])
REFERENCES [dbo].[auction] ([auction_id])
GO
ALTER TABLE [dbo].[auction_detail] CHECK CONSTRAINT [FK5dygb3k049gmjcquym4ddub04]
GO
ALTER TABLE [dbo].[auction_detail]  WITH CHECK ADD  CONSTRAINT [FKcmi76t59v5sin7ee8ppp2xy94] FOREIGN KEY([participant])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[auction_detail] CHECK CONSTRAINT [FKcmi76t59v5sin7ee8ppp2xy94]
GO
ALTER TABLE [dbo].[order_detail]  WITH CHECK ADD  CONSTRAINT [FKd9sf38t1yu7b0gbcg6iyet4pv] FOREIGN KEY([product])
REFERENCES [dbo].[product] ([product_id])
GO
ALTER TABLE [dbo].[order_detail] CHECK CONSTRAINT [FKd9sf38t1yu7b0gbcg6iyet4pv]
GO
ALTER TABLE [dbo].[order_detail]  WITH CHECK ADD  CONSTRAINT [FKgn4buybec6yic8a026fnk27g8] FOREIGN KEY([orders])
REFERENCES [dbo].[orders] ([order_id])
GO
ALTER TABLE [dbo].[order_detail] CHECK CONSTRAINT [FKgn4buybec6yic8a026fnk27g8]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FKppaknh5o3u2q53jlykyw43gtf] FOREIGN KEY([order_by])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FKppaknh5o3u2q53jlykyw43gtf]
GO
ALTER TABLE [dbo].[report]  WITH CHECK ADD  CONSTRAINT [FKcmcakv0g86ueq3ixbirjeb6qu] FOREIGN KEY([product])
REFERENCES [dbo].[product] ([product_id])
GO
ALTER TABLE [dbo].[report] CHECK CONSTRAINT [FKcmcakv0g86ueq3ixbirjeb6qu]
GO
ALTER TABLE [dbo].[report]  WITH CHECK ADD  CONSTRAINT [FKpd4nf34id6tmasos9pa7xtmrv] FOREIGN KEY([report_by])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[report] CHECK CONSTRAINT [FKpd4nf34id6tmasos9pa7xtmrv]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK20wcxq3dnh6io9qug4vc90p0p] FOREIGN KEY([role])
REFERENCES [dbo].[role] ([role_id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK20wcxq3dnh6io9qug4vc90p0p]
GO
USE [master]
GO
ALTER DATABASE [HoaLan] SET  READ_WRITE 
GO
