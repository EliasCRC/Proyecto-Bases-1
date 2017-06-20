use DB_GRUPO1

GO
CREATE PROCEDURE insertar_Encargado
	@cedula varchar(20),	
	@nombre varchar(20)
	AS
	INSERT INTO Encargado
	VALUES (@cedula,@nombre)

GO
CREATE PROCEDURE modificar_Encargado
	@cedulaVieja	varchar(20),  
	@cedulaNueva	varchar(20),	
	@nombre			varchar(20)
	AS
	UPDATE Encargado
	SET Cedula = @cedulaNueva , Nombre = @nombre
	WHERE Cedula = @cedulaVieja

GO
CREATE PROCEDURE eliminar_Encargado
	@cedula varchar(20)
	AS
	DELETE FROM Encargado
	WHERE Cedula = @cedula

GO
CREATE PROCEDURE consultar_Encargado
	@cedula varchar(20)
	AS
	SELECT *
	FROM Encargado
	WHERE Cedula = @cedula

GO

CREATE PROCEDURE insertar_DeEquipoCompleto
	@momento	datetime,
	@auto		bit,
	@tel		varchar(10)
	AS
	INSERT INTO DeEquipoCompleto
	VALUES (@momento,@auto,@tel)

GO
CREATE PROCEDURE modificar_DeEquipoCompleto
	@momentoViejo	datetime,
	@momentoNuevo	datetime,
	@auto			bit,
	@tel			varchar(10)
	AS
	UPDATE DeEquipoCompleto
	SET MomentoReservado = @momentoNuevo, EsAutomatica = @auto, TelefonoCliente = @tel
	WHERE MomentoReservado = @momentoViejo

GO
CREATE PROCEDURE eliminar_DeEquipoCompleto
	@momento	datetime
	AS
	DELETE FROM DeEquipoCompleto
	WHERE	MomentoReservado = @momento

GO
CREATE PROCEDURE consultar_DeEquipoCompleto
	@momento	datetime
	AS
	SELECT *
	FROM DeEquipoCompleto
	WHERE MomentoReservado = @momento

GO
