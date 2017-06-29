use DB_GRUPO1

Go
CREATE PROCEDURE insertar_Frecuente
	@tel	VARCHAR(10)
AS
	INSERT INTO Frecuente
	VALUES(@tel, 0);


/* No hace falta un Modificar para Frecuente */


Go
CREATE PROCEDURE eliminar_Frecuente
	@tel	VARCHAR(10)
AS
	DELETE FROM Frecuente
	WHERE Telefono = @tel;


/* El consultar del frecuente ya está abarcado en el consultar de cliente */

