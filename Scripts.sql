CREATE TABLE Usuario (
    "id" SERIAL PRIMARY KEY,
    "Nome" VARCHAR(100) NOT NULL,
    "Email" VARCHAR(255) NOT NULL UNIQUE,
    "Senha" VARCHAR(100) NOT NULL,
    "Saldo" DECIMAL(18, 2) DEFAULT 0
);

CREATE TABLE "Planejamento" (
    "id" SERIAL PRIMARY KEY,
    "Usuario_Id" INT NOT NULL REFERENCES "usuario"("id"),
    "Valor" DECIMAL(18, 2) NOT NULL,
    "Mes" VARCHAR(20) NOT NULL
);

CREATE TABLE "Receita" (
    "id" SERIAL PRIMARY KEY,
    "Usuario_Id" INT NOT NULL REFERENCES "usuario"("id"),
    "Valor" DECIMAL(18, 2) NOT NULL,
    "Moeda" VARCHAR(10) NOT NULL,
    "Data" DATE NOT NULL,
    "Categoria" VARCHAR(50) NOT NULL
);

CREATE TABLE "Despesa" (
    "id" SERIAL PRIMARY KEY,
    "Usuario_Id" INT NOT NULL REFERENCES "usuario"("id"),
    "Valor" DECIMAL(18, 2) NOT NULL,
    "Moeda" VARCHAR(10) NOT NULL,
    "Data" DATE NOT NULL,
    "Categoria" VARCHAR(50) NOT NULL
);

CREATE TABLE "Historico" (
    "id" SERIAL PRIMARY KEY,
    "Usuario_Id" INT NOT NULL REFERENCES "usuario"("id"),
    "Tipo" VARCHAR(50) NOT NULL,
    "Valor" DECIMAL(18, 2) NOT NULL,
    "Data" DATE NOT NULL,
    "Categoria" VARCHAR(50) NOT NULL
);

ALTER TABLE usuario RENAME TO "Usuario";
ALTER TABLE "Usuario" RENAME COLUMN id TO "Id";
ALTER TABLE "Historico" RENAME COLUMN id TO "Id";
ALTER TABLE "Receita" RENAME COLUMN id TO "Id";
ALTER TABLE "Despesa" RENAME COLUMN id TO "Id";
ALTER TABLE "Planejamento" RENAME COLUMN id TO "Id";