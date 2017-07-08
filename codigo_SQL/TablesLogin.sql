use DB_GRUPO1

CREATE TABLE Usuarios
(
	cedulaUsuario	VARCHAR(20)		NOT NULL,
	nombreUsuario	VARCHAR(40)		NOT NULL	PRIMARY KEY,
	esAdmin			BIT				NOT NULL,
	PasswordHash	BINARY(64)		NOT NULL,
	salt			UNIQUEIDENTIFIER,
CONSTRAINT FK_EncargadoUser FOREIGN KEY	(cedulaUsuario) REFERENCES Encargado(Cedula)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);

Go
CREATE PROCEDURE agregarUsuario
	@pLogin NVARCHAR(50),
	@pPassword NVARCHAR(50),
	@cedula varchar(9),
	@esAdmin bit,
	@estado bit OUTPUT

AS  DECLARE @salt UNIQUEIDENTIFIER=NEWID()
	BEGIN TRY
		INSERT INTO Usuarios
		VALUES(@cedula, @pLogin, @esAdmin, HASHBYTES('SHA2_512', @pPassword+CAST(@salt AS NVARCHAR(36))), @salt)
		SET @estado=1
	END TRY
	BEGIN CATCH
		SET @estado=ERROR_MESSAGE()
	END CATCH

Go
CREATE PROCEDURE Login
	@pLoginName NVARCHAR(254),
	@pPassword NVARCHAR(50),
	@isInDB bit=0	OUTPUT
AS	DECLARE @userID INT
	IF EXISTS (SELECT TOP 1	cedulaUsuario FROM [dbo].[Usuarios] WHERE nombreUsuario=@pLoginName)
	BEGIN
		SET @userID=(	SELECT cedulaUsuario 
						FROM Usuarios
						WHERE nombreUsuario=@pLoginName AND PasswordHash=HASHBYTES('SHA2_512', @pPassword+CAST(Salt AS NVARCHAR(36)))
					)
		IF(@userID IS NULL)
			SET @isInDB=0
		ELSE
			SET @isInDB=1
		END
	ELSE
		SET @isInDB=0

Go
CREATE PROCEDURE UsuarioEsAdmin
	@pLoginName NVARCHAR(254),
	@esAdmin bit	OUTPUT
AS	SELECT @esAdmin = esAdmin
	FROM Usuarios
	WHERE nombreUsuario = @pLoginName
