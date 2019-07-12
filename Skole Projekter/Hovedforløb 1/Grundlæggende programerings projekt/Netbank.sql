use master
if exists (select * from sys.databases where name = 'Netbank')
begin
print 'Databasen er der i forvejen - vi dropper den'
drop database Netbank 
end
else
begin 
  print 'Database er der ikke - gør ingenting'
end
go
--DDL---
create database Netbank
print 'Databasen oprettes - Netbank'
go
use Netbank

create table Kunder
(
Kundenummer int primary key identity(1,1),
Oprettelsesdato Date not null,
Fornavn nvarchar (60) not null,
Efternavn nvarchar (60) not null,
Organisation nvarchar (60) --Må godt være null
)
go

CREATE TABLE Kontotyper
(
Kontotype nvarchar (60) PRIMARY KEY,
Rentesats decimal(9,8) not null
)

create table Konti
(
Kontonummer int primary key identity(1,1),
Saldo int not null,
Kontotype nvarchar (60) FOREIGN KEY REFERENCES Kontotyper(Kontotype) not null,
Oprettelsesdato Date not null,
Kundenummer int foreign key references Kunder(Kundenummer) not null
)
go

create table Transaktioner
(
Transaktionsnummer int primary key identity(1,1),
Saldo int not null,
Beløb int not null,
Dato Date not null,
Kontonummer int foreign key references Konti(Kontonummer) not null
)
go
INSERT INTO Kontotyper VALUES ('Firma', 0.064),
	('Familie', 0.058),
	('Enkeltperson', 0.054),
	('Ung', 0.031),
	('NGO', 0.061)

INSERT INTO Kunder VALUES ('2019-03-21', 'Frederik', 'Nessling', null),
	('2019-03-23', 'Josefine', 'Smidt', null),
	('2019-03-25', 'Kenneth', 'Durin', null),
	('2019-04-01', 'Peter', 'Pan', 'First Order to the left'),
	('2019-04-12', 'Casper', 'Ghost', 'Iorden')

INSERT INTO Konti VALUES (5000, 'Enkeltperson', '2019-03-21', 1),
	(6000, 'Enkeltperson', '2019-03-23', 2),
	(11234, 'Familie', '2019-03-25', 3),
	(20000, 'NGO', '2019-04-01', 4),
	(25000, 'Firma', '2019-04-12', 5),
	(13000, 'Familie', '2019-04-22', 2)
	
INSERT INTO Transaktioner VALUES (5000, 5000, '2019-03-21', 1),
	(13000, 13000, '2019-03-23', 2),
	(11234, 11234, '2019-03-25', 3),
	(20000, 20000, '2019-04-01', 4),
	(25000, 25000, '2019-04-12', 5)
GO

UPDATE Konti SET Saldo = 6500 WHERE Kontonummer = 1;
INSERT INTO Transaktioner VALUES (6500, 1500, '2019-04-15', 1)
UPDATE Konti SET Saldo = 21000 WHERE Kontonummer = 5;
INSERT INTO Transaktioner VALUES (21000, -4000, '2019-04-15', 5)
GO
select * from Kunder
select * from Konti
select * from Transaktioner
