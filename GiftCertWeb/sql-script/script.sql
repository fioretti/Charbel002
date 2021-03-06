USE [GiftCertificateDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GcOutlet]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GcOutlet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OutletId] [int] NULL,
	[GiftCertNo] [int] NULL,
 CONSTRAINT [PK_GCOutlet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GcPurchase]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GcPurchase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[Active] [bit] NULL,
	[Remarks] [text] NULL,
	[PaymentMode] [varchar](50) NULL,
	[CcNumber] [varchar](50) NULL,
	[ExpirationDate] [datetime] NULL,
	[CardType] [varchar](50) NULL,
	[GiftCertNo] [int] NULL,
 CONSTRAINT [PK_GCPurchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GcRedemption]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GcRedemption](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RedemptionDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [int] NULL,
	[Active] [bit] NULL,
	[Remarks] [text] NULL,
	[GiftCertNo] [int] NULL,
 CONSTRAINT [PK_GCRedemption] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GcType]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GcType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_GCType_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiftCert]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiftCert](
	[GcTypeId] [int] NULL,
	[Value] [decimal](9, 2) NULL,
	[IssuanceDate] [datetime] NULL,
	[DtiPermitNo] [varchar](150) NULL,
	[ExpirationDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[QrCode] [varchar](50) NULL,
	[Note] [text] NULL,
	[Status] [int] NULL,
	[GiftCertNo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GiftCertNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Outlet]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Outlet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Outlet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ServicesType]    Script Date: 5/30/2018 8:07:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServicesType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[Name] [varchar](max) NULL,
	[Active] [bit] NULL,
	[GiftCertNo] [int] NULL,
 CONSTRAINT [PK_ServicesType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'2.0.2-rtm-10011')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'acfa2d47-2206-4ef7-98d2-43ecfac3c63f', 0, N'09463834-8ecd-4578-b745-34bd31f2bc20', N'brochelito@gmail.com', 0, 1, NULL, N'BROCHELITO@GMAIL.COM', N'BROCHELITO@GMAIL.COM', N'AQAAAAEAACcQAAAAEM53f3NnWCFv+LKMAzhKnAJmQbDt0VZC5Of/L0tQ2hHDJFYgclv4u59qTu9CwBSjJw==', NULL, 0, N'fbd2c313-bece-49d4-adf6-2e83419d015d', 0, N'brochelito@gmail.com')
SET IDENTITY_INSERT [dbo].[GcOutlet] ON 

INSERT [dbo].[GcOutlet] ([Id], [OutletId], [GiftCertNo]) VALUES (1024, 1, 150271)
INSERT [dbo].[GcOutlet] ([Id], [OutletId], [GiftCertNo]) VALUES (1025, 2, 150275)
INSERT [dbo].[GcOutlet] ([Id], [OutletId], [GiftCertNo]) VALUES (1026, 3, 150276)
SET IDENTITY_INSERT [dbo].[GcOutlet] OFF
SET IDENTITY_INSERT [dbo].[GcRedemption] ON 

INSERT [dbo].[GcRedemption] ([Id], [RedemptionDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active], [Remarks], [GiftCertNo]) VALUES (1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[GcRedemption] OFF
SET IDENTITY_INSERT [dbo].[GcType] ON 

INSERT [dbo].[GcType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active]) VALUES (1, N'leila', CAST(N'2018-04-30T16:24:53.783' AS DateTime), CAST(N'2018-04-30T16:24:53.783' AS DateTime), N'Regular GC', 1)
INSERT [dbo].[GcType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active]) VALUES (2, N'leila', NULL, CAST(N'2018-04-30T16:25:21.760' AS DateTime), N'Promotional GC', 1)
INSERT [dbo].[GcType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active]) VALUES (3, N'leila', NULL, CAST(N'2018-05-07T01:51:53.083' AS DateTime), N'Corporate GC', 1)
SET IDENTITY_INSERT [dbo].[GcType] OFF
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (1, CAST(5000.00 AS Decimal(9, 2)), NULL, N'', NULL, N'leila', CAST(N'2018-05-26T11:05:31.977' AS DateTime), CAST(N'2018-05-26T11:05:31.977' AS DateTime), N'afee05d6-0415-49b8-88a5-bfb60b53a4e6', N'not valid during Promotions/Peak season/Festive Season', NULL, 150270)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (2, CAST(10000.00 AS Decimal(9, 2)), NULL, N'DTI-Cebu Permit No. 048 Series of 2018', CAST(N'2019-01-28T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'0b57a541-7579-47bf-90f8-5ab66ad197d0', N'not valid during Promotions/Peak season/Festive Season', NULL, 150271)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (3, CAST(15000.00 AS Decimal(9, 2)), NULL, N'', CAST(N'2019-01-12T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'094b5f75-c879-4687-8a2f-b18ac03073c2', N'not valid during Promotions/Peak season/Festive Season', NULL, 150272)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (1, CAST(16000.00 AS Decimal(9, 2)), NULL, N'', NULL, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'671dd0cb-84a0-433b-b77e-a6d4f3e82f9d', N'not valid during Promotions/Peak season/Festive Season', NULL, 150273)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (1, CAST(18000.00 AS Decimal(9, 2)), NULL, N'', NULL, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'80afc4f9-2768-4249-b6e3-f9338fba4099', N'not valid during Promotions/Peak season/Festive Season', NULL, 150274)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (2, CAST(7000.00 AS Decimal(9, 2)), NULL, N'DTI-Cebu Permit No. 048 Series of 2018', CAST(N'2019-06-09T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'a9948c43-6135-4a33-9889-8c31935028a4', N'not valid during Promotions/Peak season/Festive Season', NULL, 150275)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (2, CAST(8000.00 AS Decimal(9, 2)), NULL, N'DTI-Cebu Permit No. 048 Series of 2018', CAST(N'2019-06-10T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'2cff69ae-74b2-4bac-9d85-5bbc95dba9c9', N'not valid during Promotions/Peak season/Festive Season', NULL, 150276)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (3, CAST(5500.00 AS Decimal(9, 2)), NULL, N'', CAST(N'2019-06-11T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'6e07cb10-02ff-4a37-9ef9-6c11675779de', N'not valid during Promotions/Peak season/Festive Season', NULL, 150277)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (3, CAST(4000.00 AS Decimal(9, 2)), NULL, N'', CAST(N'2019-06-12T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'a0a5fc6f-0aa2-4f1e-85a5-bd626e0a019a', N'not valid during Promotions/Peak season/Festive Season', NULL, 150278)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (3, CAST(8000.00 AS Decimal(9, 2)), NULL, N'', CAST(N'2019-06-13T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'f95839d1-ac1d-49b2-8d28-55c32e5f58db', N'not valid during Promotions/Peak season/Festive Season', NULL, 150279)
SET IDENTITY_INSERT [dbo].[Outlet] ON 

INSERT [dbo].[Outlet] ([Id], [Name], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active]) VALUES (1, N'Café Marco', N'leila', CAST(N'2018-04-30T16:26:03.620' AS DateTime), CAST(N'2018-04-30T16:26:03.620' AS DateTime), 1)
INSERT [dbo].[Outlet] ([Id], [Name], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active]) VALUES (2, N'Lobby Lounge', N'leila', CAST(N'2018-04-30T16:26:03.000' AS DateTime), CAST(N'2018-04-30T16:26:03.000' AS DateTime), 1)
INSERT [dbo].[Outlet] ([Id], [Name], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active]) VALUES (3, N'El Viento', N'leila', CAST(N'2018-04-30T16:26:03.000' AS DateTime), CAST(N'2018-04-30T16:26:03.000' AS DateTime), 1)
INSERT [dbo].[Outlet] ([Id], [Name], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active]) VALUES (5, N'wwww', N'leila', CAST(N'2018-05-21T08:25:54.000' AS DateTime), CAST(N'2018-05-21T08:25:54.000' AS DateTime), 1)
INSERT [dbo].[Outlet] ([Id], [Name], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active]) VALUES (7, N'ddss', N'leila', CAST(N'2018-05-21T08:28:08.883' AS DateTime), CAST(N'2018-05-21T08:28:08.883' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Outlet] OFF
SET IDENTITY_INSERT [dbo].[ServicesType] ON 

INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2046, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'Room / F&B / Spa valued at @value', 1, 150270)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2047, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'Regular Dinner Buffet and Sunday Branch for One (1)', 1, 150271)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2048, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N' Excluding Drinks at @Outlet', 1, 150271)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2049, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N' Valid until @ExpirationDate', 1, 150271)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2050, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N' (Prior Reservation Required)', 1, 150271)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2051, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'Room / F&B / Spa valued at @value', 1, 150272)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2052, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'Room / F&B / Spa valued at @value', 1, 150273)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2053, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'Room / F&B / Spa valued at @value', 1, 150274)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2054, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'Choice of Hilot Massage or Foot', 1, 150275)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2055, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N' Reflexology or Regular Foot Spa w/ 30 mins Sauna', 1, 150275)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2056, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N' (Not Valid on Fri, Sat & Sun until @ExpirationDate)', 1, 150275)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2057, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'Regular Dinner Buffet and Sunday Branch for One (1)', 1, 150276)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2058, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N' Excluding Drinks at @Outlet', 1, 150276)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2059, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N' Valid until @ExpirationDate', 1, 150276)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2060, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'Room / F&B / Spa valued at @value', 1, 150277)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2061, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'Room / F&B / Spa valued at @value', 1, 150278)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (2062, N'leila', CAST(N'2018-05-26T11:05:31.980' AS DateTime), CAST(N'2018-05-26T11:05:31.980' AS DateTime), N'Room / F&B / Spa valued at @value', 1, 150279)
SET IDENTITY_INSERT [dbo].[ServicesType] OFF
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[GcOutlet]  WITH NOCHECK ADD  CONSTRAINT [FK_GcOutlet_GiftCert] FOREIGN KEY([GiftCertNo])
REFERENCES [dbo].[GiftCert] ([GiftCertNo])
GO
ALTER TABLE [dbo].[GcOutlet] CHECK CONSTRAINT [FK_GcOutlet_GiftCert]
GO
ALTER TABLE [dbo].[GcOutlet]  WITH NOCHECK ADD  CONSTRAINT [FK_GcOutlet_Outlet] FOREIGN KEY([OutletId])
REFERENCES [dbo].[Outlet] ([Id])
GO
ALTER TABLE [dbo].[GcOutlet] CHECK CONSTRAINT [FK_GcOutlet_Outlet]
GO
ALTER TABLE [dbo].[GcPurchase]  WITH CHECK ADD  CONSTRAINT [FK_GcPurchase_GiftCert] FOREIGN KEY([GiftCertNo])
REFERENCES [dbo].[GiftCert] ([GiftCertNo])
GO
ALTER TABLE [dbo].[GcPurchase] CHECK CONSTRAINT [FK_GcPurchase_GiftCert]
GO
ALTER TABLE [dbo].[GcRedemption]  WITH CHECK ADD  CONSTRAINT [FK_GcRedemption_GiftCert] FOREIGN KEY([GiftCertNo])
REFERENCES [dbo].[GiftCert] ([GiftCertNo])
GO
ALTER TABLE [dbo].[GcRedemption] CHECK CONSTRAINT [FK_GcRedemption_GiftCert]
GO
ALTER TABLE [dbo].[GiftCert]  WITH NOCHECK ADD  CONSTRAINT [FK_GiftCert_GcType] FOREIGN KEY([GcTypeId])
REFERENCES [dbo].[GcType] ([Id])
GO
ALTER TABLE [dbo].[GiftCert] CHECK CONSTRAINT [FK_GiftCert_GcType]
GO
ALTER TABLE [dbo].[ServicesType]  WITH NOCHECK ADD  CONSTRAINT [FK_ServicesType_GiftCert] FOREIGN KEY([GiftCertNo])
REFERENCES [dbo].[GiftCert] ([GiftCertNo])
GO
ALTER TABLE [dbo].[ServicesType] CHECK CONSTRAINT [FK_ServicesType_GiftCert]
GO
