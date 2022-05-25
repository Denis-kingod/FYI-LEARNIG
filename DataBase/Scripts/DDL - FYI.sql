CREATE DATABASE DBFYI;
GO

USE DATABASE DBFYI;
GO

CREATE TABLE tipoUsuario(
idTipoUsuario int primary key identity,
titulo VARCHAR(13) NOT NULL
);

CREATE TABLE usuario(
idUsuario int primary key identity,
idTipoUsuario int foreign key references tipoUsuario(idTipoUsuario),
nome VARCHAR(50) NOT NULL,
empresa VARCHAR(50),
email VARCHAR(266) NOT NULL,
senha VARCHAR (70) NOT NULL
);

CREATE TABLE categoria(
idCategoria TINYINT PRIMARY KEY IDENTITY (1,1),
titulo  VARCHAR(30)
);

CREATE TABLE curso(
idCurso int primary key identity,
idCategoria int foreign key references categoria(idCategoria),
nomeCurso VARCHAR(50) NOT NULL,
descricao VARCHAR(2048) NOT NULL,
vagasDisponiveis VARCHAR(2048) NOT NULL,
vagasPreenchidas VARCHAR(2048) NOT NULL,
cargaHoraria VARCHAR(2048) NOT NULL,
);	

CREATE TABLE turma(
idTurma int primary key identity,
idCurso  int foreign key references curso(idCurso),
nomeTurma VARCHAR(70) NOT NULL
);

CREATE TABLE inscricao(
idInscricao INT PRIMARY KEY IDENTITY (1,1),
idUsuario int foreign key references usuario(idUsuario),
idTurma int foreign key references turma(idTurma),
dataInscricao datetime
);
