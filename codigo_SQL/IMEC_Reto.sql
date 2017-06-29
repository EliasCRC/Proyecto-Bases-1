use DB_GRUPO1

Go
CREATE PROCEDURE insertar_Reto
	@momento				DATETIME,
	@horaInicioReal			TIME,	
	@horaFinalizacionReal	TIME,
	@telReferencia			VARCHAR(10),
	@cedulaEncargado		VARCHAR(20),

	@telCliente	VARCHAR(20)
	AS 
	EXEC insertar_Reservacion @momento, @horaInicioReal, @horaFinalizacionReal, @telReferencia, @cedulaEncargado;
	INSERT INTO Reto
	VALUES	(@momento);
	INSERT INTO Participa_En
	VALUES (@telCliente, @momento, 1);

Go
CREATE PROCEDURE eliminar_Reto
	@momento	DATETIME
	AS 
	DELETE FROM Reto
	WHERE MomentoReservado = @momento

Go
CREATE PROCEDURE consultar_Reto
	@momento	DATETIME
	AS
	SELECT *
	FROM Reservacion
	WHERE MomentoReservado = @momento
