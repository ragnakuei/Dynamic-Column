CREATE TABLE [dbo].[ColumnValue](
	[ColumnMetaId] [uniqueidentifier] NOT NULL,
	[Value] [nvarchar](50) NULL, 
    CONSTRAINT [PK_ColumnValue] PRIMARY KEY ([ColumnMetaId]),
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ColumnValue]  WITH CHECK ADD  CONSTRAINT [FK_Column_ColumnMetaId] FOREIGN KEY([ColumnMetaId])
REFERENCES [dbo].[ColumnMeta] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ColumnValue] CHECK CONSTRAINT [FK_Column_ColumnMetaId]
GO