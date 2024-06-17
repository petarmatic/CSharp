DROP DATABASE IF EXISTS ednevnik;

CREATE DATABASE ednevnik WITH ENCODING 'UTF8' LC_COLLATE='hr_HR.UTF-8' LC_CTYPE='hr_HR.UTF-8' TEMPLATE=template0;


CREATE TABLE ucenici (
    id SERIAL PRIMARY KEY,
    ime VARCHAR(255) NOT NULL,
    prezime VARCHAR(255) NOT NULL,
    oib CHAR(11) NOT NULL,
    skolska_godina VARCHAR(255) NOT NULL
);

CREATE TABLE predmeti (
    id SERIAL PRIMARY KEY,
    naziv VARCHAR(255) NOT NULL
);

CREATE TABLE obavijest (
    id SERIAL PRIMARY KEY,
    tekst TEXT,
    datum DATE,
    predmet_id INT,
    FOREIGN KEY (predmet_id) REFERENCES predmeti(id)
);

CREATE TABLE ucenik_predmeti (
    ucenik_id INT,
    predmeti_id INT,
    PRIMARY KEY (ucenik_id, predmeti_id),
    FOREIGN KEY (ucenik_id) REFERENCES ucenici(id),
    FOREIGN KEY (predmeti_id) REFERENCES predmeti(id)
);

-- Create  'ocjene'
CREATE TABLE ocjene (
    id SERIAL PRIMARY KEY,
    ucenik_id INT,
    predmet_id INT,
    ocjena VARCHAR(255),
    datum TIMESTAMP,
    FOREIGN KEY (ucenik_id) REFERENCES ucenici(id),
    FOREIGN KEY (predmet_id) REFERENCES predmeti(id)
);

INSERT INTO ucenici (ime, prezime, oib, skolska_godina) VALUES 
('Pero', 'Perić', '19425162402', '2015/2016'),
('Marko', 'Markić', '45988971374', '2014/2015'),
('Ivo', 'Ivić', '17946660163', '2016/2017');

INSERT INTO predmeti (naziv) VALUES 
('Matematika'),
('Biologija'),
('Kemija');

INSERT INTO obavijest (tekst, datum, predmet_id) VALUES 
('Nema ga na nastavi', '2024-12-06', 1),
('Pobjegao', '2024-09-08', 2),
('Pravi nered', '2024-08-07', 3);

INSERT INTO ucenik_predmeti (ucenik_id, predmeti_id) VALUES 
(1, 2),
(2, 1),
(3, 3);

INSERT INTO ocjene (ucenik_id, predmet_id, ocjena, datum) VALUES 
(1, 2, '5', '2024-01-11 14:01'),
(2, 1, '3', '2024-02-09 08:58'),
(1, 2, '5', '2024-03-11 12:00');

SELECT * FROM ucenici;
SELECT * FROM predmeti;
SELECT * FROM obavijest;
SELECT * FROM ucenik_predmeti;
SELECT * FROM ocjene;
