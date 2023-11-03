USE [MyProjectDB]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 11/3/2023 4:15:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassEnroll]    Script Date: 11/3/2023 4:15:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassEnroll](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[classId] [int] NOT NULL,
	[userId] [int] NULL,
 CONSTRAINT [PK__ClassEnr__A1A6291D23706DBA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Code]    Script Date: 11/3/2023 4:15:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Code](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](50) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 11/3/2023 4:15:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[hasEduNext] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseEnroll]    Script Date: 11/3/2023 4:15:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseEnroll](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[courseId] [int] NOT NULL,
	[userId] [int] NULL,
 CONSTRAINT [PK__CourseEn__FE7952B28EE05B47] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/3/2023 4:15:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 11/3/2023 4:15:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NULL,
	[courseId] [int] NULL,
	[classId] [int] NULL,
	[userId] [int] NULL,
	[dayType] [nvarchar](50) NULL,
	[slotType] [nvarchar](50) NULL,
	[room] [nvarchar](50) NULL,
 CONSTRAINT [PK__Schedule__3213E83FE1FCE671] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SlotDuration]    Script Date: 11/3/2023 4:15:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SlotDuration](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codeId] [nvarchar](50) NULL,
	[duration] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/3/2023 4:15:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[fullName] [nvarchar](50) NULL,
	[gender] [bit] NULL,
	[address] [nvarchar](50) NULL,
	[dob] [datetime] NULL,
	[roleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Class] ON 
GO
INSERT [dbo].[Class] ([id], [name]) VALUES (2, N'GD1608-AD ')
GO
INSERT [dbo].[Class] ([id], [name]) VALUES (1, N'SE1618-NET')
GO
INSERT [dbo].[Class] ([id], [name]) VALUES (3, N'SE1817-AI ')
GO
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[ClassEnroll] ON 
GO
INSERT [dbo].[ClassEnroll] ([id], [classId], [userId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[ClassEnroll] ([id], [classId], [userId]) VALUES (2, 1, 4)
GO
INSERT [dbo].[ClassEnroll] ([id], [classId], [userId]) VALUES (3, 1, 5)
GO
INSERT [dbo].[ClassEnroll] ([id], [classId], [userId]) VALUES (4, 1, 6)
GO
INSERT [dbo].[ClassEnroll] ([id], [classId], [userId]) VALUES (5, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[ClassEnroll] OFF
GO
SET IDENTITY_INSERT [dbo].[Code] ON 
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (1, N'S1', N'SLOT', N'Slot 1')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (2, N'S2', N'SLOT', N'Slot 2')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (3, N'S3', N'SLOT', N'Slot 3')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (4, N'S4', N'SLOT', N'Slot 4')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (5, N'S5', N'SLOT', N'Slot 5')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (6, N'S6', N'SLOT', N'Slot 6')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (7, N'MON', N'DAY', N'Monday')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (9, N'TUE', N'DAY', N'Tuesday')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (10, N'WED', N'DAY', N'Wednesday')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (11, N'THU', N'DAY', N'Thursday')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (12, N'FRI', N'DAY', N'Friday')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (13, N'SAT', N'DAY', N'Saturday')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (14, N'SUN', N'DAY', N'Sunday')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (15, N'ATT', N'CHECK', N'Attended')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (16, N'ABS', N'CHECK', N'Absent')
GO
INSERT [dbo].[Code] ([id], [code], [type], [description]) VALUES (17, N'NOT', N'CHECK', N'Not yet')
GO
SET IDENTITY_INSERT [dbo].[Code] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 
GO
INSERT [dbo].[Course] ([id], [name], [hasEduNext]) VALUES (1, N'MLN111', 1)
GO
INSERT [dbo].[Course] ([id], [name], [hasEduNext]) VALUES (2, N'PRN231', 0)
GO
INSERT [dbo].[Course] ([id], [name], [hasEduNext]) VALUES (4, N'EXE201', 0)
GO
INSERT [dbo].[Course] ([id], [name], [hasEduNext]) VALUES (5, N'WDU203c', 0)
GO
INSERT [dbo].[Course] ([id], [name], [hasEduNext]) VALUES (6, N'PMG202c', 1)
GO
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseEnroll] ON 
GO
INSERT [dbo].[CourseEnroll] ([id], [courseId], [userId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[CourseEnroll] ([id], [courseId], [userId]) VALUES (2, 2, 1)
GO
INSERT [dbo].[CourseEnroll] ([id], [courseId], [userId]) VALUES (3, 2, 4)
GO
INSERT [dbo].[CourseEnroll] ([id], [courseId], [userId]) VALUES (4, 2, 5)
GO
INSERT [dbo].[CourseEnroll] ([id], [courseId], [userId]) VALUES (5, 2, 6)
GO
INSERT [dbo].[CourseEnroll] ([id], [courseId], [userId]) VALUES (6, 4, 1)
GO
INSERT [dbo].[CourseEnroll] ([id], [courseId], [userId]) VALUES (7, 5, 1)
GO
INSERT [dbo].[CourseEnroll] ([id], [courseId], [userId]) VALUES (8, 6, 1)
GO
INSERT [dbo].[CourseEnroll] ([id], [courseId], [userId]) VALUES (9, 6, 8)
GO
SET IDENTITY_INSERT [dbo].[CourseEnroll] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([id], [name]) VALUES (1, N'Student')
GO
INSERT [dbo].[Role] ([id], [name]) VALUES (2, N'Teacher')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedule] ON 
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (10, CAST(N'2023-10-02T00:00:00.000' AS DateTime), 1, 2, 3, N'MON', N'S3', N'BE-206')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (11, CAST(N'2023-10-03T00:00:00.000' AS DateTime), 2, 1, 2, N'TUE', N'S3', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (12, CAST(N'2023-10-04T11:00:00.000' AS DateTime), 4, 1, 3, N'WED', N'S4', N'DE-C308')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (13, CAST(N'2023-10-05T00:00:00.000' AS DateTime), 1, 2, 3, N'THU', N'S4', N'BE-206')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (14, CAST(N'2023-10-06T00:00:00.000' AS DateTime), 2, 1, 2, N'FRI', N'S4', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (15, CAST(N'2023-10-06T00:00:00.000' AS DateTime), 1, 2, 3, N'FRI', N'S5', N'AL-L511')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (16, CAST(N'2023-10-07T00:00:00.000' AS DateTime), 4, 1, 3, N'SAT', N'S4', N'BE-115')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (17, CAST(N'2023-10-09T00:00:00.000' AS DateTime), 1, 2, 3, N'MON', N'S3', N'BE-206')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (18, CAST(N'2023-10-10T00:00:00.000' AS DateTime), 2, 1, 2, N'TUE', N'S3', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (19, CAST(N'2023-10-11T00:00:00.000' AS DateTime), 4, 1, 3, N'WED', N'S4', N'DE-C308')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (20, CAST(N'2023-10-12T00:00:00.000' AS DateTime), 1, 2, 3, N'THU', N'S4', N'BE-206')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (21, CAST(N'2023-10-13T00:00:00.000' AS DateTime), 2, 1, 2, N'FRI', N'S4', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (22, CAST(N'2023-10-14T00:00:00.000' AS DateTime), 5, 2, 3, N'SAT', N'S4', N'DE-212')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (23, CAST(N'2023-10-14T00:00:00.000' AS DateTime), 6, 2, 3, N'SAT', N'S5', N'DE-C204')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (25, CAST(N'2023-10-14T00:00:00.000' AS DateTime), 6, 3, 3, N'SAT', N'S5', N'DE-C204')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (26, CAST(N'2023-10-16T00:00:00.000' AS DateTime), 1, 2, 3, N'MON', N'S3', N'BE-206')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (27, CAST(N'2023-10-17T00:00:00.000' AS DateTime), 2, 1, 2, N'TUE', N'S3', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (28, CAST(N'2023-10-18T00:00:00.000' AS DateTime), 4, 1, 3, N'WED', N'S4', N'DE-C308')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (29, CAST(N'2023-10-19T00:00:00.000' AS DateTime), 1, 2, 3, N'THU', N'S4', N'BE-206')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (30, CAST(N'2023-10-20T00:00:00.000' AS DateTime), 2, 1, 2, N'FRI', N'S4', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (31, CAST(N'2023-10-21T00:00:00.000' AS DateTime), 1, 2, 3, N'SAT', N'S5', N'AL-L511')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (34, CAST(N'2023-10-23T00:00:00.000' AS DateTime), 1, 2, 3, N'MON', N'S3', N'BE-206')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (35, CAST(N'2023-10-24T00:00:00.000' AS DateTime), 2, 1, 2, N'TUE', N'S3', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (36, CAST(N'2023-10-25T00:00:00.000' AS DateTime), 4, 1, 3, N'WED', N'S4', N'DE-C308')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (37, CAST(N'2023-10-26T00:00:00.000' AS DateTime), 1, 2, 3, N'THU', N'S4', N'BE-206')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (38, CAST(N'2023-10-27T00:00:00.000' AS DateTime), 2, 1, 2, N'FRI', N'S4', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (39, CAST(N'2023-10-27T00:00:00.000' AS DateTime), 4, 2, 3, N'FRI', N'S5', N'AL-L511')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (40, CAST(N'2023-10-28T00:00:00.000' AS DateTime), 5, 2, 3, N'SAT', N'S4', N'DE-212')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (41, CAST(N'2023-10-28T00:00:00.000' AS DateTime), 6, 2, 3, N'SAT', N'S5', N'DE-C204')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (42, CAST(N'2023-10-30T00:00:00.000' AS DateTime), 1, 2, 3, N'MON', N'S3', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (1034, CAST(N'2023-10-31T00:00:00.000' AS DateTime), 2, 1, 2, N'TUE', N'S3', N'BE-206')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (1035, CAST(N'2023-10-31T00:00:00.000' AS DateTime), 4, 2, 3, N'TUE', N'S4', N'Phòng tự học 1')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (1036, CAST(N'2023-11-01T00:00:00.000' AS DateTime), 4, 1, 3, N'WED', N'S4', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (1037, CAST(N'2023-11-02T00:00:00.000' AS DateTime), 1, 2, 3, N'THU', N'S4', N'BE-206')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (1038, CAST(N'2023-11-03T00:00:00.000' AS DateTime), 2, 1, 2, N'FRI', N'S4', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (1039, CAST(N'2023-11-04T00:00:00.000' AS DateTime), 4, 2, 3, N'SAT', N'S5', N'GA511(8h30-11h30)')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (1043, CAST(N'2023-11-06T00:00:00.000' AS DateTime), 1, 2, 3, N'MON', N'S3', N'BE-206')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (1044, CAST(N'2023-11-07T00:00:00.000' AS DateTime), 2, 1, 2, N'TUE', N'S3', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (1045, CAST(N'2023-11-08T00:00:00.000' AS DateTime), 4, 1, 3, N'WED', N'S4', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (1046, CAST(N'2023-11-09T00:00:00.000' AS DateTime), 1, 2, 3, N'THU', N'S4', N'BE-206')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (1047, CAST(N'2023-11-10T00:00:00.000' AS DateTime), 2, 1, 2, N'FRI', N'S4', N'DE-229')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (1048, CAST(N'2023-11-11T00:00:00.000' AS DateTime), 5, 1, 3, N'SAT', N'S4', N'DE-212')
GO
INSERT [dbo].[Schedule] ([id], [date], [courseId], [classId], [userId], [dayType], [slotType], [room]) VALUES (1049, CAST(N'2023-11-11T00:00:00.000' AS DateTime), 6, 1, 3, N'SAT', N'S5', N'DE-C204')
GO
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[SlotDuration] ON 
GO
INSERT [dbo].[SlotDuration] ([id], [codeId], [duration]) VALUES (2, N'S1', N'7:30-9:50')
GO
INSERT [dbo].[SlotDuration] ([id], [codeId], [duration]) VALUES (3, N'S2', N'10:00-12:20')
GO
INSERT [dbo].[SlotDuration] ([id], [codeId], [duration]) VALUES (4, N'S3', N'12:50-15:10')
GO
INSERT [dbo].[SlotDuration] ([id], [codeId], [duration]) VALUES (5, N'S4', N'15:20-17:40')
GO
INSERT [dbo].[SlotDuration] ([id], [codeId], [duration]) VALUES (6, N'S5', N'18:00-20:20')
GO
INSERT [dbo].[SlotDuration] ([id], [codeId], [duration]) VALUES (1002, N'S6', N'20:30-22:50')
GO
SET IDENTITY_INSERT [dbo].[SlotDuration] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([id], [email], [username], [password], [fullName], [gender], [address], [dob], [roleId]) VALUES (1, N'duongpche163153@fpt.edu.vn', N'duongpche163153', N'1', N'Phạm Chu Dương', 1, N'Phù Yên', CAST(N'2002-06-29T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[User] ([id], [email], [username], [password], [fullName], [gender], [address], [dob], [roleId]) VALUES (2, N'tientd17@fe.edu.vn', N'TienTD17', N'1', N'Tạ Đình Tiến', 1, N'Phù Yên', CAST(N'2002-06-29T00:00:00.000' AS DateTime), 2)
GO
INSERT [dbo].[User] ([id], [email], [username], [password], [fullName], [gender], [address], [dob], [roleId]) VALUES (3, N'Anhpn@fe.edu.vn', N'Anhpn', N'1', N'Phạm Ngọc Anh', 1, N'Phù Yên', CAST(N'2002-06-29T00:00:00.000' AS DateTime), 2)
GO
INSERT [dbo].[User] ([id], [email], [username], [password], [fullName], [gender], [address], [dob], [roleId]) VALUES (4, N'huypche163153@fpt.edu.vn', N'huypche163153', N'1', N'Phạm Chu Huy', 1, N'Phù Yên', CAST(N'2002-06-29T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[User] ([id], [email], [username], [password], [fullName], [gender], [address], [dob], [roleId]) VALUES (5, N'hungpthe163153@fpt.edu.vn', N'hungpthe163153', N'1', N'Phạm Thế Hưng', 1, N'Phù Yên', CAST(N'2002-06-29T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[User] ([id], [email], [username], [password], [fullName], [gender], [address], [dob], [roleId]) VALUES (6, N'duyenct163153@fpt.edu.vn', N'duyenct163153', N'1', N'Chu Thị Duyên', 0, N'Phù Yên', CAST(N'2002-06-29T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[User] ([id], [email], [username], [password], [fullName], [gender], [address], [dob], [roleId]) VALUES (8, N'pduong244@gmail.com', N'DuongPC', N'1', N'Pham Chu Duong', 1, N'Phù Yên', CAST(N'2002-06-29T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Class__72E12F1B82F1081E]    Script Date: 11/3/2023 4:15:49 PM ******/
ALTER TABLE [dbo].[Class] ADD UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Code__357D4CF9CCED90B7]    Script Date: 11/3/2023 4:15:49 PM ******/
ALTER TABLE [dbo].[Code] ADD UNIQUE NONCLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Course__72E12F1BACDF9377]    Script Date: 11/3/2023 4:15:49 PM ******/
ALTER TABLE [dbo].[Course] ADD UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClassEnroll]  WITH CHECK ADD  CONSTRAINT [FK__ClassEnro__class__6B24EA82] FOREIGN KEY([classId])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[ClassEnroll] CHECK CONSTRAINT [FK__ClassEnro__class__6B24EA82]
GO
ALTER TABLE [dbo].[ClassEnroll]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[CourseEnroll]  WITH CHECK ADD  CONSTRAINT [FK__CourseEnr__cours__5441852A] FOREIGN KEY([courseId])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[CourseEnroll] CHECK CONSTRAINT [FK__CourseEnr__cours__5441852A]
GO
ALTER TABLE [dbo].[CourseEnroll]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__classI__59063A47] FOREIGN KEY([classId])
REFERENCES [dbo].[Class] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK__Schedule__classI__59063A47]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__course__5812160E] FOREIGN KEY([courseId])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK__Schedule__course__5812160E]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__dayTyp__5AEE82B9] FOREIGN KEY([dayType])
REFERENCES [dbo].[Code] ([code])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK__Schedule__dayTyp__5AEE82B9]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__slotTy__5BE2A6F2] FOREIGN KEY([slotType])
REFERENCES [dbo].[Code] ([code])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK__Schedule__slotTy__5BE2A6F2]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__userId__236943A5] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK__Schedule__userId__236943A5]
GO
ALTER TABLE [dbo].[SlotDuration]  WITH CHECK ADD FOREIGN KEY([codeId])
REFERENCES [dbo].[Code] ([code])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([id])
GO
