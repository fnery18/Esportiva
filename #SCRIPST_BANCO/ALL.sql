USE [site_esportiva]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 14/09/2018 18:36:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](255) NOT NULL,
	[Senha] [varchar](2000) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE TIMES(
	Id int identity primary key, 
	Nome VARCHAR(100) NOT NULL,
	Sigla varchar(5),
	Cor1 varchar(100) NOT NULL,
	Cor2 varchar(100),
	Cor3 varchar(100),
	Nacionalidade varchar(100) NOT NULL,
	DataFundacao date not null,
	Usuario_id int not null
)
GO

ALTER TABLE Times
ADD FOREIGN KEY (Usuario_Id) REFERENCES Usuarios(Id);

CREATE TABLE Jogadores(
        Id int identity primary key,
        Nome varchar(255) not null,
        Sobrenome varchar(255) not null,
        Posicao varchar(255) not null,
        DataNascimento date not null,
        Time_Id int not null,
        NumeroCamisa int not null, 
        Apelido varchar(255) not null,
        Altura float not null
)
GO

ALTER TABLE Jogadores
ADD FOREIGN KEY (Time_Id) REFERENCES Times(Id);





