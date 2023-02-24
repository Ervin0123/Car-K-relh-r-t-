-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Feb 24. 11:37
-- Kiszolgáló verziója: 10.4.25-MariaDB
-- PHP verzió: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `car-carelharito`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `elado_auto`
--

CREATE TABLE `elado_auto` (
  `elado_id` int(11) NOT NULL,
  `elado_rendszam` varchar(7) NOT NULL,
  `elado_ar` int(20) NOT NULL,
  `elado_kilometer` int(10) NOT NULL,
  `elado_evjarat` int(4) NOT NULL,
  `elado_kep` varchar(150) NOT NULL,
  `elado_uzemanyag` varchar(20) NOT NULL,
  `elado_teljesitmeny` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `elado_auto`
--

INSERT INTO `elado_auto` (`elado_id`, `elado_rendszam`, `elado_ar`, `elado_kilometer`, `elado_evjarat`, `elado_kep`, `elado_uzemanyag`, `elado_teljesitmeny`) VALUES
(1, 'ABC-123', 150000, 235000, 2001, '../autok/ferka.jpg', 'benzin', 160),
(2, 'AAA-111', 3000000, 432000, 2005, '../autok/bomos.jpg', 'benzin', 300),
(3, 'string', 0, 0, 0, 'string', 'string', 0),
(4, 'string', 0, 0, 0, 'string', 'string', 0),
(6, 'string', 0, 0, 0, 'string', 'string', 0),
(7, 'string', 0, 0, 0, 'string', 'string', 0),
(8, 'string', 0, 0, 0, 'string', 'string', 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `megrendelo`
--

CREATE TABLE `megrendelo` (
  `megrend_id` int(11) NOT NULL,
  `megrend_nev` varchar(80) NOT NULL,
  `megrend_email` varchar(80) NOT NULL,
  `megrend_tel` int(11) NOT NULL,
  `megrend_rendszam` varchar(12) NOT NULL,
  `szolg_id` int(11) NOT NULL,
  `megrend_megjegyzes` varchar(255) NOT NULL,
  `megrend_idopont` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `megrendelo`
--

INSERT INTO `megrendelo` (`megrend_id`, `megrend_nev`, `megrend_email`, `megrend_tel`, `megrend_rendszam`, `szolg_id`, `megrend_megjegyzes`, `megrend_idopont`) VALUES
(1, 'string', 'string', 0, 'string', 3, 'string', '2023-02-24'),
(4, 'string', 'string', 0, 'string', 4, 'string', '2023-02-24');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szolgaltatas`
--

CREATE TABLE `szolgaltatas` (
  `szolg_id` int(11) NOT NULL,
  `szolg_nev` varchar(100) NOT NULL,
  `szolg_idotartam` varchar(10) NOT NULL,
  `szolg_ar` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `szolgaltatas`
--

INSERT INTO `szolgaltatas` (`szolg_id`, `szolg_nev`, `szolg_idotartam`, `szolg_ar`) VALUES
(1, 'a', '00:00:00', 200),
(2, 'Autó mosás', '00:25:00', 20000),
(3, 'string', 'string', 0),
(4, 'string', 'string', 0),
(5, 'string', 'string', 0),
(6, 'string', 'string', 0);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `elado_auto`
--
ALTER TABLE `elado_auto`
  ADD PRIMARY KEY (`elado_id`);

--
-- A tábla indexei `megrendelo`
--
ALTER TABLE `megrendelo`
  ADD PRIMARY KEY (`megrend_id`),
  ADD KEY `szolg_id` (`szolg_id`);

--
-- A tábla indexei `szolgaltatas`
--
ALTER TABLE `szolgaltatas`
  ADD PRIMARY KEY (`szolg_id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `elado_auto`
--
ALTER TABLE `elado_auto`
  MODIFY `elado_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT a táblához `megrendelo`
--
ALTER TABLE `megrendelo`
  MODIFY `megrend_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT a táblához `szolgaltatas`
--
ALTER TABLE `szolgaltatas`
  MODIFY `szolg_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `megrendelo`
--
ALTER TABLE `megrendelo`
  ADD CONSTRAINT `megrendelo_ibfk_2` FOREIGN KEY (`szolg_id`) REFERENCES `szolgaltatas` (`szolg_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
