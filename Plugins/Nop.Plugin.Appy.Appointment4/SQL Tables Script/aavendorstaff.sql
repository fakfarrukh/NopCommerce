﻿CREATE TABLE `aavendorstaff` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `VendorId` int DEFAULT NULL,
  `ClinicId` int DEFAULT NULL,
  `Manage` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
