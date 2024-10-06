create table smjerovi(
sifra int not null primary key identity(1,1),
naziv varchar(50) not null,
cijena decimal(18,2) null, -- ali se null ne piše, podrazumjeva se
brojsati int,
izvodiseod datetime,
vaucer bit
);

create table grupe(
sifra int not null primary key identity(1,1),
naziv varchar(20) not null,
brojslobodnihmjesta int not null,
datumpocetka datetime,
smjer int not null,
predavac varchar(50)
);

create table polaznici(
sifra int not null primary key identity(1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
email varchar(100),
oib char(11)
);

create table clanovi(
grupa int not null,
polaznik int not null
);


alter table grupe add foreign key (smjer) references smjerovi(sifra);
alter table clanovi add foreign key (grupa) references grupe(sifra);
alter table clanovi add foreign key(polaznik) references polaznici(sifra);


--select * from smjerovi;

-- ŠKOLSKA SINTAKSA
-- 1 -> ovo je šifra koju generira baza
insert into smjerovi (naziv,cijena,brojsati,izvodiseod,vaucer)
values ('Web programiranje',1599.99,225,'2024-02-07 18:00',1);


-- LOŠA SINTAKSA
-- 2
insert into smjerovi values ('Web dizajn',1200,150,null,null);

-- MVP 
-- 3
insert into smjerovi (naziv) values ('ČŠĆĐŽ čšćđž');

--select * from grupe;
-- 1
insert into grupe(naziv,brojslobodnihmjesta,smjer)
values ('WP5',26,1);
-- 2
insert into grupe(naziv,brojslobodnihmjesta,smjer)
values ('WD1',16,2);


--select * from polaznici;
-- 1 - 30
insert into polaznici (prezime, ime,email) values
('Trdin','Marina','mana2411@gmail.com'),
('Trdin','Hrvoje','hthrvojetrdin@gmail.com'),
('Bičanić','Hrvoje','chola.bog@gmail.com'),
('Sladić','Nikola','mandicnikola29@gmail.com'),
('Cuca','Luka','lukacuca@gmail.com'),
('Pavlinušić','Ante','ante.pavlinusic@gmail.com'),
('Kuna','Renato','renatokuna01@gmail.com'),
('Banjac','Senka','sbanjac88@gmail.com'),
('Lamza','Marin Matthew','lamzamarin59@gmail.com'),
('Matković','Luka','lmatkovic00@gmail.com'),
('Kamenski','David','daviddavidenko275@gmail.com'),
('Matić','Petar','petarmatic00@gmail.com'),
('Antić','Srđan','antic.family@gmail.com'),
('Živković','Goran','goran.zivkovic1993@gmail.com'),
('Merunka','Marijana','merm2431@gmail.com'),
('Puljić Ilić','Dominik','1992pulja@gmail.com'),
('Prpić','Renato','renato.prpic.efos@gmail.com'),
('Gojtan','Oleg','oleg.gojtan@gmail.com'),
('Virovac','Marko','virovac81@gmail.com'),
('Lazarević','Ivana','ivanaslazarevic@gmail.com'),
('Kotal','Domagoj','kotal.domagoj1995@gmail.com'),
('Janković','Filip','filip.vno.jankovic@gmail.com'),
('Puljić Ilić','Hrvoje','hpuljic85@gmail.com'),
('Šužberić','Jakov','jakov.suzberic@gmail.com'),
('Kukučka','Ivan','ivan.kukucka194@gmail.com'),
('Maras','Valentino','valentinomaras@yahoo.com'),
('Rogić','Tomislav','tomislav.rogic@gmail.com'),
('Jeličić','Petar','petarjelicic95@gmail.com'),
('Varga','Danijela','danijelavarga.mail@gmail.com'),
('Boduljak','Sanja','matkosanja@gmail.com');


--select * from clanovi;

insert into clanovi (grupa,polaznik) values
(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),
(1,11),(1,12),(1,13),(1,14),(1,15),(1,16),(1,17),(1,18),(1,19),(1,20),
(1,21),(1,22),(1,23),(1,24),(1,25),(1,26),(1,27),(1,28),(1,29),(1,30);

insert into clanovi (grupa,polaznik) values
(2,4),(2,8),(2,12),(2,24),(2,29);