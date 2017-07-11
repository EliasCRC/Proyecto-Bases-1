USE DB_GRUPO1


CREATE TABLE Cliente 
( 
Telefono			VARCHAR(10),
Nombre				VARCHAR(20)	NOT NULL,
Apellido			VARCHAR(20),
Deuda				INT		DEFAULT 0	NOT NULL,
NumReservCanceladas		INT		DEFAULT 0	NOT NULL
 
CONSTRAINT PKCliente PRIMARY KEY (Telefono)
);



CREATE TABLE Frecuente 
( 
Telefono					VARCHAR(10),
NumReservAutomaticasCanceladas	TINYINT		DEFAULT 0	NOT NULL
 
CONSTRAINT PKFrecuente PRIMARY KEY (Telefono),
CONSTRAINT FKClienteFrecuente FOREIGN KEY(Telefono) REFERENCES Cliente(Telefono)
	ON DELETE CASCADE
	ON UPDATE CASCADE
);



CREATE TABLE Encargado 
( 
Cedula		VARCHAR(20),
Nombre		VARCHAR(20)	NOT NULL
 
CONSTRAINT PKEncargado PRIMARY KEY (Cedula)
);



CREATE TABLE Reservacion 
( 
MomentoReservado		DATETIME,
HoraInicioReal			TIME,	
HoraFinalizacionReal		TIME,
TelefonoReferencia		VARCHAR(10),
CedulaEncargado			VARCHAR(20)
 
CONSTRAINT PKReservacion PRIMARY KEY (MomentoReservado),
CONSTRAINT FKEncargadoReserv FOREIGN KEY(CedulaEncargado) REFERENCES Encargado(Cedula)
	ON UPDATE CASCADE
	ON DELETE SET NULL
	-- Si un encargado es eliminado del sistema todas sus reservaciones no deberían de borrarse
);



CREATE TABLE Producto
(
Nombre  VARCHAR(20),
Precio 	INT		NOT NULL
 
CONSTRAINT PKProducto PRIMARY KEY (Nombre)
);



CREATE TABLE Venta
(
MomentoVenta 		DATETIME,
MontoTotal 		INT	DEFAULT 0,	
CedulaEncargado 	VARCHAR(20)
 
CONSTRAINT PKVenta PRIMARY KEY (MomentoVenta),
CONSTRAINT FKEncargadoVenta FOREIGN KEY(CedulaEncargado) REFERENCES Encargado(Cedula)
	ON UPDATE CASCADE
	ON DELETE SET NULL 
	-- Si un encargado es eliminado del sistema todas sus ventas no deberían de borrarse
);



CREATE TABLE Contiene
(
NombreProducto	VARCHAR(20),
MomentoVenta	DATETIME,
Cantidad		TINYINT		NOT NULL	CHECK(Cantidad > 0)
 
CONSTRAINT PKContiene PRIMARY KEY(NombreProducto, MomentoVenta),
CONSTRAINT FKProducto FOREIGN KEY(NombreProducto) REFERENCES Producto(Nombre)
	ON UPDATE CASCADE
	ON DELETE NO ACTION,
CONSTRAINT FKVenta FOREIGN KEY(MomentoVenta) REFERENCES Venta(MomentoVenta)
	ON UPDATE CASCADE
	ON DELETE CASCADE 

);



CREATE TABLE DeEquipoCompleto 
( 
MomentoReservado		DATETIME,
EsAutomatica			BIT				NOT NULL,
TelefonoCliente			VARCHAR(10)		NOT NULL

CONSTRAINT PKEquipoCompleto PRIMARY KEY(MomentoReservado),
CONSTRAINT FKRerservacionE FOREIGN KEY(MomentoReservado) REFERENCES Reservacion(MomentoReservado)
	ON UPDATE CASCADE
	ON DELETE CASCADE,
CONSTRAINT FKCliente FOREIGN KEY(TelefonoCliente) REFERENCES Cliente(Telefono)
	ON UPDATE CASCADE
	ON DELETE CASCADE 
 
);



CREATE TABLE Reto 
( 
MomentoReservado	DATETIME

CONSTRAINT PKReto PRIMARY KEY(MomentoReservado),
CONSTRAINT FKRerservacionR FOREIGN KEY(MomentoReservado) REFERENCES Reservacion(MomentoReservado)
	ON UPDATE CASCADE
	ON DELETE CASCADE
 );



 CREATE TABLE Participa_En 
(
TelefonoCliente		VARCHAR(10),
MomentoReservado	DATETIME,
EsCreador			BIT			NOT NULL
 
CONSTRAINT PKParticipa PRIMARY KEY(TelefonoCliente, MomentoReservado),
CONSTRAINT FKClienteParticipe FOREIGN KEY(TelefonoCliente) REFERENCES Cliente(Telefono)
	ON UPDATE CASCADE
	ON DELETE CASCADE ,
CONSTRAINT FKRerservacionP FOREIGN KEY(MomentoReservado) REFERENCES Reservacion(MomentoReservado)
	ON UPDATE CASCADE
	ON DELETE CASCADE
 
);
