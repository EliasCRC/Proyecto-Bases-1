use DB_GRUPO1

Go 
CREATE PROCEDURE Insertar_Venta
	@momento	datetime,
	@montoT		int,
	@cedulaE	varchar(20)
AS	INSERT INTO Venta
	VALUES (@momento, @montoT, @cedulaE);

Go 
CREATE PROCEDURE Modificar_Venta
	@momentoViejo	datetime,
	@momento		datetime,
	@montoT			int,
	@cedulaE		varchar(20)
AS	UPDATE Venta
	SET MomentoVenta = @momento, MontoTotal= @montoT, CedulaEncargado = @cedulaE
	WHERE MomentoVenta = @momentoViejo;

Go
CREATE PROCEDURE Eliminar_Venta
	@momento		datetime
AS	DELETE FROM Venta
	WHERE MomentoVenta = @momento

Go
CREATE PROCEDURE Consultar_Venta
	@momento		datetime
AS	SELECT *
	FROM Venta
	WHERE MomentoVenta = @momento;
