CREATE TABLE [dbo].[ColumnBlock](
	[Id] [uniqueidentifier] NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
	[ValueText] [nvarchar](50) NOT NULL,
	[Required] [bit] NOT NULL,
 CONSTRAINT [PK_ColumnBlock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO