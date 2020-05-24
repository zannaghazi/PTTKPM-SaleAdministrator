CREATE TABLE `quanlybanhang`.`qcpartner` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `partner_name` VARCHAR(50) NOT NULL,
  `date` DATETIME NOT NULL,
  `deadline` DATETIME NOT NULL,
  `infopost` VARCHAR(45) NOT NULL,
   `isDeleted` TINYINT(1) NOT NULL,
  PRIMARY KEY (`id`));
  
  CREATE TABLE `quanlybanhang`.`quangcao` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `id_customer` INT NULL,
  `id_item` INT NOT NULL,
  PRIMARY KEY (`id`));
