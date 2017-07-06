use DB_GRUPO1

-- Remover un cliente frecuente y ponerlo como clientes
Go
CREATE PROCEDURE quitar_Frecuente
@telefono varchar(10),
@estado BIT OUTPUT
AS
	BEGIN TRY
		DELETE FROM DeEquipoCompleto
		WHERE EsAutomatica = 1 AND TelefonoCliente = @telefono
		DELETE FROM Frecuente
		WHERE Telefono = @telefono
		END TRY
	BEGIN CATCH
		set @estado = ERROR_MESSAGE()
	END CATCH
 
-- Consultar todos los clientes con el estatus frecuentes
Go
CREATE PROCEDURE consultar_Frecuentes
AS 
	SELECT * FROM Frecuente F JOIN Cliente C ON F.Telefono = C.Telefono

-- Ver los horarios que el cliente tiene reservado
Go
CREATE PROCEDURE consultar_Horarios
@telefono varchar (10)
AS
	SELECT DISTINCT Datepart(WeekDay, MomentoReservado) Dia, Datepart(Hour, MomentoReservado) Hora
	FROM DeEquipoCompleto
	WHERE EsAutomatica = 1	AND TelefonoCliente = @telefono;


-- Insertar un nuevo horario para el cliente
Go
CREATE PROCEDURE agregar_HorarioFrecuente
@telefono varchar(10),
@telefonoReferencia varchar(10),
@horario datetime,
@cedulaEncargado varchar(20),
@estado BIT OUTPUT
AS
	BEGIN TRY
		INSERT INTO Reservacion
		VALUES (@horario, null, null, @telefonoReferencia, @cedulaEncargado)
		INSERT INTO DeEquipoCompleto
		VALUES (@horario, 1, @telefono)
	END TRY
	BEGIN CATCH
		set @estado = ERROR_MESSAGE()
	END CATCH

-- Eliminar un horario para el cliente
Go
CREATE PROCEDURE eliminar_HorarioFrecuente
@horario datetime,
@estado BIT OUTPUT
AS
	BEGIN TRY
	DELETE FROM DeEquipoCompleto
	WHERE DATEPART(WEEKDAY,MomentoReservado) = DATEPART(WEEKDAY, @horario) AND DATEPART(HOUR, MomentoReservado) = DATEPART(HOUR, @horario)
	END TRY
	BEGIN CATCH
	set @estado = ERROR_MESSAGE()
	END CATCH
	

-- Consultar cuales clientes son frecuentes por nombre (usando like)
-- Consultar cuales clientes son frecuentes por nombre (usando like)
Go
CREATE PROCEDURE consultar_Frecuente_PorNombre 
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
