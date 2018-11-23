use master
go

if exists(Select * FROM SysDataBases WHERE name='TerminalURU')
BEGIN
	DROP DATABASE TerminalURU
END
go

create database TerminalURU
go

use TerminalURU
go

-- creacion de tablas

create table Empleados(
CI int primary key not null,
NombreCompleto varchar(30) not null,
Contraseña varchar(6) not null check(Len(Contraseña)=6),
Estado bit default 1 not null
)
go

create table Companias(
Nombre varchar(20) not null primary key,
Direccion varchar(50) not null,
Telefono bigint not null,
Estado bit default 1 not null
)
go

create table Terminales(
Codigo varchar(3) not null primary key check(Codigo Like('[A-Z][A-Z][A-Z]')),
Ciudad varchar(20) not null,
Pais varchar(20) not null check(Pais in('argentina','uruguay','brasil','paraguay','venezuela')),
Estado bit default 1 not null
)
go

create table Facilidades(
CodigoF varchar(3) not null Foreign Key References Terminales(Codigo),
Facilidad varchar(30) not null,
primary key(CodigoF,Facilidad)
)
go																						

create table Viajes(
Numero int not null primary key,
CantAsientos int not null check(CantAsientos >= 0),
Partida datetime not null check(Partida >= getdate()),
Arribo datetime not null,
CIEmpleado int not null Foreign key references Empleados(CI),
CodTerminal varchar(3)not null Foreign Key references Terminales(Codigo),
NomCompania varchar(20) not null Foreign key references Companias(Nombre),
check(DATEDIFF(minute,Partida,Arribo)>0)
)
go

create table Nacionales(
NumeroN int not null primary key 
foreign key references Viajes(Numero),
Paradas int not null check( Paradas >= 0) default 0
)
go

create table Internacionales(
NumeroI int not null primary key
foreign key references Viajes(Numero),
ServAbordo bit not null,
Documentacion varchar(200) not null
)
go

----------------------------------------------------------- creacion de stored procedures
----------------------------------------------------------- sp de empleados

create proc Logeo
@CI int,
@Contraseña varchar(6)
as
begin
	select * from Empleados where CI = @CI and Estado = 1 and Contraseña = @Contraseña
end
go

create proc AltaEmpleado
@CI int,
@NombreCompleto varchar(30),
@Contraseña varchar(6)
as
begin
	if exists(select CI from Empleados where CI = @CI and Estado = 0)
	begin
		update Empleados set Estado = 1, Contraseña = @Contraseña where CI = @CI
		return 1
	end
	if exists(select CI from Empleados where CI = @CI and Estado = 1)
	begin
		return -1
	end
	insert into Empleados (CI,NombreCompleto,Contraseña) values(@CI,@NombreCompleto,@Contraseña)
		return 1
end
go

create proc ModificarEmpleado
@CI int,
@NombreCompleto varchar(30),
@Contraseña varchar(6)
as
begin
	if exists(select CI from Empleados where CI = @CI and Estado = 1)
	begin
		update Empleados set NombreCompleto = @NombreCompleto,
		Contraseña = @Contraseña 
		where CI = @CI
		return 1
	end
	return -1
end
go

create proc BajaEmpleado
@CI int
as
begin
	if exists(select CI from Empleados where CI = @CI)
	begin
		if exists(select CIEmpleado from Viajes where CIEmpleado=@CI)
		begin
			update Empleados set Estado = 0 where CI=@CI
			return 1
		end
		delete from Empleados where CI = @CI
		return 1
	end	
	return -1
end
go

create proc BuscarEmpleadosTodos
@CI int
as
begin
	select * from Empleados where CI=@CI
end
go

create proc BuscarEmpleadoActivo
@CI int
as
begin
	select * from Empleados where CI=@CI and Estado = 1
end
go

-------------------------------------------------------------- sp de companias

create proc AltaCompania
@Nombre varchar(20),
@Direccion varchar(50),
@Telefono bigint
as
begin
	if exists (select Nombre from Companias where Nombre = @Nombre and Estado = 1)
	begin
		return -1
	end
	if exists(select Nombre from Companias where Nombre = @Nombre and Estado = 0)
	begin
		update Companias set Estado = 1, Direccion = @Direccion, Telefono = @Telefono where Nombre = @Nombre
		return 1
	end
	insert into Companias (Nombre,Direccion,Telefono) values(@Nombre,@Direccion,@Telefono)
	return 1
end
go

create proc ModificarCompania
@Nombre varchar(20),
@Direccion varchar(50),
@Telefono bigint
as
begin
	if exists(select Nombre from Companias where Nombre = @Nombre and Estado = 1)
	begin
		update Companias set Direccion=@Direccion,Telefono = @Telefono where Nombre = @Nombre
		return 1
	end
	return -1
end
go

create proc BajaCompania
@Nombre varchar(20)
as
begin
	if exists (select Nombre from Companias where Nombre = @Nombre)
	begin
		if exists(select NomCompania from Viajes where NomCompania = @Nombre)
		begin
			update Companias set Estado = 0 where Nombre = @Nombre
			return 1
		end
		
	delete from Companias where Nombre = @Nombre
	return 1
	end
	
	return -1
end

go

create proc ListarCompanias
as
begin
	select * from Companias where Estado = 1
end
go

create proc BuscarCompaniaTodas
@Nombre varchar(20)
as
begin
	select * from Companias where Nombre = @Nombre 
end
go

create proc BuscarCompaniaActiva
@Nombre varchar(20)
as
begin
	select * from Companias where Nombre = @Nombre and Estado = 1
end
go


----------------------------------------------------------- sp terminales

create proc AltaTerminal
@Codigo varchar(3),
@Ciudad varchar(20),
@Pais varchar(20)
as
begin
	if exists(select Codigo from Terminales where Codigo = @Codigo and Estado = 1)
	begin
		return -1
	end
	if exists (select Codigo from Terminales where Codigo = @Codigo and Estado = 0)
	begin
		update Terminales set Estado = 1, Ciudad = @Ciudad, Pais = @Pais where Codigo = @Codigo
		return 1
	end
	
	insert into Terminales(Codigo,Ciudad,Pais) Values(@Codigo,@Ciudad,@Pais)
	return 1
end
go

create proc ModificarTerminal
@Codigo varchar(3),
@Ciudad varchar(20),
@Pais varchar(20)
as
begin
	if exists (select Codigo from Terminales where Codigo = @Codigo and Estado = 0)
	begin
		return -1
	end
	if exists(select Codigo from Terminales where Codigo = @Codigo and Estado = 1)
	begin
		update Terminales set Ciudad = @Ciudad, Pais = @Pais where Codigo = @Codigo
		return 1
	end
	return -1
end
go

create proc BajaTerminal
@Codigo varchar(3)
as
begin
	if exists(select Codigo from Terminales where Codigo = @Codigo and Estado = 1)
	begin
	
		if exists (select CodTerminal from Viajes where CodTerminal = @Codigo)
		begin
			update Terminales set Estado = 0 where Codigo = @Codigo
			return 1
		end
		begin transaction 
		
		delete from Terminales where Codigo = @Codigo
		
		if (@@ERROR <> 0)
		rollback transaction
		
		delete from Facilidades where CodigoF = @Codigo
		if (@@ERROR <> 0)
		rollback transaction
		
		commit transaction
		return 1
		
	end
	return -1
end
go

create proc BuscarTerminalActiva
@Codigo varchar(3)
as
begin
	select * from Terminales where Codigo = @Codigo and Estado = 1
end
go

create proc BuscarTerminalTodos
@Codigo varchar(3)
as
begin
	select * from Terminales where Codigo = @Codigo
end
go

create proc ListarTerminales
as
begin
	select * from Terminales where Estado = 1
end
go

-------------------------------------- sp facilidades

create proc AltaFacilidad
@CodigoF varchar(3),
@Facilidad varchar(30)
as
begin
	if exists (select Facilidad from Facilidades where CodigoF = @CodigoF and Facilidad = @Facilidad)
	begin
		return - 1
	end

	if  exists(select Codigo from Terminales where Codigo = @CodigoF and  Estado=1)
	begin
	insert into Facilidades values(@CodigoF,@Facilidad)
		return 1
	end

	else
		return -2
end
go

create proc EliminarFacilidad
@CodigoF varchar(3)
as
begin

	delete from Facilidades where CodigoF = @CodigoF
	return 1
end
go

create proc BuscarFacilidad
@Codigo varchar(3)
as
begin

select * from Facilidades where CodigoF=@Codigo

end
go

---------------------------------------------- sp Viajes

create proc AltaViajeNacional
@Numero int,
@CantAsientos int,
@Partida datetime,
@Arribo datetime,
@CIEmpleado int,
@CodTerminal varchar(3),
@NomCompania varchar(20),
@Paradas int
as
begin
	
	if exists (select Numero from Viajes where Numero = @Numero)
		return -1
	if not exists (select CI from Empleados where CI = @CIEmpleado and Estado = 1)
		return -2
	if not exists (select Codigo from Terminales where Codigo = @CodTerminal and Estado = 1)
		return -3
	if not exists (select Nombre from Companias where Nombre = @NomCompania and Estado = 1)
		return -4
	if exists (select * from Viajes where (DATEDIFF(MINUTE,Partida,@Partida)<120 and CodTerminal = @CodTerminal))
		return -5
		
		begin transaction
		
		insert into Viajes values (@Numero,@CantAsientos,@Partida,@Arribo,@CIEmpleado,@CodTerminal,	@NomCompania)
		if (@@ERROR <> 0)
		begin
			rollback transaction
			return -6
		end
		insert into Nacionales values(@Numero, @Paradas)
		if (@@ERROR <> 0)
		begin
			rollback transaction
			return -6
		end
		
		commit transaction
	return 1
end
go

create proc AltaViajeInternacional
@Numero int,
@CantAsientos int,
@Partida datetime,
@Arribo datetime,
@CIEmpleado int,
@CodTerminal varchar(3),
@NomCompania varchar(20),
@ServAbordo bit,
@Documentacion varchar(50)
as
begin
	
	if exists (select Numero from Viajes where Numero = @Numero)
		return -1
	if not exists (select CI from Empleados where CI = @CIEmpleado and Estado = 1)
		return -2
	if not exists (select Codigo from Terminales where Codigo = @CodTerminal and Estado = 1)
		return -3
	if not exists (select Nombre from Companias where Nombre = @NomCompania and Estado = 1)
		return -4
	if exists (select * from Viajes where (ABS(DATEDIFF(MINUTE,Partida,@Partida))<120 and CodTerminal = @CodTerminal))
		return -5	
		begin transaction
		
		insert into Viajes values (@Numero,@CantAsientos,@Partida,@Arribo,@CIEmpleado,@CodTerminal,	@NomCompania)
		if (@@ERROR <> 0)
		begin
			rollback transaction
			return -6
		end
		insert into Internacionales values(@Numero, @ServAbordo, @Documentacion)
		if (@@ERROR <> 0)
		begin
			rollback transaction
			return -6
		end
		
		commit transaction
	return 1
end
go

create proc ModificarViajeNacional
@Numero int,
@CantAsientos int,
@Partida datetime,
@Arribo datetime,
@CIEmpleado int,
@CodTerminal varchar(3),
@NomCompania varchar(20),
@Paradas int
as
begin
	
	if not exists (select NumeroN from Nacionales where NumeroN = @Numero)
		return -1
	if not exists (select CI from Empleados where CI = @CIEmpleado and Estado = 1)
		return -2
	if not exists (select Codigo from Terminales where Codigo = @CodTerminal and Estado = 1)
		return -3
	if not exists (select Nombre from Companias where Nombre = @NomCompania and Estado = 1)
		return -4
	if exists (select * from Viajes where (DATEDIFF(MINUTE,Partida,@Partida)<120 and CodTerminal = @CodTerminal))
		return -5
	begin transaction
	
		update Viajes set CantAsientos = @CantAsientos,
		Partida = @Partida,
		Arribo = @Arribo,
		CIEmpleado = @CIEmpleado,
		CodTerminal = @CodTerminal,
		NomCompania = @NomCompania where Numero = @Numero
		if(@@ERROR <> 0)
		begin
			rollback transaction
			return -6
		end
		
		update Nacionales set Paradas = @Paradas where NumeroN = @Numero
		if(@@ERROR <> 0)
		begin
			rollback transaction
			return -6
		end

	commit transaction
	return 1
end
go

create proc ModificarViajeInternacional
@Numero int,
@CantAsientos int,
@Partida datetime,
@Arribo datetime,
@CIEmpleado int,
@CodTerminal varchar(3),
@NomCompania varchar(20),
@ServAbordo bit,
@Documentacion varchar(50)
as
begin
	
	if not exists (select NumeroI from Internacionales where NumeroI = @Numero)
		return -1
	if not exists (select CI from Empleados where CI = @CIEmpleado and Estado = 1)
		return -2
	if not exists (select Codigo from Terminales where Codigo = @CodTerminal and Estado = 1)
		return -3
	if not exists (select Nombre from Companias where Nombre = @NomCompania and Estado = 1)
		return -4
	if exists (select * from Viajes where (ABS(DATEDIFF(MINUTE,Partida,@Partida))<120) and (CodTerminal = @CodTerminal and Numero <> @Numero))
		return -5	
	begin transaction
	
		update Viajes set CantAsientos = @CantAsientos,
		Partida = @Partida,
		Arribo = @Arribo,
		CIEmpleado = @CIEmpleado,
		CodTerminal = @CodTerminal,
		NomCompania = @NomCompania where Numero = @Numero
		if(@@ERROR <> 0)
		begin
			rollback transaction
			return -6
		end
		
		update Internacionales set ServAbordo = @ServAbordo, Documentacion = @Documentacion where NumeroI = @Numero
		if(@@ERROR <> 0)
		begin
			rollback transaction
			return -6
		end

	commit transaction
	return 1
end
go

create proc BajaViajeNacional
@Numero int
as
begin

	if  exists (select * from Nacionales where NumeroN = @Numero )
	begin
		begin transaction
		
		delete from Nacionales where NumeroN = @Numero
		if(@@ERROR <>0)
		begin
			rollback transaction
			return -1
		end
		delete from Viajes where Numero = @Numero
		if(@@ERROR <> 0)
		begin
			rollback transaction
			return -1
		end
		commit transaction
		return 1
	end
	return -1
end
go

create proc BajaViajeInternacional
@Numero int
as
begin

	if  exists (select * from Internacionales where NumeroI = @Numero )
	begin
		begin transaction
		
		delete from Internacionales where NumeroI = @Numero
		if(@@ERROR <>0)
		begin
			rollback transaction
			return -1
		end
		delete from Viajes where Numero = @Numero
		if(@@ERROR <> 0)
		begin
			rollback transaction
			return -1
		end
		commit transaction
		return 1
	end
	return -1
end
go

create proc BuscarViajeInternacional
@Numero int
as
begin
	select Numero,CantAsientos,Partida,Arribo,
	CIEmpleado,CodTerminal,NomCompania,ServAbordo,Documentacion
	from Viajes inner join Internacionales on Numero=@Numero and Internacionales.NumeroI=@Numero
end

go
create proc BuscarViajeNacional
@Numero int
as
begin
	select Numero,CantAsientos,Partida,Arribo,
	CIEmpleado,CodTerminal,NomCompania,Paradas
	from Viajes inner join Nacionales on Viajes.Numero=@Numero and Nacionales.NumeroN=@Numero
	end
go

create proc ListarViajesInternacionales
as
begin

select Numero,CantAsientos,Partida,Arribo,
CIEmpleado,CodTerminal,NomCompania,ServAbordo,Documentacion
 from Viajes inner join Internacionales on Viajes.Numero=Internacionales.NumeroI where 
  Viajes.Partida>GETDATE()
end

go

create proc ListarViajesNacionales
as
begin

	select Numero,CantAsientos,Partida,Arribo,
	CIEmpleado,CodTerminal,NomCompania,Paradas
	from Viajes inner join Nacionales on Viajes.Numero=Nacionales.NumeroN where 
	Viajes.Partida>GETDATE()
end
go

create proc ListarInternacionalesTodos
as
begin
	select Numero,CantAsientos,Partida,Arribo,
	CIEmpleado,CodTerminal,NomCompania,ServAbordo,Documentacion
	from Viajes inner join Internacionales on Viajes.Numero=Internacionales.NumeroI
end
go

create proc ListarNacionalesTodos
as
begin
	select Numero,CantAsientos,Partida,Arribo,
	CIEmpleado,CodTerminal,NomCompania,Paradas
	from Viajes inner join Nacionales on Viajes.Numero=Nacionales.NumeroN
end
go

-------------------Registros de prueba----------------------------------------
exec AltaCompania 'EGA','Rio Negro 2030',099665544
go
exec AltaCompania 'Rutas del sol','Av Italia 2223',094645567
go
exec AltaCompania 'Copsa','Bolivia 1473',098786532
go
exec AltaCompania 'Cutsa','Rivera 7240',095324580
go
exec AltaEmpleado 46181064,'Pablo Gonzalez','pablo1'
go
exec AltaEmpleado 53062247,'Juan Lopez','juan01'
go
exec AltaEmpleado 47590802,'Juan Ignacio Rastov','rastov'
go

exec AltaTerminal 'NCU','Canelones','Uruguay'
go
exec AltaTerminal 'NAU','Artigas','Uruguay'
go
exec AltaTerminal 'NSU','San Jose','Uruguay'
go
exec AltaTerminal 'NMU','Montevideo','Uruguay'
go

exec AltaTerminal 'IAP','Asuncion','Paraguay'
go
exec AltaTerminal 'ISB','Sao Pablo','Brasil'
go
exec AltaTerminal 'IBA','Buenos Aires','Argentina'
go
exec AltaTerminal 'ICV','Caracas','Venezuela'
go

exec AltaFacilidad 'NCU','Cambio'
go
exec AltaFacilidad 'NCU','Correo'
go
exec AltaFacilidad 'NAU','Telefonía'
go
exec AltaFacilidad 'NSU','Correo'
go
exec AltaFacilidad 'NMU','Cambio'
go
exec AltaFacilidad 'NMU','Telefonía'
go
exec AltaFacilidad 'NMU','Correo'
go

exec AltaFacilidad 'IAP','Cambio'
go
exec AltaFacilidad 'ISB','Cambio'
go
exec AltaFacilidad 'IBA','Cambio'
go
exec AltaFacilidad 'ICV','Cambio'
go
exec AltaFacilidad 'ICV','Correo'
go
exec AltaFacilidad 'IAP','Telefonia'
go
exec AltaFacilidad 'ISB','Correo'
go
exec AltaFacilidad 'IBA','Telefonia'


exec AltaViajeInternacional 100,5,'20190126 10:00 AM','20190129 11:30 AM',46181064,'IAP','EGA',1,'CI vigente'
go
exec AltaViajeInternacional 101,1,'20190210 8:00 PM','20190213 10:00 PM',53062247,'IAP','EGA',0,'CI vigente'
go
exec AltaViajeInternacional 109,2,'20190317 5:00 AM','20190318 11:00 PM',47590802,'IAP','Rutas del sol',1,'CI vigente'
go
exec AltaViajeInternacional 102,2,'20190411 4:00 AM','20190411 8:00 PM',46181064,'ISB','Rutas del sol',1,'CI vigente'
go
exec AltaViajeInternacional 103,2,'20190519 5:00 PM','20190521 4:00 AM',53062247,'ISB','EGA',1,'CI vigente'
go
exec AltaViajeInternacional 104,4,'20190522 5:00 PM','20190523 3:00 AM',47590802,'IBA','Rutas del sol',1,'CI vigente'
go
exec AltaViajeInternacional 105,3,'20190626 1:00 PM','20190627 1:00 AM',46181064,'IBA','EGA',1,'CI vigente'
go
exec AltaViajeInternacional 110,10,'20190710 5:00 AM','20190711 2:00 PM',53062247,'IBA','Rutas del sol',1,'CI vigente'
go
exec AltaViajeInternacional 106,2,'20190715 2:00 PM','20190718 1:00 AM',47590802,'ICV','EGA',1,'CI vigente'
go
exec AltaViajeInternacional 107,8,'20190723 5:00 PM','20190726 8:00 PM',46181064,'ICV','EGA',1,'CI vigente'
go
exec AltaViajeInternacional 108,6,'20190811 5:00 AM','20190814 3:00 PM',53062247,'ICV','Rutas del sol',1,'CI vigente'
go



exec AltaViajeNacional 200,5,'20190101 5:00 AM','20190101 6:00 PM',46181064,'NCU','Copsa',1
go
exec AltaViajeNacional 201,1,'20190110 8:00 AM','20190110 2:00 PM',53062247,'NCU','Cutsa',0
go
exec AltaViajeNacional 202,2,'20190215 5:00 AM','20190215 2:30 PM',47590802,'NAU','Cutsa',2
go
exec AltaViajeNacional 203,4,'20190217 8:00 AM','20190217 5:30 PM',46181064,'NAU','Cutsa',2
go
exec AltaViajeNacional 204,10,'20190222 8:00 PM','20190223 1:45 AM',53062247,'NSU','Cutsa',1
go
exec AltaViajeNacional 205,5,'20190311 9:00 AM','20190311 1:30 PM',47590802,'NSU','Copsa',1
go
exec AltaViajeNacional 206,2,'20190316 4:30 AM','20190316 11:00 AM',46181064,'NSU','Cutsa',1
go
exec AltaViajeNacional 207,9,'20190320 10:00 AM','20190320 3:00 PM',53062247,'NMU','Copsa',1
go
exec AltaViajeNacional 208,5,'20190325 10:00 PM','20190326 2:00 AM',47590802,'NMU','Copsa',1
go
exec AltaViajeNacional 209,9,'20190401 5:00 PM','20190401 10:00 PM',46181064,'NMU','Copsa',0
go
exec AltaViajeNacional 210,5,'20190407 1:00 PM','20190407 6:00 PM',53062247,'NMU','Copsa',0
go



USE master
GO

CREATE LOGIN [IIS APPPOOL\DefaultAppPool] FROM WINDOWS 
GO

USE TerminalURU
GO

CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
GO

Grant Execute to [IIS APPPOOL\DefaultAppPool]