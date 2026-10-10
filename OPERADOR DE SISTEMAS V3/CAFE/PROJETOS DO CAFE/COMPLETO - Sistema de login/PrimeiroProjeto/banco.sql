CREATE DATABASE IF NOT EXISTS primeiroprojeto
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;

USE primeiroprojeto;

CREATE TABLE IF NOT EXISTS usuarios
(
    id INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(150) NOT NULL,
    email VARCHAR(254) NOT NULL,
    senha VARCHAR(255) NOT NULL,
    PRIMARY KEY (id),
    UNIQUE KEY uq_usuarios_email (email)
);
