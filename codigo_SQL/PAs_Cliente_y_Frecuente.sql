use DB_GRUPO1

-- Modificar datos del cliente (Nombre, Apellido o Teléfono)
GO
CREATE PROCEDURE modificarTelefonoCliente
@telefonoViejo varchar(10),
@telefonoNuevo varchar(10)
AS
	UPDATE Cliente
	SET Telefono = @telefonoNuevo
	WHERE Telefono = @telefonoViejo

-- Consultar un cliente con nombre usando like (si llega a ser necesario)
GO
CREATE PROCEDURE ConsultarClienteNombre 
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

--Consultar un cliente con un teléfono específico
GO
CREATE PROCEDURE ConsultarClienteTelefono 
@telefono varchar(10)
AS
	SELECT * FROM Cliente
	WHERE Telefono = @telefono

-- Promover un cliente a cliente frecuente
GO
CREATE PROCEDURE hacerFrecuente
@telefono varchar(10)
AS
	INSERT INTO Frecuente
	VALUES (@telefono, 0)

-- Remover un cliente frecuente y ponerlo como clientes
GO
CREATE PROCEDURE quitarFrecuente
@telefono varchar(10)
AS
	DELETE FROM DeEquipoCompleto
	WHERE EsAutomatica = 1 AND TelefonoCliente = @telefono
	DELETE FROM Frecuente
	WHERE Telefono = @telefono

-- Consultar todos los clientes con el estatus frecuentes
GO
CREATE PROCEDURE consultarFrecuentes
AS 
	SELECT * FROM Frecuente F JOIN Cliente C ON F.Telefono = C.Telefono

-- Ver los horarios que el cliente tiene reservado
GO
CREATE PROCEDURE verHorarios
@telefono varchar (10)
AS
	SELECT DISTINCT Datepart(WeekDay, MomentoReservado) Dia, Datepart(Hour, MomentoReservado) Hora
	FROM DeEquipoCompleto
	WHERE EsAutomatica = 1;

-- Consultar todas las reservaciones de un cliente
GO
CREATE PROCEDURE verReservacionesCliente
@telefono varchar(10)
AS
	SELECT Telefono, Nombre, Apellido, MomentoReservado
	FROM Cliente JOIN Participa_En ON Telefono = TelefonoCliente
	UNION
	SELECT Telefono, Nombre, Apellido, MomentoReservado
	FROM Cliente JOIN DeEquipoCompleto ON Telefono = TelefonoCliente

-- Modificar la deuda (Incrementar o decrementar)
GO
CREATE PROCEDURE modificarDeuda
@monto int,
@telefono varchar(10)
AS
	UPDATE Cliente
	Set Deuda += @monto
	WHERE Telefono = @telefono

-- Insertar un nuevo horario para el cliente
GO
CREATE PROCEDURE agregarHorarioFrecuente
@telefono varchar(10),
@telefonoReferencia varchar(10),
@horario datetime,
@cedulaEncargado varchar(20)
AS
	INSERT INTO Reservacion
	VALUES (@horario, null, null, @telefonoReferencia, @cedulaEncargado)
	INSERT INTO DeEquipoCompleto
	VALUES (@horario, 1, @telefono)

-- Eliminar un horario para el cliente
GO
CREATE PROCEDURE eliminarHorarioFrecuente
@horario datetime
AS
	DELETE FROM DeEquipoCompleto
	WHERE DATEPART(WEEKDAY,MomentoReservado) = DATEPART(WEEKDAY, @horario) AND DATEPART(HOUR, MomentoReservado) = DATEPART(HOUR, @horario)

-- Consultar cuales clientes son frecuentes por nombre (usando like)
GO
CREATE PROCEDURE ConsultarFrecuenteNombre 
@nombre varchar(20),
@apellido varchar(20)
AS
	IF @apellido IS NULL 
		SELECT * FROM Cliente C JOIN Frecuente F on C.Telefono = F.Telefono
		WHERE Nombre LIKE '%' + @nombre + '%'
	ELSE IF @nombre IS NULL
		SELECT * FROM Cliente C JOIN Frecuente F on C.Telefono = F.Telefono
		WHERE Apellido LIKE '%' + @apellido + '%'
	ELSE 
		SELECT * FROM Cliente C JOIN Frecuente F on C.Telefono = F.Telefono
		WHERE Nombre LIKE '%' + @nombre + '%' AND Apellido LIKE '%' + @apellido + '%'

-- Consultar cuales clientes son frecuentes por teléfono
GO
CREATE PROCEDURE consultarFrecuenteTelefono
@telefono varchar(10)
AS 
	SELECT * FROM Frecuente F JOIN Cliente C ON F.Telefono = C.Telefono
	WHERE F.Telefono = @telefono
