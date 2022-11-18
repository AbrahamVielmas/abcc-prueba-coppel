DELIMITER $$
USE `abcc_coppel`$$
CREATE PROCEDURE `SP_InsertArticulo`(
 _sku mediumint,
_nombreArticulo varchar(15),
_marca varchar(15),
_modelo varchar(20),
_idDepartamento int,
_idClase int,
_idFamilia int,
_stock int,
_cantidad int
)
BEGIN
	insert into articulos (sku, nombreArticulo, marca, modelo, idDepartamento, idClase, idFamilia, stock, cantidad)
	values (_sku, _nombreArticulo, _marca, _modelo, _idDepartamento, _idClase, _idFamilia, _stock, _cantidad);
END$$

DELIMITER ;

DELIMITER $$
USE `abcc_coppel`$$
CREATE PROCEDURE `SP_InsertClase`(
_nombreClase varchar(20)
)
BEGIN
	insert into clases (nombreClase)
	values (_nombreClase);
END$$

DELIMITER ;

DELIMITER $$
USE `abcc_coppel`$$
CREATE PROCEDURE `SP_InsertDepartamento`(
_nombreDepartamento varchar(20)
)
BEGIN
	insert into departamentos (nombreDepartamento)
	values (_nombreDepartamento);
END$$

DELIMITER ;

DELIMITER $$
USE `abcc_coppel`$$
CREATE PROCEDURE `SP_InsertFamilia`(
_nombreFamilia varchar(20)
)
BEGIN
	insert into familias (nombreFamilia)
	values (_nombreFamilia);
END$$

DELIMITER ;