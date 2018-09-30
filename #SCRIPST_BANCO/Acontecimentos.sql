USE [GuimaDB]
GO

/****** Object:  Table [dbo].[Acontecimentos]    Script Date: 14/09/2018 18:35:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Acontecimentos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Partida_id] [int] NOT NULL,
	[EntidadeRealizadora] [int] NOT NULL,
	[EntidadeRealizadora_id] [int] NOT NULL,
	[Acontecimento] [int] NOT NULL,
	[PercentualPosseDeBola] [int] NULL,
 CONSTRAINT [PK_Acontecimentos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Acontecimentos]  WITH CHECK ADD  CONSTRAINT [FK_Acontecimentos_Jogadores] FOREIGN KEY([EntidadeRealizadora_id])
REFERENCES [dbo].[Jogadores] ([Id])
GO

ALTER TABLE [dbo].[Acontecimentos] CHECK CONSTRAINT [FK_Acontecimentos_Jogadores]
GO

ALTER TABLE [dbo].[Acontecimentos]  WITH CHECK ADD  CONSTRAINT [FK_Acontecimentos_Partidas] FOREIGN KEY([Partida_id])
REFERENCES [dbo].[Partidas] ([Id])
GO

ALTER TABLE [dbo].[Acontecimentos] CHECK CONSTRAINT [FK_Acontecimentos_Partidas]
GO

ALTER TABLE [dbo].[Acontecimentos]  WITH CHECK ADD  CONSTRAINT [FK_Acontecimentos_Times] FOREIGN KEY([EntidadeRealizadora_id])
REFERENCES [dbo].[Times] ([Id])
GO

ALTER TABLE [dbo].[Acontecimentos] CHECK CONSTRAINT [FK_Acontecimentos_Times]
GO


