use DB_GRUPO1

Go 
CREATE PROCEDURE Insertar_Contiene
	@nombreP	varchar(20),
	@momentoV	datetime,
	@cantidad	tinyint
AS	INSERT INTO Contiene
	VALUES (@nombreP, @momentoV, @cantidad);

Go 
CREATE PROCEDURE Modificar_Contiene
	@nombrePViejo	varchar(20),
	@nombreP	varchar(20),
	@momentoV	datetime,
	@cantidad	tinyint
AS	UPDATE Contiene
	SET NombreProducto = @nombreP, MomentoVenta = @momentoV, Cantidad = @cantidad
	WHERE NombreProducto = @nombrePViejo;

Go
CREATE PROCEDURE Eliminar_Contiene
	@nombreP	varchar(20)
AS	DELETE FROM Contiene
	WHERE NombreProducto = @nombreP

Go
CREATE PROCEDURE Consultar_Contiene
	@nombreP	varchar(20)
AS	SELECT *
	FROM Contiene
	WHERE NombreProducto = @nombreP;
