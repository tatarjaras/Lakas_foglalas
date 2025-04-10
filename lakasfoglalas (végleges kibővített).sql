-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Ápr 10. 18:34
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
(10, 'Ferenc Utca', 40, 2, 50000000, 'Beépített konyha.', 19, 3, 0),
(11, 'Ferenc Utca', 60, 2, 10000000, 'Friss festés', 14, 1, 0),
(12, 'Kossuth Utca', 55, 2, 9500000, 'Tágas nappali', 14, 1, 0),
(13, 'Petőfi Sándor Utca', 48, 1, 8700000, 'Felújított konyha', 14, 1, 0),
(14, 'Bajcsy-Zsilinszky út', 72, 3, 12000000, 'Erkélyes', 14, 1, 0),
(15, 'Ady Endre Utca', 65, 2, 10500000, 'Csendes környék', 14, 1, 0),
(16, 'Arany János Utca', 60, 2, 10200000, 'Frissen burkolt fürdő', 14, 1, 0),
(17, 'Széchenyi Tér', 70, 3, 11500000, 'Kertkapcsolatos', 14, 1, 0),
(18, 'Bartók Béla Út', 50, 1, 8800000, 'Központi fűtés', 14, 1, 0),
(19, 'Rákóczi Út', 58, 2, 9800000, 'Közel a tömegközlekedéshez', 14, 1, 0),
(20, 'Vörösmarty Utca', 62, 2, 10300000, 'Világos lakás', 14, 1, 0),
(21, 'Csokonai Utca', 75, 3, 12500000, 'Panorámás kilátás', 14, 1, 0),
(22, 'Kálvin Tér', 61, 2, 10100000, 'Felújított fürdő', 14, 1, 0),
(23, 'Móricz Zsigmond Körtér', 59, 2, 9900000, 'Csendes utca', 14, 1, 0),
(24, 'Jókai Utca', 50, 1, 8700000, 'Alacsony rezsi', 14, 1, 0),
(25, 'Dózsa György Út', 73, 3, 11800000, 'Teraszos', 14, 1, 0),
(26, 'Bem József Utca', 66, 2, 10600000, 'Modern nyílászárók', 14, 1, 0),
(27, 'Károlyi Mihály Utca', 58, 2, 9700000, 'Jó elrendezés', 14, 1, 0),
(28, 'Szent István Körút', 64, 2, 10300000, 'Zöldövezet', 14, 1, 0),
(29, 'Váci Út', 55, 1, 8900000, 'Lift van', 14, 1, 0),
(30, 'Árpád Út', 63, 2, 10150000, 'Világos terek', 14, 1, 0),
(31, 'Hunyadi János Utca', 70, 3, 11600000, 'Közel bolt, iskola', 14, 1, 0),
(32, 'Király Utca', 57, 2, 9800000, 'Jó közlekedés', 14, 1, 0),
(33, 'Régiposta Utca', 49, 1, 8600000, 'Befektetésnek is jó', 14, 1, 0),
(34, 'Fő Utca', 60, 2, 10050000, 'Új konyhabútor', 14, 1, 0),
(35, 'Mester Utca', 65, 2, 10400000, 'Alacsony fenntartási költség', 14, 1, 0),
(36, 'Hársfa Utca', 52, 1, 8750000, 'Belváros közeli', 14, 1, 0),
(37, 'Táncsics Mihály Utca', 68, 2, 10900000, 'Kocsibeállóval', 14, 1, 0),
(38, 'Akácfa Utca', 56, 2, 9400000, 'Nagy ablakok', 14, 1, 0),
(39, 'József Attila Tér', 67, 2, 10700000, 'Kettő erkély', 14, 1, 0),
(40, 'Vasút Utca', 61, 2, 10000000, 'Szép kilátás', 14, 1, 0),
(41, 'Templom Utca', 54, 1, 8800000, 'Csendes szomszédság', 14, 1, 0),
(42, 'Kertész Utca', 62, 2, 10200000, 'Friss festés', 14, 1, 0),
(43, 'Kassai Út', 69, 3, 11200000, 'Tágas lakás', 14, 1, 0),
(44, 'Somogyi Béla Utca', 48, 1, 8500000, 'Frissen burkolva', 14, 1, 0),
(45, 'Bajza Utca', 53, 2, 9300000, 'Jó elosztás', 14, 1, 0),
(46, 'Ilka Utca', 66, 2, 10550000, 'Padlófűtés', 14, 1, 0),
(47, 'Róna Utca', 70, 3, 11400000, 'Két fürdőszoba', 14, 1, 0),
(48, 'Veres Péter Út', 63, 2, 10100000, 'Nagy erkély', 14, 1, 0),
(49, 'Báthory Utca', 51, 1, 8700000, 'Garázzsal', 14, 1, 0),
(50, 'Garay Utca', 60, 2, 10000000, 'Zárt lépcsőház', 14, 1, 0),
(51, 'Kéthly Anna Tér', 59, 2, 9800000, 'Közel piac', 14, 1, 0),
(52, 'Huba Utca', 64, 2, 10450000, 'Tágas nappali', 14, 1, 0),
(53, 'Nagy Lajos Király Útja', 68, 3, 11100000, 'Szigetelt ház', 14, 1, 0),
(54, 'Török Utca', 58, 2, 9600000, 'Frissen felújítva', 14, 1, 0),
(55, 'Erzsébet Körút', 55, 2, 9500000, 'Közel metróhoz', 14, 1, 0),
(56, 'Garibaldi Utca', 61, 2, 10100000, 'Beépített szekrények', 14, 1, 0),
(57, 'Csengery Utca', 52, 1, 8800000, 'Új nyílászárók', 14, 1, 0),
(58, 'Kútvölgyi Út', 67, 3, 11300000, 'Családbarát környék', 14, 1, 0),
(59, 'Fadrusz Utca', 60, 2, 10000000, 'Csendes társasház', 14, 1, 0),
(60, 'Márvány Utca', 65, 2, 10500000, 'Tágas előszoba', 14, 1, 0),
(61, 'Zuglói Körút', 70, 3, 11500000, 'Kertre néző', 14, 1, 0),
(62, 'Vérmező Út', 59, 2, 9900000, 'Felújított tető', 14, 1, 0),
(63, 'Kazinczy Utca', 54, 1, 8800000, 'Belváros szíve', 14, 1, 0),
(64, 'Sasadi Út', 66, 2, 10600000, 'Zöld kilátás', 14, 1, 0),
(65, 'Teleki Tér', 57, 2, 9700000, 'Tágas konyha', 14, 1, 0),
(66, 'Böszörményi Út', 62, 2, 10250000, 'Sarki lakás', 14, 1, 0),
(67, 'Thököly Út', 60, 2, 10000000, 'Lift van a házban', 14, 1, 0),
(68, 'Tátra Utca', 63, 2, 10150000, 'Központi hely', 14, 1, 0),
(69, 'Menyecske Utca', 65, 2, 10400000, 'Nagy nappali', 14, 1, 0),
(70, 'Tétényi Út', 68, 3, 11000000, 'Nappali+étkező', 14, 1, 0),
(71, 'Zágrábi Utca', 56, 2, 9400000, 'Távfűtés', 14, 1, 0),
(72, 'Kinizsi Utca', 61, 2, 10100000, 'Felújított belső tér', 14, 1, 0);

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=73;

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
