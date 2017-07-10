GO
CREATE TRIGGER Actualizar_MontoTotal
ON Contiene AFTER INSERT, DELETE, UPDATE
AS
	DECLARE  @momento datetime, @producto varchar(20), @cantidad tinyint , @MontoTotal  int = 0
	IF EXISTS ( SELECT *
				FROM inserted i
	)
	BEGIN 
		SELECT @momento = i.MomentoVenta, @producto = i.NombreProducto, @cantidad = i.Cantidad
		FROM	inserted i
	END	
	ELSE BEGIN
		SELECT @momento = d.MomentoVenta, @producto = d.NombreProducto, @cantidad = d.Cantidad
		FROM	deleted d
	END
	
	IF(@producto IS NOT NULL) BEGIN
		SELECT @MontoTotal = @MontoTotal + (Precio*Cantidad)
		FROM Contiene C inner join Producto P on C.NombreProducto = P.Nombre 
		WHERE @momento = C.MomentoVenta

		UPDATE Venta
		SET	 MontoTotal = @MontoTotal
		WHERE MomentoVenta = @momento	
	END
