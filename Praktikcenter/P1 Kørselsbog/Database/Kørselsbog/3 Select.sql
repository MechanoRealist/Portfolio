USE [K�rselsbog];
GO
SELECT * FROM MedarbejderK�rsel; --Eksempler p� Select kommandoer der bruges i C# programmet
SELECT * FROM MedarbejderK�rsel WHERE FuldNavn LIKE '%Tom%';
SELECT * FROM MedarbejderK�rsel WHERE Dato BETWEEN '2019-03-01' AND '2019-03-26';
SELECT * FROM MedarbejderK�rsel WHERE Kilometer > 5;
SELECT * FROM MedarbejderK�rsel WHERE Nummerplade LIKE '%21%';