use DB_GRUPO1

Go															
CREATE PROCEDURE modificar_Nombre_Producto
	@nombreViejo	VARCHAR(20),
	@nombreNuevo	VARCHAR(20)
	AS
	UPDATE Producto
	SET Nombre = @nombreNuevo
	WHERE Nombre = @nombreViejo

Go																
CREATE PROCEDURE modificar_Precio_Producto
	@nombre			VARCHAR(20),
	@precio			INT
	AS
	UPDATE Producto
	SET Precio = @precio
	WHERE Nombre = @nombre

Go
CREATE PROCEDURE consultar_Todos_Productos
AS
SELECT *
FROM Producto

Go
CREATE PROCEDURE consultar_Producto_Nombre_Precio
	@nombre VARCHAR(20),
	@precio INT
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

