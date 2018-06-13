﻿CREATE TABLE [dbo].[ColumnValue](
	[Id] [uniqueidentifier] NOT NULL,
	[ColumnMetaId] [uniqueidentifier] NOT NULL,
	[Value] [nvarchar](50) NULL,
 CONSTRAINT [PK_Column] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ColumnValue]  WITH CHECK ADD  CONSTRAINT [FK_Column_ColumnMetaId] FOREIGN KEY([ColumnMetaId])
REFERENCES [dbo].[ColumnMeta] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ColumnValue] CHECK CONSTRAINT [FK_Column_ColumnMetaId]
GO