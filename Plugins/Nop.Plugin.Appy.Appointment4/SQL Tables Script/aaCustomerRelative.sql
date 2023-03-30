--CREATE TABLE `aacustomerrelative` (
--  `Id` INT NOT NULL AUTO_INCREMENT,
--  `CardId` VARCHAR(100) NULL,
--  `CardType` VARCHAR(45) NULL,
--  `ArabicName` VARCHAR(45) NULL,
--  `EnglishName` VARCHAR(45) NULL,
--  `BirthDate` DATETIME NULL,
--  `CustomerId` INT NULL,
--  PRIMARY KEY (`Id`));

  CREATE TABLE `aacustomerrelative` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CardId` varchar(100) DEFAULT NULL,
  `CardType` varchar(45) DEFAULT NULL,
  `ArabicName` varchar(45) DEFAULT NULL,
  `EnglishName` varchar(45) DEFAULT NULL,
  `BirthDate` datetime DEFAULT NULL,
  `CustomerId` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
