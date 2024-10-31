create table operateri(
id int not null primary key identity(1,1),
email varchar(50) not null,
lozinka varchar(200) not null
);

-- Lozinka edunova generirana pomoću https://bcrypt-generator.com/
insert into operateri values ('mail@mail.hr',
'$2a$12$OieSFjAvIfRg6hd6Krqrme3LfqHJdTJQxbHO9CbRW/YLcusoGb75W');
