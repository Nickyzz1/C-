use master
go

if exists(select * from sys.databases where name = 'SistemaEscolar')
    drop database SistemaEscolar

CREATE DATABASE SistemaEscolar;
GO

CREATE TABLE [Professor]
(
    [id] VARCHAR(255) primary key,
    [nome] VARCHAR(255) not null,
    [formacao] VARCHAR(255),
)
GO

CREATE TABLE [Sala]
(
    [id] VARCHAR(255) primary key,
    [className] VARCHAR(255) not null,
    [idProfessor] VARCHAR(255) FOREIGN KEY REFERENCES [Professor](id)
)
GO

create table [Alunos]
(
    [id] VARCHAR(255) primary key,
    [nome] VARCHAR(255) not null,
    [idade] int,
    [idSala] VARCHAR(255) FOREIGN key REFERENCES [Sala](id)
);
GO