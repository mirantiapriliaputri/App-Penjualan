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
-- Table structure for table `tbl_detailjual`
--

CREATE TABLE `tbl_detailjual` (
  `no_jual` varchar(10) NOT NULL,
  `kode_barang` varchar(6) NOT NULL,
  `nama_barang` varchar(50) NOT NULL,
  `harga_jual` int(11) NOT NULL,
  `jumlah_jual` int(11) NOT NULL,
  `subtotal` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_detailjual`
--

INSERT INTO `tbl_detailjual` (`no_jual`, `kode_barang`, `nama_barang`, `harga_jual`, `jumlah_jual`, `subtotal`) VALUES
('J200410003', 'BRG001', 'Mie', 2500, 2, 5000),
('J200410003', 'BRG002', 'Kecap', 8000, 2, 16000),
('J200412004', 'BRG001', 'Mie', 2500, 5, 12500),
('J200412004', 'BRG001', 'Mie', 2500, 2, 5000),
('J200412005', 'BRG002', 'Kecap', 8000, 2, 16000),
('J200412006', 'BRG001', 'Mie', 2500, 2, 5000),
('J200414007', 'BRG002', 'Kecap', 8000, 2, 16000);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
