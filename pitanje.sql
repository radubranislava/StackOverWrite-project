-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 26, 2023 at 10:55 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `stackoverwrite`
--

-- --------------------------------------------------------

--
-- Table structure for table `pitanje`
--

CREATE TABLE `pitanje` (
  `id_pitanja` int(11) NOT NULL,
  `naslov` text NOT NULL,
  `sadrzaj` text NOT NULL,
  `datum_postavljanja` datetime NOT NULL,
  `id_korisnika` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pitanje`
--

INSERT INTO `pitanje` (`id_pitanja`, `naslov`, `sadrzaj`, `datum_postavljanja`, `id_korisnika`) VALUES
(1, ' Kako izvrsiti azuriranje vise redova odjednom u SQL-u?', 'Imam tabelu u bazi podataka sa velikim brojem redova. Trebam da azuriram vrednosti odredjenih kolona za vise redova istovremeno. Kako mogu efikasno izvršiti ovo azuriranje bez da rucno pisem upite za svaki red?', '2023-08-01 07:13:25', 1),
(2, 'Kako da proverim da li je String prazan u Javi?', 'Treba da proverim da li je String promenljiva prazna ili sadrzi samo beline (praznine) u Javi. Koji je najbolji nacin da izvedem ovu proveru?', '2023-08-04 20:13:25', 2),
(3, 'Kako u  SQL-u da  izvrsim azuriranje vise redova?', 'Imam tabelu u bazi podataka sa velikim brojem redova. Trebam da azuriram vrednosti odredjenih kolona za vise redova istovremeno. Kako mogu efikasno izvrsiti ovo azuriranje bez da rucno pisem upite za svaki red?', '2023-08-05 08:18:57', 4);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pitanje`
--
ALTER TABLE `pitanje`
  ADD PRIMARY KEY (`id_pitanja`),
  ADD KEY `FK_korisnik_pitanje` (`id_korisnika`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `pitanje`
--
ALTER TABLE `pitanje`
  MODIFY `id_pitanja` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `pitanje`
--
ALTER TABLE `pitanje`
  ADD CONSTRAINT `pitanje_ibfk_1` FOREIGN KEY (`id_korisnika`) REFERENCES `korisnik` (`id_korisnika`) ON DELETE NO ACTION ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
