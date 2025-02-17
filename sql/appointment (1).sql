-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3308
-- Generation Time: Feb 16, 2025 at 10:07 PM
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
-- Table structure for table `appointment`
--

CREATE TABLE `appointment` (
  `appointmentId` int(11) NOT NULL,
  `date` date NOT NULL,
  `time` time NOT NULL,
  `appointmentStatus` varchar(25) NOT NULL,
  `description` varchar(250) DEFAULT NULL,
  `vehicleId` int(11) DEFAULT NULL,
  `customerId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `appointment`
--

INSERT INTO `appointment` (`appointmentId`, `date`, `time`, `appointmentStatus`, `description`, `vehicleId`, `customerId`) VALUES
(1, '2025-02-16', '09:00:00', 'Confirmed', 'test drive needed', 9, 9),
(4, '2025-02-16', '10:00:00', 'Confirmed', 'test description 2', 1, 3),
(5, '2025-02-16', '10:00:00', 'Confirmed', 'test description 3', 4, 4),
(6, '2025-02-16', '10:00:00', 'Confirmed', 'test description 4', 5, 4),
(7, '2025-02-16', '10:00:00', 'Confirmed', 'test description 5', 7, 9);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `appointment`
--
ALTER TABLE `appointment`
  ADD PRIMARY KEY (`appointmentId`),
  ADD KEY `FK_VehicleId` (`vehicleId`),
  ADD KEY `FK_CustomerId` (`customerId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `appointment`
--
ALTER TABLE `appointment`
  MODIFY `appointmentId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `appointment`
--
ALTER TABLE `appointment`
  ADD CONSTRAINT `FK_CustomerId` FOREIGN KEY (`customerId`) REFERENCES `customer` (`customerId`),
  ADD CONSTRAINT `FK_VehicleId` FOREIGN KEY (`vehicleId`) REFERENCES `vehicle` (`vehicleId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
