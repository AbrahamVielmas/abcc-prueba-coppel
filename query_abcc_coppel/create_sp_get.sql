DELIMITER $$
USE `abcc_coppel`$$
CREATE PROCEDURE `SP_GetArticulosBySku`(
 _sku mediumint
)
BEGIN
	select id, sku, nombreArticulo, marca, modelo, idDepartamento, idClase, idFamilia, fechaAlta
    ,stock, cantidad, descontinuado, fechaBaja from articulos
    where sku = _sku;
END$$

DELIMITER ;

DELIMITER $$
USE `abcc_coppel`$$
CREATE PROCEDURE `SP_GetClases`()
BEGIN
	select id, nombreClase from clases;
END$$

DELIMITER ;

DELIMITER $$
USE `abcc_coppel`$$
CREATE PROCEDURE `SP_GetDepartamentos`()
BEGIN
	select id, nombreDepartamento from departamentos;
END$$

DELIMITER ;

DELIMITER $$
USE `abcc_coppel`$$
CREATE PROCEDURE `SP_GetFamilias`()
BEGIN
	select id, nombreFamilia from familias;
END$$

DELIMITER ;