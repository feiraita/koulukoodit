-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: autokauppa
-- ------------------------------------------------------
-- Server version	8.0.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `asiakas`
--

DROP TABLE IF EXISTS `asiakas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `asiakas` (
  `customerID` int unsigned NOT NULL AUTO_INCREMENT,
  `firstName` varchar(45) NOT NULL,
  `lastName` varchar(45) NOT NULL,
  `addressID` int unsigned NOT NULL,
  PRIMARY KEY (`customerID`),
  KEY `fk_asiakas_osoite_idx` (`addressID`),
  CONSTRAINT `fk_asiakas_osoite` FOREIGN KEY (`addressID`) REFERENCES `osoite` (`addressID`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asiakas`
--

LOCK TABLES `asiakas` WRITE;
/*!40000 ALTER TABLE `asiakas` DISABLE KEYS */;
INSERT INTO `asiakas` VALUES (1,'Mikko','Saarinen',1),(2,'Elina','Virtanen',2),(3,'Janne','Karjalainen',3),(4,'Tanja','Korhonen',4),(5,'Kati','Lehtonen',6),(6,'Pekka','Hämäläinen',7),(7,'Tuomas','Aalto',8),(8,'Anna','Koskinen',10),(9,'Liisa','Heikkinen',11),(10,'Marko','Laakso',13),(11,'Sari','Peltola',14),(12,'Risto','Järvinen',16),(13,'Laura','Mäkinen',17),(14,'Teemu','Räsänen',19),(15,'Kari','Leino',20);
/*!40000 ALTER TABLE `asiakas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `auto`
--

DROP TABLE IF EXISTS `auto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `auto` (
  `carID` int unsigned NOT NULL AUTO_INCREMENT,
  `brand` varchar(45) NOT NULL,
  `model` varchar(45) NOT NULL,
  `color` enum('blue','red','black','white','grey') NOT NULL,
  `shopID` int unsigned NOT NULL,
  `purchasePrice` decimal(10,2) NOT NULL,
  PRIMARY KEY (`carID`),
  KEY `fk_auto_toimipiste_idx` (`shopID`),
  CONSTRAINT `fk_auto_toimipiste` FOREIGN KEY (`shopID`) REFERENCES `toimipiste` (`shopID`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `auto`
--

LOCK TABLES `auto` WRITE;
/*!40000 ALTER TABLE `auto` DISABLE KEYS */;
INSERT INTO `auto` VALUES (1,'Toyota','Corolla','grey',1,15000.00),(2,'Honda','Civic','white',2,18000.99),(3,'Ford','Focus','black',3,16000.50),(4,'BMW','3 Series','red',4,35000.20),(5,'Audi','A4','blue',5,32000.45),(6,'Mercedes','C-Class','grey',2,40000.60),(7,'Volkswagen','Golf','white',3,22000.35),(8,'Skoda','Octavia','black',4,25000.10),(9,'Toyota','Corolla','red',1,16000.00),(10,'Nissan','Qashqai','blue',2,27000.40),(11,'Peugeot','308','grey',3,21000.60),(12,'Fiat','500','white',4,13000.99),(13,'Toyota','Yaris','black',5,14000.25),(14,'Hyundai','i30','red',2,16000.55),(15,'Mazda','3','blue',3,22000.70),(16,'Opel','Astra','grey',4,20000.85),(17,'Renault','Clio','white',1,12000.95),(18,'Ford','Fiesta','black',2,11000.50),(19,'Chevrolet','Cruze','red',3,15000.45),(20,'BMW','5 Series','blue',4,45000.30),(21,'Audi','A6','grey',5,48000.80),(22,'Volkswagen','Passat','white',2,27000.15),(23,'Mercedes','E-Class','black',3,60000.75),(24,'Volvo','V40','red',4,29000.90),(25,'Peugeot','2008','blue',1,21000.10),(26,'Fiat','Panda','grey',2,9000.45),(27,'Hyundai','i20','white',3,11000.60),(28,'Kia','Sportage','black',4,24000.55),(29,'Toyota','Land Cruiser','red',5,55000.40),(30,'Nissan','Micra','blue',2,12000.20),(31,'Skoda','Fabia','grey',3,14000.99),(32,'Honda','Jazz','white',4,16000.65),(33,'BMW','X5','black',1,75000.50),(34,'Ford','Kuga','red',2,30000.25),(35,'Chevrolet','Malibu','blue',3,22000.35),(36,'Renault','Megane','grey',4,17000.75),(37,'Opel','Mokka','white',5,25000.40),(38,'Mazda','CX-5','black',2,29000.60),(39,'Volkswagen','Tiguan','red',3,35000.85),(40,'Audi','Q5','blue',4,40000.99),(41,'Peugeot','508','grey',1,33000.90),(42,'Hyundai','Tucson','white',2,32000.25),(43,'Toyota','RAV4','black',3,37000.55),(44,'BMW','X3','red',4,49000.70),(45,'Mercedes','GLC','blue',5,56000.30),(46,'Skoda','Superb','grey',2,33000.15),(47,'Nissan','X-Trail','white',3,35000.25),(48,'Kia','Niro','black',4,31000.60),(49,'Ford','Edge','red',1,42000.90),(50,'Honda','CR-V','blue',2,47000.10),(51,'Chevrolet','Equinox','grey',3,43000.80);
/*!40000 ALTER TABLE `auto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `myyja`
--

DROP TABLE IF EXISTS `myyja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `myyja` (
  `staffID` int unsigned NOT NULL AUTO_INCREMENT,
  `firstName` varchar(45) NOT NULL,
  `lastName` varchar(45) NOT NULL,
  `addressID` int unsigned NOT NULL,
  `shopID` int unsigned NOT NULL,
  PRIMARY KEY (`staffID`),
  KEY `fk_myyja_osoite_idx` (`addressID`),
  KEY `fk_myyja_toimipiste_idx` (`shopID`),
  CONSTRAINT `fk_myyja_osoite` FOREIGN KEY (`addressID`) REFERENCES `osoite` (`addressID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_myyja_toimipiste` FOREIGN KEY (`shopID`) REFERENCES `toimipiste` (`shopID`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `myyja`
--

LOCK TABLES `myyja` WRITE;
/*!40000 ALTER TABLE `myyja` DISABLE KEYS */;
INSERT INTO `myyja` VALUES (1,'Matti','Virtanen',21,1),(2,'Anna','Korhonen',22,2),(3,'Janne','Leppänen',23,3),(4,'Sari','Aalto',24,4),(5,'Mikko','Mäkelä',25,5),(6,'Liisa','Heikkinen',26,2),(7,'Marko','Koskinen',27,3),(8,'Kati','Järvinen',28,4);
/*!40000 ALTER TABLE `myyja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `myynti`
--

DROP TABLE IF EXISTS `myynti`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `myynti` (
  `saleID` int unsigned NOT NULL AUTO_INCREMENT,
  `staffID` int unsigned NOT NULL,
  `carID` int unsigned NOT NULL,
  `saleDate` datetime NOT NULL,
  `salePrice` decimal(10,2) NOT NULL,
  `customerID` int unsigned NOT NULL,
  PRIMARY KEY (`saleID`),
  KEY `fk_myynti_auto_idx` (`carID`),
  KEY `fk_myynti_myyja_idx` (`staffID`),
  KEY `fk_myynti_asiakas_idx` (`customerID`),
  CONSTRAINT `fk_myynti_asiakas` FOREIGN KEY (`customerID`) REFERENCES `asiakas` (`customerID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_myynti_auto` FOREIGN KEY (`carID`) REFERENCES `auto` (`carID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `fk_myynti_myyja` FOREIGN KEY (`staffID`) REFERENCES `myyja` (`staffID`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `myynti`
--

LOCK TABLES `myynti` WRITE;
/*!40000 ALTER TABLE `myynti` DISABLE KEYS */;
INSERT INTO `myynti` VALUES (1,3,9,'2022-05-01 10:15:00',17000.00,3),(2,4,23,'2025-05-01 11:20:00',70000.00,2),(3,3,17,'2023-01-03 12:30:00',19000.00,1),(4,4,11,'2025-05-04 14:00:00',22000.00,4),(5,5,2,'2025-05-04 15:10:00',21000.00,5),(6,6,41,'2024-02-11 16:25:00',35000.50,6),(7,7,19,'2019-12-29 09:30:00',20000.99,7),(8,8,30,'2024-05-10 17:45:00',16000.75,8),(9,3,13,'2022-05-09 10:15:00',15000.25,1),(10,2,36,'2025-05-10 11:20:00',21000.99,9),(11,1,5,'2025-05-10 12:30:00',35000.00,10),(12,4,26,'2022-02-09 14:00:00',15000.00,11),(13,5,39,'2025-02-13 15:10:00',370000.00,12),(14,6,10,'2025-05-14 16:25:00',30000.00,13),(15,7,33,'2023-10-10 09:30:00',80000.00,14),(16,1,3,'2024-05-31 17:45:00',17000.50,15),(17,8,47,'2021-09-17 10:15:00',39000.25,2),(18,4,50,'2023-10-18 11:20:00',50000.10,8),(19,7,8,'2025-05-19 12:30:00',27000.75,3),(20,8,28,'2024-02-20 14:00:00',26000.60,4);
/*!40000 ALTER TABLE `myynti` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `osoite`
--

DROP TABLE IF EXISTS `osoite`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `osoite` (
  `addressID` int unsigned NOT NULL AUTO_INCREMENT,
  `address` varchar(45) NOT NULL,
  `city` varchar(45) NOT NULL,
  PRIMARY KEY (`addressID`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `osoite`
--

LOCK TABLES `osoite` WRITE;
/*!40000 ALTER TABLE `osoite` DISABLE KEYS */;
INSERT INTO `osoite` VALUES (1,'Mannerheimintie 10','Helsinki'),(2,'Kalevankatu 4','Tampere'),(3,'Yliopistonkatu 5','Turku'),(4,'Savilahdenkatu 6','Kuopio'),(5,'Rautatienkatu 8','Oulu'),(6,'Kirkkokatu 1','Lahti'),(7,'Itäinen Pitkäkatu 33','Turku'),(8,'Linnankatu 20','Helsinki'),(9,'Pirkankatu 17','Tampere'),(10,'Puijonkatu 45','Kuopio'),(11,'Rautatienkatu 10','Oulu'),(12,'Vesijärvenkatu 8','Lahti'),(13,'Sepänkatu 9','Jyväskylä'),(14,'Valtakatu 3','Lappeenranta'),(15,'Hallituskatu 27','Oulu'),(16,'Mannerheimintie 15','Helsinki'),(17,'Teiskontie 55','Tampere'),(18,'Sammonkatu 14','Lahti'),(19,'Kauppakatu 18','Joensuu'),(20,'Kalevalankatu 11','Kajaani'),(21,'Kauppakatu 25','Helsinki'),(22,'Rautatieasema 3','Tampere'),(23,'Puistokatu 21','Turku'),(24,'Mäkelänkatu 44','Oulu'),(25,'Pohjoisesplanadi 18','Helsinki'),(26,'Asemakatu 12','Jyväskylä'),(27,'Keskuskatu 28','Lahti'),(28,'Kalevankatu 11','Helsinki');
/*!40000 ALTER TABLE `osoite` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `toimipiste`
--

DROP TABLE IF EXISTS `toimipiste`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `toimipiste` (
  `shopID` int unsigned NOT NULL AUTO_INCREMENT,
  `addressID` int unsigned NOT NULL,
  `shopName` varchar(45) NOT NULL,
  PRIMARY KEY (`shopID`),
  KEY `fk_toimipiste_osoite_idx` (`addressID`),
  CONSTRAINT `fk_toimipiste_osoite` FOREIGN KEY (`addressID`) REFERENCES `osoite` (`addressID`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `toimipiste`
--

LOCK TABLES `toimipiste` WRITE;
/*!40000 ALTER TABLE `toimipiste` DISABLE KEYS */;
INSERT INTO `toimipiste` VALUES (1,5,'Auto Asema'),(2,9,'Kiesi Keskus'),(3,12,'Tähtimoottori'),(4,15,'Menopeli Merket'),(5,18,'PrimeAuto Oy');
/*!40000 ALTER TABLE `toimipiste` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-11 23:58:15
