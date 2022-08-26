create database ExamenFinal

create table Marticulos
(
CodigoArticulo int identity(1,1),
DescripcionArticulo varchar (30)not null,
CodigoTipo int,
PrecioArticulo money,
CostoArticulo money,
Cantidad int,
Constraint PK_CodigoArticulo primary key(CodigoArticulo),
Constraint FK_CodigoTipo foreign key (CodigoTipo) references TipoArticulo (CodigoTipo),
)

Create table ArticuloBitacora
(
DescripcionArticulo varchar (30),
CodigoTipo int,
PrecioArticulo money,
CostoArticulo money,
Cantidad int,
Fecha datetime,
Tipo varchar(15),
)

Create trigger BitacoraArticulo
on MArticulos 
after insert, delete
as
	begin	
	insert into ArticuloBitacora(DescripcionArticulo,CodigoTipo,PrecioArticulo,CostoArticulo,Cantidad,Fecha,Tipo)
	select i.DescripcionArticulo,i.CodigoTipo, i.PrecioArticulo,i.CostoArticulo,i.Cantidad, Getdate(), 'Ingreso' from inserted i
	union all
	select d.DescripcionArticulo, d.CodigoTipo, d.PrecioArticulo, d.CostoArticulo,d.Cantidad, Getdate(), 'borrado' from deleted d
	end

Create procedure MostrarBitacora
	as
		begin	
		select * from ArticuloBitacora
		end

Create proc AgregarArticulo
@descripcion varchar(30),
@codigotipo int,
@precioarticulo money,
@costoarticulo money,
@cantidad int
	as
		begin 
		insert into Marticulos(DescripcionArticulo, CodigoTipo, PrecioArticulo, CostoArticulo, Cantidad)
		values (@descripcion,@codigotipo,@precioarticulo,@costoarticulo,@cantidad)
		end

Create proc BorrarArticulo
@codigo int
	as
		begin 
		delete from Marticulos where CodigoArticulo = @codigo
		end


Create proc ActualizarArticulo
@codigo int,
@descripcion varchar(30),
@codigotipo int,
@precioarticulo money,
@costoarticulo money,
@cantidad int
	as
		begin 
		update Marticulos set DescripcionArticulo = @descripcion, CodigoTipo = @codigotipo, 
		PrecioArticulo = @precioarticulo, CostoArticulo = @costoarticulo, Cantidad = @cantidad where CodigoArticulo = @codigo
		end

Create procedure MostrarArticulos
	as
		begin
		select * from Marticulos
		end

create table TipoArticulo
(
CodigoTipo int identity(1,1),
DescripcionTipo varchar (30),
Constraint PK_CodigoTipo primary key(CodigoTipo), 
)

Create procedure AgregarTipoArticulo
@descripcion varchar (30)
	as
		begin
		insert into TipoArticulo (DescripcionTipo) values (@descripcion)
		end

Create procedure BorrarTipoArticulo
@codigo int
	as
		begin
		delete from TipoArticulo where CodigoTipo = @codigo
		end

Create procedure ActualizarTipoArticulo
@codigo int,
@descripcion varchar (30)
	as
		begin
		update TipoArticulo set DescripcionTipo = @descripcion where CodigoTipo = @codigo
		end

Create procedure MostrarTipoArticulo
	as
		begin
		select * from TipoArticulo
		end

Create table Usuarios
(
CodigoUsuario int identity(1,1),
NombreUsuario varchar (30),
ClaveUsuario varchar (30),
TipoUsuario int,
Constraint PK_CodigoUsuario primary key(CodigoUsuario), 
Constraint FK_TipoUsuario foreign key (TipoUsuario) references TiposUsuario (CodigoTipoUsuario),
)

Create procedure AgregarUsuario
@nombre varchar (30),
@clave varchar (30),
@tipousuario int
	as
		begin
		insert into Usuarios (NombreUsuario,ClaveUsuario,TipoUsuario) values (@nombre,@clave,@tipousuario)
		end

Create procedure BorrarUsuario
@codigo int
	as
		begin
		delete from Usuarios where CodigoUsuario = @codigo
		end

Create procedure ActualizarUsuario
@codigo int, 
@nombre varchar (30),
@clave varchar (30),
@tipousuario int
	as
		begin
		update Usuarios set NombreUsuario = @nombre, ClaveUsuario = @clave, TipoUsuario = @tipousuario where CodigoUsuario = @codigo
		end

Create procedure MostrarUsuarios
	as
		begin
		select * from Usuarios
		end

select * from Usuarios

Create table TiposUsuario
(
CodigoTipoUsuario int identity (1,1),
DescripcionTipoUsuario varchar (30),
Constraint PK_CodigoTipoUsuario primary key (CodigoTipoUsuario),
)

insert into TiposUsuario values ('Administrador'),('Regular')

Create procedure Registro
@nombreusuario varchar(30),
@claveusuario varchar(30),
@tipousuario int
as
	begin 
		insert into Usuarios (NombreUsuario,ClaveUsuario,TipoUsuario)
		values (@nombreusuario,@claveusuario,@tipousuario)
	end

Create procedure Inicio
@nombre varchar (30),
@clave varchar (30)
as
	begin 
	select NombreUsuario, ClaveUsuario from Usuarios where NombreUsuario = @nombre and ClaveUsuario = @clave;
	end

Create procedure CostoInventario
	as
		begin
		select DescripcionArticulo, CostoArticulo, Cantidad, Cantidad * CostoArticulo as [Costo Inventario] from Marticulos
		end

Create procedure Ganancias
	as
		begin
		select DescripcionArticulo, CostoArticulo, PrecioArticulo, Cantidad, Cantidad * CostoArticulo as [Costo Inventario], 
		Cantidad * PrecioArticulo as [Total Ventas], (Cantidad * PrecioArticulo) -   (Cantidad * CostoArticulo) as [Ganancias]
		from Marticulos
		end

Create procedure ReporteArticulos
	as
		begin
		select a.DescripcionArticulo, a.CostoArticulo, a.PrecioArticulo, a.Cantidad, t.DescripcionTipo as [Descripcion Tipo Articulo]
		from Marticulos as a
		inner join TipoArticulo t on t.CodigoTipo = a.CodigoTipo
		end	