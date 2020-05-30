-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 30, 2020 at 02:22 AM
-- Server version: 10.1.36-MariaDB
-- PHP Version: 5.6.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_penjualan`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_jual`
--

CREATE TABLE `tbl_jual` (
  `no_jual` varchar(10) NOT NULL,
  `tgl_jual` date NOT NULL,
  `jam_jual` time NOT NULL,
  `item_jual` int(11) NOT NULL,
  `total_jual` int(11) NOT NULL,
  `dibayar` int(11) NOT NULL,
  `kembali` int(11) NOT NULL,
  `kode_pelanggan` varchar(6) NOT NULL,
  `kode_admin` varchar(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_jual`
--

INSERT INTO `tbl_jual` (`no_jual`, `tgl_jual`, `jam_jual`, `item_jual`, `total_jual`, `dibayar`, `kembali`, `kode_pelanggan`, `kode_admin`) VALUES
('J200410001', '0000-00-00', '10:04:23', 7, 28500, 50000, 21500, 'PLG002', 'ADM001'),
('J200410002', '2020-04-10', '10:21:59', 8, 47500, 50000, 2500, 'PLG002', 'ADM001'),
('J200410003', '2020-04-10', '11:17:52', 4, 21000, 50000, 29000, 'PLG002', 'ADM001'),
('J200412004', '2020-04-12', '11:30:07', 7, 17500, 20000, 2500, 'PLG003', 'ADM001'),
('J200412005', '2020-04-12', '11:35:05', 2, 16000, 50000, 34000, 'PLG002', 'ADM001'),
('J200412006', '2020-04-12', '11:56:03', 2, 5000, 10000, 5000, 'PLG002', 'ADM001'),
('J200414007', '2020-04-14', '08:41:16', 2, 16000, 20000, 4000, 'PLG003', 'ADM001');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_jual`
--
ALTER TABLE `tbl_jual`
  ADD PRIMARY KEY (`no_jual`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
