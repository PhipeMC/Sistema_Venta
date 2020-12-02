CREATE DATABASE  IF NOT EXISTS `tiendita` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `tiendita`;
-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: tiendita
-- ------------------------------------------------------
-- Server version	8.0.19

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
-- Table structure for table `categorias`
--

DROP TABLE IF EXISTS `categorias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categorias` (
  `idCategoria` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(30) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idCategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorias`
--

LOCK TABLES `categorias` WRITE;
/*!40000 ALTER TABLE `categorias` DISABLE KEYS */;
INSERT INTO `categorias` VALUES (1,'Frituras','Papas fritas de distintas marcas'),(2,'Fruta','Distintos tipos de fruta'),(3,'Verdura','Distintos tipos de verdura'),(4,'Sopas','Distintos tipos de pastas y sopas'),(5,'Bebidas','Cualquier tipo de liquido consumible');
/*!40000 ALTER TABLE `categorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientes` (
  `idCliente` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(40) NOT NULL,
  `RFC` varchar(15) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `telefono` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`idCliente`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (1,'José Alberto Zavala Calderón','JAZC000708','Adolfo Lopez Mateos 20','4451011851'),(2,'Cesar Dominguez Mosqueda','DOMC991001CN1','Francisco I. Madero #159','4451041569'),(3,'Leonardo Garcia Zamudio','CADE981001FX9','Pipila #45','4451045968'),(4,'Juan Zamudio Ortiz','CMAS983298CA1','Pipila #12','4457781248'),(5,'Juana','IUSHC983222271','Madero #15','4892651236'),(6,'Laura','DCJB9083745CA1','Pipila 45','4564561235'),(7,'Pepe','CLKINA092384A','Madero #156','7894512369');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detallesventa`
--

DROP TABLE IF EXISTS `detallesventa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detallesventa` (
  `precioXUnidad` decimal(6,2) NOT NULL,
  `cantidad` int NOT NULL,
  `descuento` decimal(6,2) NOT NULL,
  `idVenta` int NOT NULL,
  `idProducto` int NOT NULL,
  PRIMARY KEY (`idVenta`,`idProducto`),
  KEY `fk_detallesventa_productos1_idx` (`idProducto`),
  CONSTRAINT `fk_detallesventa_productos1` FOREIGN KEY (`idProducto`) REFERENCES `productos` (`idProducto`),
  CONSTRAINT `fk_detallesventa_ventas1` FOREIGN KEY (`idVenta`) REFERENCES `ventas` (`idVenta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detallesventa`
--

LOCK TABLES `detallesventa` WRITE;
/*!40000 ALTER TABLE `detallesventa` DISABLE KEYS */;
INSERT INTO `detallesventa` VALUES (45.20,2,0.00,4,2),(11.00,2,0.00,4,3),(11.00,2,0.00,8,3);
/*!40000 ALTER TABLE `detallesventa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleados`
--

DROP TABLE IF EXISTS `empleados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empleados` (
  `idEmpleado` int NOT NULL AUTO_INCREMENT,
  `nombreCompleto` varchar(45) NOT NULL,
  `direccion` varchar(45) DEFAULT NULL,
  `telefono` varchar(10) DEFAULT NULL,
  `Usuario` varchar(20) NOT NULL,
  `contrasenia` varchar(15) NOT NULL,
  `puesto` enum('cajero','chalan','admin') NOT NULL,
  PRIMARY KEY (`idEmpleado`),
  UNIQUE KEY `Usuario_UNIQUE` (`Usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleados`
--

LOCK TABLES `empleados` WRITE;
/*!40000 ALTER TABLE `empleados` DISABLE KEYS */;
INSERT INTO `empleados` VALUES (1,'Brayan Villagomez Cotrtez','Mexicanos Ilustres 123','4451082332','BrayanVC','BVC123','admin'),(3,'Cesar Dominguez','Maderto #159','4451041569','Phipe','root','admin');
/*!40000 ALTER TABLE `empleados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos` (
  `idProducto` int NOT NULL AUTO_INCREMENT,
  `precio` decimal(6,2) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `stock` int NOT NULL,
  `idCategoria` int NOT NULL,
  `idProveedor` int NOT NULL,
  PRIMARY KEY (`idProducto`),
  KEY `idCategoria` (`idCategoria`),
  KEY `idProveedor` (`idProveedor`),
  CONSTRAINT `productos_ibfk_1` FOREIGN KEY (`idCategoria`) REFERENCES `categorias` (`idCategoria`),
  CONSTRAINT `productos_ibfk_2` FOREIGN KEY (`idProveedor`) REFERENCES `proveedores` (`idProveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (2,16.00,'Jitomate','O tomate rojo, Fruto',100,2,1),(3,11.00,'Doritos','Papas marca sabritas',50,1,2);
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedores`
--

DROP TABLE IF EXISTS `proveedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proveedores` (
  `idProveedor` int NOT NULL AUTO_INCREMENT,
  `nombreCompleto` varchar(60) NOT NULL,
  `direccion` varchar(30) NOT NULL,
  `telefono` varchar(10) NOT NULL,
  PRIMARY KEY (`idProveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedores`
--

LOCK TABLES `proveedores` WRITE;
/*!40000 ALTER TABLE `proveedores` DISABLE KEYS */;
INSERT INTO `proveedores` VALUES (1,'Aldo Zamudio Diaz','Pipila 106','4451085245'),(2,'Sabritas','Ponciano Vega 205','4451052565');
/*!40000 ALTER TABLE `proveedores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventas`
--

DROP TABLE IF EXISTS `ventas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ventas` (
  `idVenta` int NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `idEmpleado` int NOT NULL,
  `idCliente` int NOT NULL,
  PRIMARY KEY (`idVenta`),
  KEY `idEmpleado` (`idEmpleado`),
  KEY `idCliente` (`idCliente`),
  CONSTRAINT `ventas_ibfk_1` FOREIGN KEY (`idEmpleado`) REFERENCES `empleados` (`idEmpleado`),
  CONSTRAINT `ventas_ibfk_2` FOREIGN KEY (`idCliente`) REFERENCES `clientes` (`idCliente`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventas`
--

LOCK TABLES `ventas` WRITE;
/*!40000 ALTER TABLE `ventas` DISABLE KEYS */;
INSERT INTO `ventas` VALUES (4,'2020-11-28',1,1),(5,'2015-11-10',1,1),(6,'2020-11-10',1,1),(8,'2020-11-28',3,1);
/*!40000 ALTER TABLE `ventas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'tiendita'
--

--
-- Dumping routines for database 'tiendita'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-12-02 15:51:10
