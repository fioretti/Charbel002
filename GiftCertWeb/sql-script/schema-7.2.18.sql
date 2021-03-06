USE [GiftCertificateDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/2/2018 2:20:57 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 7/2/2018 2:20:57 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/2/2018 2:20:57 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/2/2018 2:20:57 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/2/2018 2:20:57 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/2/2018 2:20:57 PM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/2/2018 2:20:57 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 7/2/2018 2:20:57 PM ******/
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
/****** Object:  Table [dbo].[GcOutlet]    Script Date: 7/2/2018 2:20:57 PM ******/
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
/****** Object:  Table [dbo].[GcPurchase]    Script Date: 7/2/2018 2:20:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GcPurchase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseId] [int] NULL,
	[GiftCertNo] [int] NULL,
 CONSTRAINT [PK_GCPurchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GcRedemption]    Script Date: 7/2/2018 2:20:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GcRedemption](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RedemptionId] [int] NULL,
	[GiftCertNo] [int] NULL,
 CONSTRAINT [PK_GCRedemption] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GcType]    Script Date: 7/2/2018 2:20:57 PM ******/
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
/****** Object:  Table [dbo].[GiftCert]    Script Date: 7/2/2018 2:20:57 PM ******/
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
/****** Object:  Table [dbo].[Outlet]    Script Date: 7/2/2018 2:20:57 PM ******/
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
/****** Object:  Table [dbo].[Purchase]    Script Date: 7/2/2018 2:20:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
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
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Redemption]    Script Date: 7/2/2018 2:20:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Redemption](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RedemptionDate] [datetime] NULL,
	[LastModifiedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [int] NULL,
	[Active] [bit] NULL,
	[Remarks] [text] NULL,
 CONSTRAINT [PK_Redemption] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ServicesType]    Script Date: 7/2/2018 2:20:57 PM ******/
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
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'55677fb3-a9fe-44a9-8f7a-60e47f5f301b', 0, N'3581b7ce-2fc3-48db-837c-68a16d0db516', N'manay@yahoo.com', 0, 1, NULL, N'MANAY@YAHOO.COM', N'MANAY@YAHOO.COM', N'AQAAAAEAACcQAAAAEGXvUbB1WujeAX9mvZ2XDEnVv+7npm3dr5nPag68zFLPVe90sRxtwsoVjVd0eK6FMw==', NULL, 0, N'52aaf8af-13e9-40f6-8dab-f1b0e7f6dd7f', 0, N'manay@yahoo.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'acfa2d47-2206-4ef7-98d2-43ecfac3c63f', 0, N'09463834-8ecd-4578-b745-34bd31f2bc20', N'brochelito@gmail.com', 0, 1, NULL, N'BROCHELITO@GMAIL.COM', N'BROCHELITO@GMAIL.COM', N'AQAAAAEAACcQAAAAEM53f3NnWCFv+LKMAzhKnAJmQbDt0VZC5Of/L0tQ2hHDJFYgclv4u59qTu9CwBSjJw==', NULL, 0, N'fbd2c313-bece-49d4-adf6-2e83419d015d', 0, N'brochelito@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'c67266ae-d9ca-4a8c-8c31-ff7a00d3a550', 0, N'0d71f11d-93ae-4e8f-be67-60f49c01bb8b', N'fioretti08@gmail.com', 0, 1, NULL, N'FIORETTI08@GMAIL.COM', N'FIORETTI08@GMAIL.COM', N'AQAAAAEAACcQAAAAEA9uYWTe3ajkAPiLtakp1Gdr+K6h4vLTraZEMKY0VPkqoHC4PowWT/Y2qd3arhB6oA==', NULL, 0, N'c920e227-485e-4e5c-9852-5e7873c8bc63', 0, N'fioretti08@gmail.com')
SET IDENTITY_INSERT [dbo].[GcOutlet] ON 

INSERT [dbo].[GcOutlet] ([Id], [OutletId], [GiftCertNo]) VALUES (3048, 1, 150271)
INSERT [dbo].[GcOutlet] ([Id], [OutletId], [GiftCertNo]) VALUES (3049, 5, 150275)
INSERT [dbo].[GcOutlet] ([Id], [OutletId], [GiftCertNo]) VALUES (3050, 7, 150276)
SET IDENTITY_INSERT [dbo].[GcOutlet] OFF
SET IDENTITY_INSERT [dbo].[GcPurchase] ON 

INSERT [dbo].[GcPurchase] ([Id], [PurchaseId], [GiftCertNo]) VALUES (3, 1, 150270)
INSERT [dbo].[GcPurchase] ([Id], [PurchaseId], [GiftCertNo]) VALUES (1002, 2, 150271)
INSERT [dbo].[GcPurchase] ([Id], [PurchaseId], [GiftCertNo]) VALUES (1003, 1, 150275)
SET IDENTITY_INSERT [dbo].[GcPurchase] OFF
SET IDENTITY_INSERT [dbo].[GcRedemption] ON 

INSERT [dbo].[GcRedemption] ([Id], [RedemptionId], [GiftCertNo]) VALUES (1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[GcRedemption] OFF
SET IDENTITY_INSERT [dbo].[GcType] ON 

INSERT [dbo].[GcType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active]) VALUES (1, N'leila', CAST(N'2018-04-30T16:24:53.783' AS DateTime), CAST(N'2018-04-30T16:24:53.783' AS DateTime), N'Regular GC', 1)
INSERT [dbo].[GcType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active]) VALUES (2, N'leila', NULL, CAST(N'2018-04-30T16:25:21.760' AS DateTime), N'Promotional GC', 1)
INSERT [dbo].[GcType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active]) VALUES (3, N'leila', NULL, CAST(N'2018-05-07T01:51:53.083' AS DateTime), N'Corporate GC', 1)
SET IDENTITY_INSERT [dbo].[GcType] OFF
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (1, CAST(5000.00 AS Decimal(9, 2)), CAST(N'2018-06-21T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, N'c238f612-f35c-4557-b755-b0d56a25da81', N'not valid during Promotions/Peak season/Festive Season', NULL, 150270)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (2, CAST(1000000.00 AS Decimal(9, 2)), CAST(N'2018-06-21T00:00:00.000' AS DateTime), N'DTI-Cebu Permit No. 048 Series of 2018', CAST(N'2019-06-12T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'b89aca3e-351d-403b-9b45-fc03d86058da', N'not valid during Promotions/Peak season/Festive Season', NULL, 150271)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (3, CAST(15000.00 AS Decimal(9, 2)), CAST(N'2018-06-21T00:00:00.000' AS DateTime), N'IDTI- Cebu Permit No. 048, Series of 2018', CAST(N'2019-06-12T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'cf981c2a-d567-463a-9779-47f747b35025', N'Note: not valid during Promotions/Peak season/Festive Season', NULL, 150272)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (1, CAST(5000.00 AS Decimal(9, 2)), CAST(N'2018-06-21T00:00:00.000' AS DateTime), N'', NULL, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'ddee8645-bc7d-47e8-aaf5-82bf56b00767', N'not valid during Promotions/Peak season/Festive Season', NULL, 150273)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (1, CAST(18000.00 AS Decimal(9, 2)), CAST(N'2018-06-21T00:00:00.000' AS DateTime), N'', NULL, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'15243899-6f9b-4351-96d9-c6d07ddf49ce', N'not valid during Promotions/Peak season/Festive Season', NULL, 150274)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (2, CAST(7000.00 AS Decimal(9, 2)), CAST(N'2018-06-21T00:00:00.000' AS DateTime), N'DTI-Cebu Permit No. 048 Series of 2018', CAST(N'2019-06-09T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'5d07048f-9753-4b24-ba64-99b027e109a8', N'not valid during Promotions/Peak season/Festive Season', NULL, 150275)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (2, CAST(8000.00 AS Decimal(9, 2)), CAST(N'2018-06-21T00:00:00.000' AS DateTime), N'DTI-Cebu Permit No. 048 Series of 2018', CAST(N'2019-06-10T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'891cc70e-41fa-446e-bd0e-b8266081a512', N'not valid during Promotions/Peak season/Festive Season', NULL, 150276)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (3, CAST(5500.00 AS Decimal(9, 2)), CAST(N'2018-06-21T00:00:00.000' AS DateTime), N'', CAST(N'2019-06-11T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'92c347e4-f7e8-4841-8205-c859aad472df', N'not valid during Promotions/Peak season/Festive Season', NULL, 150277)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (3, CAST(4000.00 AS Decimal(9, 2)), CAST(N'2018-06-21T00:00:00.000' AS DateTime), N'', CAST(N'2019-06-12T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'599539a6-c2b5-48b2-809a-29c52c651ccd', N'not valid during Promotions/Peak season/Festive Season', NULL, 150278)
INSERT [dbo].[GiftCert] ([GcTypeId], [Value], [IssuanceDate], [DtiPermitNo], [ExpirationDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [QrCode], [Note], [Status], [GiftCertNo]) VALUES (3, CAST(8000.00 AS Decimal(9, 2)), CAST(N'2018-06-21T00:00:00.000' AS DateTime), N'', CAST(N'2019-06-13T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'6be66e26-7fcb-474c-8832-33c0db98cc49', N'not valid during Promotions/Peak season/Festive Season', NULL, 150279)
SET IDENTITY_INSERT [dbo].[Outlet] ON 

INSERT [dbo].[Outlet] ([Id], [Name], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active]) VALUES (1, N'Café Marco', N'leila', CAST(N'2018-04-30T16:26:03.620' AS DateTime), CAST(N'2018-04-30T16:26:03.620' AS DateTime), 1)
INSERT [dbo].[Outlet] ([Id], [Name], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active]) VALUES (2, N'Lobby Lounge', N'leila', CAST(N'2018-04-30T16:26:03.000' AS DateTime), CAST(N'2018-04-30T16:26:03.000' AS DateTime), 1)
INSERT [dbo].[Outlet] ([Id], [Name], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active]) VALUES (3, N'El Viento', N'leila', CAST(N'2018-04-30T16:26:03.000' AS DateTime), CAST(N'2018-04-30T16:26:03.000' AS DateTime), 1)
INSERT [dbo].[Outlet] ([Id], [Name], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active]) VALUES (5, N'Wellness Zone Spa
', N'leila', CAST(N'2018-05-21T08:25:54.000' AS DateTime), CAST(N'2018-05-21T08:25:54.000' AS DateTime), 1)
INSERT [dbo].[Outlet] ([Id], [Name], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active]) VALUES (7, N'Rooms
', N'leila', CAST(N'2018-05-21T08:28:08.883' AS DateTime), CAST(N'2018-05-21T08:28:08.883' AS DateTime), 1)
INSERT [dbo].[Outlet] ([Id], [Name], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active]) VALUES (10, N'Blu Bar & Grill', N'leila', CAST(N'2018-05-21T08:28:08.883' AS DateTime), CAST(N'2018-05-21T08:28:08.883' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Outlet] OFF
SET IDENTITY_INSERT [dbo].[Purchase] ON 

INSERT [dbo].[Purchase] ([Id], [PurchaseDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active], [Remarks], [PaymentMode], [CcNumber], [ExpirationDate], [CardType]) VALUES (1, CAST(N'2018-06-21T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-06-21T00:00:00.000' AS DateTime), CAST(N'2018-06-21T00:00:00.000' AS DateTime), 1, N'123', NULL, NULL, NULL, NULL)
INSERT [dbo].[Purchase] ([Id], [PurchaseDate], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Active], [Remarks], [PaymentMode], [CcNumber], [ExpirationDate], [CardType]) VALUES (2, CAST(N'2018-06-21T00:00:00.000' AS DateTime), N'leila', CAST(N'2018-06-21T00:00:00.000' AS DateTime), CAST(N'2018-06-21T00:00:00.000' AS DateTime), 1, N'322', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Purchase] OFF
SET IDENTITY_INSERT [dbo].[ServicesType] ON 

INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4182, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'Room / F&B / Spa valued at 5000', 1, 150270)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4183, N'leila', CAST(N'2018-06-23T12:31:02.000' AS DateTime), CAST(N'2018-06-23T12:31:02.000' AS DateTime), N'Regular Dinner Buffet for One (1)', 1, 150271)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4185, N'leila', CAST(N'2018-06-23T12:31:02.000' AS DateTime), CAST(N'2018-06-23T12:31:02.000' AS DateTime), N'Exclusive of Drink @ Café Marco', 1, 150271)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4187, N'leila', CAST(N'2018-06-23T12:31:02.000' AS DateTime), CAST(N'2018-06-23T12:31:02.000' AS DateTime), N'Breakfast buffet with (1) One Year Validity', 1, 150272)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4188, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'Room / F&B / Spa valued at 5000', 1, 150273)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4189, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'Room / F&B / Spa valued at 18000', 1, 150274)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4190, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'Choice of Hilot Massage or Foot', 1, 150275)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4191, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N' Reflexology or Regular Foot Spa w/ 30 mins Sauna', 1, 150275)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4192, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N' (Not Valid on Fri, Sat & Sun until 6/9/2019)', 1, 150275)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4193, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'Regular Dinner Buffet and Sunday Branch for One (1)', 1, 150276)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4194, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N' Excluding Drinks at Rooms', 1, 150276)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4195, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N' Valid until 6/10/2019', 1, 150276)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4196, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'Room / F&B / Spa valued at 5500', 1, 150277)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4197, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'Room / F&B / Spa valued at 4000', 1, 150278)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4198, N'leila', CAST(N'2018-06-23T12:31:02.777' AS DateTime), CAST(N'2018-06-23T12:31:02.777' AS DateTime), N'Room / F&B / Spa valued at 8000', 1, 150279)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4199, N'leila', CAST(N'2018-07-02T01:13:11.730' AS DateTime), CAST(N'2018-07-02T01:13:11.730' AS DateTime), N'(Valid until Mon – Sun – Until November 17, 2018)', 1, 150271)
INSERT [dbo].[ServicesType] ([Id], [LastModifiedBy], [CreatedDate], [ModifiedDate], [Name], [Active], [GiftCertNo]) VALUES (4200, N'leila', CAST(N'2018-07-02T01:48:31.000' AS DateTime), CAST(N'2018-07-02T01:48:31.000' AS DateTime), N'(Valid until January 28, 2020)', 1, 150272)
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
ALTER TABLE [dbo].[GcPurchase]  WITH CHECK ADD  CONSTRAINT [FK_GcPurchase_Purchase] FOREIGN KEY([PurchaseId])
REFERENCES [dbo].[Purchase] ([Id])
GO
ALTER TABLE [dbo].[GcPurchase] CHECK CONSTRAINT [FK_GcPurchase_Purchase]
GO
ALTER TABLE [dbo].[GcRedemption]  WITH CHECK ADD  CONSTRAINT [FK_GcRedemption_GiftCert] FOREIGN KEY([GiftCertNo])
REFERENCES [dbo].[GiftCert] ([GiftCertNo])
GO
ALTER TABLE [dbo].[GcRedemption] CHECK CONSTRAINT [FK_GcRedemption_GiftCert]
GO
ALTER TABLE [dbo].[GcRedemption]  WITH CHECK ADD  CONSTRAINT [FK_GcRedemption_Redemption] FOREIGN KEY([RedemptionId])
REFERENCES [dbo].[Redemption] ([Id])
GO
ALTER TABLE [dbo].[GcRedemption] CHECK CONSTRAINT [FK_GcRedemption_Redemption]
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
