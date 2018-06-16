CREATE TABLE [dbo].[ColumnValue](
	[Id] [uniqueidentifier] NOT NULL, 
	[Value] [nvarchar](50) NULL, 
	[ColumnMetaId] [uniqueidentifier] NOT NULL,
    CONSTRAINT [PK_ColumnValue] PRIMARY KEY ([Id]),
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ColumnValue]  WITH CHECK ADD  CONSTRAINT [FK_Column_ColumnMetaId] FOREIGN KEY([ColumnMetaId])
REFERENCES [dbo].[ColumnMeta] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ColumnValue] CHECK CONSTRAINT [FK_Column_ColumnMetaId]
GO