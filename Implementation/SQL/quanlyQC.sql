-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: quanlybanhang
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `customer` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `address` text NOT NULL,
  `point` int(11) NOT NULL,
  `is_banned` tinyint(1) NOT NULL,
  `sdt` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,'Võ Minh Hiếu','vmhieu@gmail.com','85/ 65 Phạm Viết Chánh, Phường 19, Bình Thạnh, TP HCM',0,0,'0314454780'),(2,'Nguyễn Văn Nghĩa','nvnghia@gmail.com','184 Nguyễn Chí Thanh, Quận 10, TP HCM',0,0,'0524579215'),(3,'Võ Thanh Hiếu','vthieu@gmail.com','38 Tú Xương, Phường 7, Quận 3, Sài Gòn',0,0,'3154789625'),(4,'Võ Lê Minh','vlminh@gmail.com','215 Võ Thị Sáu, Phường 7, Quận 3, TP HCM',0,0,'0124789534'),(5,'Cái Nhân Đức','cnduc@gmail.com','18 Võ Văn Ngân, Thủ Đức, TP HCM',0,0,'0315897456'),(6,'Võ Lê Công Kết','vlcket@gmail.com','459B Nguyễn Đình Chiểu, Quận 3, TP HCM',1,0,'0'),(7,'Trịnh Đại Phát','tdphat@gmail.com','80/76 Trần Quang Diệu, Phường14, Quận 3, TP HCM',0,0,'0315478568'),(8,'Nguyễn Như Anh','nnanh@gmail.com','838 Tú Xương, Phường 7, Quận 3, Sài Gòn',0,0,'0'),(9,'Nguyễn Thái Hoàng','nthoang@gmail.com','210/18/2 Cách mạng Tháng 8, Phường 10, Quận 3, TP HCM',0,0,'0'),(10,'Trần Hoàng Anh Thư','thathu@gmail.com','16/99 – 16/101 Kỳ Đồng, Phường 9, Quận 3, TP HCM',0,0,'0125478968'),(11,'Đặng Quang Huy','dqhuy@gmail.com','275/6/7 Lý Thường Kiệt, Phường 15, Quận 11',0,0,'0125424856'),(12,'Hồ Hoàng Hảo','hhhao@gmail.com','218 Phó Cơ Điền, Phường 6, Quận 11, TP HCM',0,0,'0125624856'),(13,'Dư Kiến Luân','dkluan@gmail.com','48/10 Hòa Hưng, Phường 12, Quận 10, TP HCM',0,0,'0'),(14,'Lê Xuân Kha','lxkha@gmail.com','57B/500 Lê Hồng Phong, Phường 1, Quận 10, TP HCM',0,0,'0125874698'),(15,'Nguyễn Thành Đô','ntdo@gmail.com','133/ 5 Hòa Hưng, Phường 4, Quận 10, TP HCM',0,0,'0'),(16,'Trần Thiên Hoàng','tthoang@gmail.com','273 Quốc Lộ 1A, Phường Bình Chiểu, Thủ Đức, TP HCM',0,0,'0'),(17,'Trần Hoàng Khánh Châu','thkchau@gmail.com','24/7 đường số 1, KP.1 Phường Tam Đình, Thủ Đức, TP HCM',0,0,'0369875218'),(18,'Trần Hưng Tài','thtai@gmail.com','97 Trường Chinh, Phường 12, Tân Bình, TP HCM',0,0,'0'),(19,'Trần Hưng Quốc','thquoc@gmail.com','40 Đặng văn Bi, phường Bình Thọ, Thủ Đức, TP HCM',0,0,'0'),(20,'Nguyễn Trường Hải','nthai@gmail.com','122 Nguyễn Ngọc Nhựt, Phường Tân Quý, Tân Phú, TP HCM',0,0,'0'),(21,'Nguyễn Minh Châu','nmchau@gmail.com','17/15/11 Gò Dầu, Phường Tân Quý, Quận Tân Phú, TP HCM',0,0,'0369874518'),(22,'Hồ Ngọc Long','hnlong@gmail.com','261/1A Đồng Đen, Phường 14, Tân Bình, TP HCM',0,0,'0'),(23,'Phan Dương Phi','pdphi@gmail.com',' 96 Nguyễn Thượng Hiền, Phường 5, Gò Vấp, TP HCM',0,0,'0314454785');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `qcpartner`
--

DROP TABLE IF EXISTS `qcpartner`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `qcpartner` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `partner_name` varchar(50) NOT NULL,
  `date` datetime NOT NULL,
  `deadline` datetime NOT NULL,
  `location` text NOT NULL,
  `IDBaiQC` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `qcpartner`
--

LOCK TABLES `qcpartner` WRITE;
/*!40000 ALTER TABLE `qcpartner` DISABLE KEYS */;
INSERT INTO `qcpartner` VALUES (3,'da','2020-08-10 00:00:00','2020-08-26 00:00:00','da',1),(4,'add','2020-08-22 00:00:00','2020-08-22 00:00:00','rrr',2),(5,'tttttttt','2020-08-10 00:00:00','2020-08-29 00:00:00','reaasdsdsdsdsd',3);
/*!40000 ALTER TABLE `qcpartner` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quangcao`
--

DROP TABLE IF EXISTS `quangcao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `quangcao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TieuDe` text NOT NULL,
  `NoiDung` text NOT NULL,
  `isDeleted` int(2) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quangcao`
--

LOCK TABLES `quangcao` WRITE;
/*!40000 ALTER TABLE `quangcao` DISABLE KEYS */;
INSERT INTO `quangcao` VALUES (1,'dien thoai sam sung','sam sung no1',0),(2,'123','asdsad',0),(3,'may tinh abc','nen mua máy tinh đây nha bà con',0),(4,'sach abc','noi dung sách cần quảng cáo',0),(5,'aa','bbb',1),(6,'123123','32323232',0);
/*!40000 ALTER TABLE `quangcao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quangcaosdt`
--

DROP TABLE IF EXISTS `quangcaosdt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `quangcaosdt` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `sdt` text,
  `IDBaiQC` int(2) DEFAULT NULL,
  `dateqc` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quangcaosdt`
--

LOCK TABLES `quangcaosdt` WRITE;
/*!40000 ALTER TABLE `quangcaosdt` DISABLE KEYS */;
INSERT INTO `quangcaosdt` VALUES (1,'0314454780',1,'2020-08-10 14:38:35'),(2,'0524579215',2,'2020-08-24 15:48:09'),(11,'0125424856',1,'2020-08-24 15:48:09'),(12,'0125624856',2,'2020-08-24 15:48:09'),(19,'3154789625',6,'2020-08-24 15:23:01');
/*!40000 ALTER TABLE `quangcaosdt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'quanlybanhang'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-08-24 16:08:01
