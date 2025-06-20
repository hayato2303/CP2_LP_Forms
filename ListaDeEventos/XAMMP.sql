-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de gera��o: 20/06/2025 �s 18:11
-- Vers�o do servidor: 10.4.32-MariaDB
-- Vers�o do PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `lp2_cp2`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `eventos`
--

CREATE TABLE `eventos` (
  `id` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `turma` varchar(100) DEFAULT NULL,
  `nome` varchar(255) NOT NULL,
  `data_inicio` date NOT NULL,
  `data_fim` date NOT NULL,
  `hora_inicio` time NOT NULL,
  `hora_fim` time NOT NULL,
  `descricao` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Despejando dados para a tabela `eventos`
--

INSERT INTO `eventos` (`id`, `usuario_id`, `turma`, `nome`, `data_inicio`, `data_fim`, `hora_inicio`, `hora_fim`, `descricao`) VALUES
(1, 1, 'Turma A', 'Revis�o de Banco de Dados', '2025-06-25', '2025-06-25', '09:00:00', '11:00:00', 'Aula de revis�o sobre SQL e modelagem.'),
(2, 2, 'Turma B', 'Apresenta��o de Projetos', '2025-06-26', '2025-06-26', '14:00:00', '17:00:00', 'Apresenta��o dos projetos finais.'),
(3, 3, 'Turma C', 'Workshop de Front-End', '2025-06-27', '2025-06-27', '10:00:00', '16:00:00', 'Workshop sobre HTML, CSS e JavaScript.'),
(4, 4, 'Turma A', 'Palestra: Carreira em TI', '2025-06-28', '2025-06-28', '13:30:00', '15:30:00', 'Palestra sobre mercado de trabalho em tecnologia.'),
(5, 5, 'Turma D', 'Avalia��o Intermedi�ria', '2025-06-29', '2025-06-29', '08:00:00', '10:00:00', 'Prova te�rica da disciplina.'),
(6, 6, 'Turma B', 'Oficina de C#', '2025-06-30', '2025-06-30', '09:00:00', '12:00:00', 'Oficina pr�tica sobre desenvolvimento em C#.'),
(7, 7, 'Turma C', 'Revis�o de L�gica', '2025-07-01', '2025-07-01', '10:00:00', '12:00:00', 'Aula para revis�o de l�gica de programa��o.'),
(8, 8, 'Turma D', 'Hackathon Interno', '2025-07-02', '2025-07-02', '09:00:00', '18:00:00', 'Competi��o de desenvolvimento de software.'),
(9, 9, 'Turma A', 'Aula Pr�tica de Redes', '2025-07-03', '2025-07-03', '08:00:00', '11:00:00', 'Montagem e configura��o de redes locais.'),
(10, 10, 'Turma B', 'Encerramento do Semestre', '2025-07-04', '2025-07-04', '15:00:00', '17:00:00', 'Festa de encerramento do semestre.');

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `senha` varchar(255) NOT NULL,
  `turma` varchar(100) NOT NULL,
  `nome` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Despejando dados para a tabela `usuarios`
--

INSERT INTO `usuarios` (`id`, `email`, `senha`, `turma`, `nome`) VALUES
(1, 'ana.silva@email.com', 'senha123', 'Turma A', 'Ana Silva'),
(2, 'bruno.souza@email.com', 'senha123', 'Turma B', 'Bruno Souza'),
(3, 'carla.mendes@email.com', 'senha123', 'Turma C', 'Carla Mendes'),
(4, 'daniel.lima@email.com', 'senha123', 'Turma A', 'Daniel Lima'),
(5, 'elisa.costa@email.com', 'senha123', 'Turma D', 'Elisa Costa'),
(6, 'felipe.gomes@email.com', 'senha123', 'Turma B', 'Felipe Gomes'),
(7, 'gabriela.pereira@email.com', 'senha123', 'Turma C', 'Gabriela Pereira'),
(8, 'henrique.alves@email.com', 'senha123', 'Turma D', 'Henrique Alves'),
(9, 'isabela.ramos@email.com', 'senha123', 'Turma A', 'Isabela Ramos'),
(10, 'joao.fernandes@email.com', 'senha123', 'Turma B', 'Jo�o Fernandes');

--
-- �ndices para tabelas despejadas
--

--
-- �ndices de tabela `eventos`
--
ALTER TABLE `eventos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- �ndices de tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `eventos`
--
ALTER TABLE `eventos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de tabela `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Restri��es para tabelas despejadas
--

--
-- Restri��es para tabelas `eventos`
--
ALTER TABLE `eventos`
  ADD CONSTRAINT `eventos_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
