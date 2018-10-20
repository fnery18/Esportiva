USE [site_esportiva] /* aqui você coloca o nome do seu banco de dados */
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*inicio criacao tabela de usuarios*/

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
/*final criacao tabela de usuarios*/

/*-----------------------------------*/

/*inicio criacao tabela de times*/
CREATE TABLE [dbo].[Times](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Cor1] [varchar](255) NOT NULL,
	[Cor2] [varchar](255) NOT NULL,
	[Cor3] [varchar](255) NOT NULL,
	[Sigla] [varchar] (255) NOT NULL,
	[Nacionalidade] [varchar](255) NOT NULL,
	[DataFundacao] [date] NOT NULL,
	Usuario_id int not null,
 CONSTRAINT [PK_Times] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Times]  WITH CHECK ADD  CONSTRAINT [FK_Times_Usuarios] FOREIGN KEY(Usuario_id)
REFERENCES [dbo].[Usuarios] ([Id])
GO

ALTER TABLE [dbo].[Times] CHECK CONSTRAINT [FK_Times_Usuarios]
GO

/*final criacao tabela de times*/

/*-----------------------------------*/

/*inicio criacao tabela jogadores*/

CREATE TABLE [dbo].[Jogadores](
		Id int identity,
        Nome varchar(255) not null,
        Sobrenome varchar(255) not null,
        Posicao varchar(255) not null,
        DataNascimento date not null,
        Time_Id int not null,
        NumeroCamisa int not null, 
        Apelido varchar(255) not null,
        Altura float not null,
 CONSTRAINT [PK_Jogadores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Jogadores]  WITH CHECK ADD  CONSTRAINT [FK_Jogadores_Times] FOREIGN KEY([Time_Id])
REFERENCES [dbo].[Times] ([Id])
GO

ALTER TABLE [dbo].[Jogadores] CHECK CONSTRAINT [FK_Jogadores_Times]
GO

/*final criacao tabela de jogadores*/

/*-----------------------------------*/

CREATE TABLE Partidas(
	Id INT PRIMARY KEY IDENTITY,
	NomePartida varchar(255) NOT NULL,
	DataPartida date NOT NULL, 
	Time1_Id INT NOT NULL,
	Time2_Id INT NOT NULL,
	LocalCompeticao VARCHAR(255) NOT NULL,
	Competicao VARCHAR(255) NOT NULL
	FOREIGN KEY (Time1_Id) REFERENCES Times(Id),
	FOREIGN KEY (Time2_Id) REFERENCES Times(Id)
)

GO 

CREATE TABLE TipoAcontecimento(
	Id INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(255) NOT NULL
)


CREATE TABLE Acontecimentos(
	Id INT PRIMARY KEY IDENTITY,
	Jogador_Id INT NOT NULL,
	Partida_Id INT NOT NULL,
	Tempo INT NOT NULL,
	Time_Id INT NOT NULL,
	TipoAcontecimento_Id INT NOT NULL
	FOREIGN KEY (Jogador_Id) REFERENCES Jogadores(Id),
	FOREIGN KEY (Partida_Id) REFERENCES Partidas(Id),
	FOREIGN KEY (Time_Id) REFERENCES Times(Id),
	FOREIGN KEY (TipoAcontecimento_Id) REFERENCES TipoAcontecimento(Id),
)

INSERT INTO TipoAcontecimento VALUES ('Cartão Vermelho', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Cartão Amarelo', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Escalação', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Falta Cometida', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Falta Tomada', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Gol Tomado', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Tomada de Bola', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Drible', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Defesa', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Cruzamento', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Passe Errado', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Passe Certo', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Chute para Fora', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Chute para o Gol', 'cartao_vermelho.png')
INSERT INTO TipoAcontecimento VALUES ('Gol', 'cartao_vermelho.png')


/*Function*/
CREATE FUNCTION ValidaTrocaDeTecnico (@TecnicoId int, @TimeId int)
RETURNS int /*retorna 0 caso seja invalido, 1 caso seja valido*/ 
AS
BEGIN

DECLARE @ret int;

	If((select count(*) from Times where Id = @TimeId) + (select count(*) from Usuarios where Id = @TecnicoId)) != 2
		set @ret = 0;
	else
		set @ret = 1;

RETURN @ret;  
end;
GO
/*Final function*/


/*Procedures*/
CREATE PROCEDURE ExecutarTrocaDeTecnico @TecnicoId int, @TimeId int 
AS
	/* Primeiro remove o tecnico do time atual dele */
	Update Times 
	Set Tecnico_id = null
	where Tecnico_id = @TecnicoId
	/*Final remocao*/

	/* Coloca o tecnico em outro time */
	Update Times 
	Set Tecnico_id = @TecnicoId
	where Id = @TimeId
	/* final alteracao */
GO

CREATE PROCEDURE ValidarETrocarTecnicoDeTime @TecnicoId int, @TimeId int 
AS

If(select dbo.ValidaTrocaDeTecnico(@TecnicoId,@TimeId)) = 0
	print 'Time ou Tecnico Inexistente'
else
	Exec ExecutarTrocaDeTecnico @TecnicoId,@TimeId
GO
/*Final procedures*/