-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Dec 16. 12:52
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `lakásfoglalás`
--
CREATE DATABASE IF NOT EXISTS `lakásfoglalás` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `lakásfoglalás`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `eladások`
--

CREATE TABLE `eladások` (
  `ID` int(11) NOT NULL,
  `FelhasznaloID` int(11) NOT NULL,
  `LakasID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `eladások`
--

INSERT INTO `eladások` (`ID`, `FelhasznaloID`, `LakasID`) VALUES
(1, 1, 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalok`
--

CREATE TABLE `felhasznalok` (
  `ID` int(11) NOT NULL,
  `Nev` varchar(30) NOT NULL,
  `Jelszo` varchar(30) NOT NULL,
  `Email` varchar(30) NOT NULL,
  `Telefonszam` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `felhasznalok`
--

INSERT INTO `felhasznalok` (`ID`, `Nev`, `Jelszo`, `Email`, `Telefonszam`) VALUES
(1, 'Havasi Márk', 'Markolajj0', 'havasim@kkszki.hu', '06705614500'),
(2, 'Illés Máté', '12345Jelszo', 'illesm@kkszki.hu', '06701234567'),
(3, 'Admin', 'Admin', 'Admin@gmail.com', '06704535642');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `foglalasok`
--

CREATE TABLE `foglalasok` (
  `ID` int(11) NOT NULL,
  `FelhasznaloID` int(11) NOT NULL,
  `LakasID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `foglalasok`
--

INSERT INTO `foglalasok` (`ID`, `FelhasznaloID`, `LakasID`) VALUES
(1, 2, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `lakások`
--

CREATE TABLE `lakások` (
  `ID` int(11) NOT NULL,
  `Utca` varchar(32) NOT NULL,
  `Meret` int(10) NOT NULL,
  `Szobak szama` int(10) NOT NULL,
  `Ar` int(10) NOT NULL,
  `Leiras` varchar(100) NOT NULL,
  `FelhasznaloID` int(11) NOT NULL,
  `VarosID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `lakások`
--

INSERT INTO `lakások` (`ID`, `Utca`, `Meret`, `Szobak szama`, `Ar`, `Leiras`, `FelhasznaloID`, `VarosID`) VALUES
(1, 'Ady Endre utca 46.', 54, 3, 7000000, 'szép', 3, 1),
(2, 'Fő utca', 43, 2, 4000000, 'romos', 3, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `megyek`
--

CREATE TABLE `megyek` (
  `ID` int(11) NOT NULL,
  `Megye` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `megyek`
--

INSERT INTO `megyek` (`ID`, `Megye`) VALUES
(1, 'Bács-Kiskun'),
(2, 'Baranya'),
(3, 'Békés'),
(4, 'Borsod-Abaúj-Zemplén'),
(5, 'Csongrád-Csanád'),
(6, 'Fejér'),
(7, 'Győr-Moson-Sopron'),
(8, 'Hajdú-Bihar'),
(9, 'Heves'),
(10, 'Jász-Nagykun-Szolnok'),
(11, 'Komárom-Esztergom'),
(12, 'Nógrád'),
(13, 'Pest'),
(14, 'Somogy'),
(15, 'Szabolcs-Szatmár-Bereg'),
(16, 'Tolna'),
(17, 'Vas'),
(18, 'Veszprém'),
(19, 'Zala');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `varosok`
--

CREATE TABLE `varosok` (
  `ID` int(11) NOT NULL,
  `Varos` varchar(30) NOT NULL,
  `MegyeID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `varosok`
--

INSERT INTO `varosok` (`ID`, `Varos`, `MegyeID`) VALUES
(1, 'Miskolc', 4),
(2, 'Budapest', 13),
(3, 'Salgótarján', 12),
(4, 'Győr', 7);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `eladások`
--
ALTER TABLE `eladások`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FelhasznaloID` (`FelhasznaloID`),
  ADD KEY `LakasID` (`LakasID`);

--
-- A tábla indexei `felhasznalok`
--
ALTER TABLE `felhasznalok`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `foglalasok`
--
ALTER TABLE `foglalasok`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FelhasznaloID` (`FelhasznaloID`),
  ADD KEY `LakasID` (`LakasID`);

--
-- A tábla indexei `lakások`
--
ALTER TABLE `lakások`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FelhasznaloID` (`FelhasznaloID`),
  ADD KEY `VarosID` (`VarosID`);

--
-- A tábla indexei `megyek`
--
ALTER TABLE `megyek`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `varosok`
--
ALTER TABLE `varosok`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `MegyeID` (`MegyeID`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `eladások`
--
ALTER TABLE `eladások`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT a táblához `felhasznalok`
--
ALTER TABLE `felhasznalok`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `foglalasok`
--
ALTER TABLE `foglalasok`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT a táblához `lakások`
--
ALTER TABLE `lakások`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `megyek`
--
ALTER TABLE `megyek`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT a táblához `varosok`
--
ALTER TABLE `varosok`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `eladások`
--
ALTER TABLE `eladások`
  ADD CONSTRAINT `eladások_ibfk_1` FOREIGN KEY (`FelhasznaloID`) REFERENCES `felhasznalok` (`ID`),
  ADD CONSTRAINT `eladások_ibfk_2` FOREIGN KEY (`LakasID`) REFERENCES `lakások` (`ID`);

--
-- Megkötések a táblához `foglalasok`
--
ALTER TABLE `foglalasok`
  ADD CONSTRAINT `foglalasok_ibfk_1` FOREIGN KEY (`FelhasznaloID`) REFERENCES `felhasznalok` (`ID`),
  ADD CONSTRAINT `foglalasok_ibfk_2` FOREIGN KEY (`LakasID`) REFERENCES `lakások` (`ID`);

--
-- Megkötések a táblához `lakások`
--
ALTER TABLE `lakások`
  ADD CONSTRAINT `lakások_ibfk_1` FOREIGN KEY (`VarosID`) REFERENCES `varosok` (`ID`),
  ADD CONSTRAINT `lakások_ibfk_2` FOREIGN KEY (`FelhasznaloID`) REFERENCES `felhasznalok` (`ID`);

--
-- Megkötések a táblához `varosok`
--
ALTER TABLE `varosok`
  ADD CONSTRAINT `varosok_ibfk_1` FOREIGN KEY (`MegyeID`) REFERENCES `megyek` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
