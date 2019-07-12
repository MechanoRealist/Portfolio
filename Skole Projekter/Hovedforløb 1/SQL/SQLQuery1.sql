use master
create database Personer
use Personer

create table Nisser
(
	NisseID int identity(100,5),
	Navn varchar(50) not null check(Navn <> 'Linse'),
	alder int not null
);
drop table nisser;

select * from Nisser;

insert into Nisser (Navn, alder) values ('Bob', 102),
							('Magnus', 304),
							('Jørgen', 241),
							('Bob', 102),
							('Bob', 102),
							('Bob', 102);

insert into Nisser (alder,navn) values (50,'Linse');

delete from Nisser where Navn = 'Bob';

update Nisser set Navn = 'Didrik' where NisseID = 120;