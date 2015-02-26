CREATE TABLE [Blogs]
(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](255) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Created_at] [datetime] NOT NULL,
	[Updated_at] [datetime] NOT NULL,
	CONSTRAINT [PK_Blogs_ID] PRIMARY KEY 
	(
		[ID] ASC
	)
)

CREATE TABLE [Comments]
(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Content] [nvarchar](500) NOT NULL,
	[Created_at] [datetime] NOT NULL,
	[BlogID] [int] NOT NULL,
	CONSTRAINT [PK_Comments_ID] PRIMARY KEY 
	(
		[ID] ASC
	)
)

ALTER TABLE [Comments]  WITH CHECK ADD CONSTRAINT [FK_Comments_Blogs] FOREIGN KEY([BlogID])
REFERENCES [Blogs] ([ID])