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
-- Table structure for table `maintenance`
--

CREATE TABLE `maintenance` (
  `maintenanceId` int(5) NOT NULL,
  `maintenanceStatus` varchar(30) NOT NULL,
  `maintenanceDescription` varchar(30) NOT NULL,
  `vehicleId` int(5) NOT NULL,
  `serviceId` int(5) NOT NULL,
  `customerInvoiceId` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `maintenance`
--

INSERT INTO `maintenance` (`maintenanceId`, `maintenanceStatus`, `maintenanceDescription`, `vehicleId`, `serviceId`, `customerInvoiceId`) VALUES
(11, 'Ongoing', 'Test', 1, 3, 1),
(12, 'Ongoing', 'Test', 1, 5, 1),
(13, 'Ongoing', 'Test 2', 1, 3, 1),
(14, 'Ongoing', 'Test 2', 1, 5, 1),
(23, 'Ongoing', 'Test description', 2, 7, 2),
(24, 'Ongoing', 'Test description', 2, 9, 2),
(25, 'Ongoing', 'Test description', 2, 11, 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `maintenance`
--
ALTER TABLE `maintenance`
  ADD PRIMARY KEY (`maintenanceId`),
  ADD KEY `fk_m_vehiId` (`vehicleId`),
  ADD KEY `fk_m_servId` (`serviceId`),
  ADD KEY `fk_m_custinvId` (`customerInvoiceId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `maintenance`
--
ALTER TABLE `maintenance`
  MODIFY `maintenanceId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `maintenance`
--
ALTER TABLE `maintenance`
  ADD CONSTRAINT `fk_m_custinvId` FOREIGN KEY (`customerInvoiceId`) REFERENCES `customer_invoice` (`customerInvoiceId`),
  ADD CONSTRAINT `fk_m_servId` FOREIGN KEY (`serviceId`) REFERENCES `service` (`serviceId`),
  ADD CONSTRAINT `fk_m_vehiId` FOREIGN KEY (`vehicleId`) REFERENCES `vehicle` (`vehicleId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
