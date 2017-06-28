use DB_GRUPO1

GO
CREATE PROCEDURE Insertar_Nuevo_Producto
	@nombre	varchar(20),
	@precio int
	AS
	INSERT INTO Producto
	VALUES (@nombre,@precio)
GO

CREATE PROCEDURE Modificar_Datos_Producto
	@nombreViejo varchar(20),
	@nombreNuevo varchar(20),
	@precio		int
	AS
	UPDATE Producto
	SET Nombre = @nombreNuevo, Precio = @precio
	WHERE Nombre = @nombreViejo
GO

CREATE PROCEDURE Consultar_Todos_Productos
AS
SELECT *
FROM Producto

GO

CREATE PROCEDURE Consultar_Producto_Nombre_Precio
	@nombre varchar(20),
	@precio int
	AS

	IF @NOMBRE IS NULL BEGIN
		SELECT *
		FROM Producto
		WHERE Precio = @precio
	END
	ELSE BEGIN
		SELECT *
		FROM Producto
		WHERE Nombre = @nombre 
	END

GO

CREATE PROCEDURE Consultar_Ventas_Fecha
	@fecha1 datetime,
	@fecha2 datetime
	AS
	SELECT *
	FROM Venta
	WHERE @fecha1 BETWEEN @fecha2
GO

CREATE PROCEDURE Consultar_Productos_Venta
	@momento datetime
	AS
	SELECT	C.NombreProducto, C.Cantidad
	FROM Venta V INNER JOIN Contiene C ON V.MomentoVenta = c.MomentoVenta
	WHERE V.MomentoVenta = @momento
GO


CREATE PROCEDURE Modificar_Contenido_Venta
	@nombreViejo varchar(20),
	@nombreNuevo varchar(20),
	@cantidad tinyint,
	@momento datetime
	AS
	UPDATE Contiene
	SET NombreProducto = @nombreNuevo, Cantidad = @cantidad
	WHERE MomentoVenta = @momento AND NombreProducto = @nombreViejo
GO

CREATE PROCEDURE Modificar_Cantidad_Venta
	@nombre varchar(20),
	@momento datetime,
	@cantidad tinyint
	AS
	UPDATE Contiene
	SET Cantidad = @cantidad
	WHERE MomentoVenta = @momento AND NombreProducto = @nombre


