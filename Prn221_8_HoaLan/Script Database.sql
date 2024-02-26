USE [master]
GO
/****** Object:  Database [HoaLan]    Script Date: 2/26/2024 2:54:16 PM ******/
CREATE DATABASE [HoaLan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HoaLan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.GAHONGHAC\MSSQL\DATA\HoaLan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HoaLan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.GAHONGHAC\MSSQL\DATA\HoaLan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
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
EXEC sys.sp_db_vardecimal_storage_format N'HoaLan', N'ON'
GO
ALTER DATABASE [HoaLan] SET QUERY_STORE = OFF
GO
USE [HoaLan]
GO
/****** Object:  Table [dbo].[auction]    Script Date: 2/26/2024 2:54:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[auction](
	[auction_id] [int] IDENTITY(1,1) NOT NULL,
	[auction_name] [nvarchar](100) NULL,
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
/****** Object:  Table [dbo].[auction_detail]    Script Date: 2/26/2024 2:54:16 PM ******/
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
/****** Object:  Table [dbo].[order_detail]    Script Date: 2/26/2024 2:54:16 PM ******/
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
/****** Object:  Table [dbo].[orders]    Script Date: 2/26/2024 2:54:16 PM ******/
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
/****** Object:  Table [dbo].[product]    Script Date: 2/26/2024 2:54:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](1000) NULL,
	[image] [varchar](max) NULL,
	[price] [real] NOT NULL,
	[product_name] [nvarchar](100) NULL,
	[status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[report]    Script Date: 2/26/2024 2:54:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[report](
	[report_id] [int] IDENTITY(1,1) NOT NULL,
	[report_content] [nvarchar](255) NULL,
	[product] [int] NULL,
	[report_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[report_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 2/26/2024 2:54:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 2/26/2024 2:54:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[address] [nvarchar](200) NULL,
	[first_name] [nvarchar](100) NULL,
	[last_name] [nvarchar](100) NULL,
	[password] [varchar](255) NULL,
	[phone_number] [varchar](255) NULL,
	[status] [bit] NOT NULL,
	[user_email] [varchar](255) NULL,
	[user_name] [varchar](100) NULL,
	[role] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[role] ON 

INSERT [dbo].[role] ([role_id], [role_name]) VALUES (1, N'Administrator')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (2, N'Staff')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (3, N'Product Owner')
INSERT [dbo].[role] ([role_id], [role_name]) VALUES (4, N'Customer')
SET IDENTITY_INSERT [dbo].[role] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (2, N'300 Võ Văn Ngân, p, Thủ Đức, Thành phố Hồ Chí Minh ', N'Minh Trí', N'Nguyễn', N'123456@', N'0706699123', 1, N'minhtri@gmail.com', N'admin', 1)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (3, N'1 Võ Văn Ngân, Linh Chiểu, Thủ Đức, Thành phố Hồ Chí Minh', N'Tuấn Anh', N'Nguyễn', N'st123456', N'0707893182', 1, N'tuananh@gmail.com', N'sttuananh', 2)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (5, N'58 3 Tân Lập 1, Hiệp Phú, Quận 9, Thành phố Hồ Chí Minh ', N'Điền Minh', N'Tạ', N'st123456', N'8133499258', 1, N'tadienminh@gmail.com', N'stdienminh', 2)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (6, N'381 Lê Văn Việt, Tăng Nhơn Phú A, Quận 9, Thành phố Hồ Chí Minh', N'Thanh Thiên', N'Bao', N'st123456', N'9214871272', 1, N'baothanh@gmail.com', N'stbaothanhthien', 2)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (8, N'Long Thạnh Mỹ, Quận 9, Ho Chi Minh City', N'Hoàng', N'Nguyễn', N'st123123', N'9217492114', 1, N'nguyenhoang@gmail.com', N'stnguyenhoang', 2)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (9, N'Đường D2, Tăng Nhơn Phú B, Quận 9, Thành phố Hồ Chí Minh', N'Minh', N'Trần', N'123@123a', N'7264616222', 1, N'tranminh123@gmail.com', N'tranminh123', 3)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (10, N'Quận Ninh Kiều, Cần Thơ', N'Tạ', N'Trần', N'123@123a', N'8283311112', 1, N'tatran2k2cute@gmail.com', N'tatran2k2', 3)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (41, N'23 Nguyễn Du, Quận 1, Thành phố Hồ Chí Minh', N'Lê Thị', N'Hồng', N'123@123a', N'0987654321', 1, N'lethihong@gmail.com', N'lethihong', 3)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (42, N'456 Lê Văn Sỹ, Quận 3, Thành phố Hồ Chí Minh', N'Lê Công', N'Minh', N'133@123a', N'0912345678', 1, N'lecongminh@gmail.com', N'lecongminh', 3)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (43, N'789 Cầu Giấy, Quận Cầu Giấy, Hà Nội', N'Lê Tuấn', N'Anh', N'123@123a', N'0978563412', 1, N'letuananh@gmail.com', N'letuananh', 3)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (44, N'101 Trần Hưng Đạo, Quận Hoàn Kiếm, Hà Nội', N'Lê Minh', N'Quang', N'123@123a', N'0965432187', 1, N'leminhquang@gmail.com', N'leminhquang', 3)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (45, N'202 Hải Phòng, Quận Ngô Quyền, Hải Phòng', N'Nguyễn Văn', N'Hải', N'123@123a', N'0901234567', 1, N'nguyenvanhai@gmail.com', N'nguyenvanha', 3)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (46, N'303 Lý Tự Trọng, Quận Thanh Khê, Đà Nẵng', N'Nguyễn Thị Tú', N'Lan', N'123@123a', N'0943216785', 1, N'nguyenthitulan@gmail.com', N'nguyenthitulan', 3)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (47, N'404 Hùng Vương, Quận Ninh Kiều, Cần Thơ', N'Nguyễn Bá', N'Hoàng', N'123@123a', N'0938765432', 1, N'bahoang@gmail.com', N'bahoang', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (48, N'505 Điện Biên Phủ, Quận Thanh Khê, Đà Nẵng', N'Nguyễn Minh', N'Bình', N'123@123a', N'0923456781', 1, N'binhminhnguyen@gmail.com', N'binhminhnguyen', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (49, N'606 Lê Lai, Quận Ninh Kiều, Cần Thơ', N'Nguyễn Nhật', N'Dương', N'123@123a', N'0956783412', 1, N'duongnguyen@gmail.com', N'duongnguyen', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (50, N'606 Lê Lai, Quận Ninh Kiều, Cần Thơ', N'Trần Đại', N'Thành', N'123@123a', N'0998765123', 1, N'thanhdai2k2@gmail.com', N'thanhdai2k2', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (51, N'808 Đường 2 Tháng 9, Quận 1, Thành phố Hồ Chí Minh', N'Trần Minh', N'Ngọc', N'123@123a', N'0981234567', 1, N'ngocminh2k3@gmail.com', N'ngocminh2k3', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (52, N'909 Phan Chu Trinh, Quận Hoàn Kiếm, Hà Nội', N'Trần Tú', N'Quỳnh', N'123@123a', N'0967812345', 1, N'tuquynhcute@gmail.com', N'tuquynhcute', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (53, N'909 Phan Chu Trinh, Quận Hoàn Kiếm, Hà Nội', N'Trần Bạch', N'Mai', N'123@123a', N'0918765432', 1, N'maibachfla@gmail.com', N'maibachfla', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (54, N'1111 Phan Đăng Lưu, Quận Bình Thạnh, Thành phố Hồ Chí Minh', N'Vũ', N'Long', N'123@123a', N'0945123786', 1, N'vulongk16@gmail.com', N'vulongk16', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (55, N'1212 Bùi Thị Xuân, Quận 1, Thành phố Hồ Chí Minh', N'Vũ Tuấn', N'Kiệt', N'123@123a', N'0976543218', 1, N'kiettuanvu@gmail.com', N'kiettuanvu', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (56, N'1313 Lê Quý Đôn, Quận Bình Thạnh, Thành phố Hồ Chí Minh', N'Vũ Ngọc', N'Ngân', N'123@123a', N'0934125678', 1, N'vuhaho@gmail.com', N'vuhaho', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (57, N'1414 Nguyễn Trãi, Quận 5, Thành phố Hồ Chí Minh', N'Vũ Hồ', N'Hà', N'123@123a', N'0909876123', 1, N'khanhlinh2k2@gmail.com', N'khanhlinh2k2', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (58, N'1515 Quang Trung, Quận Hải Châu, Đà Nẵng', N'Vũ Linh', N'Khánh', N'123@123a', N'0956781234', 1, N'huu2910@gmail.com', N'huu2910', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (59, N'1717 Trần Phú, Quận Hồng Bàng, Hải Phòng', N'Đặng Trần', N'Hữu', N'123@123a', N'0923456789', 1, N'huong211023@gmail.com', N'huong211023', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (60, N'1616 Nguyễn Trãi, Quận 1, Thành phố Hồ Chí Minh', N'Minh', N'Hương', N'123@123a', N'0934567128', 1, N'trung112341@gmail.com', N'trung112341', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (61, N'Lê Lai, Quận Ninh Kiều, Cần Thơ', N'Đặng Tuấn', N'Trung', N'123@123a', N'0998765123', 1, N'nguyetngoc1234@gmail.com', N'nguyetngoc1234', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (62, N'101 Trần Hưng Đạo, Quận Hoàn Kiếm, Hà Nội', N'Đặng Ngọc', N'Nguyệt', N'123@123a', N'0978563412', 1, N'namdangtran23124@gmail.com', N'namdangtran23124', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (63, N'Lê Lai, Quận Ninh Kiều, Cần Thơ', N'Đặng Trần', N'Nam', N'123@123a', N'0901234567', 1, N'phuong213141@gmail.com', N'phuong213141', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (64, N'101 Trần Hưng Đạo, Quận Hoàn Kiếm, Hà Nội', N'Đặng Thu', N'Phương', N'123@123a', N'0901234567', 1, N'phuongthudang@gmail.com', N'phuongthudang', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (65, N'122 Lê Văn Sỹ, Quận 3, Thành phố Hồ Chí Minh', N'Bùi Công Tuấn', N'Đức', N'123@123a', N'0923456789
', 1, N'haonhatbui@gmail.com', N'haonhatbui', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (66, N'Lê Văn Sỹ, Quận 3, Thành phố Hồ Chí Minh', N'Bùi Nhật', N'Hào', N'123@123a', N'0923456789
', 1, N'linhnhat@gmail.com', N'linhnhat', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (67, N'Quang Trung, Quận Hải Châu, Đà Nẵng', N'Bùi Nhật', N'Linh', N'123@123a', N'0918765432', 1, N'nguyennam215512@gmail.com', N'nguyennam215512', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (68, N'Quang Trung, Quận Hải Châu, Đà Nẵng', N'Bùi Nam', N'Nguyên', N'123@123a', N'0998765123', 1, N'quangtrung2k1461@gmail.com', N'quangtrung2k1461', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (69, N'7 Bạch Đằng, Quận Hai Bà Trưng, Hà Nội', N'Bùi Thanh', N'Trang', N'123@123a', N'0912345679', 1, N'trangthanhbuibe2k@gmail.com', N'trangthanhbuibe2k', 4)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (70, N'abc123', N'tiến', N'trần', N'123@123a', N'0706600157', 0, N'123a@gmail.com', N'adminabcd', 1)
INSERT [dbo].[users] ([user_id], [address], [first_name], [last_name], [password], [phone_number], [status], [user_email], [user_name], [role]) VALUES (71, N'a', N'a', N'b', N'123123', N'1231231231', 1, N'a@gmail.com', N'abc123', 1)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
/****** Object:  Index [UK_bvlmyhb2isivkfvtp5kv3tpl0]    Script Date: 2/26/2024 2:54:16 PM ******/
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
