create table operateri(
id int not null primary key identity(1,1),
email varchar(50) not null,
lozinka varchar(200) not null
);

-- Lozinka edunova generirana pomo?u https://bcrypt-generator.com/
insert into operateri values ('mail@mail.hr',
'$2a$12$KsCSQD2iTy6HDJ.zB64Dju2IbQ4DMwq4AfsHcadctOM06y5WTVvnK
');
