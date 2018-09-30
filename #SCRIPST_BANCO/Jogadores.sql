USE [GuimaDB]
GO

/****** Object:  Table [dbo].[Jogadores]    Script Date: 14/09/2018 18:35:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Jogadores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Idade] [int] NOT NULL,
	[Posicao] [varchar](255) NOT NULL,
	[Altura] [float] NOT NULL,
	[Peso] [float] NOT NULL,
	[Time_id] [int] NOT NULL,
 CONSTRAINT [PK_Jogadores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Jogadores]  WITH CHECK ADD  CONSTRAINT [FK_Jogadores_Times] FOREIGN KEY([Time_id])
REFERENCES [dbo].[Times] ([Id])
GO

ALTER TABLE [dbo].[Jogadores] CHECK CONSTRAINT [FK_Jogadores_Times]
GO


