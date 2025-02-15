-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 15, 2025 at 04:19 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

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
-- Table structure for table `appointments`
--

CREATE TABLE `appointments` (
  `id` int(11) NOT NULL,
  `vehicleNumber` varchar(20) NOT NULL,
  `vehicleType` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `time` time NOT NULL,
  `serviceStation` varchar(50) NOT NULL,
  `servicesString` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `appointments`
--

INSERT INTO `appointments` (`id`, `vehicleNumber`, `vehicleType`, `date`, `time`, `serviceStation`, `servicesString`) VALUES
(1, 'CBE-3143', 'car', '2025-02-09', '22:54:00', 'Panadura', 'interiorCleaning, radiatorCoolantChange'),
(2, 'CBE-3143', 'car', '2025-02-09', '22:54:00', 'Panadura', 'oilFilterChange, interiorCleaning, radiatorCoolantChange'),
(3, 'CBE-3143', 'suv', '2025-02-21', '22:58:00', 'Gampola', 'fullService'),
(4, 'CBE-3143', 'suv', '2025-02-22', '23:08:00', 'Gampola', 'totalTreatment, radiatorCoolantChange'),
(5, 'CBE-3143', 'car', '2025-02-21', '12:41:00', 'Gampola', 'exteriorCutPolish, radiatorCoolantChange, brakeOilChange'),
(6, 'CBE-3143', 'car', '2025-02-14', '12:54:00', 'Gampola', 'exteriorCutPolish, totalTreatment');

-- --------------------------------------------------------

--
-- Table structure for table `contact`
--

CREATE TABLE `contact` (
  `messageId` int(5) NOT NULL,
  `message` varchar(100) NOT NULL,
  `firstName` varchar(50) NOT NULL,
  `lastName` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `phone` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `contact`
--

INSERT INTO `contact` (`messageId`, `message`, `firstName`, `lastName`, `email`, `phone`) VALUES
(1, 'dhwijdqwofqow', 'binithi', 'elvitigala', 'binithi.vihanga@gmail.com', '0704313535'),
(2, 'dhwijdqwofqow', 'binithi', 'elvitigala', 'binithi.vihanga@gmail.com', '0704313535'),
(3, 'dgwe', 'binithi', 'elvitigala', 'wjpq8454@outlook.com', '0704313535'),
(4, 'sckmka', 'binithi', 'elvitigala', 'wjpq8454@outlook.com', '0704313535'),
(5, 'svmafa', 'binithi', 'elvitigala', 'wjpq8454@outlook.com', '0704313535'),
(6, 'mnk', 'binithi', 'elvitigala', 'binithi.vihanga@gmail.com', '070431353'),
(7, 'mnk', 'binithi', 'elvitigala', 'binithi.vihanga@gmail.com', '0704313'),
(8, 'kjol', 'binithi', 'elvitigala', 'binithi.vihanga@gmail.com', '070431353'),
(9, 'hnik', 'binithi', 'elvitigala', 'binithi.vihanga@gmail.com', '07043135'),
(10, 'cnaK', 'binithi', 'elvitigala', 'binithi.vihanga@gmail.com', '0704313535'),
(11, 'fwefcdfqe', 'binithi', 'elvitigala', 'binithi.vihanga@gmail.com', '0704313535'),
(12, 'hiiiiiiiiii', 'binithi', 'elvitigala', 'wjpq8454@outlook.com', '0704313535'),
(13, 'bj', 'binithi', 'elvitigala', 'binithi.vihanga@gmail.com', '0704313535');

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `customerId` int(5) NOT NULL,
  `firstName` varchar(30) NOT NULL,
  `lastName` varchar(30) NOT NULL,
  `email` varchar(30) NOT NULL,
  `phone` varchar(15) NOT NULL,
  `userId` int(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`customerId`, `firstName`, `lastName`, `email`, `phone`, `userId`) VALUES
(1, 'Binithi', 'Elvitigala', 'binithi.vihanga@gmail.com', '0704313535', 1),
(4, 'binithi', 'elvitigala', 'dantha@gmail.com', '0704313535', 4),
(19, 'fcwq', 'vqe', 'binie2@efjiw.com', '0704313535', 19);

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `itemId` int(5) NOT NULL,
  `itemName` varchar(50) NOT NULL,
  `itemCategory` varchar(50) NOT NULL,
  `itemBrand` varchar(50) NOT NULL,
  `itemDescription` varchar(100) NOT NULL,
  `itemPrice` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`itemId`, `itemName`, `itemCategory`, `itemBrand`, `itemDescription`, `itemPrice`) VALUES
(1, 'clsc, ', 'Braking System', 'mcls', 's c', 500),
(3, 'd', 'Braking System', 'v', 'qd', 500);

-- --------------------------------------------------------

--
-- Table structure for table `inventory_manager`
--

CREATE TABLE `inventory_manager` (
  `inventoryManagerId` int(5) NOT NULL,
  `firstName` varchar(30) NOT NULL,
  `lastName` varchar(30) NOT NULL,
  `email` varchar(50) NOT NULL,
  `phoneNumber` varchar(15) NOT NULL,
  `inventoryManagerSalary` float NOT NULL,
  `userId` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inventory_manager`
--

INSERT INTO `inventory_manager` (`inventoryManagerId`, `firstName`, `lastName`, `email`, `phoneNumber`, `inventoryManagerSalary`, `userId`) VALUES
(1, 'bini', 'el', 'bini@gmal.com', '071567665', 7000, 1);

-- --------------------------------------------------------

--
-- Table structure for table `offer`
--

CREATE TABLE `offer` (
  `offerId` int(5) NOT NULL,
  `offerType` varchar(50) NOT NULL,
  `offerDescription` varchar(100) NOT NULL,
  `discount` float NOT NULL,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `offer`
--

INSERT INTO `offer` (`offerId`, `offerType`, `offerDescription`, `discount`, `startDate`, `endDate`) VALUES
(1, 'sc', 'offer2', 5000, '2025-01-28', '2025-02-13'),
(2, 'wsfw', 'ev', 5000, '2025-02-12', '2025-02-12');

-- --------------------------------------------------------

--
-- Table structure for table `payment`
--

CREATE TABLE `payment` (
  `paymentId` int(5) NOT NULL,
  `paymentAmount` float NOT NULL,
  `paymentDate` date NOT NULL,
  `paymentType` varchar(50) NOT NULL,
  `downPayment` float NOT NULL,
  `paymentStatus` varchar(50) NOT NULL,
  `offerId` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `purchase`
--

CREATE TABLE `purchase` (
  `purchaseId` int(5) NOT NULL,
  `quantity` int(4) NOT NULL,
  `purchaseDate` date NOT NULL,
  `comment` varchar(100) DEFAULT NULL,
  `itemId` int(5) NOT NULL,
  `supplierId` int(5) NOT NULL,
  `supplierInvoiceId` int(5) NOT NULL,
  `inventoryManagerId` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `purchase`
--

INSERT INTO `purchase` (`purchaseId`, `quantity`, `purchaseDate`, `comment`, `itemId`, `supplierId`, `supplierInvoiceId`, `inventoryManagerId`) VALUES
(22, 5, '2025-02-14', 'fwe', 1, 1, 1, 1),
(23, 4, '2025-02-14', 'ev', 1, 1, 2, 1),
(24, 8, '2025-02-28', 'cs', 3, 3, 5, 1),
(25, 3, '2025-02-20', 'vce', 3, 3, 4, 1),
(26, 10, '2025-02-24', 'ev', 1, 1, 6, 1);

-- --------------------------------------------------------

--
-- Table structure for table `service`
--

CREATE TABLE `service` (
  `serviceId` int(5) NOT NULL,
  `serviceName` varchar(30) NOT NULL,
  `serviceDescription` varchar(70) NOT NULL,
  `servicePrice` float NOT NULL,
  `serviceManagerId` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `service`
--

INSERT INTO `service` (`serviceId`, `serviceName`, `serviceDescription`, `servicePrice`, `serviceManagerId`) VALUES
(3, 'nlk', 'ms', 50100, 1),
(5, 'mjmols', 's,c', 82, 1),
(6, 'hikmlkp', 'binithi', 5000, 1),
(7, 'jdol', 'evw', 82, 1),
(8, 'dcfe', 'e,v', 600, 1),
(9, 'kdwl', 'l,cv;/', 52111, 1),
(11, 'ml', 'hvidvd', 5000, 1),
(12, 'hbk', 'nk', 72200, 1);

-- --------------------------------------------------------

--
-- Table structure for table `service_manager`
--

CREATE TABLE `service_manager` (
  `serviceManagerId` int(5) NOT NULL,
  `firstName` varchar(30) NOT NULL,
  `lastName` varchar(30) NOT NULL,
  `email` varchar(50) NOT NULL,
  `phoneNumber` varchar(15) NOT NULL,
  `serviceManagerSalary` float NOT NULL,
  `userId` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `service_manager`
--

INSERT INTO `service_manager` (`serviceManagerId`, `firstName`, `lastName`, `email`, `phoneNumber`, `serviceManagerSalary`, `userId`) VALUES
(1, 'binithi', 'el', 'bini@gmail.com', '0715698365', 5200, 1);

-- --------------------------------------------------------

--
-- Table structure for table `stock`
--

CREATE TABLE `stock` (
  `stockId` int(5) NOT NULL,
  `itemId` int(5) NOT NULL,
  `quantity` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `stock`
--

INSERT INTO `stock` (`stockId`, `itemId`, `quantity`) VALUES
(13, 1, 19),
(14, 3, 11);

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `supplierId` int(5) NOT NULL,
  `supplierfirstName` varchar(30) NOT NULL,
  `supplierlastName` varchar(30) NOT NULL,
  `phoneNumber` varchar(15) NOT NULL,
  `email` varchar(50) NOT NULL,
  `supplierCompany` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`supplierId`, `supplierfirstName`, `supplierlastName`, `phoneNumber`, `email`, `supplierCompany`) VALUES
(1, 'mdjowl,l', 'duqjkdmow', '0716060975', 'hdiwkmcol', 'mfcle'),
(3, 'ndk', 'ef', '0715676065', 'fqef', 'nibm');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `userId` int(5) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userId`, `username`, `password`) VALUES
(1, 'binithi.vihanga@gmail.com', 'biniEl2*'),
(4, 'dantha@gmail.com', 'danE@123'),
(19, 'binie2@efjiw.com', 'BINeI856@/+');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `appointments`
--
ALTER TABLE `appointments`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `contact`
--
ALTER TABLE `contact`
  ADD PRIMARY KEY (`messageId`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`customerId`),
  ADD KEY `fk_userId` (`userId`);

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`itemId`);

--
-- Indexes for table `inventory_manager`
--
ALTER TABLE `inventory_manager`
  ADD PRIMARY KEY (`inventoryManagerId`),
  ADD KEY `fk_invuserId` (`userId`);

--
-- Indexes for table `offer`
--
ALTER TABLE `offer`
  ADD PRIMARY KEY (`offerId`);

--
-- Indexes for table `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`paymentId`),
  ADD KEY `fk_orderId` (`offerId`);

--
-- Indexes for table `purchase`
--
ALTER TABLE `purchase`
  ADD PRIMARY KEY (`purchaseId`),
  ADD KEY `fk_suppId` (`supplierId`),
  ADD KEY `fk_inv_mngerId` (`inventoryManagerId`),
  ADD KEY `fk_puritemId` (`itemId`);

--
-- Indexes for table `service`
--
ALTER TABLE `service`
  ADD PRIMARY KEY (`serviceId`),
  ADD KEY `fk_smid` (`serviceManagerId`);

--
-- Indexes for table `service_manager`
--
ALTER TABLE `service_manager`
  ADD PRIMARY KEY (`serviceManagerId`),
  ADD KEY `fk_sm_userId` (`userId`);

--
-- Indexes for table `stock`
--
ALTER TABLE `stock`
  ADD PRIMARY KEY (`stockId`),
  ADD KEY `fk_itemId` (`itemId`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`supplierId`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `appointments`
--
ALTER TABLE `appointments`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `contact`
--
ALTER TABLE `contact`
  MODIFY `messageId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `customerId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `inventory`
--
ALTER TABLE `inventory`
  MODIFY `itemId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `inventory_manager`
--
ALTER TABLE `inventory_manager`
  MODIFY `inventoryManagerId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `offer`
--
ALTER TABLE `offer`
  MODIFY `offerId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `payment`
--
ALTER TABLE `payment`
  MODIFY `paymentId` int(5) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `purchase`
--
ALTER TABLE `purchase`
  MODIFY `purchaseId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `service`
--
ALTER TABLE `service`
  MODIFY `serviceId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `service_manager`
--
ALTER TABLE `service_manager`
  MODIFY `serviceManagerId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `stock`
--
ALTER TABLE `stock`
  MODIFY `stockId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `supplierId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `userId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `customer`
--
ALTER TABLE `customer`
  ADD CONSTRAINT `fk_userId` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`);

--
-- Constraints for table `inventory_manager`
--
ALTER TABLE `inventory_manager`
  ADD CONSTRAINT `fk_invuserId` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`);

--
-- Constraints for table `payment`
--
ALTER TABLE `payment`
  ADD CONSTRAINT `fk_orderId` FOREIGN KEY (`offerId`) REFERENCES `offer` (`offerId`);

--
-- Constraints for table `purchase`
--
ALTER TABLE `purchase`
  ADD CONSTRAINT `fk_inv_mngerId` FOREIGN KEY (`inventoryManagerId`) REFERENCES `inventory_manager` (`inventoryManagerId`),
  ADD CONSTRAINT `fk_puritemId` FOREIGN KEY (`itemId`) REFERENCES `inventory` (`itemId`),
  ADD CONSTRAINT `fk_suppId` FOREIGN KEY (`supplierId`) REFERENCES `supplier` (`supplierId`);

--
-- Constraints for table `service`
--
ALTER TABLE `service`
  ADD CONSTRAINT `fk_smid` FOREIGN KEY (`serviceManagerId`) REFERENCES `service_manager` (`serviceManagerId`);

--
-- Constraints for table `service_manager`
--
ALTER TABLE `service_manager`
  ADD CONSTRAINT `fk_sm_userId` FOREIGN KEY (`userId`) REFERENCES `user` (`userId`);

--
-- Constraints for table `stock`
--
ALTER TABLE `stock`
  ADD CONSTRAINT `fk_itemId` FOREIGN KEY (`itemId`) REFERENCES `inventory` (`itemId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
