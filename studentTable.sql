

CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[EmailId] [varchar](100) NULL,
	[Password] [varchar](max) NULL,
	[Mobile] [bigint] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedAt] [date] NULL,
	[UpdatedAt] [date] NULL,
	[Image] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Student] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[Student] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[Student] ADD  DEFAULT (NULL) FOR [UpdatedAt]
GO

ALTER TABLE [dbo].[Student] ADD  DEFAULT ('default.jpg') FOR [Image]
GO


