create database nombre_apellido_login;
create database nombre_apellido_db;

use nombre_apellido_login;

create table nombre_apellido_user(
	id int identity,
	usuario varchar(100),
	password int,
);

use nombre_apellido_db;

create table Empleados(
	id int identity,
	nombre varchar(100),
	correo varchar(100),
	DUI varchar(100),
	activo bit,
	idTienda int,
	primary key(id),
);

create table Tienda(
	id int identity,
	nombre_tienda varchar(100),
	idEmpleado int,
	primary key(id),
	foreign key(idEmpleado) references Empleados
);

insert into Empleados values('juan rodriguez', 'juan@gmail.com', '05446987-3', 1, 1);
insert into Empleados values('Karla Reyez', 'karla@gmail.com', '04898526-3', 1, 2);
insert into Empleados values('jose dominguez', 'jose@gmail.com', '1234567-8', 0, 1);

insert into Tienda values('walmart', 1);
insert into Tienda values('maxi despensa', 2);
insert into Tienda values('despensa familiar', 3);


create procedure registrar_empleado 
@id int, 
@nombre varchar(100), 
@correo varchar(100), 
@DUI varchar(100), 
@activo bit, 
@idTienda int
as
begin
	select nombre, DUI from empleados where @activo = 1
	if @activo = 1 print 'Empleado ya registrado en la bd'
	else 
		insert into Empleados values(@id, @nombre, @correo, @DUI, @activo, @idTienda);
end; 

create procedure DatosEmpleados (@id int)
as
begin
	select t.id, t.nombre_tienda, t.idEmpleado, empl.nombre, empl.DUI from Empleados as empl
	inner join Tienda as t on empl.idTienda = t.idEmpleado where empl.id = @id
end;

exec DatosEmpleados 1;

drop procedure DatosEmpleados;