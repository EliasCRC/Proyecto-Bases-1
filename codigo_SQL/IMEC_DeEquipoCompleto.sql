use DB_GRUPO1

Go
CREATE PROCEDURE insertar_DeEquipoCompleto
	@momento				DATETIME,
	@horaInicioReal			TIME,	
	@horaFinalizacionReal	TIME,
	@telReferencia			VARCHAR(10),
	@cedulaEncargado		VARCHAR(20),

	@auto		BIT,
	@tel		VARCHAR(10)
	AS
	EXEC insertar_Reservacion @momento, @horaInicioReal, @horaFinalizacionReal, @telReferencia, @cedulaEncargado;
	INSERT INTO DeEquipoCompleto
	VALUES (@momento,@auto,@tel);

Go
CREATE PROCEDURE modificar_DeEquipoCompleto
	@momento		DATETIME,
	@auto			BIT,
	@tel			VARCHAR(10)
AS	IF @auto IS NULL BEGIN
		SELECT @auto = EsAutomatica
		FROM DeEquipoCompleto
		WHERE MomentoReservado = @momento
	END
	IF @tel IS NULL BEGIN
		SELECT @tel = TelefonoCliente
		FROM DeEquipoCompleto
		WHERE MomentoReservado = @momento
	END
	UPDATE DeEquipoCompleto
	SET EsAutomatica = @auto, TelefonoCliente = @tel
	WHERE MomentoReservado = @momento

Go
CREATE PROCEDURE eliminar_DeEquipoCompleto
	@momento	DATETIME
	AS
	DELETE FROM DeEquipoCompleto
	WHERE	MomentoReservado = @momento

Go
CREATE PROCEDURE consultar_DeEquipoCompleto
	@momento	DATETIME
	AS
	SELECT *
	FROM DeEquipoCompleto E JOIN Reservacion R ON E.MomentoReservado = R.MomentoReservado
	WHERE E.MomentoReservado = @momento
