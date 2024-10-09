--Creaci�n base de datos DBXYZ

CREATE DATABASE DBXYZ

GO

USE DBXYZ

go

--Creaci�n de tabla departamentos

CREATE TABLE DEPARTAMENTO(

IdDepartamento int primary key identity,
NombreDepartamento varchar(100),
Region varchar(100)-- este campo pertenece a la region del departamento(occidente, oriente y central)

);

GO

--Creaci�n de tabla empleados

CREATE TABLE EMPLEADOS(

IdEmpleado int primary key identity,
Nombre varchar(100),
Apellido varchar(100),
telefono varchar(8), --actualmente El Salvador posee una estandarizaci�n de 8 digitos para el numero de telefono
FechaContratacion datetime default getdate(), -- la fecha se insertara automatacamente el dia que se guarde el registro del empleado
IdDepartamento int references DEPARTAMENTO(IdDepartamento)
);

--Relacion de uno a muchos ya que un departamento posee muchos empleados   Departamento(1)---->(N)Empleados


--Insertar departamentos

go 

INSERT INTO DEPARTAMENTO(NombreDepartamento, Region) VALUES
('Ahuachap�n', 'Occidente'),
('Caba�as', 'Central'),
('Chalatenango', 'Central'),
('Cuscatl�n', 'Central'),
('La Libertad', 'Central'),
('La Paz', 'Central'),
('La Uni�n', 'Oriente'),
('Moraz�n', 'Oriente'),
('San Miguel', 'Oriente'),
('San Salvador', 'Central'),
('San Vicente', 'Central'),
('Santa Ana', 'Occidente'),
('Sonsonate', 'Occidente'),
('Usulut�n', 'Oriente');

go 

select* from EMPLEADOS 

go

--Consulta para ver el id del empleado, nombre y al departamento que pertenece
SELECT e.IdEmpleado, e.nombre, d.NombreDepartamento
FROM EMPLEADOS e
JOIN departamento d ON e.IdDepartamento = d.IdDepartamento;

