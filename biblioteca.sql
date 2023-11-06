-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 06/11/2023 às 05:35
-- Versão do servidor: 10.4.28-MariaDB
-- Versão do PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `biblioteca`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `emprestimos`
--

CREATE TABLE `emprestimos` (
  `Id` int(11) NOT NULL,
  `DataEmprestimo` datetime(6) NOT NULL,
  `DataDevolucao` datetime(6) NOT NULL,
  `NomeUsuario` longtext DEFAULT NULL,
  `Telefone` longtext DEFAULT NULL,
  `Devolvido` tinyint(1) NOT NULL,
  `LivroId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `emprestimos`
--

INSERT INTO `emprestimos` (`Id`, `DataEmprestimo`, `DataDevolucao`, `NomeUsuario`, `Telefone`, `Devolvido`, `LivroId`) VALUES
(3, '2023-10-20 00:00:00.000000', '2023-10-27 00:00:00.000000', 'asdsad', 'asdsad', 0, 1),
(4, '2023-10-23 00:00:00.000000', '2023-11-23 00:00:00.000000', 'Lucas', '99999', 0, 2),
(5, '2023-08-13 00:00:00.000000', '2023-08-20 00:00:00.000000', 'Martin Danilo Fernandes', '(49) 99798-5115', 0, 11),
(6, '2023-08-22 00:00:00.000000', '2023-09-19 00:00:00.000000', 'André Heitor Isaac Jesus', '(81) 98554-7041', 0, 3),
(7, '2023-08-19 00:00:00.000000', '2023-12-19 00:00:00.000000', 'Martin Marcelo Duarte', '(85) 98260-3172', 0, 12);

-- --------------------------------------------------------

--
-- Estrutura para tabela `livros`
--

CREATE TABLE `livros` (
  `Id` int(11) NOT NULL,
  `Titulo` longtext DEFAULT NULL,
  `Autor` longtext DEFAULT NULL,
  `Ano` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `livros`
--

INSERT INTO `livros` (`Id`, `Titulo`, `Autor`, `Ano`) VALUES
(1, 'AA', 'Tavares', 2020),
(2, 'AB July', 'Souza Aquino', 2020),
(3, 'C Clayton', 'Mendes Guedes', 2022),
(4, 'T', 'TT', 2023),
(5, 'Livro 5', 'Autor 5', 2023),
(6, 'Livro 6', 'Autor 6', 2023),
(7, 'Livro 7', 'Autor 7 ', 2023),
(8, 'Livro 8', 'Autor 8', 2023),
(9, 'Livro 9', 'Autor 9', 2020),
(10, 'Livro 10', 'Autor 10', 2021),
(11, 'Livro 11', 'Autor 11', 2022),
(12, 'Livro 12', 'Autor 12', 2023);

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `usuario_id` int(11) NOT NULL,
  `usuario_nome` varchar(100) NOT NULL,
  `usuario_login` varchar(100) NOT NULL,
  `usuario_senha` varchar(150) NOT NULL,
  `usuario_tipo` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `usuarios`
--

INSERT INTO `usuarios` (`usuario_id`, `usuario_nome`, `usuario_login`, `usuario_senha`, `usuario_tipo`) VALUES
(2, 'Lucas Tavares', 'admin', '202cb962ac59075b964b07152d234b70', 'Admin'),
(3, 'Usuario2', 'user2', '202cb962ac59075b964b07152d234b70', 'User'),
(4, 'Usuario 3', 'User3', 'e10adc3949ba59abbe56e057f20f883e', 'User');

-- --------------------------------------------------------

--
-- Estrutura para tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20231021012743_CreateDatabase', '3.0.0');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `emprestimos`
--
ALTER TABLE `emprestimos`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Emprestimos_LivroId` (`LivroId`);

--
-- Índices de tabela `livros`
--
ALTER TABLE `livros`
  ADD PRIMARY KEY (`Id`);

--
-- Índices de tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`usuario_id`);

--
-- Índices de tabela `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `emprestimos`
--
ALTER TABLE `emprestimos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de tabela `livros`
--
ALTER TABLE `livros`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de tabela `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `usuario_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `emprestimos`
--
ALTER TABLE `emprestimos`
  ADD CONSTRAINT `FK_Emprestimos_Livros_LivroId` FOREIGN KEY (`LivroId`) REFERENCES `livros` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
