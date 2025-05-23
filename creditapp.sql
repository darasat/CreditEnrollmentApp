USE [CreditEnrollmentDb]
GO
/****** Object:  Table [dbo].[Professors]    Script Date: 11/05/2025 1:42:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[ProfessorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfessorSubjects]    Script Date: 11/05/2025 1:42:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfessorSubjects](
	[ProfessorId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
 CONSTRAINT [PK_ProfessorSubjects] PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC,
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramCredits]    Script Date: 11/05/2025 1:42:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramCredits](
	[ProgramId] [int] IDENTITY(1,1) NOT NULL,
	[ProgramName] [nvarchar](100) NOT NULL,
	[Credits] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProgramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentProgramEnrollment]    Script Date: 11/05/2025 1:42:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentProgramEnrollment](
	[StudentId] [int] NOT NULL,
	[ProgramId] [int] NOT NULL,
	[EnrollmentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[ProgramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 11/05/2025 1:42:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[ProgramId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentSubjects]    Script Date: 11/05/2025 1:42:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentSubjects](
	[StudentId] [int] NULL,
	[SubjectId] [int] NULL,
	[ProfessorId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 11/05/2025 1:42:17 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](100) NOT NULL,
	[Credits] [int] NOT NULL,
	[ProfessorId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[StudentProgramEnrollment] ADD  DEFAULT (getdate()) FOR [EnrollmentDate]
GO
ALTER TABLE [dbo].[Students] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ProfessorSubjects]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorSubjects_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([ProfessorId])
GO
ALTER TABLE [dbo].[ProfessorSubjects] CHECK CONSTRAINT [FK_ProfessorSubjects_Professor]
GO
ALTER TABLE [dbo].[ProfessorSubjects]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorSubjects_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[ProfessorSubjects] CHECK CONSTRAINT [FK_ProfessorSubjects_Subject]
GO
ALTER TABLE [dbo].[StudentProgramEnrollment]  WITH CHECK ADD FOREIGN KEY([ProgramId])
REFERENCES [dbo].[ProgramCredits] ([ProgramId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentProgramEnrollment]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Programs] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[ProgramCredits] ([ProgramId])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Programs]
GO
ALTER TABLE [dbo].[StudentSubjects]  WITH CHECK ADD  CONSTRAINT [FK__StudentSu__Profe__440B1D61] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([ProfessorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentSubjects] CHECK CONSTRAINT [FK__StudentSu__Profe__440B1D61]
GO
ALTER TABLE [dbo].[StudentSubjects]  WITH CHECK ADD  CONSTRAINT [FK__StudentSu__Stude__4222D4EF] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentSubjects] CHECK CONSTRAINT [FK__StudentSu__Stude__4222D4EF]
GO
ALTER TABLE [dbo].[StudentSubjects]  WITH CHECK ADD  CONSTRAINT [FK__StudentSu__Subje__4316F928] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentSubjects] CHECK CONSTRAINT [FK__StudentSu__Subje__4316F928]
GO
ALTER TABLE [dbo].[StudentSubjects]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubjects_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([ProfessorId])
GO
ALTER TABLE [dbo].[StudentSubjects] CHECK CONSTRAINT [FK_StudentSubjects_Professor]
GO
ALTER TABLE [dbo].[StudentSubjects]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubjects_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[StudentSubjects] CHECK CONSTRAINT [FK_StudentSubjects_Student]
GO
ALTER TABLE [dbo].[StudentSubjects]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubjects_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId])
GO
ALTER TABLE [dbo].[StudentSubjects] CHECK CONSTRAINT [FK_StudentSubjects_Subject]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Professors] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professors] ([ProfessorId])
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Professors]
GO
