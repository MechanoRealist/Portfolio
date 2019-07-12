use master
if exists (select * from sys.databases where name = 'elever')
begin
	drop database elever
end
create database elever
GO
USE elever

CREATE TABLE PostNrBy
( 
	PostNr smallint NOT NULL,
	[By] varchar(60) NOT NULL,
	PRIMARY KEY (PostNr)
)
CREATE TABLE Klasse
(
	KlasseID int IDENTITY(1,1),
	KlasseNavn varchar(20) NOT NULL,
	PRIMARY KEY (KlasseID)
)
CREATE TABLE Elev
(
	ElevID int IDENTITY(1,1),
	Fornavn varchar(20) NOT NULL,
	Efternavn varchar(20) NOT NULL,
	Adresse varchar(60) NOT NULL,
	PostNr smallint NOT NULL,
	KlasseID int NOT NULL,
	PRIMARY KEY (ElevID)
)
CREATE TABLE Laerer
(
	LaererID int IDENTITY(1,1),
	Fornavn varchar(20) NOT NULL,
	Efternavn varchar(20) NOT NULL,
	Adresse varchar(60) NOT NULL,
	PostNr smallint NOT NULL,
	PRIMARY KEY (LaererID)
)
CREATE TABLE LaererKlasse
(
	LKID int IDENTITY(1,1),
	LaererID int NOT NULL,
	KlasseID int NOT NULL,
	Fag varchar(30) NOT NULL,
	PRIMARY KEY (LKID)
)
CREATE TABLE Fag
(
	Fag varchar(30) PRIMARY KEY
)

GO
ALTER TABLE Elev ADD
CONSTRAINT FK_Elev_Postnr FOREIGN KEY (PostNr) REFERENCES PostNrBy(PostNr),
CONSTRAINT FK_Elev_KlasseID FOREIGN KEY (KlasseID) REFERENCES Klasse(KlasseID)

ALTER TABLE Laerer ADD CONSTRAINT FK_Laerer_Postnr FOREIGN KEY (PostNr) REFERENCES PostNrBy(PostNr)

ALTER TABLE LaererKlasse ADD
CONSTRAINT FK_LaererKlasse_LaererID FOREIGN KEY (LaererID) REFERENCES Laerer(LaererID),
CONSTRAINT FK_LaererKlasse_KlasseID FOREIGN KEY (KlasseID) REFERENCES Klasse(KlasseID),
CONSTRAINT FK_LaererKlasse_Fag FOREIGN KEY (Fag) REFERENCES Fag(Fag)
GO

INSERT INTO PostNrBy VALUES (2650, 'Hvidovre'),
	(2300, 'København S'),
	(2500, 'Valby'),
	(2610, 'Rødovre'),
	(3650, 'Ølstykke'),
	(2830, 'Virum'),
	(2770, 'Kastrup'),
	(1824, 'Frederiksberg C'),
	(2740, 'Skovlunde'),
	(2750, 'Ballerup')

INSERT INTO Fag VALUES ('Generel Programmering'), ('Netværk 1'), ('SQL'), ('C#')

INSERT INTO Klasse VALUES ('A210'), ('E224'), ('D307')

INSERT INTO Laerer VALUES
	('Tom', 'It', 'Sankt Thomas Alle 3', 1824),
	('Lars', 'Henriksen', 'Nissedalen 76', 2740),
	('Mia', 'Hansen', 'Østervej 16', 2750)

INSERT INTO Elev VALUES
	('Bo','Andersen', 'Gammel Byvej 12', 2650, 1),
	('Frederikke', 'Hansen', 'Amager Boulevard 5', 2300, 1),
	('Jens', 'Mikkelsen', 'Lily Brobergs Vej 17', 2500, 1),
	('Phillip', 'Mortensen', 'Brunevang 90', 2610, 2),
	('Kasper', 'Frederiksen', 'Bryggertorvet 32', 3650, 2),
	('Milla', 'Jørgensen', 'Virum Torv 25', 2830, 2),
	('Fie', 'Knudsen', 'Allen 85', 2770, 3),
	('Henrik', 'Madsen', 'Lily Brobergs Vej 53', 2500, 3)

INSERT INTO LaererKlasse VALUES --Skal komme til sidst fordi den refererer data i tidligere tabeller
	(1,2,'Generel Programmering'),
	(2,3,'Netværk 1'),
	(3,1,'C#'),
	(1,1,'SQL')

--SELECT * FROM Laerer
--SELECT * FROM Klasse
--SELECT * FROM Fag
--SELECT * FROM LaererKlasse

SELECT Laerer.Fornavn, Efternavn, Adresse, Laerer.PostNr, PostnrBy.[By], Klasse.KlasseNavn, Fag.Fag FROM Laerer,PostNrBy,Klasse,Fag,LaererKlasse
WHERE Laerer.PostNr = PostnrBy.Postnr AND Laerer.LaererID = LaererKlasse.LaererID AND Klasse.KlasseID = LaererKlasse.KlasseID