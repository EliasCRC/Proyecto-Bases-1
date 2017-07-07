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

Go
CREATE PROCEDURE consultar_FrecuenteTelefono
	@tel varchar(10)
AS
	SELECT C.Telefono, C.Nombre, C.Apellido, Deuda, NumReservCanceladas, NumReservAutomaticasCanceladas
	FROM Cliente C join Frecuente F on C.Telefono = F.Telefono
	WHERE C.Telefono = @tel

