IF DB_ID(N'K�rselsbog') IS NULL --Tjekker hvis databasen med det navn ikke findes.
	CREATE DATABASE [K�rselsbog];
GO
USE [K�rselsbog];
GO
IF OBJECT_ID(N'MedarbejderK�rsel', N'U') IS NULL --Tjekker hvis tabellen ikke findes.
BEGIN
	CREATE TABLE MedarbejderK�rsel( --Alt sammen ligesom i SQL opgaven. Create table laver tabellen og Insert s�tter r�kker ind.
		MbkID int IDENTITY(1,1) NOT NULL,
		FuldNavn varchar(60) NOT NULL,
		Nummerplade varchar(20) NOT NULL,
		Dato date NOT NULL,
		Kilometer smallint NOT NULL,
		PRIMARY KEY (MbkID)
	)
	INSERT MedarbejderK�rsel(FuldNavn, Nummerplade, Dato, Kilometer) VALUES ('Tom Khristensen', 'DB443290', '2019-03-28', 12),
						('Kim Jakobsen', 'HJ432199', '2019-03-25', 4),
						('Erik Svigermose', 'WE321569', '2019-03-19', 8);
END
