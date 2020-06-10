CREATE DATABASE bdSistemaEscolar;

USE bdSistemaEscolar;

CREATE TABLE tb_secretaria
(
	idSecretaria	INT			NOT NULL PRIMARY KEY IDENTITY (1,1),
	nome			VARCHAR(50) NOT NULL,
	formacao		VARCHAR(50) NOT NULL
);

CREATE TABLE tb_professor 
(
	idProfessor		INT			NOT NULL PRIMARY KEY IDENTITY (1,1),
	nome			VARCHAR(50) NOT NULL,
	especializacao	VARCHAR(30)	NOT NULL
);

CREATE TABLE tb_curso
(
	idCurso			INT			NOT NULL PRIMARY KEY IDENTITY (1,1),
	nomec			VARCHAR(50) NOT NULL,
	custo			INT			NOT NULL,
	FK_idProfessor	INT			FOREIGN KEY REFERENCES tb_professor(idProfessor)
);

CREATE TABLE tb_aluno
(
	idAluno			INT			NOT NULL PRIMARY KEY IDENTITY (1,1),
	nome			VARCHAR(50) NOT NULL,
	nomeP			VARCHAR(50) NOT NULL,
	nomeM			VARCHAR(50) NOT NULL,
	telefone		VARCHAR(11)	NOT NULL,
	dataNasc		DATE		NOT NULL,
	cpf				VARCHAR(14)	NOT NULL,
	rg				VARCHAR(20) NOT NULL,
	genero			VARCHAR(10) NOT NULL,
	cep				VARCHAR(8)  NOT NULL,
	rua				VARCHAR(50) NOT NULL,
	bairro			VARCHAR(50) NOT NULL,
	cidade			VARCHAR(50) NOT NULL,
	estado			VARCHAR(50) NOT NULL,
	email			VARCHAR(50) NOT NULL,
	FK_idCurso		INT			FOREIGN KEY REFERENCES tb_curso(idCurso)
);

CREATE TABLE tb_usuarios
(
	idUsuario		INT			NOT NULL PRIMARY KEY IDENTITY (1,1),
	nome			VARCHAR(15) NOT NULL,
	senha			VARCHAR(15) NOT NULL
);

SELECT * FROM tb_professor;
SELECT * FROM tb_curso;
SELECT * FROM tb_aluno; 
SELECT * FROM tb_usuarios;

SELECT tb_professor.nome, tb_curso.nomec FROM tb_professor 
INNER JOIN tb_curso ON tb_professor.idProfessor	= tb_curso.FK_idProfessor WHERE idProfessor = 1;

SELECT tb_aluno.nome, tb_aluno.nomeP, tb_aluno.nomeM, tb_aluno.telefone, tb_aluno.dataNasc, tb_aluno.cpf, tb_aluno.rg, tb_aluno.genero, tb_aluno.cep, +
tb_aluno.rua, tb_aluno.bairro, tb_aluno.cidade, tb_aluno.estado, tb_aluno.email, tb_curso.nomec FROM tb_aluno 
INNER JOIN tb_curso ON tb_aluno.FK_idCurso = tb_curso.idCurso;

UPDATE tb_aluno SET nome = 'Nome quatro', nomeP = 'Nome Paipai', nomeM = 'Nome Maemae' WHERE idAluno = 5;

SELECT * FROM tb_aluno; SELECT * FROM tb_curso; 