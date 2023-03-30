CREATE TABLE `aaproductlanguage` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Language` varchar(500) DEFAULT NULL,
  `ProductId` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;