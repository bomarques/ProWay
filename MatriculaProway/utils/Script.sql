USE master;
DROP DATABASE testeproway;
CREATE DATABASE testeproway;
USE testeproway;

CREATE TABLE Aluno(
AlunoId INTEGER IDENTITY(1,1) PRIMARY KEY,
Nome VARCHAR(50),
Sobrenome VARCHAR(100),
);

CREATE TABLE Sala(
SalaId INTEGER IDENTITY(1,1) PRIMARY KEY,
Nome VARCHAR(50),
Capacidade INTEGER
);

CREATE TABLE Lanchonete(
LanchoneteId INTEGER IDENTITY(1,1) PRIMARY KEY,
Nome VARCHAR(50)
);

CREATE TABLE Matricula(
MatriculaId INTEGER IDENTITY(1,1) PRIMARY KEY,
AlunoId INTEGER,
Etapa1 INTEGER,
Etapa2 INTEGER,
Turno1_Lanchonete INTEGER,
Turno2_Lanchonete INTEGER,
CONSTRAINT fk_aluno FOREIGN KEY (AlunoId) REFERENCES Aluno(AlunoId),
CONSTRAINT fk_sala_etapa
 FOREIGN KEY(Etapa1) REFERENCES Sala(SalaId),
 FOREIGN KEY(Etapa2) REFERENCES Sala(SalaId),
 CONSTRAINT fk_lanchonete_turno
 FOREIGN KEY(Turno1_Lanchonete) REFERENCES Lanchonete(LanchoneteId),
 FOREIGN KEY(Turno2_Lanchonete) REFERENCES Lanchonete(LanchoneteId)
);
