use DB_GRUPO1

Go 
CREATE PROCEDURE insertar_Contiene
	@nombreP	VARCHAR(20),
	@momentoV	DATETIME,
	@cantidad	TINYINT,
	@estado		bit output
AS	
BEGIN TRY	
	INSERT INTO Contiene
	VALUES (@nombreP, @momentoV, @cantidad);
	END TRY
BEGIN CATCH
	SET @estado = ERROR_MESSAGE()
END CATCH
Go 
CREATE PROCEDURE modificar_Contiene
	@nombrePViejo	VARCHAR(20),
	@nombreP		VARCHAR(20),
	@momentoV		DATETIME,
	@momentoVViejo	DATETIME,
	@cantidad		TINYINT,
	@estado		bit output
AS	
BEGIN TRY	
IF @nombreP IS NULL BEGIN
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
	END TRY
BEGIN CATCH
	SET @estado = ERROR_MESSAGE()
END CATCH

Go
CREATE PROCEDURE eliminar_Contiene
	@nombreP	VARCHAR(20),
	@momento	DATETIME,
	@estado		bit output
AS	
BEGIN TRY
	DELETE FROM Contiene
	WHERE NombreProducto = @nombreP AND MomentoVenta = @momento
	END TRY
BEGIN CATCH
	SET @estado = ERROR_MESSAGE()
END CATCH

Go
CREATE PROCEDURE consultar_Contiene
	@nombreP	VARCHAR(20)
AS	SELECT *
	FROM Contiene
	WHERE NombreProducto = @nombreP;
Go	
CREATE PROCEDURE consultar_Todos_Contiene
	@momento DATETIME
AS	SELECT*
	FROM Contiene
	WHERE MomentoVenta = @momento
