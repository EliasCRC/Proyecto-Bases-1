use DB_GRUPO1

Go
CREATE PROCEDURE consultar_Ventas_Entre_Fechas
	@fecha1	DATETIME,
	@fecha2 DATETIME
	AS
	SELECT *
	FROM Venta
	WHERE MomentoVenta BETWEEN @fecha1 AND @fecha2

Go
CREATE PROCEDURE consultar_Productos_Venta
	@momento DATETIME
	AS
	SELECT	C.NombreProducto, C.Cantidad
	FROM Venta V INNER JOIN Contiene C ON V.MomentoVenta = c.MomentoVenta
	WHERE V.MomentoVenta = @momento

Go
CREATE PROCEDURE modificar_Cantidad_Venta
	@nombre varchar(20),
	@momento datetime,
	@cantidad tinyint
	AS
	UPDATE Contiene
	SET Cantidad = @cantidad
	WHERE MomentoVenta = @momento AND NombreProducto = @nombre
