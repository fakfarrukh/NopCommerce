CREATE TABLE `aaproduct` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Gender` varchar(45) DEFAULT NULL,
  `Nationality` varchar(45) DEFAULT NULL,
  `HomeVisit` bit(1) DEFAULT NULL,
  `PhoneCall` bit(1) DEFAULT NULL,
  `VirtualConf` bit(1) DEFAULT NULL,
  `ProductId` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;