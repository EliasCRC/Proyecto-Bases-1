use DB_GRUPO1

Go 
CREATE PROCEDURE insertar_Venta
	@momento	datetime,
	@montoT		int,
	@cedulaE	varchar(20),
	@estado		bit output
AS	
BEGIN TRY
	INSERT INTO Venta
	VALUES (@momento, @montoT, @cedulaE);
END TRY
BEGIN CATCH
	SET @estado = ERROR_MESSAGE()
END CATCH

Go 
CREATE PROCEDURE modificar_Venta
	@momentoViejo	datetime,
	@momento		datetime,
	@montoT			int,
	@cedulaE		varchar(20)
AS	IF @momento IS NULL BEGIN
		SELECT @momento = @momentoViejo
	END
	IF @montoT IS NULL BEGIN
		SELECT @montoT = MontoTotal
		FROM Venta
		WHERE MomentoVenta = @momentoViejo
	END
	IF @cedulaE IS NULL BEGIN
		SELECT @cedulaE = CedulaEncargado 
		FROM Venta 
		WHERE MomentoVenta = @momentoViejo
	END
	UPDATE Venta
	SET MomentoVenta = @momento, MontoTotal= @montoT, CedulaEncargado = @cedulaE
	WHERE MomentoVenta = @momentoViejo;

Go
CREATE PROCEDURE eliminar_Venta
	@momento		datetime
AS	DELETE FROM Venta
	WHERE MomentoVenta = @momento

Go
CREATE PROCEDURE consultar_Venta
	@momento		datetime
AS	SELECT *
	FROM Venta
	WHERE MomentoVenta = @momento;
