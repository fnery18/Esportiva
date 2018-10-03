CREATE TABLE TIMES(
	Id int identity primary key, 
	Nome VARCHAR(100) NOT NULL,
	Nacionalidade varchar(100) NOT NULL,
	DataFundacao datetime not null,
	Sigla varchar(5),
	Cor1 varchar(100) NOT NULL,
	Cor2 varchar(100),
	Cor3 varchar(100),
	Usuario_id int not null
)
go 

ALTER TABLE Times
ADD FOREIGN KEY (Usuario_Id) REFERENCES Usuarios(Id);

