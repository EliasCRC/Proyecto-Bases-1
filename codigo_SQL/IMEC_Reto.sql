CREATE PROCEDURE insertar_Reto
	@momento				datetime
	AS 
	INSERT INTO Reto
	VALUES	(@momento)

CREATE PROCEDURE consultar_Reto
	@momento datetime
	AS
	SELECT *
	FROM Reservacion
	WHERE MomentoReservado = @momento

CREATE PROCEDURE eliminar_Reto
	@momento
	AS 
	DELETE FROM Reto
	WHERE MomentoReservacion = @momento
