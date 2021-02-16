--CREATE DATABASE bdFutbol;
--USE bdFutbol;

CREATE TABLE Ligas (
	codLiga CHAR(5),
	nomLiga VARCHAR(50),
    CONSTRAINT pk_codLiga PRIMARY KEY (codLiga)
);

CREATE TABLE Equipos (
	codEquipo INT IDENTITY(1,1),
	nomEquipo VARCHAR(40),
	codLiga CHAR(5) DEFAULT 'PDN',
	localidad VARCHAR(60),
	internacional BIT DEFAULT '0',
    CONSTRAINT pk_codEquipo PRIMARY KEY (codEquipo),
    CONSTRAINT fk_codLiga FOREIGN KEY (codLiga) REFERENCES Ligas (codLiga)
);

CREATE TABLE Futbolistas (
	codDNIoNIE CHAR(9),
	nombre VARCHAR(50),
	nacionalidad VARCHAR(40),
    CONSTRAINT pk_codDNIoNIE PRIMARY KEY (codDNIoNIE)
);

CREATE TABLE Contratos (
	codContrato INT IDENTITY(1,1),
	codDNIoNIE CHAR(9),
	codEquipo INT,
	fechaInicio DATE,
	fechaFin DATE,
	precioAnual INT,
	precioRecision INT,
    CONSTRAINT pk_codContrato PRIMARY KEY (codContrato),
    CONSTRAINT fk_codDNIoNIE FOREIGN KEY (codDNIoNIE) REFERENCES Futbolistas (codDNIoNIE),
    CONSTRAINT fk_codEquipo FOREIGN KEY (codEquipo) REFERENCES Equipos (codEquipo)
);

/* INSERTAR VALORES */

INSERT INTO Ligas (codLiga, nomLiga) VALUES 
	('LFP01', 'Primera Divisi�n'),
	('LFP02', 'Segunda Divisi�n'),
	('LFP03', 'Tercera Divisi�n');

INSERT INTO Equipos (nomEquipo, codLiga, localidad) VALUES
	('Real Madrid C. F.', 'LFP01', 'Madrid'),
	('F. C. Barcelona', 'LFP01', 'Barcelona'),
	('Athletic Club', 'LFP01', 'Bilbao'),
	('Atl�tico de Madrid', 'LFP01', 'Madrid'),
	('Real Betis', 'LFP01', 'Sevilla'),

	('R. C. D. Mallorca', 'LFP02', 'Palma de Mallorca'),
	('M�laga Club de F�tbol', 'LFP02', 'M�laga'),
	('U. D. Las Palmas', 'LFP02', 'Las Palmas de Gran Canaria'),
	('C. D. Tenerife', 'LFP02', 'Santa Cruz de Tenerife'),
	('Real Zaragoza', 'LFP02', 'Zaragoza');

INSERT INTO Futbolistas (codDNIoNIE, nombre, nacionalidad) VALUES
	('11111111M', 'Iker Casillas', 'Espa�ola'),
	('22222222M', 'Xabi Alonso', 'Espa�ola'),
	('33333333M', 'Hugo S�nchez', 'Hugo S�nchez'),
	('44444444M', 'Iv�n Zamorano', 'Chileno'),
	('55555555M', 'Cristiano Ronaldo', 'Portuguesa'),

	('66666666B', 'I�aki Pe�a', 'Espa�ola'),
	('77777777B', 'Gerard Piqu�', 'Espa�ola'),
	('88888888B', 'Jean-Clair Todibo', 'Francesa'),
	('99999999B', 'Cl�ment Lenglet', 'Francesa'),
	('12121212B', 'Jordi Alba', 'Espa�ola');

INSERT INTO Contratos (codDNIoNIE, codEquipo, fechaInicio, fechaFin, precioAnual, precioRecision) VALUES
	('11111111M', '1', '2020-01-01','2020-12-31','99999999','11111111'),
	('22222222M', '1', '2020-01-01','2020-12-31','99999999','11111111'),
	('33333333M', '1', '2020-01-01','2020-12-31','99999999','11111111'),
	('44444444M', '1', '2020-01-01','2020-12-31','99999999','11111111'),
	('55555555M', '1', '2020-01-01','2020-12-31','99999999','11111111'),

	('66666666B', '2', '2020-01-01','2020-12-31','99999999','11111111'),
	('77777777B', '2', '2020-01-01','2020-12-31','99999999','11111111'),
	('88888888B', '2', '2020-01-01','2020-12-31','99999999','11111111'),
	('99999999B', '2', '2020-01-01','2020-12-31','99999999','11111111'),
	('12121212B', '2', '2020-01-01','2020-12-31','99999999','11111111');
