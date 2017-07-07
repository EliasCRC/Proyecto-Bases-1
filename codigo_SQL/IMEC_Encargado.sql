use DB_GRUPO1

GO
CREATE PROCEDURE insertar_Encargado
	@cedula VARCHAR(20),	
	@nombre VARCHAR(20)
	AS
	INSERT INTO Encargado
	VALUES (@cedula,@nombre)

GO
CREATE PROCEDURE modificar_Encargado
	@cedulaVieja	VARCHAR(20),  
	@cedulaNueva	VARCHAR(20),	
	@nombre			VARCHAR(20)
AS	IF @cedulaNueva IS NULL BEGIN
		SELECT @cedulaNueva = @cedulaVieja
	END
	IF @nombre IS NULL BEGIN
		SELECT @nombre = Nombre
		FROM Encargado
		WHERE Cedula = @cedulaVieja
	END
	UPDATE Encargado
	SET Cedula = @cedulaNueva , Nombre = @nombre
	WHERE Cedula = @cedulaVieja

GO
CREATE PROCEDURE eliminar_Encargado
	@cedula VARCHAR(20)
	AS
	DELETE FROM Encargado
	WHERE Cedula = @cedula

GO
CREATE PROCEDURE consultar_Encargado
	@cedula VARCHAR(20)
	AS
	SELECT *
	FROM Encargado
	WHERE Cedula = @cedula

