use DB_GRUPO1

Go
CREATE PROCEDURE modificar_Deuda
	@tel varchar(10),
	@cantidad int
	AS
	UPDATE Cliente
	SET Deuda = Deuda + @cantidad
	WHERE Telefono = @tel;

GO
CREATE PROCEDURE verHorarios
@telefono varchar (10),
@fechaActual datetime
AS
	SELECT DISTINCT Datepart(WeekDay, MomentoReservado) Dia, Datepart(Hour, MomentoReservado) Hora
	FROM DeEquipoCompleto
	WHERE EsAutomatica = 1 AND MomentoReservado >= @fechaActual AND TelefonoCliente = @telefono

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

GO
CREATE PROCEDURE hacerFrecuente
@telefono varchar(10)
AS
	INSERT INTO Frecuente
	VALUES (@telefono, 0)

-- Eliminar un horario para el cliente
GO
CREATE PROCEDURE eliminarHorarioFrecuente
@diaSemana int,
@hora int,
@hoy datetime,
@telefono varchar(10)
AS
	DELETE FROM DeEquipoCompleto
	WHERE DATEPART(WEEKDAY,MomentoReservado) = @diaSemana
	AND DATEPART(HOUR, MomentoReservado) = @hora
	AND MomentoReservado > @hoy
	AND TelefonoCliente = @telefono

Go
CREATE PROCEDURE editar_Cliente
	@telviejo varchar(10),
	@telnuevo varchar(10),
	@nom varchar(20),
	@ape varchar(20)
AS	IF @telnuevo IS NULL BEGIN 
		SELECT @telnuevo = @telviejo
	END
	IF @nom IS NULL BEGIN
		SELECT @nom = Nombre
		FROM Cliente
		WHERE Telefono = @telviejo
	END
	UPDATE Cliente
	SET Telefono = @telnuevo, Nombre = @nom, Apellido = @ape
	WHERE Telefono = @telviejo;

Go
CREATE PROCEDURE crear_Cliente
	@tel varchar(10),
	@nomb varchar(20),
	@ape varchar(20)
AS
	INSERT INTO Cliente
	VALUES(@tel, @nomb, @ape, 0, 0);

Go
CREATE PROCEDURE borrar_Cliente
	@tel varchar(10)
AS
	DELETE FROM Cliente
	WHERE Telefono = @tel;

Go 
CREATE PROCEDURE obtenerCedulaUsuario
	@nombre varchar(40),
	@cedula varchar(20) OUTPUT
AS	
	SELECT @cedula = cedulaUsuario
	FROM Usuarios
	WHERE nombreUsuario = @nombre
	return @cedula

Go
CREATE PROCEDURE reiniciarCanceladas
	@telefono varchar(10)
AS
	UPDATE Cliente
	SET NumReservCanceladas = 0
	WHERE Telefono = @telefono

Go
CREATE PROCEDURE reiniciarCanceladasAuto
	@telefono varchar(10)
AS
	UPDATE Frecuente
	SET NumReservAutomaticasCanceladas = 0
	WHERE Telefono = @telefono

GO
CREATE PROCEDURE consultar_Frecuente_PorNombre 
@nombre varchar(20),
@apellido varchar(20)
AS
	IF @apellido IS NULL 
		SELECT C.Telefono, Nombre, Apellido, Deuda, NumReservAutomaticasCanceladas 'Autom. Canceladas'
		FROM Cliente C JOIN Frecuente F on C.Telefono = F.Telefono
		WHERE Nombre LIKE '%' + @nombre + '%'
	ELSE IF @nombre IS NULL
		SELECT C.Telefono, Nombre, Apellido, Deuda, NumReservAutomaticasCanceladas 'Autom. Canceladas'
		FROM Cliente C JOIN Frecuente F on C.Telefono = F.Telefono
		WHERE Apellido LIKE '%' + @apellido + '%'
	ELSE 
		SELECT C.Telefono, Nombre, Apellido, Deuda, NumReservAutomaticasCanceladas 'Autom. Canceladas'
		FROM Cliente C JOIN Frecuente F on C.Telefono = F.Telefono
		WHERE Nombre LIKE '%' + @nombre + '%' AND Apellido LIKE '%' + @apellido + '%'
