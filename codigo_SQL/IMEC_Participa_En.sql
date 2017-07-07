use DB_GRUPO1

Go
CREATE PROCEDURE insertar_Participa_En
	@telefonoC	VARCHAR(10),
	@momento	DATETIME,
	@esCreador	BIT
AS	INSERT INTO Participa_En
	VALUES (@telefonoC, @momento, @esCreador);

Go
CREATE PROCEDURE modificar_Participa_En
	@telClienteViejo	VARCHAR(10),	
	@momentoViejo		DATETIME,
	@telClienteNuevo	VARCHAR(10),	
	@momentoNuevo		DATETIME,
	@esCreador			BIT
AS	IF @telClienteNuevo IS NULL AND @momentoNuevo IS NULL  BEGIN
		SELECT @telClienteNuevo = @telClienteViejo, @momentoNuevo = @momentoViejo
	END
	IF @esCreador IS NULL BEGIN
		SELECT @esCreador = EsCreador 
		FROM Participa_En
		WHERE MomentoReservado = @momentoViejo AND TelefonoCliente = @telClienteViejo
	END
	UPDATE Participa_En
	SET TelefonoCliente = @telClienteNuevo, MomentoReservado = @momentoNuevo, EsCreador = @esCreador
	WHERE TelefonoCliente = @telClienteViejo AND MomentoReservado = @momentoViejo
	
Go
CREATE PROCEDURE consultar_Participa_En
	@telCliente varchar(10),
	@momento	datetime
AS
	SELECT *
	FROM Participa_En
	WHERE MomentoReservado = @momento AND TelefonoCliente = @telCliente

Go
CREATE PROCEDURE eliminar_Participa_En
	@telCliente varchar(10),
	@momento	datetime
AS
	DELETE FROM Participa_En
	WHERE TelefonoCliente = @telCliente AND MomentoReservado = @momento
