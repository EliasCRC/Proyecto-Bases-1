use DB_GRUPO1

GO
CREATE TRIGGER ActualizaMontoTotal
ON Contiene AFTER INSERT
AS
	DECLARE @nombProducto varchar(20), @momento datetime, @cantidad tinyint, @precioUnidad int
	DECLARE cursorContiene CURSOR FOR
		SELECT NombreProducto, MomentoVenta, Cantidad
		FROM Contiene
	OPEN cursorContiene
	FETCH NEXT FROM cursorContiene INTO @nombProducto, @momento, @cantidad
	WHILE @@FETCH_STATUS = 0 BEGIN
		SELECT @precioUnidad = Precio
		FROM Producto P
		WHERE P.Nombre = @nombProducto
		IF @precioUnidad IS NULL BEGIN
			SET @precioUnidad = 0
		END
		UPDATE Venta
		SET MontoTotal += @cantidad * @precioUnidad
		WHERE MomentoVenta = @momento
		FETCH NEXT FROM cursorContiene INTO @nombProducto, @momento, @cantidad
	END
	CLOSE cursorContiene
	DEALLOCATE cursorContiene
;
