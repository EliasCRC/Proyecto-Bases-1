CREATE PROCEDURE insertar_Participa_En
	@telCliente	varchar(10),	
	@momento	datetime
	AS 
	INSERT INTO Participa_En
	VALUES	(@telCliente, @momento)


CREATE PROCEDURE modificar_Participa_En
	@telClienteViejo	varchar(10),	
	@momentoViejo		datetime,
	@telClienteNuevo	varchar(10),	
	@momentoNuevo		datetime
	AS 
	UPDATE Participa_En
	SET TelefonoCliente = @telClienteNuevo, MomentoReservado = @momentoNuevo
	WHERE TelefonoCliente = @telClienteViejo AND MomentoReservado = @momentoViejo

CREATE PROCEDURE consultar_Participa_En
	@telCliente varchar(10),
	@momento	datetime
	AS
	SELECT *
	FROM Participa_En
	WHERE MomentoReservado = @momento AND TelefonoCliente = @telCliente

CREATE PROCEDURE eliminar_Participa_En
	@telCliente varchar(10),
	@momento	datetime
	AS
	DELETE FROM Participa_En
	WHERE TelefonoCliente = @telCliente AND MomentoReservado = @momento
