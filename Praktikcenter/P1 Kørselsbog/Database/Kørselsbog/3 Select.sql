USE [Kørselsbog];
GO
SELECT * FROM MedarbejderKørsel; --Eksempler på Select kommandoer der bruges i C# programmet
SELECT * FROM MedarbejderKørsel WHERE FuldNavn LIKE '%Tom%';
SELECT * FROM MedarbejderKørsel WHERE Dato BETWEEN '2019-03-01' AND '2019-03-26';
SELECT * FROM MedarbejderKørsel WHERE Kilometer > 5;
SELECT * FROM MedarbejderKørsel WHERE Nummerplade LIKE '%21%';