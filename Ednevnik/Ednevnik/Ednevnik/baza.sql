


create table ucenici(
	id int not null primary key identity(1,1),
	ime varchar(255) not null,
	prezime varchar(255) not null,
	oib char(11) not null,
	skolska_godina varchar(255) not null
);

create table obavijesti(
	id int not null primary key identity(1,1),
	tekst text,
	datum date,
	predmet_id int
);

create table predmeti(
	id int not null primary key identity(1,1),
	naziv varchar(255) not null
);

create table ucenik_predmeti(
	ucenik_id int,
	predmeti_id int
);

create table ocjene(
	id int not null primary key identity(1,1),
	ucenik_id int,
	predmet_id int,
	VrijednostOcjena varchar(255),
	datum datetime
);

alter table obavijesti add foreign key(predmet_id) references predmeti(id);
alter table ucenik_predmeti add foreign key( ucenik_id) references ucenici(id);
alter table ucenik_predmeti add foreign key(predmeti_id) references predmeti(id);
alter table ocjene add foreign key(ucenik_id) references ucenici(id);
alter table ocjene add foreign key(predmet_id) references predmeti(id);

insert into ucenici(ime,prezime,oib,skolska_godina) values('Pero','Perić','19425162402','2015/2016');
insert into ucenici(ime,prezime,oib,skolska_godina) values('Marko','Markić','45988971374','2014/2015');
insert into ucenici(ime,prezime,oib,skolska_godina) values('Ivo','Ivić','17946660163','2016/2017');

insert into predmeti(naziv) values('Matematika');
insert into predmeti(naziv) values('Biologija');
insert into predmeti(naziv) values('Kemija');

insert into obavijesti(tekst,datum,predmet_id) values ('Nema ga na nastavi', '2024-12-6 14:53',1);
insert into obavijesti(tekst,datum,predmet_id) values ('Pobjegao', '2024-9-8 17:52',2);
insert into obavijesti(tekst,datum,predmet_id) values ('Pravi nered', '2024-8-7 09:04',3);

insert into ucenik_predmeti(ucenik_id,predmeti_id) values(1,2);
insert into ucenik_predmeti(ucenik_id,predmeti_id) values(2,1);
insert into ucenik_predmeti(ucenik_id,predmeti_id) values(3,3);

insert into ocjene(ucenik_id,predmet_id,VrijednostOcjena,datum) values(1,2,'5','2024-01-11 14:01');
insert into ocjene(ucenik_id,predmet_id,VrijednostOcjena,datum) values(2,1,'3','2024-02-09 08:58');
insert into ocjene(ucenik_id,predmet_id,VrijednostOcjena,datum) values(1,2,'5','2024-03-11 12:00');


select *from ucenici;
select*from predmeti;
select*from obavijesti;
select*from ucenik_predmeti;
select*from ocjene;