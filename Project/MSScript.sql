USE [MusicStore]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 4/4/2020 12:08:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[GenreId] [int] NOT NULL,
	[ArtistId] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
	[AlbumUrl] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artists]    Script Date: 4/4/2020 12:08:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 4/4/2020 12:08:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 4/4/2020 12:08:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[AlbumId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [float] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4/4/2020 12:08:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Total] [int] NOT NULL,
	[userid] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/4/2020 12:08:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Type] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Albums] ON 

INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (3, 2, 1, N'Part Of Me', 100, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (7, 5, 1, N'The One That Got Away', 200, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (8, 6, 1, N'Wide Awake', 300, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (10, 7, 2, N'New Kids On The Block', 400, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (11, 8, 3, N'Nothin'' on You', 300, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (12, 9, 3, N'Billionaire', 400, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (13, 10, 4, N'Royalty', 200, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (14, 11, 5, N'The Fame', 200, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (15, 12, 5, N'Born This Way', 200, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (17, 13, 6, N'Career beginnings', 200, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (18, 14, 6, N'Never Say Never', 100, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (19, 15, 7, N'Fearless ', 200, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (20, 2, 7, N'Speak Now', 300, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (21, 5, 7, N'1989', 200, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (22, 6, 8, N' 21, worldwide recognition', 100, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (23, 7, 8, N'25 and Adele Live 2016', 100, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (25, 8, 9, N'Destiny''s Child', 200, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (26, 9, 9, N'Dangerously in Love', 200, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (27, 10, 9, N'B''Day', 300, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (28, 11, 10, N'Beginnings', 200, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (30, 12, 10, N'Annual releases and collaborations', 200, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (31, 16, 11, N'Con Mua Ngang Qua', 100, N'#')
INSERT [dbo].[Albums] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumUrl]) VALUES (32, 17, 12, N'Mot Con Vit', 50, N'#')
SET IDENTITY_INSERT [dbo].[Albums] OFF
SET IDENTITY_INSERT [dbo].[Artists] ON 

INSERT [dbo].[Artists] ([ArtistId], [Name]) VALUES (1, N'Katy Perry')
INSERT [dbo].[Artists] ([ArtistId], [Name]) VALUES (2, N'Jennifer Lopez')
INSERT [dbo].[Artists] ([ArtistId], [Name]) VALUES (3, N'Bruno Mars')
INSERT [dbo].[Artists] ([ArtistId], [Name]) VALUES (4, N'Chris Brown')
INSERT [dbo].[Artists] ([ArtistId], [Name]) VALUES (5, N'Lady Gaga')
INSERT [dbo].[Artists] ([ArtistId], [Name]) VALUES (6, N'Justin Bieber')
INSERT [dbo].[Artists] ([ArtistId], [Name]) VALUES (7, N'Taylor Swift')
INSERT [dbo].[Artists] ([ArtistId], [Name]) VALUES (8, N'Adele')
INSERT [dbo].[Artists] ([ArtistId], [Name]) VALUES (9, N'Beyonce')
INSERT [dbo].[Artists] ([ArtistId], [Name]) VALUES (10, N'Rihanna')
INSERT [dbo].[Artists] ([ArtistId], [Name]) VALUES (11, N'Son Tung MTP')
INSERT [dbo].[Artists] ([ArtistId], [Name]) VALUES (12, N'ABC Bands')
SET IDENTITY_INSERT [dbo].[Artists] OFF
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (2, N'Art Punk', N'Alternative')
INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (5, N'Alternative Rock', N'Alternative')
INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (6, N'Britpunk', N'Alternative')
INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (7, N'Anime', N'Anime')
INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (8, N'Acoustic Blues', N'Blues')
INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (9, N'Blues Rock', N'Blues')
INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (10, N'Lullabies', N'Children''s music')
INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (11, N'Stories', N'Children''s music')
INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (12, N'Ballet', N'Classical')
INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (13, N'Cantata', N'Classical')
INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (14, N'Novelty', N'Comedy')
INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (15, N'Parody Music', N'Comedy')
INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (16, N'Chu Tinh', N'Nhac Viet Nam')
INSERT [dbo].[Genres] ([GenreId], [Name], [Description]) VALUES (17, N'Nhac ROCK', N'nhac viet nam')
SET IDENTITY_INSERT [dbo].[Genres] OFF
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (5, 1, 7, 2, 200)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (6, 1, 8, 2, 300)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (7, 1, 11, 2, 300)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (8, 1, 3, 3, 100)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (9, 1, 12, 3, 400)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (10, 2, 7, 1, 200)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (11, 2, 12, 1, 400)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (12, 2, 10, 1, 400)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (13, 2, 13, 3, 200)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (14, 2, 8, 1, 300)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (15, 3, 8, 2, 300)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (16, 3, 11, 2, 300)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (17, 3, 10, 3, 400)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (18, 4, 3, 2, 100)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (19, 4, 8, 1, 300)
INSERT [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [AlbumId], [Quantity], [UnitPrice]) VALUES (20, 4, 11, 2, 300)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [OrderDate], [FirstName], [LastName], [Address], [City], [State], [Country], [Phone], [Email], [Total], [userid]) VALUES (1, CAST(N'2020-04-23T11:22:16.000' AS DateTime), N'Quan', N'Nguyen', N'Ha Noi 1', N'Ha Noi', N'Ha Noi', N'Viet Nam', N'0966 848 112', N'quanndh130577@fpt.edu.vn', 3100, 7)
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [FirstName], [LastName], [Address], [City], [State], [Country], [Phone], [Email], [Total], [userid]) VALUES (2, CAST(N'2020-04-02T11:22:16.000' AS DateTime), N'Quan', N'Nguyen', N'', N'', N'', N'', N'', N'quan@gmail.com', 1900, 8)
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [FirstName], [LastName], [Address], [City], [State], [Country], [Phone], [Email], [Total], [userid]) VALUES (3, CAST(N'2020-04-02T11:22:16.000' AS DateTime), N'Quan', N'Nguyen', N'Hai Duong', N'Hai Duong', N'Thanh Ha', N'Viet Nam', N'1234', N'quan@gmail.com', 2400, 8)
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [FirstName], [LastName], [Address], [City], [State], [Country], [Phone], [Email], [Total], [userid]) VALUES (4, CAST(N'2020-04-02T11:22:16.000' AS DateTime), N'Quan', N'Nguyen', N'Ha Noi', N'Ha Noi', N'Ha Noi', N'Viet Nam', N'0966 848 112', N'quanndh130577@fpt.edu.vn', 1100, 7)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [UserName], [Password], [FirstName], [LastName], [Address], [City], [State], [Country], [Phone], [Email], [Type]) VALUES (7, N'admin', N'admin', N'Quan', N'Nguyen', N'Ha Noi', N'Ha Noi', N'Ha Noi', N'Viet Nam', N'0966 848 112', N'quanndh130577@fpt.edu.vn', 1)
INSERT [dbo].[User] ([id], [UserName], [Password], [FirstName], [LastName], [Address], [City], [State], [Country], [Phone], [Email], [Type]) VALUES (8, N'quannd', N'123', N'Quan', N'Nguyen', NULL, NULL, NULL, NULL, NULL, N'quan@gmail.com', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_OrderDate]  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [FK_Albums_Artists] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artists] ([ArtistId])
GO
ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [FK_Albums_Artists]
GO
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [FK_Albums_Genres] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([GenreId])
GO
ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [FK_Albums_Genres]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Albums] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Albums] ([AlbumId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Albums]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([userid])
REFERENCES [dbo].[User] ([id])
GO
