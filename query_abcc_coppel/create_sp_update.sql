USE `abcc_coppel`;
DROP procedure IF EXISTS `SP_UpdateArticulo`;

DELIMITER $$
USE `abcc_coppel`$$
CREATE PROCEDURE `SP_UpdateArticulo` (
 _id int,
 _sku mediumint,
_nombreArticulo varchar(15),
_marca varchar(15),
_modelo varchar(20),
_idDepartamento int,
_idClase int,
_idFamilia int,
_stock int,
_cantidad int,
_descontinuado tinyint(1),
_fechaBaja date
)
BEGIN
	update articulos
    set sku = _sku, nombreArticulo = _nombreArticulo, marca = _marca, modelo = _modelo,
    idDepartamento = _idDepartemento, idClase = _idClase, idFamilia = _idFamilia, stock = _stock,
    cantidad = _cantidad, descontinuado = _descontinuado, fechaBaja = _fechaBaja
    where id = _id;
END$$

DELIMITER ;