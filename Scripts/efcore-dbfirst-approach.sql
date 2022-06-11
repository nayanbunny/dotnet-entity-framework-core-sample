CREATE DATABASE EFCoreDBFirstDatabase
GO

USE EFCoreDBFirstDatabase;

-- Create Skills Table
CREATE TABLE [dbo].[Skills](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_NewTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Skills] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Skills] ADD  DEFAULT ((0)) FOR [IsActive]
GO


-- Create Departments Table
CREATE TABLE [dbo].[Departments](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Departments] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Departments] ADD  DEFAULT ((0)) FOR [IsActive]
GO


-- Create Employees Table
CREATE TABLE [dbo].[Employees](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [bigint] NULL,
	[DepartmentId] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments]
GO


-- Create Employee Skills Relation Mapping Table
CREATE TABLE [dbo].[EmployeeSkills](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[SkillId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_EmployeeSkills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeSkills] ADD  CONSTRAINT [DF_EmployeeSkills_id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[EmployeeSkills]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSkills_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EmployeeSkills] CHECK CONSTRAINT [FK_EmployeeSkills_Employees]
GO
ALTER TABLE [dbo].[EmployeeSkills]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSkills_Skills] FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skills] ([Id])
GO
ALTER TABLE [dbo].[EmployeeSkills] CHECK CONSTRAINT [FK_EmployeeSkills_Skills]
GO


-- Sample Data Insertion

INSERT [dbo].[Departments] ([Id], [Name], [IsActive]) VALUES (N'0684877a-4db5-4e64-9728-c44ace259cfa', N'Finance', 0)
GO
INSERT [dbo].[Departments] ([Id], [Name], [IsActive]) VALUES (N'fbf88bf4-8d2b-46d4-9e52-c5b0e7e97279', N'Designing', 1)
GO
INSERT [dbo].[Departments] ([Id], [Name], [IsActive]) VALUES (N'5a573a17-b74f-4f74-a8e1-d0184f4b0c90', N'Engineering', 1)
GO
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [DepartmentId], [IsActive]) VALUES (N'43df727e-b8f7-4b9b-98c3-187e32844ec9', N'John', N'john@abc.com', 8765432109, N'fbf88bf4-8d2b-46d4-9e52-c5b0e7e97279', 1)
GO
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [DepartmentId], [IsActive]) VALUES (N'367de4bd-a143-4196-8baa-288705cd8963', N'Arjun', N'arjun@abc.com', 9876543210, N'5a573a17-b74f-4f74-a8e1-d0184f4b0c90', 1)
GO
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [DepartmentId], [IsActive]) VALUES (N'170528a9-3d66-4038-a16d-e6d10de12824', N'Ram', N'ram@abc.com', 7654321098, N'0684877a-4db5-4e64-9728-c44ace259cfa', 0)
GO
INSERT [dbo].[Employees] ([Id], [Name], [Email], [Phone], [DepartmentId], [IsActive]) VALUES (N'9b5c0afd-9e08-4724-88f1-ecf47bc8bbb9', N'Siri', N'siri@abc.com', 9123456780, N'5a573a17-b74f-4f74-a8e1-d0184f4b0c90', 1)
GO
INSERT [dbo].[Skills] ([Id], [Name], [IsActive]) VALUES (N'69d0e326-2520-486c-99e2-385a34803579', N'Designing', 1)
GO
INSERT [dbo].[Skills] ([Id], [Name], [IsActive]) VALUES (N'd765cbe3-0a1c-4a28-9f2e-56b36a50e8d2', N'Management', 1)
GO
INSERT [dbo].[Skills] ([Id], [Name], [IsActive]) VALUES (N'3760c414-d917-467f-a482-9ed3887639de', N'Programming', 1)
GO
INSERT [dbo].[Skills] ([Id], [Name], [IsActive]) VALUES (N'c64489f0-2ee7-444f-a9fc-ad18550d8b6c', N'Testing', 1)
GO
INSERT [dbo].[Skills] ([Id], [Name], [IsActive]) VALUES (N'3873d6ca-2b0c-44fc-b548-bdf22354e638', N'Machine Assembly', 1)
GO
INSERT [dbo].[Skills] ([Id], [Name], [IsActive]) VALUES (N'0de189f1-a036-40d8-aea4-c0704c04ebe7', N'Training', 0)
GO
INSERT [dbo].[Skills] ([Id], [Name], [IsActive]) VALUES (N'd811546c-b66b-46d3-9e23-f7441b4cd094', N'Workflow', 0)
GO
INSERT [dbo].[EmployeeSkills] ([Id], [EmployeeId], [SkillId]) VALUES (N'137e00ef-c9e4-4938-8e51-3938a954b2d2', N'170528a9-3d66-4038-a16d-e6d10de12824', N'd811546c-b66b-46d3-9e23-f7441b4cd094')
GO
INSERT [dbo].[EmployeeSkills] ([Id], [EmployeeId], [SkillId]) VALUES (N'a91b0e9d-4a18-4ba6-8d97-4c10ae43dae8', N'367de4bd-a143-4196-8baa-288705cd8963', N'0de189f1-a036-40d8-aea4-c0704c04ebe7')
GO
INSERT [dbo].[EmployeeSkills] ([Id], [EmployeeId], [SkillId]) VALUES (N'5953c3f5-e8ac-4007-9372-5b979f78f0ad', N'9b5c0afd-9e08-4724-88f1-ecf47bc8bbb9', N'c64489f0-2ee7-444f-a9fc-ad18550d8b6c')
GO
INSERT [dbo].[EmployeeSkills] ([Id], [EmployeeId], [SkillId]) VALUES (N'4710c4f0-8259-4dc4-9d45-8701214ccb88', N'170528a9-3d66-4038-a16d-e6d10de12824', N'd765cbe3-0a1c-4a28-9f2e-56b36a50e8d2')
GO
INSERT [dbo].[EmployeeSkills] ([Id], [EmployeeId], [SkillId]) VALUES (N'468dc805-c4ef-4287-b591-c70be4c2f5d7', N'43df727e-b8f7-4b9b-98c3-187e32844ec9', N'69d0e326-2520-486c-99e2-385a34803579')
GO
INSERT [dbo].[EmployeeSkills] ([Id], [EmployeeId], [SkillId]) VALUES (N'acd58021-9f5c-41af-b9e9-c79ac37a11ad', N'9b5c0afd-9e08-4724-88f1-ecf47bc8bbb9', N'3760c414-d917-467f-a482-9ed3887639de')
GO
INSERT [dbo].[EmployeeSkills] ([Id], [EmployeeId], [SkillId]) VALUES (N'5a63768a-6740-4929-9e40-e6cc246b3a25', N'367de4bd-a143-4196-8baa-288705cd8963', N'3760c414-d917-467f-a482-9ed3887639de')
GO
INSERT [dbo].[EmployeeSkills] ([Id], [EmployeeId], [SkillId]) VALUES (N'b0571c42-b526-47e0-b061-ec07880b7efa', N'367de4bd-a143-4196-8baa-288705cd8963', N'd765cbe3-0a1c-4a28-9f2e-56b36a50e8d2')
GO
