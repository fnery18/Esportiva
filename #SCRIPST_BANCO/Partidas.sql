USE [GuimaDB]
GO

/****** Object:  Table [dbo].[Partidas]    Script Date: 14/09/2018 18:35:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Partidas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [date] NOT NULL,
	[Time1_id] [int] NOT NULL,
	[Time2_id] [int] NOT NULL,
 CONSTRAINT [PK_Partidas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Partidas]  WITH CHECK ADD  CONSTRAINT [FK_Partidas_Times] FOREIGN KEY([Time1_id])
REFERENCES [dbo].[Times] ([Id])
GO

ALTER TABLE [dbo].[Partidas] CHECK CONSTRAINT [FK_Partidas_Times]
GO

ALTER TABLE [dbo].[Partidas]  WITH CHECK ADD  CONSTRAINT [FK_Partidas_Times1] FOREIGN KEY([Time2_id])
REFERENCES [dbo].[Times] ([Id])
GO

ALTER TABLE [dbo].[Partidas] CHECK CONSTRAINT [FK_Partidas_Times1]
GO


