CREATE TABLE `aaproductrange` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Saturday` bit(1) DEFAULT NULL,
  `Sunday` bit(1) DEFAULT NULL,
  `Monday` bit(1) DEFAULT NULL,
  `Tuesday` bit(1) DEFAULT NULL,
  `Wednesday` bit(1) DEFAULT NULL,
  `Thurday` bit(1) DEFAULT NULL,
  `Friday` bit(1) DEFAULT NULL,
  `Bookable` bit(1) DEFAULT NULL,
  `FromTime` datetime DEFAULT NULL,
  `ToTime` datetime DEFAULT NULL,
  `Priority` int DEFAULT NULL,
  `ProductId` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
