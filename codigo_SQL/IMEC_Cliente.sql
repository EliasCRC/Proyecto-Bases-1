use DB_GRUPO1

Go
CREATE PROCEDURE insertar_Cliente
	@tel varchar(10),
	@nomb varchar(20),
	@ape varchar(20)
AS
	INSERT INTO Cliente
	VALUES(@tel, @nomb, @ape, 0, 0);


Go
CREATE PROCEDURE modificar_Cliente
	@telviejo varchar(10),
	@telnuevo varchar(10),
	@nom varchar(20),
	@ape varchar(20)
AS	IF @telnuevo IS NULL BEGIN 
		SELECT @telnuevo = @telviejo
	END
	IF @nom IS NULL BEGIN
		SELECT @nom = Nombre
		FROM Cliente
		WHERE Telefono = @telviejo
	END
	IF @ape IS NULL BEGIN
		SELECT @ape = Apellido
		FROM Cliente
		WHERE Telefono = @telviejo
	END
	UPDATE Cliente
	SET Telefono = @telnuevo, Nombre = @nom, Apellido = @ape
	WHERE Telefono = @telviejo;


Go
CREATE PROCEDURE eliminar_Cliente
	@tel varchar(10)
AS
	DELETE FROM Cliente
	WHERE Telefono = @tel;


Go
CREATE PROCEDURE consultar_Cliente
	@tel varchar(10)
AS
	SELECT *
	FROM Cliente C JOIN Frecuente F ON C.Telefono = F.Telefono;