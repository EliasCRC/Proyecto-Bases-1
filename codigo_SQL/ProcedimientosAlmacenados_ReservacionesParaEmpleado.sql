use DB_GRUPO1

Go
CREATE PROCEDURE modificar_momento_reservacion
	@momentoViejo	DATETIME,
	@momentoNuevo	DATETIME,
	@estado			bit OUTPUT
AS	BEGIN TRY
		UPDATE Reservacion
		SET MomentoReservado = @momentoNuevo
		WHERE MomentoReservado = @momentoViejo;
	END TRY
	BEGIN CATCH
		SET @estado=ERROR_MESSAGE()
	END CATCH

Go
CREATE PROCEDURE inicio_reservacion
	@momento	DATETIME,
	@horaInicio	TIME,
	@estado		bit OUTPUT
AS	BEGIN TRY
		UPDATE Reservacion
		SET HoraInicioReal = @horaInicio
		WHERE MomentoReservado = @momento;
	END TRY
	BEGIN CATCH
		SET @estado=ERROR_MESSAGE()
	END CATCH

Go
CREATE PROCEDURE final_reservacion
	@momento	DATETIME,
	@horaFinal	TIME,
	@estado		bit OUTPUT
AS	BEGIN TRY
		UPDATE Reservacion
		SET HoraFinalizacionReal = @horaFinal
		WHERE MomentoReservado = @momento;
	END TRY
	BEGIN CATCH
		SET @estado=ERROR_MESSAGE()
	END CATCH

Go
CREATE PROCEDURE modificar_telefono_referencia
	@momento	DATETIME,
	@telefono	VARCHAR(10),
	@isDelete	BIT,
	@estado		bit OUTPUT
AS	BEGIN TRY
		IF @isDelete = 1 BEGIN 
			SELECT @telefono = NULL;
		END
		UPDATE Reservacion
		SET TelefonoReferencia = @telefono
		WHERE MomentoReservado = @momento
	END TRY
	BEGIN CATCH
		SET @estado=ERROR_MESSAGE()
	END CATCH

Go
CREATE PROCEDURE cancelar_reservacion
	@momento			DATETIME,
	@telefonoCliente	VARCHAR(10),
	@aumentarContador	BIT,
	@estado				bit OUTPUT
AS	BEGIN TRY
		IF @aumentarContador = 1 BEGIN
			UPDATE Cliente
			SET NumReservCanceladas = NumReservCanceladas + 1
			WHERE Telefono = @telefonoCliente;
		END;
		DELETE FROM Reservacion
		WHERE MomentoReservado = @momento;
	END TRY
	BEGIN CATCH
		SET @estado=ERROR_MESSAGE()
	END CATCH

Go
CREATE PROCEDURE consultar_reservaciones
	@momentoBase	DATETIME,
	@momentoTop		DATETIME
AS	SELECT RE.MomentoReservado, RE.HoraInicioReal, RE.HoraFinalizacionReal, RE.TelefonoReferencia, RE.CedulaEncargado, 0 AS EsAutomatica,'Reto' AS Tipo
	FROM Reservacion RE JOIN Reto R ON RE.MomentoReservado = R.MomentoReservado
	WHERE RE.MomentoReservado BETWEEN @momentoBase AND @momentoTop 
	UNION
	SELECT RE.MomentoReservado, RE.HoraInicioReal, RE.HoraFinalizacionReal, RE.TelefonoReferencia, RE.CedulaEncargado, R.EsAutomatica, 'De Equipo Completo' AS Tipo
	FROM Reservacion RE JOIN DeEquipoCompleto R ON RE.MomentoReservado = R.MomentoReservado
	WHERE RE.MomentoReservado BETWEEN @momentoBase AND @momentoTop 
	
Go
CREATE PROCEDURE consultar_EquipoCompleto_Intervalo
	@momentoBase	DATETIME,
	@momentoTop		DATETIME
AS	SELECT RE.MomentoReservado, RE.HoraInicioReal, RE.HoraFinalizacionReal, RE.TelefonoReferencia, RE.CedulaEncargado, R.EsAutomatica
	FROM Reservacion RE JOIN DeEquipoCompleto R ON RE.MomentoReservado = R.MomentoReservado
	WHERE RE.MomentoReservado BETWEEN @momentoBase AND @momentoTop 
	
Go
CREATE PROCEDURE consultar_Reto_Intervalo
	@momentoBase	DATETIME,
	@momentoTop		DATETIME
AS	SELECT RE.MomentoReservado, RE.HoraInicioReal, RE.HoraFinalizacionReal, RE.TelefonoReferencia, RE.CedulaEncargado
	FROM Reservacion RE JOIN Reto R ON RE.MomentoReservado = R.MomentoReservado
	WHERE RE.MomentoReservado BETWEEN @momentoBase AND @momentoTop 

Go
CREATE PROCEDURE cancelar_reservacion_automatica
	@momento			DATETIME,
	@telefonoFrecuente	VARCHAR(10),
	@aumentarContador	BIT,
	@estado				bit OUTPUT
AS	BEGIN TRY
		IF @aumentarContador = 1 BEGIN
			UPDATE Frecuente
			SET NumReservAutomaticasCanceladas = NumReservAutomaticasCanceladas + 1
			WHERE Telefono = @telefonoFrecuente;
		END;
		EXEC cancelar_reservacion @momento, @telefonoFrecuente, @aumentarContador, @estado;
	END TRY
	BEGIN CATCH
		SET @estado=ERROR_MESSAGE()
	END CATCH

Go
CREATE PROCEDURE consultar_reto_participantes
	@momento	DATETIME
AS	SELECT RE.MomentoReservado, RE.HoraInicioReal, RE.HoraFinalizacionReal, RE.TelefonoReferencia, RE.CedulaEncargado, C.Nombre, C.Telefono, P.EsCreador
	FROM ((Reto R JOIN Reservacion RE ON R.MomentoReservado = RE.MomentoReservado)JOIN Participa_En P ON R.MomentoReservado = P.MomentoReservado) JOIN Cliente C ON P.TelefonoCliente = C.Telefono
	WHERE R.MomentoReservado = @momento
