
CREATE TABLE [dbo].[ColumnMeta](
	[Id] [uniqueidentifier] NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
	[ValueText] [nvarchar](50) NULL,
	[IsRequired] [bit] NOT NULL,
	[ColumnBlockId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ColumnMeta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ColumnMeta]  WITH CHECK ADD  CONSTRAINT [FK_ColumnMeta_ColumnBlockId] FOREIGN KEY([ColumnBlockId])
REFERENCES [dbo].[ColumnBlock] ([Id])
GO

ALTER TABLE [dbo].[ColumnMeta] CHECK CONSTRAINT [FK_ColumnMeta_ColumnBlockId]
GO