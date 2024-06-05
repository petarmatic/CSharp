use master;
go
drop database if exists ednevnik;
go
create database ednevnik;
go
use ednevnik;


create table ucenici(
	id int not null primary key identity(1,1),
	ime varchar(255),
	prezime varchar(255),
	oib char(11),
	skolska_godina varchar(255)
);

create table obavijest(
	id int not null primary key identity(1,1),
	tekst text,
	datum date,
	predmet_id int
);

create table predmeti(
	id int not null primary key identity(1,1),
	naziv varchar(255)
);

create table ucenik_predmeti(
	ucenik_id int,
	predmeti_id int
);

create table ocjene(
	id int not null primary key identity(1,1),
	ucenik_id int,
	predmet_id int,
	ocjena varchar(255),
	datum date
);

alter table obavijest add foreign key(predmet_id) references predmeti(id);
alter table ucenik_predmeti add foreign key( ucenik_id) references ucenici(id);
alter table ucenik_predmeti add foreign key(predmeti_id) references predmeti(id);
alter table ocjene add foreign key(ucenik_id) references ucenici(id);
alter table ocjene add foreign key(predmet_id) references predmeti(id);