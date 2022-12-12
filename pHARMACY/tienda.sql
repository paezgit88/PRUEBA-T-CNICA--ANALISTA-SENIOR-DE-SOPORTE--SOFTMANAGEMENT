-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 12-12-2022 a las 00:41:21
-- Versión del servidor: 5.7.31
-- Versión de PHP: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `tienda`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ciudad`
--

DROP TABLE IF EXISTS `ciudad`;
CREATE TABLE IF NOT EXISTS `ciudad` (
  `COD_CIUDAD` int(11) NOT NULL AUTO_INCREMENT,
  `CODIGO_DEPTO` int(11) NOT NULL,
  `DESCRIPCION_CIUDAD` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`COD_CIUDAD`),
  KEY `CODIGO_DEPTO` (`CODIGO_DEPTO`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ciudad`
--

INSERT INTO `ciudad` (`COD_CIUDAD`, `CODIGO_DEPTO`, `DESCRIPCION_CIUDAD`) VALUES
(1, 2, 'descripcion'),
(2, 2, 'descripcion');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

DROP TABLE IF EXISTS `clientes`;
CREATE TABLE IF NOT EXISTS `clientes` (
  `ID_CLIENTE` int(11) NOT NULL AUTO_INCREMENT,
  `TIPO_IDENTIFICACION` varchar(25) DEFAULT NULL,
  `NUMERO_IDENTIFICACION` varchar(25) DEFAULT NULL,
  `NOMBRES` varchar(25) DEFAULT NULL,
  `APELLIDOS` varchar(25) DEFAULT NULL,
  `CARGO` varchar(20) DEFAULT NULL,
  `MAIL` varchar(25) DEFAULT NULL,
  `DIRECCION` varchar(25) DEFAULT NULL,
  `TELEFONO` varchar(20) DEFAULT NULL,
  `CODIGO_CIUDAD` int(11) NOT NULL,
  `CODIGO_USUARIO` int(11) NOT NULL,
  `CLASE` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID_CLIENTE`),
  KEY `CODIGO_CIUDAD` (`CODIGO_CIUDAD`),
  KEY `CODIGO_USUARIO` (`CODIGO_USUARIO`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`ID_CLIENTE`, `TIPO_IDENTIFICACION`, `NUMERO_IDENTIFICACION`, `NOMBRES`, `APELLIDOS`, `CARGO`, `MAIL`, `DIRECCION`, `TELEFONO`, `CODIGO_CIUDAD`, `CODIGO_USUARIO`, `CLASE`) VALUES
(1, 'CEDULA DE CIUDADANIA', '123456789', 'USUARIO TEST', 'NUMERO UNO', 'VENDEDOR', 'CORREO@CORREO.COM', 'DIRECCION 12-34 5', '123456789654', 1, 1, 'ALTO'),
(2, 'CEDULA DE CIUDADANIA', '123456889', 'USUARIO TEST 1', 'NUMERO DOS', 'VENDEDOR', 'CORREO1@CORREO.COM', 'DIRECCION 13-34 5', '123456789654', 2, 2, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `departamento`
--

DROP TABLE IF EXISTS `departamento`;
CREATE TABLE IF NOT EXISTS `departamento` (
  `CODIGO_DEPTO` int(11) NOT NULL AUTO_INCREMENT,
  `DESCRIPCION_DPTO` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`CODIGO_DEPTO`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `departamento`
--

INSERT INTO `departamento` (`CODIGO_DEPTO`, `DESCRIPCION_DPTO`) VALUES
(1, 'DEPARTAMENTO TEST'),
(2, 'DEPARTAMENTO TEST 1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

DROP TABLE IF EXISTS `productos`;
CREATE TABLE IF NOT EXISTS `productos` (
  `CODIGO_PRODUCTO` int(11) NOT NULL AUTO_INCREMENT,
  `DESC_PRODUCTO` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`CODIGO_PRODUCTO`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`CODIGO_PRODUCTO`, `DESC_PRODUCTO`) VALUES
(1, 'PRODUCTO TEST'),
(2, 'PRODUCTO TEST 1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE IF NOT EXISTS `usuarios` (
  `CODIGO_USUARIO` int(11) NOT NULL AUTO_INCREMENT,
  `USUARIO` varchar(25) DEFAULT NULL,
  `CLAVE` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`CODIGO_USUARIO`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`CODIGO_USUARIO`, `USUARIO`, `CLAVE`) VALUES
(1, 'USUARIO TEST', 'CLAVE_DEL_USUARIO_123'),
(2, 'USUARIO TEST 1', 'CLAVE_DEL_USUARIO_123');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas`
--

DROP TABLE IF EXISTS `ventas`;
CREATE TABLE IF NOT EXISTS `ventas` (
  `ID_CLIENTE` int(11) NOT NULL,
  `COD_CIUDAD` int(11) NOT NULL,
  `CODIGO_PRODUCTO` int(11) NOT NULL,
  `FECHA_VENTA` datetime DEFAULT NULL,
  `VALOR_VENTA` double DEFAULT NULL,
  `CANTIDAD_PRODUCTO` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_CLIENTE`),
  KEY `COD_CIUDAD` (`COD_CIUDAD`),
  KEY `CODIGO_PRODUCTO` (`CODIGO_PRODUCTO`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `ventas`
--

INSERT INTO `ventas` (`ID_CLIENTE`, `COD_CIUDAD`, `CODIGO_PRODUCTO`, `FECHA_VENTA`, `VALOR_VENTA`, `CANTIDAD_PRODUCTO`) VALUES
(1, 1, 1, '2022-12-11 14:12:33', 250000, 1),
(2, 1, 2, '2022-12-11 14:12:33', 250000, 1);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
