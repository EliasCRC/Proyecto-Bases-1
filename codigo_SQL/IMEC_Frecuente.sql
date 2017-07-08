use DB_GRUPO1

Go
CREATE PROCEDURE insertar_Frecuente
	@tel	VARCHAR(10),
	@numR  tinyint,
	@estado bit output
AS
BEGIN TRY	
	INSERT INTO Frecuente
	VALUES(@tel, @numR);
	END TRY
BEGIN CATCH
	SET @estado = ERROR_MESSAGE()
END CATCH


/* No hace falta un Modificar para Frecuente */
GO
CREATE PROCEDURE modificar_Frecuente
	@telViejo 	VARCHAR(10),
	@telNuevo	VARCHAR(10),
	@numR  tinyint,
	@estado bit output
AS
BEGIN TRY	
	UPDATE Frecuente
	SET Telefono = @telNuevo , NumReservAutomaticasCanceladas = @numR
	WHERE Telefono = @telViejo
	END TRY
BEGIN CATCH
	SET @estado = ERROR_MESSAGE()
END CATCH

Go
CREATE PROCEDURE eliminar_Frecuente
	@tel	VARCHAR(10),
	@estado bit output
AS
BEGIN TRY	
	DELETE FROM Frecuente
	WHERE Telefono = @tel;
	END TRY
BEGIN CATCH
	SET @estado = ERROR_MESSAGE()
END CATCH


/* El consultar del frecuente ya está abarcado en el consultar de cliente */

Go
CREATE PROCEDURE consultar_FrecuenteTelefono
	@tel varchar(10)
AS
	SELECT C.Telefono, C.Nombre, C.Apellido, Deuda, NumReservCanceladas, NumReservAutomaticasCanceladas
	FROM Cliente C join Frecuente F on C.Telefono = F.Telefono
	WHERE C.Telefono = @tel

