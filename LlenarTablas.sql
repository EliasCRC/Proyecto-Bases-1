use DB_GRUPO1

INSERT INTO Encargado
VALUES	('1', 'Pepe'),
		('2', 'Rene'),
		('3', 'Jose')

INSERT INTO Cliente
VALUES	('4', 'Luis', null, 0, 0),
		('0', 'Adan', null, 0, 0),
		('5', 'Rodrigo', 'Rodriguez', 1000, 1),
		('6', 'Fernando', 'Fernandez', 2000, 0)

INSERT INTO Frecuente
VALUES	('4', 1),
		('5', 0)

INSERT INTO Reservacion
VALUES	('20170707 10:00:00 AM', NULL, NULL, NULL, '1'),
		('20170708 10:00:00 AM', NULL, NULL, NULL, '2'),
		('20170707 11:00:00 AM', NULL, NULL, NULL, '3')

INSERT INTO DeEquipoCompleto
VALUES	('20170707 10:00:00 AM', 0, '4'),
		('20170708 10:00:00 AM', 1, '5'),
		('20170707 11:00:00 AM', 0, '0')

INSERT INTO Reservacion
VALUES	('20170705 10:00:00 AM', NULL, NULL, NULL, '1'),
		('20170704 10:00:00 AM', NULL, NULL, NULL, '2'),
		('20170703 11:00:00 AM', NULL, NULL, NULL, '3')

INSERT INTO Reto
VALUES	('20170705 10:00:00 AM'),
		('20170704 10:00:00 AM')

INSERT INTO Participa_En
VALUES	('5', '20170705 10:00:00 AM', 1),
		('0', '20170705 10:00:00 AM', 0),
		('4', '20170704 10:00:00 AM', 0),
		('6', '20170704 10:00:00 AM', 1)

