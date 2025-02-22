-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 22, 2025 at 01:19 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `car_service_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `employee_maintenance`
--

CREATE TABLE `employee_maintenance` (
  `employeeId` int(5) NOT NULL,
  `maintenanceId` int(5) NOT NULL,
  `maintenanceDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employee_maintenance`
--

INSERT INTO `employee_maintenance` (`employeeId`, `maintenanceId`, `maintenanceDate`) VALUES
(1, 11, '2025-02-20'),
(1, 12, '2025-02-20'),
(2, 13, '2025-02-21'),
(2, 14, '2025-02-21'),
(2, 23, '2025-02-22'),
(2, 24, '2025-02-22'),
(2, 25, '2025-02-22');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `employee_maintenance`
--
ALTER TABLE `employee_maintenance`
  ADD PRIMARY KEY (`employeeId`,`maintenanceId`),
  ADD KEY `fk_e_m_maintenanceId` (`maintenanceId`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `employee_maintenance`
--
ALTER TABLE `employee_maintenance`
  ADD CONSTRAINT `fk_e_m_employeeId` FOREIGN KEY (`employeeId`) REFERENCES `employee` (`employeeId`),
  ADD CONSTRAINT `fk_e_m_maintenanceId` FOREIGN KEY (`maintenanceId`) REFERENCES `maintenance` (`maintenanceId`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
