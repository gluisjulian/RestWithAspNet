CREATE TABLE IF NOT EXISTS `person` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `address` varchar(100) NOT NULL,
  `first_name` varchar(80) NOT NULL,
  `gender` varchar(6) NOT NULL,
  `last_name` varchar(80) NOT NULL,
  PRIMARY KEY (`id`)
);



INSERT INTO `rest_with_aspnet`.`person`
(`id`,
`address`,
`first_name`,
`gender`,
`last_name`)
VALUES
(4,
'Minas Gerais/MG - Brasil',
'Teste',
'Female',
'da Silva');