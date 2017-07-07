use DB_GRUPO1

Go 
CREATE PROCEDURE insertar_Producto
	@nombre		VARCHAR(20),
	@precio		INT
AS	INSERT INTO Producto
	VALUES (@nombre, @precio);

Go 
CREATE PROCEDURE modificar_Producto
	@nombreViejo	VARCHAR(20),
	@nombre			VARCHAR(20),
	@precio			INT
AS	IF @nombre IS NULL BEGIN
		SELECT @nombre = @nombreViejo
	END
	IF @precio IS NULL BEGIN 
		SELECT @precio = Precio
		FROM Producto
		WHERE Nombre = @nombreViejo
	END
	UPDATE Producto
	SET Nombre = @nombre, Precio = @precio
	WHERE Nombre = @nombreViejo;

Go
CREATE PROCEDURE eliminar_Producto
	@nombre		VARCHAR(20)
AS	DELETE FROM Producto
	WHERE Nombre = @nombre

Go
CREATE PROCEDURE consultar_Producto
	@nombre		VARCHAR(20)		
AS	SELECT *
	FROM Producto
	WHERE Nombre = @nombre
