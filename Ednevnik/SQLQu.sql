CREATE TABLE operateri (
     INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    email VARCHAR(50) NOT NULL,
    lozinka VARCHAR(200) NOT NULL
);

-- Umetanje zapisa s bcrypt hashom lozinke
INSERT INTO Operateri (email, lozinka) 
VALUES ('mail@mail.hr', '$2a$12$KsCSQD2iTy6HDJ.zB64Dju2IbQ4DMwq4AfsHcadctOM06y5WTVvnK
');