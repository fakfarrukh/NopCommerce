CREATE TABLE `nopcommerence_app04`.`aaappointment` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `BookingPeriod` varchar(45) DEFAULT NULL,
  `BookingTimeBlock` varchar(54) DEFAULT NULL,
  `Cancelable` bit(1) DEFAULT NULL,
  `ConfirmationNeeded` bit(1) DEFAULT NULL,
  `BookingOpenSooner` varchar(54) DEFAULT NULL,
  `BookingOpenLater` varchar(54) DEFAULT NULL,
  `ProductId` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `nopcommerence_app04`.`aacustomerrelative` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CardId` varchar(100) DEFAULT NULL,
  `CardType` varchar(45) DEFAULT NULL,
  `ArabicName` varchar(45) DEFAULT NULL,
  `EnglishName` varchar(45) DEFAULT NULL,
  `BirthDate` datetime DEFAULT NULL,
  `CustomerId` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `nopcommerence_app04`.`aaproduct` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Gender` varchar(45) DEFAULT NULL,
  `Nationality` varchar(45) DEFAULT NULL,
  `HomeVisit` bit(1) DEFAULT NULL,
  `PhoneCall` bit(1) DEFAULT NULL,
  `VirtualConf` bit(1) DEFAULT NULL,
  `ProductId` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `nopcommerence_app04`.`aaproductlanguage` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Language` varchar(500) DEFAULT NULL,
  `ProductId` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `nopcommerence_app04`.`aaproductrange` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Saturday` bit(1) DEFAULT NULL,
  `Sunday` bit(1) DEFAULT NULL,
  `Monday` bit(1) DEFAULT NULL,
  `Tuesday` bit(1) DEFAULT NULL,
  `Wednesday` bit(1) DEFAULT NULL,
  `Thurday` bit(1) DEFAULT NULL,
  `Friday` bit(1) DEFAULT NULL,
  `Bookable` bit(1) DEFAULT NULL,
  `FromTime` time DEFAULT NULL,
  `ToTime` time DEFAULT NULL,
  `Priority` int DEFAULT NULL,
  `ProductId` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `nopcommerence_app04`.`aaproductservicecategory` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ServiceCategoryId` int DEFAULT NULL,
  `ProductId` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE `nopcommerence_app04`.`aastateprovince` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Abbreviation` varchar(500) DEFAULT NULL,
  `IsPublished` bit(1) DEFAULT NULL,
  `DisplayOrder` double DEFAULT NULL,
  `ArabicName` varchar(500) DEFAULT NULL,
  `StateProvinceID` int DEFAULT NULL,
  `CountryId` int DEFAULT NULL,
  `aastateprovincecol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
