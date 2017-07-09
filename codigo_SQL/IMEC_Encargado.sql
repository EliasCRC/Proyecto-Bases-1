use DB_GRUPO1

GO
CREATE PROCEDURE insertar_Encargado
	@cedula VARCHAR(20),	
	@nombre VARCHAR(20),
	@estado int output
AS
BEGIN TRY
	INSERT INTO Encargado
	VALUES (@cedula,@nombre)
			END TRY
BEGIN CATCH
	SET @estado = ERROR_MESSAGE()
END CATCH

GO
CREATE PROCEDURE modificar_Encargado
	@cedulaVieja	VARCHAR(20),  
	@cedulaNueva	VARCHAR(20),	
	@nombre			VARCHAR(20),
	@estado int output
AS
BEGIN TRY
	IF @cedulaNueva IS NULL BEGIN
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
END TRY
BEGIN CATCH
	SET @estado = ERROR_MESSAGE()
END CATCH

GO
CREATE PROCEDURE eliminar_Encargado
	@cedula VARCHAR(20),
	@estado int output
AS
BEGIN TRY
	DELETE FROM Encargado
	WHERE Cedula = @cedula
END TRY
BEGIN CATCH
	SET @estado = ERROR_MESSAGE()
END CATCH


GO
CREATE PROCEDURE consultar_Encargado
	@cedula VARCHAR(20)
	AS
	SELECT *
	FROM Encargado
	WHERE Cedula = @cedula

