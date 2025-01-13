-- Cria��o do banco ControleFinanceiro
CREATE DATABASE ControleFinanceiro;

USE ControleFinanceiro;

-- Cria��o da tabela Usuario
CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Senha NVARCHAR(100) NOT NULL,
    Saldo DECIMAL(18, 2) NULL DEFAULT 0
);

-- Cria��o da tabela Planejamento
CREATE TABLE Planejamento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Usuario_Id INT NOT NULL FOREIGN KEY REFERENCES Usuario(Id),
    Valor DECIMAL(18, 2) NOT NULL,
    Mes NVARCHAR(20) NOT NULL
);

-- Cria��o da tabela Receita
CREATE TABLE Receita (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Usuario_Id INT NOT NULL FOREIGN KEY REFERENCES Usuario(Id),
    Valor DECIMAL(18, 2) NOT NULL,
    Moeda NVARCHAR(10) NOT NULL,
    Data DATE NOT NULL,
    Categoria NVARCHAR(50) NOT NULL
);

-- Cria��o da tabela Despesa
CREATE TABLE Despesa (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Usuario_Id INT NOT NULL FOREIGN KEY REFERENCES Usuario(Id),
    Valor DECIMAL(18, 2) NOT NULL,
    Moeda NVARCHAR(10) NOT NULL,
    Data DATE NOT NULL,
    Categoria NVARCHAR(50) NOT NULL
);

-- Cria��o da tabela Historico
CREATE TABLE Historico (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Usuario_Id INT NOT NULL FOREIGN KEY REFERENCES Usuario(Id),
    Tipo NVARCHAR(50) NOT NULL,
    Valor DECIMAL(18, 2) NOT NULL,
    Data DATE NOT NULL
);
