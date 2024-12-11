-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.30 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para prueba
CREATE DATABASE IF NOT EXISTS `prueba` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_spanish_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `prueba`;

-- Volcando estructura para tabla prueba.personas
CREATE TABLE IF NOT EXISTS `personas` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) COLLATE utf8mb4_spanish_ci NOT NULL,
  `edad` int NOT NULL,
  `pais` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL,
  `nit` varchar(20) COLLATE utf8mb4_spanish_ci NOT NULL,
  `mayoriaEdad` tinyint(1) GENERATED ALWAYS AS ((`edad` >= 18)) STORED,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla prueba.personas: ~31 rows (aproximadamente)
INSERT INTO `personas` (`id`, `nombre`, `edad`, `pais`, `nit`) VALUES
	(1, 'Steven Yara', 26, 'México', '1234567890'),
	(2, 'Ana Gómez', 16, 'Colombia', '9876543210'),
	(3, 'Carlos Martínez', 32, 'España', '1233211234'),
	(4, 'María Rodríguez', 19, 'Argentina', '5678901234'),
	(5, 'Luis Hernández', 45, 'Chile', '6543219876'),
	(6, 'Laura Sánchez', 15, 'Perú', '4321098765'),
	(7, 'Pedro González', 23, 'México', '5432109876'),
	(8, 'Sofia López', 30, 'España', '1239874560'),
	(9, 'Antonio García', 17, 'Colombia', '5678904321'),
	(10, 'Elena Martínez', 40, 'Argentina', '9876543210'),
	(11, 'Javier Fernández', 22, 'Chile', '6541230987'),
	(12, 'Isabel Ruiz', 16, 'Perú', '8765432109'),
	(13, 'Felipe Pérez', 28, 'México', '2109876543'),
	(14, 'Victoria Torres', 20, 'España', '9871234567'),
	(15, 'Ricardo Ramírez', 33, 'Colombia', '4321097654'),
	(16, 'Felipe Ruiz', 24, 'Perú', '345678901'),
	(17, 'Sofía Pérez', 14, 'Colombia', '456789012'),
	(18, 'Martín Sánchez', 32, 'Chile', '567890123'),
	(19, 'Verónica Fernández', 19, 'España', '678901234'),
	(20, 'José García', 22, 'México', '789012345'),
	(21, 'Mónica Herrera', 16, 'Argentina', '890123456'),
	(22, 'Ricardo Martínez', 40, 'Venezuela', '901234567'),
	(23, 'Paola González', 25, 'Bolivia', '012345678'),
	(24, 'Eduardo Ramírez', 17, 'Honduras', '213456789'),
	(25, 'Raquel Torres', 27, 'Uruguay', '324567890'),
	(26, 'Luis Martínez', 33, 'Costa Rica', '435678901'),
	(27, 'Carmen Díaz', 45, 'Paraguay', '546789012'),
	(28, 'Juanita Rodríguez', 29, 'Brasil', '657890123'),
	(29, 'Enrique López', 18, 'Panamá', '768901234'),
	(30, 'Gabriela González', 21, 'El Salvador', '879012345'),
	(36, 'Sebastián Yara', 21, 'Brasil', '111111111');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
