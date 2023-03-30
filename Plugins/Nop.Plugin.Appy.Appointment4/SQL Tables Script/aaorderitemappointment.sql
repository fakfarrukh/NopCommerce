CREATE TABLE `aaorderitemappointment` (
  `orderItemID` int NOT NULL,
  `cardID` varchar(27) NOT NULL,
  `appointmentDate` datetime NOT NULL,
  `timeFrom` datetime NOT NULL,
  `timeTo` datetime NOT NULL,
  `OrderId` int DEFAULT NULL,
  PRIMARY KEY (`orderItemID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
