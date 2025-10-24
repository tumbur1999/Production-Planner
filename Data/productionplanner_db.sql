-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 24, 2025 at 11:47 AM
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
-- Database: `productionplanner_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `plannings`
--

CREATE TABLE `plannings` (
  `Id` int(11) NOT NULL,
  `Senin` int(11) NOT NULL,
  `Selasa` int(11) NOT NULL,
  `Rabu` int(11) NOT NULL,
  `Kamis` int(11) NOT NULL,
  `Jumat` int(11) NOT NULL,
  `Sabtu` int(11) NOT NULL,
  `Minggu` int(11) NOT NULL,
  `Result` longtext,
  `TotalAwal` int(11) NOT NULL,
  `TotalAkhir` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `plannings`
--

INSERT INTO `plannings` (`Id`, `Senin`, `Selasa`, `Rabu`, `Kamis`, `Jumat`, `Sabtu`, `Minggu`, `Result`, `TotalAwal`, `TotalAkhir`, `CreatedAt`) VALUES
(1, 4, 5, 1, 7, 6, 4, 0, '4, 5, 4, 5, 5, 4, 0', 27, 27, '2025-10-24 16:37:00.742440'),
(2, 6, 0, 4, 6, 5, 0, 0, '6, 0, 5, 5, 5, 0, 0', 21, 21, '2025-10-24 16:38:44.940686'),
(3, 5, 5, 5, 5, 5, 5, 5, '5, 5, 5, 5, 5, 5, 5', 35, 35, '2025-10-24 16:39:15.892152'),
(4, 4, 4, 4, 4, 4, 0, 0, '4, 4, 4, 4, 4, 0, 0', 20, 20, '2025-10-24 16:39:33.050475'),
(5, 6, 0, 4, 6, 5, 0, 0, '6, 0, 5, 5, 5, 0, 0', 21, 21, '2025-10-24 16:42:27.437090'),
(6, 3, 2, 6, 5, 4, 0, 0, '4, 4, 4, 4, 4, 0, 0', 20, 20, '2025-10-24 16:43:28.453658'),
(7, 7, 7, 0, 7, 5, 0, 0, '8, 6, 0, 6, 6, 0, 0', 26, 26, '2025-10-24 16:43:50.252574'),
(8, 10, 8, 9, 7, 6, 5, 0, '8, 8, 8, 7, 7, 7, 0', 45, 45, '2025-10-24 16:44:55.855880'),
(9, 5, 0, 0, 6, 0, 5, 6, '5, 0, 0, 7, 0, 5, 5', 22, 22, '2025-10-24 16:45:23.003904'),
(10, 2, 3, 1, 4, 2, 3, 0, '2, 4, 2, 3, 2, 2, 0', 15, 15, '2025-10-24 16:45:41.352257');

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
('20251024093249_InitialCreate', '9.0.10');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `plannings`
--
ALTER TABLE `plannings`
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
-- AUTO_INCREMENT for table `plannings`
--
ALTER TABLE `plannings`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
