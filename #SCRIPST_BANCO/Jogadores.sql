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
go 

ALTER TABLE Jogadores
ADD FOREIGN KEY (Time_Id) REFERENCES Times(Id);

