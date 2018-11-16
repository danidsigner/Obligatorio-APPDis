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
	
	
	--If @@ERROR = 0
	--		return 1
	--	else
	--		return 0
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

exec AltaCompania 'Rutas del sol','Av Italia 2223',094645567
go
exec AltaCompania 'Copsa','Bolivia 1473',098786532
go
exec AltaCompania 'Cutsa','Rivera 7240',095324580
go

exec AltaEmpleado 46281426,'Pablo Javier Bengochea','270665'
go
exec AltaEmpleado 53272348,'Paolo Montero','manya1'
go
exec AltaEmpleado 47290843,'Richardt Morales','Bolso2'
go
select * from Terminales

exec AltaTerminal 'ABC','Canelones','Uruguay'
go
exec AltaTerminal 'DEF','Sao Pablo','Brasil'
go
exec AltaTerminal 'WYZ','Buenos Aires','Argentina'
go

exec AltaFacilidad 'ABC','Cambio'
go
exec AltaFacilidad 'ABC','Correo'
go
exec AltaFacilidad 'DEF','Telefonía glll'
go
exec AltaFacilidad 'WYZ','Correo'
go
exec AltaFacilidad 'WYZ','Cambio'
go
exec AltaFacilidad 'WYZ','Telefonía'
go

exec AltaViajeInternacional 332,5,'20181126 10:00 AM','20181126 11:30 AM',46281426,'ABC','Copsa',1,'CI vigente'
go
exec AltaViajeInternacional 333,1,'20181028 8:00 PM','20181030 10:00 PM',53272348,'DEF','Cutsa',0,'CI vigente'
go
exec AltaViajeInternacional 334,2,'20181029 1:00 PM','20181029 2:00 PM',47290843,'WYZ','Rutas del sol',1,'CI vigente'
go
exec AltaViajeInternacional 335,2,'20181129 5:00 PM','20181129 8:00 PM',47290843,'WYZ','Copsa',1,'CI vigente'
go
exec AltaViajeNacional 336,5,'20191024 5:00 PM','20191025 6:00 PM',46281426,'ABC','Copsa',1
go
exec AltaViajeNacional 337,1,'20181030 8:00 AM','20181030 11:00 AM',53272348,'DEF','Cutsa',0
go
exec AltaViajeNacional 338,2,'20181125 5:00 PM','20181126 5:30 PM',47290843,'WYZ','Rutas del sol',1
go
exec AltaViajeNacional 339,2,'20181025 5:00 PM','20181026 5:30 PM',47290843,'DEF','Rutas del sol',1
go
exec AltaViajeNacional 340,2,'20191025 5:00 PM','20191026 5:30 PM',47290843,'DEF','Rutas del sol',1
go
exec AltaViajeNacional 341,2,'20181228 9:00 PM','20181229 11:30 PM',47290843,'WYZ','Copsa',1
go
exec AltaViajeNacional 346,2,'20191229 4:30 PM','20191229 7:30 PM',46281426,'DEF','Rutas del sol',1
select * from Viajes

USE master
GO

CREATE LOGIN [IIS APPPOOL\DefaultAppPool] FROM WINDOWS 
GO

USE TerminalURU
GO

CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
GO

Grant Execute to [IIS APPPOOL\DefaultAppPool]

--select*from Viajes
--select * from Internacionales
--exec BuscarViajeNacional 111
--select * from Companias
--exec BuscarViajeInternacional 332
--exec ModificarViajeInternacional 332,2,'20180826','20180827',46281426,'ABC','Copsa',1,'no lo se rick'