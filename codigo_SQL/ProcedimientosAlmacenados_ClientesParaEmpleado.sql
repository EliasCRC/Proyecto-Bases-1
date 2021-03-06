use DB_GRUPO1

-- Modificar datos del cliente (Nombre, Apellido o Teléfono)
Go
CREATE PROCEDURE modificar_TelefonoCliente
	@telefonoViejo varchar(10),
	@telefonoNuevo varchar(10),
	@estado bit OUTPUT
AS BEGIN TRY 
		UPDATE Cliente
		SET Telefono = @telefonoNuevo
		WHERE Telefono = @telefonoViejo
	END TRY
	BEGIN CATCH
		SET @estado=ERROR_MESSAGE()
	END CATCH

-- Consultar un cliente con nombre usando like (si llega a ser necesario)
Go
CREATE PROCEDURE consultar_ClienteNombre 
@nombre varchar(20),
@apellido varchar(20)
AS
	IF @apellido IS NULL 
		SELECT * FROM Cliente
		WHERE Nombre LIKE '%' + @nombre + '%'
	ELSE IF @nombre IS NULL
		SELECT * FROM Cliente
		WHERE Apellido LIKE '%' + @apellido + '%'
	ELSE 
		SELECT * FROM Cliente
		WHERE Nombre LIKE '%' + @nombre + '%' AND Apellido LIKE '%' + @apellido + '%'

-- Consultar todas las reservaciones de un cliente
Go
CREATE PROCEDURE comsultar_Reservaciones_DeCliente
@telefono varchar(10)
AS
	SELECT Telefono, Nombre, Apellido, MomentoReservado
	FROM Cliente JOIN Participa_En ON Telefono = TelefonoCliente
	UNION
	SELECT Telefono, Nombre, Apellido, MomentoReservado
	FROM Cliente JOIN DeEquipoCompleto ON Telefono = TelefonoCliente

-- Modificar la deuda (Incrementar o decrementar)
Go
CREATE PROCEDURE modificar_Deuda
	@tel varchar(10),
	@cantidad int,
	@estado bit OUTPUT
AS	BEGIN TRY
		UPDATE Cliente
		SET Deuda = Deuda + @cantidad
		WHERE Telefono = @tel;
	END TRY
	BEGIN CATCH
		SET @estado=ERROR_MESSAGE()
	END CATCH

-- Consultar un cliente que no sea frecuente con nombre usando like (si llega a ser necesario)
Go
CREATE PROCEDURE consultar_EsporadicoNombre 
@nombre varchar(20),
@apellido varchar(20)
AS
	IF @apellido IS NULL 
		SELECT * FROM Cliente 
		WHERE Nombre LIKE '%' + @nombre + '%'
		EXCEPT SELECT C.Telefono, C.Nombre, C.Apellido, C.Deuda, C.NumReservCanceladas
		FROM Frecuente F JOIN Cliente C on C.Telefono = F.Telefono
	ELSE IF @nombre IS NULL
		SELECT * FROM Cliente
		WHERE Apellido LIKE '%' + @apellido + '%'
		EXCEPT SELECT C.Telefono, C.Nombre, C.Apellido, C.Deuda, C.NumReservCanceladas
		FROM Frecuente F JOIN Cliente C on C.Telefono = F.Telefono
	ELSE 
		SELECT * FROM Cliente
		WHERE Nombre LIKE '%' + @nombre + '%' AND Apellido LIKE '%' + @apellido + '%'
		EXCEPT SELECT C.Telefono, C.Nombre, C.Apellido, C.Deuda, C.NumReservCanceladas
		FROM Frecuente F JOIN Cliente C on C.Telefono = F.Telefono
