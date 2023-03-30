
CREATE TABLE `aaappointment` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `BookingPeriod` varchar(45) DEFAULT NULL,
  `BookingTimeBlock` double DEFAULT NULL,
  `Cancelable` bit(1) DEFAULT NULL,
  `ConfirmationNeeded` bit(1) DEFAULT NULL,
  `BookingOpenSooner` double DEFAULT NULL,
  `BookingOpenLater` double DEFAULT NULL,
  `ProductId` int DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
