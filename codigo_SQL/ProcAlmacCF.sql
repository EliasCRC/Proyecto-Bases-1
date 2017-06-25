use DB_GRUPO1


GO
CREATE PROCEDURE InsertarCliente
	@tel varchar(10),
	@nomb varchar(20),
	@ape varchar(20)
AS
	INSERT INTO Cliente
	VALUES(@tel, @nomb, @ape, 0, 0);


GO
CREATE PROCEDURE ModificarCliente
	@telviejo varchar(10),
	@telnuevo varchar(10),
	@nom varchar(20),
	@ape varchar(20)
AS
	UPDATE Cliente
	SET Telefono = @telnuevo, Nombre = @nom, Apellido = @ape
	WHERE Telefono = @telviejo;


GO
CREATE PROCEDURE EliminarCliente
	@tel varchar(10)
AS
	DELETE FROM Cliente
	WHERE Telefono = @tel;


GO
CREATE PROCEDURE ConsultarCliente
	@tel varchar(10)
AS
	SELECT *
	FROM Cliente C JOIN Frecuente F ON C.Telefono = F.Telefono;


GO
CREATE PROCEDURE InsertarFrecuente
	@tel varchar(10)
AS
	INSERT INTO Frecuente
	VALUES(@tel, 0);


/* No hace falta un Modificar para Frecuente */


GO
CREATE PROCEDURE EliminarFrecuente
	@tel varchar(10)
AS
	DELETE FROM Frecuente
	WHERE Telefono = @tel;


/* No hace falta un Consultar para Frecuente */


GO
CREATE PROCEDURE ModificarDeuda
	@tel varchar(10),
	@cantidad int
AS
	UPDATE Cliente
	SET Deuda = Deuda + @cantidad
	WHERE Telefono = @tel;