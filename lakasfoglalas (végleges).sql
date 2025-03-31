-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Már 31. 07:41
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `lakasfoglalas`
--
CREATE DATABASE IF NOT EXISTS `lakasfoglalas` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `lakasfoglalas`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `eladasok`
--

CREATE TABLE `eladasok` (
  `ID` int(11) NOT NULL,
  `FelhasznaloID` int(11) NOT NULL,
  `LakasID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `lakasok`
--

CREATE TABLE `lakasok` (
  `ID` int(11) NOT NULL,
  `Utca` varchar(32) NOT NULL,
  `Meret` int(10) NOT NULL,
  `Szobak szama` int(10) NOT NULL,
  `Ar` int(10) NOT NULL,
  `Leiras` varchar(100) NOT NULL,
  `FelhasznaloID` int(11) NOT NULL,
  `VarosID` int(11) NOT NULL,
  `Eladva` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `lakasok`
--

INSERT INTO `lakasok` (`ID`, `Utca`, `Meret`, `Szobak szama`, `Ar`, `Leiras`, `FelhasznaloID`, `VarosID`, `Eladva`) VALUES
(1, 'Ady Endre utca 46.', 54, 3, 7000000, 'szép', 1, 1, 0),
(2, 'Fő utca', 43, 2, 4000000, 'romos', 1, 1, 0),
(7, 'Kádár utca', 52, 3, 10000000, 'Nagyon jó ajánlat', 17, 1, 0),
(8, 'Acél utca', 70, 4, 25000000, 'Nagy előre beépített szobák.', 14, 1, 0),
(9, 'Ady Endre utca', 20, 1, 2500000, 'kicsi egyszobás konyha szobával', 15, 1, 0),
(10, 'Ferenc Utca', 40, 2, 50000000, 'Beépített konyha.', 19, 3, 0);

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
-- Tábla szerkezet ehhez a táblához `user`
--

CREATE TABLE `user` (
  `Id` int(11) NOT NULL,
  `LoginNev` varchar(16) NOT NULL,
  `HASH` varchar(64) NOT NULL,
  `SALT` varchar(64) NOT NULL,
  `Name` varchar(64) NOT NULL,
  `PermissionId` int(11) NOT NULL,
  `Active` tinyint(1) NOT NULL,
  `Email` varchar(64) NOT NULL,
  `ProfilePicturePath` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `user`
--

INSERT INTO `user` (`Id`, `LoginNev`, `HASH`, `SALT`, `Name`, `PermissionId`, `Active`, `Email`, `ProfilePicturePath`) VALUES
(1, 'kerenyir', 'dcedbd2d352d19c6eae0dfb12271b74d985c825b8d774afd2abd0d101b6e57ef', 'jQGX8grO1yjNqhiZbtROcseiqj1NVZJd2iqlfxPx1GKLJ9H8smnLJ9dloScCK6Zp', 'Kerényi Róbert', 9, 1, 'kerenyir@kkszki.hu', 'lrn.jpg'),
(14, 'Markolajj', '90d8ba8022793eeef9fa2927aea5065fdc6036159d396112d01c7dfd514adf3b', 'SeUixBcCwUqhEATa2I1yEg2oU9oC0muQAUET68fQ9WEmhPjG4BKKbvdj2bZ1lHCN', 'Havasi Márk', 9, 1, 'havmark04@gmail.com', 'default.jpg'),
(15, 'Illes', '563441f427b49e5f0d70488dcc0c87655de4c30a290986fab0c32ef1192eb3f4', 'lDW5183y8oU3UifKfbAnCUIT4QHlF6oq8dCqhZiSkwOAlMJ2HYlXiQc2vbxhuLDW', 'Illés Máté', 9, 1, 'illesm@kkszki.hu', 'default.jpg'),
(16, 'jani', '848d0ecb056a650ce01752c0e53993fd7961c45eedfa17089be42ffcedb44668', 'aU8kPl1yhHV8jBxgvD9Fh1vb43cfj7XVgD75szq7Gj22c1kMMyjbOE47WZ7AWXSD', 'Kovács János', 1, 1, 'kova@gmail.com', 'default.jpg'),
(17, 'tesó', 'a03808d5e5c56f66b79f7840edf9fcdeb5073281089c8b86095cf73e03e72489', 'vHlADvFDWAQYCxTgT3Ehu33ovJJWQ5zJO82gm2pOFZ7no0wJ3xcsAPJue1Tfm1MZ', 'Nagy Kristóf', 1, 1, 'nagykirstof@freemail.hu', 'default.jpg'),
(18, 'Süti', '5dd85c98ad19158c0b44df39b7e2868f0b460a0ff0f1cd20b4c8315fcaad0c87', '7GPtPjcYxiw7FwimCjdIKAGPEx641ML61qlHuHoBvnaM2P3fQLZr2yjFEyaPalmq', 'Mádai Áron', 1, 1, 'árcsi@gmail.com', 'default.jpg'),
(19, 'Kender', '9d3fa02e848b37ebbe2a28fecfee82cada036da7b656b51ff37b5ee6b334d96b', 'C3n5AWs5JKpC11kU64r7xKivZ29eLGEjRv04M4VE4KO8kll9Z8Odobu3wlfViVbo', 'Kender Ferenc', 9, 1, 'Kender@gmail.com', 'default.jpg');

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
-- A tábla indexei `eladasok`
--
ALTER TABLE `eladasok`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FelhasznaloID` (`FelhasznaloID`),
  ADD KEY `LakasID` (`LakasID`);

--
-- A tábla indexei `lakasok`
--
ALTER TABLE `lakasok`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FelhasznaloID` (`FelhasznaloID`),
  ADD KEY `VarosID` (`VarosID`);

--
-- A tábla indexei `megyek`
--
ALTER TABLE `megyek`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `LoginNev` (`LoginNev`),
  ADD UNIQUE KEY `Email` (`Email`),
  ADD KEY `Jog` (`PermissionId`);

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
-- AUTO_INCREMENT a táblához `eladasok`
--
ALTER TABLE `eladasok`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT a táblához `lakasok`
--
ALTER TABLE `lakasok`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `megyek`
--
ALTER TABLE `megyek`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT a táblához `user`
--
ALTER TABLE `user`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT a táblához `varosok`
--
ALTER TABLE `varosok`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `eladasok`
--
ALTER TABLE `eladasok`
  ADD CONSTRAINT `eladasok_ibfk_2` FOREIGN KEY (`LakasID`) REFERENCES `lakasok` (`ID`),
  ADD CONSTRAINT `eladasok_ibfk_3` FOREIGN KEY (`FelhasznaloID`) REFERENCES `user` (`Id`);

--
-- Megkötések a táblához `lakasok`
--
ALTER TABLE `lakasok`
  ADD CONSTRAINT `lakasok_ibfk_1` FOREIGN KEY (`VarosID`) REFERENCES `varosok` (`ID`),
  ADD CONSTRAINT `lakasok_ibfk_2` FOREIGN KEY (`FelhasznaloID`) REFERENCES `user` (`Id`);

--
-- Megkötések a táblához `varosok`
--
ALTER TABLE `varosok`
  ADD CONSTRAINT `varosok_ibfk_1` FOREIGN KEY (`MegyeID`) REFERENCES `megyek` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
