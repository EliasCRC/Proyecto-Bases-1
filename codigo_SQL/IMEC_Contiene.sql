use DB_GRUPO1

Go 
CREATE PROCEDURE insertar_Contiene
	@nombreP	VARCHAR(20),
	@momentoV	DATETIME,
	@cantidad	TINYINT
AS	INSERT INTO Contiene
	VALUES (@nombreP, @momentoV, @cantidad);

Go 
CREATE PROCEDURE modificar_Contiene
	@nombrePViejo	VARCHAR(20),
	@nombreP		VARCHAR(20),
	@momentoV		DATETIME,
	@momentoVViejo	DATETIME,
	@cantidad		TINYINT
AS	IF @nombreP IS NULL BEGIN
		SELECT @nombreP = @nombrePViejo
	END
	IF @momentoV IS NULL BEGIN 
		SELECT @momentoV = @momentoVViejo
	END
	IF @cantidad IS NULL BEGIN
		SELECT @cantidad = Cantidad
		FROM Contiene
		WHERE NombreProducto = @nombrePViejo AND MomentoVenta = @momentoVViejo;
	END
	UPDATE Contiene
	SET NombreProducto = @nombreP, MomentoVenta = @momentoV, Cantidad = @cantidad
	WHERE NombreProducto = @nombrePViejo AND MomentoVenta = @momentoVViejo;

Go
CREATE PROCEDURE eliminar_Contiene
	@nombreP	VARCHAR(20)
AS	DELETE FROM Contiene
	WHERE NombreProducto = @nombreP

Go
CREATE PROCEDURE consultar_Contiene
	@nombreP	VARCHAR(20)
AS	SELECT *
	FROM Contiene
	WHERE NombreProducto = @nombreP;
