CREATE SCHEMA `abcc_coppel`;
use abcc_coppel;

create table articulos(
	id int not null auto_increment primary key,
    sku mediumint unsigned,
    nombreArticulo varchar(15),
    marca varchar(15),
    modelo varchar(20),
    idDepartamento int,
    idClase int,
    idFamilia int,
    fechaAlta date default now(),
    stock int,
    cantidad int,
    descontinuado tinyint(1) default 0,
    fechaBaja date default "1900-01-01"
);

create table departamentos(
	id int not null auto_increment primary key,
    nombreDepartamento varchar(20)
);

create table clases(
	id int not null auto_increment primary key,
    nombreClase varchar(20)
);

create table familias(
	id int not null auto_increment primary key,
    nombreFamilia varchar(20)
);

alter table articulos add constraint fk_Departamento foreign key (idDepartamento) references departamentos(id);
alter table articulos add constraint fk_Clase foreign key (idClase) references clases(id);
alter table articulos add constraint fk_Familia foreign key (idFamilia) references familias(id);

