USE `abcc_coppel`;
DROP procedure IF EXISTS `SP_DeleteArticulo`;

DELIMITER $$
USE `abcc_coppel`$$
CREATE PROCEDURE `SP_DeleteArticulo` (
_sku mediumint
)
BEGIN
	delete from articulos
    where sku = _sku;
END$$

DELIMITER ;