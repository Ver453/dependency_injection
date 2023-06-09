USE [StudentDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/9/2023 4:18:00 PM ******/
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
/****** Object:  Table [dbo].[Academics]    Script Date: 5/9/2023 4:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Academics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Qualification] [nvarchar](max) NULL,
	[PassedYear] [nvarchar](max) NULL,
	[Marks] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_Academics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 5/9/2023 4:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Authors] [varchar](100) NULL,
	[Price] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 5/9/2023 4:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[FacultyId] [int] NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 5/9/2023 4:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[FacultyId] [int] IDENTITY(1,1) NOT NULL,
	[FacultyName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[FacultyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 5/9/2023 4:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[JoinDate] [datetime2](7) NOT NULL,
	[Gender] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[FacultyId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[ProfilePicture] [nvarchar](max) NOT NULL,
	[MidName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230316053239_student', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230316101536_faculty', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230316110312_student', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230316110936_student', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230317033303_courses', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230317041034_change', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230323041142_profile picture', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230324110345_academics', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230324110710_std fk', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230324111129_std fk1', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230327054625_studentmodel update', N'3.1.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230329053258_aca', N'3.1.1')
SET IDENTITY_INSERT [dbo].[Academics] ON 

INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2306, N'Nisi voluptate illum', N'2018', 41, 4177)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2307, N'Nisi voluptate illum', N'2018', 41, 4178)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2310, N'Qui optio in amet ', N'1978', 14, 4181)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2311, N'Eveniet quisquam au', N'1981', 86, 4182)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2333, N'Doloremque nihil omn', N'1975', 24, 4204)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2337, N'Eos molestiae obcae', N'2008', 43, 4208)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2339, N'Officiis necessitati', N'1974', 11, 4210)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2340, N'Repudiandae eius nem', N'1982', 55, 4211)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2342, N'Nobis consequatur V', N'2015', 17, 4213)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2343, N'Eos consequuntur ei', N'1982', 71, 4213)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2344, N'Cupiditate eaque mol', N'2008', 69, 4214)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2345, N'Et ut architecto cup', N'2014', 54, 4214)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2346, N'Quidem perspiciatis', N'2002', 72, 4214)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2347, N'Laudantium sit off', N'1974', 80, 4215)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2348, N'Est voluptatem Qua', N'1971', 45, 4215)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2349, N'Sint cillum tempor a', N'2018', 97, 4216)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2350, N'Quia corrupti in vo', N'2002', 39, 4217)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2351, N'Laboriosam enim odi', N'2000', 22, 4218)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2353, N'Quo consequatur Atq', N'2015', 81, 4220)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2355, N'Atque obcaecati tene', N'1997', 57, 4222)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2357, N'Molestiae quis perfe', N'1972', 82, 4224)
INSERT [dbo].[Academics] ([Id], [Qualification], [PassedYear], [Marks], [StudentId]) VALUES (2358, N'Mollitia veritatis p', N'2004', 11, 4225)
SET IDENTITY_INSERT [dbo].[Academics] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Name], [Authors], [Price]) VALUES (3, N'Math', N'Rajan', CAST(500 AS Decimal(18, 0)))
INSERT [dbo].[Books] ([Id], [Name], [Authors], [Price]) VALUES (4, N'Science', N'Sagar', CAST(300 AS Decimal(18, 0)))
INSERT [dbo].[Books] ([Id], [Name], [Authors], [Price]) VALUES (5, N'Social', N'Rajendra', CAST(320 AS Decimal(18, 0)))
INSERT [dbo].[Books] ([Id], [Name], [Authors], [Price]) VALUES (6, N'Nepali', N'Renu', CAST(204 AS Decimal(18, 0)))
INSERT [dbo].[Books] ([Id], [Name], [Authors], [Price]) VALUES (7, N'English', N'Pratab', CAST(324 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([Id], [Name], [FacultyId]) VALUES (2210, N'Business Studies', 1005)
INSERT [dbo].[Courses] ([Id], [Name], [FacultyId]) VALUES (2211, N'Business Math', 1005)
INSERT [dbo].[Courses] ([Id], [Name], [FacultyId]) VALUES (2212, N'Data Science', 1004)
INSERT [dbo].[Courses] ([Id], [Name], [FacultyId]) VALUES (2213, N'AI', 1003)
INSERT [dbo].[Courses] ([Id], [Name], [FacultyId]) VALUES (2214, N'Nepali', 1006)
INSERT [dbo].[Courses] ([Id], [Name], [FacultyId]) VALUES (2215, N'Cloud Computing', 2006)
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[Faculties] ON 

INSERT [dbo].[Faculties] ([FacultyId], [FacultyName]) VALUES (1003, N'BCSIT')
INSERT [dbo].[Faculties] ([FacultyId], [FacultyName]) VALUES (1004, N'MSC CSIT')
INSERT [dbo].[Faculties] ([FacultyId], [FacultyName]) VALUES (1005, N'BBA')
INSERT [dbo].[Faculties] ([FacultyId], [FacultyName]) VALUES (1006, N'jkmkk')
INSERT [dbo].[Faculties] ([FacultyId], [FacultyName]) VALUES (2006, N'New')
SET IDENTITY_INSERT [dbo].[Faculties] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4177, N'Richard', N'Cooper', N'Libero molestias sun', CAST(N'2000-02-17T00:00:00.0000000' AS DateTime2), N'Female', 0, 1003, 2153, N'dummy.png', N'Hall Sutton')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4178, N'Richard', N'Cooper', N'Libero molestias sun', CAST(N'2000-02-17T00:00:00.0000000' AS DateTime2), N'Female', 0, 1003, 2153, N'dummy.png', N'Hall Sutton')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4181, N'Jamal', N'Coffey', N'Corrupti et Nam tem', CAST(N'2010-06-04T00:00:00.0000000' AS DateTime2), N'Female', 0, 1005, 2187, N'dummy.png', N'Yen Hubbard')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4182, N'Steel', N'Dunn', N'Et sunt cupiditate ', CAST(N'1971-08-08T00:00:00.0000000' AS DateTime2), N'Other', 1, 1005, 2187, N'dummy.png', N'Emerald Wyatt')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4204, N'Wesley', N'Lara', N'Rerum non est laboru', CAST(N'1997-04-15T00:00:00.0000000' AS DateTime2), N'Female', 0, 1006, 2188, N'dummy.png', N'Clio Knowles')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4208, N'Joan', N'Harrell', N'Dolores in ullamco a', CAST(N'1988-05-29T00:00:00.0000000' AS DateTime2), N'Other', 1, 1003, 2153, N'dummy.png', N'Serena Diaz')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4210, N'Zelenia', N'Wade', N'Esse repellendus Su', CAST(N'1987-04-28T00:00:00.0000000' AS DateTime2), N'Male', 1, 1004, 2154, N'dummy.png', N'Melanie Payne')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4211, N'Quyn', N'Yang', N'Veritatis cillum sed', CAST(N'2012-07-02T00:00:00.0000000' AS DateTime2), N'Other', 1, 1003, 2153, N'dummy.png', N'Xyla Green')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4213, N'Kennedy', N'Carson', N'Enim ', CAST(N'1986-03-20T00:00:00.0000000' AS DateTime2), N'Female', 1, 1006, 2188, N'dummy.png', N'Susan Clemons')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4214, N'ergfdg', N'erer', N'Quisquam earum enim ', CAST(N'2019-05-27T00:00:00.0000000' AS DateTime2), N'Other', 0, 1004, 2154, N'dummy.png', NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4215, N'Samantha', N'Poole', N'Sunt dicta velit qua', CAST(N'2005-05-07T00:00:00.0000000' AS DateTime2), N'Female', 1, 1004, 2154, N'dummy.png', N'Ryan Mercado')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4216, N'Herrod', N'Vance', N'Minim alias quam ass', CAST(N'1992-07-24T00:00:00.0000000' AS DateTime2), N'Other', 0, 1004, 2154, N'dummy.png', N'Germane Nash')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4217, N'Eve', N'Brown', N'Veniam dolor expedi', CAST(N'2017-03-02T00:00:00.0000000' AS DateTime2), N'Female', 1, 1003, 2153, N'dummy.png', N'Flynn Aguilar')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4218, N'Forrest', N'Mcclure', N'Porro voluptatem des', CAST(N'1979-02-22T00:00:00.0000000' AS DateTime2), N'Other', 1, 2006, 2194, N'dummy.png', N'Blair Kent')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4220, N'Jordan', N'Hancock', N'Adipisci impedit ut', CAST(N'2002-02-10T00:00:00.0000000' AS DateTime2), N'Other', 1, 1003, 2153, N'dummy.png', N'Neville Molina')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4222, N'Serena', N'Webb', N'Expedita minus ex lo', CAST(N'1995-06-21T00:00:00.0000000' AS DateTime2), N'Female', 0, 1005, 2187, N'dummy.png', N'Astra Craft')
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4224, N'Kibo', N'fdgfg', N'At sunt provident q', CAST(N'2009-04-26T00:00:00.0000000' AS DateTime2), N'Male', 1, 1003, 2153, N'dummy.png', NULL)
INSERT [dbo].[Students] ([StudentId], [FirstName], [LastName], [Address], [JoinDate], [Gender], [IsActive], [FacultyId], [CourseId], [ProfilePicture], [MidName]) VALUES (4225, N'Xander', N'Mendoza', N'Id quia accusantium ', CAST(N'2023-03-03T00:00:00.0000000' AS DateTime2), N'Male', 0, 2006, 2215, N'1a7af033-153e-447a-8001-88f2115f4e4e_eerf.jpg', N'Halla Wagner')
SET IDENTITY_INSERT [dbo].[Students] OFF
ALTER TABLE [dbo].[Academics] ADD  DEFAULT ((0)) FOR [StudentId]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT ((0)) FOR [CourseId]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT (N'') FOR [ProfilePicture]
GO
ALTER TABLE [dbo].[Academics]  WITH CHECK ADD  CONSTRAINT [FK_Academics_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Academics] CHECK CONSTRAINT [FK_Academics_Students_StudentId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Faculties_FacultyId] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([FacultyId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Faculties_FacultyId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties_FacultyId] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([FacultyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties_FacultyId]
GO
