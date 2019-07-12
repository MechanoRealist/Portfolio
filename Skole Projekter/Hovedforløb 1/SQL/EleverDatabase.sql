use master;
if exists (select * from sys.databases where name = 'elever')
begin
	print 'Databesen er der i firvejen - vi dropper den'
	drop database elever
end
else
begin
	print 'Databasen er der ikke - gør ingenting'
end
go
--DDL
create database elever
print 'Databasen oprettes - Elever'
go
use elever
-- stadigvæk DDL

create table PostnrBy
(
	Postnr int primary key check(Postnr >= 1000 and Postnr <= 9999),
	[By] varchar(100) not null
)
go
insert into PostnrBy values (4000, 'Roskilde'),
							(2750, 'Ballerup'),
							(2800, 'Lyngby'),
							(2000, 'Frederiksberg')
select * from PostnrBy

create table elever
(
	Elevid smallint identity (10,1),
	Fornavn nvarchar(50) not null, --
	Efternavn nvarchar(100) not null,
	Adresse nvarchar(100) default 'Adresse beskyttet',
	Postnr int not null foreign key references PostnrBy(Postnr),
	KlasseNr int,
	constraint PK_elever_nossefår primary key (elevid)
)
go

--DML
insert into elever values ('Linse', 'Kessler', 'Islands brygge 12', 2750,1)

-- lav lige en selec af hele tabellen
--select * from elever

insert into elever (Fornavn, Efternavn, Adresse, Postnr) values
('Amalie', 'Zigerthy', 'Tabervej 32', 2800)

insert into elever (Fornavn, Efternavn, Postnr) values
('Amalia', 'Hansen' , 2000)


update elever set KlasseNr = 235 where Fornavn = 'Amalie'

insert into elever values ('Karl Mar', 'Møller', 'Jordbunken 12', 2000, null)

-- select på relationer
select * from elever,PostnrBy where elever.Postnr = PostnrBy.Postnr
select Fornavn,Efternavn,Adresse,elever.Postnr,PostnrBy.[By], KlasseNr from elever,PostnrBy where elever.Postnr = PostnrBy.Postnr