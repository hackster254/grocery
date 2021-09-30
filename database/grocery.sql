-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 27, 2021 at 07:49 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `grocery`
--

-- --------------------------------------------------------

--
-- Table structure for table `bill`
--

CREATE TABLE `bill` (
  `BId` int(11) NOT NULL,
  `BClientName` varchar(35) NOT NULL,
  `BAmt` int(11) NOT NULL,
  `BDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `bill`
--

INSERT INTO `bill` (`BId`, `BClientName`, `BAmt`, `BDate`) VALUES
(1, 'System.Windows.Forms.TextBox, Text:', 0, '2021-08-26'),
(2, 'E', 312, '2021-08-27'),
(3, 'TOM', 3, '2021-08-27');

-- --------------------------------------------------------

--
-- Table structure for table `item`
--

CREATE TABLE `item` (
  `ItId` int(11) NOT NULL,
  `ItName` varchar(20) NOT NULL,
  `ItPrice` int(11) NOT NULL,
  `ItQty` int(11) NOT NULL,
  `ItCat` varchar(35) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `item`
--

INSERT INTO `item` (`ItId`, `ItName`, `ItPrice`, `ItQty`, `ItCat`) VALUES
(11, 'ME', 45, 19, ''),
(12, 'Kales', 23, 15, 'VEGETABLE'),
(13, 'WOW', 45, 13, ''),
(14, 'Pineapples', 50, 23, 'VEGETABLE'),
(15, 'Spinach', 23, 5, 'VEGETABLE'),
(16, 'STEAK', 450, 4, 'MEAT');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bill`
--
ALTER TABLE `bill`
  ADD UNIQUE KEY `BId` (`BId`);

--
-- Indexes for table `item`
--
ALTER TABLE `item`
  ADD PRIMARY KEY (`ItId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bill`
--
ALTER TABLE `bill`
  MODIFY `BId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `item`
--
ALTER TABLE `item`
  MODIFY `ItId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
