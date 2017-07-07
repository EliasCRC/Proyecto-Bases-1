use DB_GRUPO1

Go															
CREATE PROCEDURE modificar_Nombre_Producto
	@nombreViejo	VARCHAR(20),
	@nombreNuevo	VARCHAR(20),
	@estado			BIT	OUTPUT
	AS
	BEGIN TRY
	UPDATE Producto
	SET Nombre = @nombreNuevo
	WHERE Nombre = @nombreViejo
	END TRY
	BEGIN CATCH
		SET @estado = ERROR_MESSAGE()
	END CATCH

Go																
CREATE PROCEDURE modificar_Precio_Producto
	@nombre			VARCHAR(20),
	@precio			INT,
	@estado			BIT	OUTPUT
	AS
	BEGIN TRY
	UPDATE Producto
	SET Precio = @precio
	WHERE Nombre = @nombre
	END TRY
	BEGIN CATCH
	SET @estado = ERROR_MESSAGE()
	END CATCH

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
