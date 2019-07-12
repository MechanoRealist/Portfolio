--1.  2.
USE master
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'Kundekartotek')
BEGIN
	DROP DATABASE Kundekartotek
END
CREATE DATABASE Kundekartotek
GO --BEGIN END og GO er ikke T-SQL statements men ord som SSMS bruger til at styre eksekveringen.
USE Kundekartotek
SET DATEFORMAT dmy; --Sætter dato og tids formatet https://docs.microsoft.com/en-us/sql/t-sql/statements/set-dateformat-transact-sql?view=sql-server-2017
GO
CREATE TABLE Postnumre
(
	Postnummer smallint PRIMARY KEY CHECK(Postnummer >= 1000 AND Postnummer <= 9999),
	[By] varchar(50) NOT NULL
)

CREATE TABLE Kontakttyper
(
	Kontaktform varchar(5) PRIMARY KEY,
	KontaktNavn varchar(50) NOT NULL
)

CREATE TABLE  Kontaktpersoner
(
	[Kontaktet af] varchar(5) PRIMARY KEY,
	[Kontaktet Navn] varchar(50) NOT NULL
)

CREATE TABLE Kunder
(
	Kundenummer int PRIMARY KEY IDENTITY(1,1),
	Firmanavn varchar(50) NOT NULL,
	Adresse varchar(50) NOT NULL,
	Postnummer smallint NOT NULL,
	[e-mail] varchar(50) DEFAULT 'Ingen email'
)

CREATE TABLE Kontakter
(
	Kundenummer int NOT NULL,
	Kontakttidspunkt DateTime NOT NULL,
	[Kontaktet af] varchar(5) NOT NULL,
	[Att.] varchar(50) NOT NULL,
	Kontaktform varchar(5) NOT NULL,
	Referat text,
	PRIMARY KEY (Kundenummer,Kontakttidspunkt,[Kontaktet af])
)
GO
ALTER TABLE Kunder ADD
CONSTRAINT FK_Kunder_Postnummer FOREIGN KEY (Postnummer) REFERENCES Postnumre(Postnummer)

ALTER TABLE Kontakter ADD
CONSTRAINT FK_Kontakter_Kundenummer FOREIGN KEY (Kundenummer) REFERENCES Kunder(Kundenummer),
CONSTRAINT FK_Kontakter_KontaktetAf FOREIGN KEY ([Kontaktet af]) REFERENCES Kontaktpersoner([Kontaktet af]),
CONSTRAINT FK_Kontakter_Kontaktform FOREIGN KEY (Kontaktform) REFERENCES Kontakttyper(Kontaktform)
GO
INSERT INTO Postnumre VALUES
	(8000, 'Aarhus C'),
	(8660, 'Skanderborg'),
	(9000, 'Aalborg'),
	(6760, 'Ribe'),
	(6800, 'Varde'),
	(3700, 'Rønne'),
	(5000, 'Odense'),
	(2750, 'Ballerup')

INSERT INTO Kontakttyper VALUES
	('BO', 'Brev fra os'),
	('KA', 'Kampagne'),
	('TK', 'Telefon fra kunden'),
	('TO', 'Telefon fra os')

INSERT INTO Kontaktpersoner VALUES
	('AB', 'Anne Bendix'),
	('HH', 'Hanne Hansen'),
	('MJ', 'Max Jensen')

INSERT INTO Kunder VALUES
	('D.K.G', 'Åbyvej 27', 8000 , 'info@dkg.dk'),
	('Unikom', 'Vibyvej 104', 8660 , 'dk@unicom.com'),
	('Hammer-holdt', 'Adelgade 1', 9000 , 'hr@HHolding.com'),
	('Jydsk Is', 'Brovej 9', 6760 , 'mail@jydskis.dk'),
	('Anker Juul', 'Midtvej 8', 6800 , default),
	('Rønne Vand', 'Havvej 43', 3700 , 'Rv@vandland.dk')

INSERT INTO Kontakter VALUES
	(1, '05-03-95 11:05', 'AB', 'Jørgen Fick', 'TO', 'Kunden kont'),
	(1, '09-03-95 09:45', 'MJ', 'Jørgen Fick', 'TO', 'De ønsker'),
	(2, '07-03-95 14:45', 'AB', 'Anne Madsen', 'TK', 'Bestilt 3 PO'),
	(3, '12-03-95', 'MJ', 'Kurt Tanders', 'BO', 'Kontakt'),
	(4, '21-05-95 15:05', 'HH', 'Niels Hansen', 'TK', 'Manglede'),
	(5, '08-06-95 08:30', 'AB', 'Pia Nissen', 'TO', 'Bad om at'),
	(3, '03-05-95 11:10', 'MJ', 'Leo Nøhr', 'TO', 'Anker ønsk'),
	(6, '07-05-95', 'HH', 'Ib Rossin', 'KA', 'K95 ismaskine')
GO

--3.
CREATE INDEX IDX_KundePostnummer ON Kunder(Postnummer);
CREATE INDEX IDX_KontakterKontaktetAf ON Kontakter([Kontaktet af]);
CREATE INDEX IDX_KontakterAtt ON Kontakter([Att.])

--4.
SELECT * FROM Kunder WHERE Postnummer > 8000 OR Postnummer = 3700;

--5.
SELECT * FROM Kontakter WHERE [Kontaktet af] = 'AB' ORDER BY Kundenummer DESC;

--6.
SELECT * FROM Kontakter WHERE [Att.] LIKE '%sen';

--7.
INSERT INTO Kontakter VALUES (9, '05-03-95 11:05', 'AB', 'Jørgen Fick', 'TO', 'Kunden kont') --Kan ikke indsætte et kundenumer der ikke findes.

--8.
SELECT COUNT([Kontaktet af]) AS [Antal gange],[Kontaktet af] FROM Kontakter WHERE [Kontaktet af] IN ('AB','MJ','HH') GROUP BY [Kontaktet af];

--Join øvelser
SELECT Kundenummer,Firmanavn,Adresse,Kunder.Postnummer,Postnumre.[By],[e-mail] FROM Kunder,Postnumre
WHERE Kunder.Postnummer = Postnumre.Postnummer

SELECT Kundenummer,Firmanavn,Adresse,Kunder.Postnummer,[By] FROM Kunder INNER JOIN Postnumre
ON Kunder.Postnummer = Postnumre.Postnummer

SELECT Kundenummer,Firmanavn,Adresse,Kunder.Postnummer,[By] FROM Kunder LEFT JOIN Postnumre
ON Kunder.Postnummer = Postnumre.Postnummer

SELECT Kundenummer,Firmanavn,Adresse,Postnumre.Postnummer,[By] FROM Kunder RIGHT JOIN Postnumre
ON Kunder.Postnummer = Postnumre.Postnummer

SELECT Kundenummer,Firmanavn,Adresse,Postnumre.Postnummer,[By] FROM Kunder FULL OUTER JOIN Postnumre
ON Kunder.Postnummer = Postnumre.Postnummer

--Samlet tælling
SELECT COUNT(*) FROM Kontakter WHERE [Kontaktet af] IN ('AB','MJ','HH');

--SELECT * FROM Postnumre
--SELECT * FROM Kontakttyper
--SELECT * FROM Kontaktpersoner
--SELECT * FROM Kunder
--SELECT * FROM Kontakter