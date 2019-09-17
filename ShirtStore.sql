create database T_ShirtStore

use T_ShirtStore

--DDL

Create table Marca
(
	IdMarca int primary key identity
	,Nome varchar (255) not null unique
);
 Create table Perfil
 (
	IdPerfil int primary key identity
	,Nome varchar (255) not null unique
);

Create table Usuario
(
	IdUsuario int primary key identity
	,Nome varchar (255) not null unique
	,Email varchar (255) not null unique
	,Senha varchar (255)
);

Create table Cor
(
	IdCor int primary key identity
	,Nome varchar(255)
);

Create table Tamanho
(
	IdTamanho int primary key identity
	,Nome varchar(255)
);

Create table Estoque
(
	IdEstoque int primary key identity
	,Nome varchar(255)
);

Create table Camiseta
(
	IdCamiseta int primary key identity
	,Descricao varchar (255) 
	,IdCor int foreign key references Cor(IdCor)
	,IdTamanho int foreign key references Tamanho(IdTamanho)
	,IdMarca int foreign key references Marca(IdMarca)
	,IdEstoque int foreign key references Estoque(IdEstoque)
);



--DML

insert into Marca(Nome) values ('Khelf'), ('Hollister'), ('Adidas');

select * from Marca

insert into Perfil(Nome) values ('Gerente'), ('Atendente');

select * from Perfil

insert into Usuario(Nome, Email, Senha) values ('ADMINISTRADOR','admin@gmail.com','123456'), ('CLIENTE','cliente@gmail.com','123456');

select * from Usuario

insert into Cor(Nome) values ('Preta'), ('Cinza'), ('Roxa'), ('Azul');

select * from Cor

insert into Tamanho(Nome) values ('PP'), ('P'), ('M'), ('G'), ('GG');

select * from Tamanho

insert into Estoque(Nome) values ('0 unidades'), ('1 unidade'), ('2 unidades'), ('3 unidades');

select * from Estoque

insert into Camiseta(Descricao, IdCor, IdTamanho, IdMarca, IdEstoque) values ('Polo', 1 , 3 , 3 , 3) , ('Normal', 2 , 5 , 1 , 2 );

select * from Camiseta

-- DQL

select Camiseta.Descricao, Cor.Nome
from Camiseta
join Cor
on Camiseta.IdCor = Cor.IdCor

select Camiseta.Descricao, Tamanho.Nome
from Camiseta
join Tamanho
on Camiseta.IdTamanho = Tamanho.IdTamanho

select Camiseta.Descricao, Marca.Nome
from Camiseta
join Marca
on Camiseta.IdMarca = Marca.IdMarca

select Camiseta.Descricao, Estoque.Nome
from Camiseta
join Estoque
on Camiseta.IdEstoque = Estoque.IdEstoque