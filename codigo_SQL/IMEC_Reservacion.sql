use DB_GRUPO1

Go
CREATE PROCEDURE insertar_Reservacion
	@momento				DATETIME,
	@horaInicioReal			TIME,	
	@horaFinalizacionReal	TIME,
	@telReferencia			VARCHAR(10),
	@cedulaEncargado		VARCHAR(20)
	AS 
	INSERT INTO Reservacion
	VALUES	(@momento, @horaInicioReal, @horaFinalizacionReal, @telReferencia, @cedulaEncargado)

Go
CREATE PROCEDURE consultar_Reservacion
	@momento	DATETIME
	AS 
	SELECT * 
	FROM Reservacion
	WHERE @momento = MomentoReservado

Go
CREATE PROCEDURE eliminar_Reservacion
	@momento	DATETIME
	AS
	DELETE FROM Reservacion
	WHERE MomentoReservado = @momento

Go
CREATE PROCEDURE modificar_Reservacion
	@momentoViejo			DATETIME,
	@momentoNuevo			DATETIME,
	@horaInicioReal			TIME,	
	@horaFinalizacionReal	TIME,
	@telReferencia			VARCHAR(10),
	@cedulaEncargado		VARCHAR(20)
	AS 
	IF @momentoNuevo IS NULL BEGIN
		SELECT @momentoNuevo = @momentoViejo
	END
	IF @horaInicioReal IS NULL BEGIN
		SELECT @horaInicioReal = HoraInicioReal
		FROM Reservacion
		WHERE MomentoReservado = @momentoViejo
	END
	IF @horaFinalizacionReal IS NULL BEGIN
		SELECT @horaFinalizacionReal = HoraFinalizacionReal
		FROM Reservacion
		WHERE MomentoReservado = @momentoViejo
	END
	IF @telReferencia IS NULL BEGIN
		SELECT @telReferencia = TelefonoReferencia
		FROM Reservacion
		WHERE MomentoReservado = @momentoViejo
	END
	IF @cedulaEncargado IS NULL BEGIN
		SELECT @cedulaEncargado = CedulaEncargado
		FROM Reservacion
		WHERE MomentoReservado = @momentoViejo
	END
	UPDATE Reservacion
	SET MomentoReservado = @momentoNuevo, HoraInicioReal = @horaInicioReal, HoraFinalizacionReal = @horaFinalizacionReal, 
		TelefonoReferencia = @telReferencia, CedulaEncargado = @cedulaEncargado
	WHERE MomentoReservado = @momentoViejo
