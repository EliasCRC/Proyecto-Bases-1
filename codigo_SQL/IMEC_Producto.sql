use DB_GRUPO1

Go 
CREATE PROCEDURE Insertar_Producto
	@nombre		varchar(20),
	@precio		int
AS	INSERT INTO Producto
	VALUES (@nombre, @precio);

Go 
CREATE PROCEDURE Modificar_Producto
	@nombreViejo	varchar(20),
	@nombre			varchar(20),
	@precio			int
AS	UPDATE Producto
	SET Nombre = @nombre, Precio = @precio
	WHERE Nombre = @nombreViejo;

Go
CREATE PROCEDURE Eliminar_Producto
	@nombre		varchar(20)
AS	DELETE FROM Producto
	WHERE Nombre = @nombre

Go
CREATE PROCEDURE Consultar_Producto
	@nombre		varchar(20)		
AS	SELECT *
	FROM Producto
	WHERE Nombre = @nombre

Go
CREATE PROCEDURE Consultar_Todos_Productos
AS	SELECT *
	FROM Producto

