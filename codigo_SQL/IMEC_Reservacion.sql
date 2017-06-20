USE DB_GRUPO1

CREATE PROCEDURE insertar_Reservacion
	@momento				datetime,
	@horaInicioReal			TIME,	
	@horaFinalizacionReal	TIME,
	@telReferencia			VARCHAR(10),
	@cedulaEncargado		VARCHAR(20)
	AS 
	INSERT INTO Reservacion
	VALUES	(@momento, @horaInicioReal, @horaFinalizacionReal, @telReferencia, @cedulaEncargado)

CREATE PROCEDURE consultar_Reservacion
	@momento	datetime
	AS 
	SELECT * 
	FROM Reservacion
	WHERE @momento = MomentoReservado

CREATE PROCEDURE eliminar_Reservacion
	@momento
	AS
	DELETE FROM Reservacion
	WHERE MomentoReservado = @momento

CREATE PROCEDURE modificar_Reservacion
	@momentoViejo			datetime,
	@momentoNuevo			datetime,
	@horaInicioReal			TIME,	
	@horaFinalizacionReal	TIME,
	@telReferencia			VARCHAR(10),
	@cedulaEncargado		VARCHAR(20)
	AS 
	UPDATE Reservacion
	SET MomentoReservado = @momentoNuevo, HoraInicioReal = @horaInicioReal, HoraFinalizacionReal = @horaFinalizacionReal, TelefonoReferencia = @telReferencia, CedulaEncargado = @cedulaEncargado
	WHERE MomentoReservado = @momentoViejo
