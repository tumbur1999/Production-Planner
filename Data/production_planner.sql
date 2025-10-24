-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 24, 2025 at 10:00 PM
-- Server version: 10.1.30-MariaDB
-- PHP Version: 7.2.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `production_planner`
--

-- --------------------------------------------------------

--
-- Table structure for table `productionplans`
--

CREATE TABLE `productionplans` (
  `Id` int(11) NOT NULL,
  `CreatedDate` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `Senin` int(11) NOT NULL,
  `Selasa` int(11) NOT NULL,
  `Rabu` int(11) NOT NULL,
  `Kamis` int(11) NOT NULL,
  `Jumat` int(11) NOT NULL,
  `Sabtu` int(11) NOT NULL,
  `Minggu` int(11) NOT NULL,
  `ImprovedSenin` int(11) NOT NULL,
  `ImprovedSelasa` int(11) NOT NULL,
  `ImprovedRabu` int(11) NOT NULL,
  `ImprovedKamis` int(11) NOT NULL,
  `ImprovedJumat` int(11) NOT NULL,
  `ImprovedSabtu` int(11) NOT NULL,
  `ImprovedMinggu` int(11) NOT NULL,
  `TotalProduction` int(11) NOT NULL,
  `WorkingDays` int(11) NOT NULL,
  `PlanType` varchar(50) NOT NULL DEFAULT 'Task2'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `productionplans`
--

INSERT INTO `productionplans` (`Id`, `CreatedDate`, `Senin`, `Selasa`, `Rabu`, `Kamis`, `Jumat`, `Sabtu`, `Minggu`, `ImprovedSenin`, `ImprovedSelasa`, `ImprovedRabu`, `ImprovedKamis`, `ImprovedJumat`, `ImprovedSabtu`, `ImprovedMinggu`, `TotalProduction`, `WorkingDays`, `PlanType`) VALUES
(1, '2025-10-25 01:49:54.294349', 5, 4, 3, 6, 4, 0, 0, 5, 4, 4, 5, 4, 0, 0, 22, 5, 'Task2'),
(2, '2025-10-25 01:57:47.811127', 4, 5, 1, 7, 6, 4, 0, 4, 5, 4, 5, 5, 4, 0, 27, 6, 'Task2'),
(3, '2025-10-25 02:31:58.435038', 8, 7, 6, 9, 5, 0, 0, 7, 7, 7, 7, 7, 0, 0, 35, 5, 'Task2'),
(4, '2025-10-25 02:34:17.245765', 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 35, 7, 'Task2'),
(5, '2025-10-25 02:35:23.967251', 3, 3, 3, 3, 3, 10, 8, 4, 4, 5, 5, 5, 5, 5, 33, 7, 'Task2'),
(6, '2025-10-25 02:36:27.216313', 0, 0, 0, 0, 0, 15, 10, 0, 0, 0, 0, 0, 13, 12, 25, 2, 'Task2'),
(7, '2025-10-25 02:36:55.252703', 12, 2, 8, 15, 3, 6, 0, 8, 7, 8, 8, 7, 8, 0, 46, 6, 'Task2'),
(8, '2025-10-25 02:37:31.805043', 2, 1, 3, 2, 1, 0, 0, 2, 1, 2, 2, 2, 0, 0, 9, 5, 'Task2'),
(9, '2025-10-25 02:38:14.579024', 25, 20, 30, 35, 15, 10, 5, 20, 20, 20, 20, 20, 20, 20, 140, 7, 'Task2'),
(10, '2025-10-25 02:40:20.902927', 10, 0, 8, 0, 12, 0, 6, 9, 0, 9, 0, 9, 0, 9, 36, 4, 'Task2'),
(11, '2025-10-25 02:45:24.930436', 4, 5, 1, 7, 6, 4, 0, 4, 5, 4, 5, 5, 4, 0, 27, 6, 'Task2'),
(12, '2025-10-25 02:46:58.496427', 8, 7, 6, 9, 5, 0, 0, 7, 7, 7, 7, 7, 0, 0, 35, 5, 'Task2'),
(13, '2025-10-25 02:47:50.819461', 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 35, 7, 'Task2'),
(14, '2025-10-25 02:48:47.268422', 3, 3, 3, 3, 3, 10, 8, 4, 4, 5, 5, 5, 5, 5, 33, 7, 'Task2'),
(15, '2025-10-25 02:51:41.259820', 0, 0, 0, 0, 0, 15, 10, 0, 0, 0, 0, 0, 13, 12, 25, 2, 'Task2'),
(16, '2025-10-25 02:52:39.798520', 12, 2, 8, 15, 3, 6, 0, 8, 7, 8, 8, 7, 8, 0, 46, 6, 'Task2'),
(17, '2025-10-25 02:53:35.347399', 2, 1, 3, 2, 1, 0, 0, 2, 1, 2, 2, 2, 0, 0, 9, 5, 'Task2'),
(18, '2025-10-25 02:54:22.496848', 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0, 20, 1, 'Task2'),
(19, '2025-10-25 02:55:36.657563', 25, 20, 30, 35, 15, 10, 5, 20, 20, 20, 20, 20, 20, 20, 140, 7, 'Task2'),
(20, '2025-10-25 02:56:51.731767', 10, 0, 8, 0, 12, 0, 6, 9, 0, 9, 0, 9, 0, 9, 36, 4, 'Task2');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20251024184246_InitialCreate', '9.0.10');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `productionplans`
--
ALTER TABLE `productionplans`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `productionplans`
--
ALTER TABLE `productionplans`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
