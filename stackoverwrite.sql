CREATE DATABASE stackoverwrite

CREATE TABLE korisnik (
id_korisnika int IDENTITY (1,1) NOT NULL PRIMARY KEY,
email varchar(30) NOT NULL,
username varchar(30) NOT NULL,  
lozinka varchar(30) NOT NULL
);


INSERT INTO korisnik (email,username,lozinka)
VALUES ('milicailijev@gmail.com','Milica Ilijev','!milica123!');

INSERT INTO korisnik (email,username,lozinka)
VALUES ('milianmarkovic@gmail.com','Milan Markovic ','!milan!123');

CREATE TABLE odgovor (
  id_odgovora int IDENTITY (1,1) NOT NULL PRIMARY KEY,
  tekst_odgovora text NOT NULL,
  datum_postavljanja datetime NOT NULL,
);

INSERT INTO odgovor (tekst_odgovora,datum_postavljanja)
VALUES ('Rekurzija je koncept u programiranju gde funkcija poziva samu sebe. Primer problema resenog rekurzijom je izracunavanje faktorijela.','2023-08-28 17:30:00');

INSERT INTO odgovor (tekst_odgovora,datum_postavljanja)
VALUES ('Staticka tipizacija zahteva unapred definisane tipove i proverava ih pre izvrsavanja. Dinamicka tipizacija dozvoljava promenu tipova tokom izvrsavanja. Staticka tipizacija pruza vecu sigurnost, dok dinamicka tipizacija donosi vecu fleksibilnost.','2023-08-31 9:30:00');


CREATE TABLE pitanje (
  id_pitanja int IDENTITY (1,1) NOT NULL PRIMARY KEY,
  naslov text NOT NULL,
  sadrzaj text NOT NULL,
  datum_postavljanja datetime NOT NULL,
);

INSERT INTO pitanje (naslov,sadrzaj,datum_postavljanja)
VALUES ('Upotreba rekurzije u programiranju','Kako se rekurzivne funkcije koriste za resavanje problema i pruziti primer jednog problema koji se elegantno resava kroz rekurziju?','2023-08-27 14:30:00');

INSERT INTO pitanje (naslov,sadrzaj,datum_postavljanja)
VALUES ('Staticka i dinamicka tipizacija','Kako se razlikuju staticka i dinamicka tipizacija u programiranju? Koje su glavne prednosti i mane svakog pristupa? Dajte primer kako bi se lakse razumela njihova razlika i uticaj na pisanje koda.','2023-08-29 19:30:00');



CREATE TABLE pitanjeodgovor (
  id_pitanja_odgovora int IDENTITY (1,1) NOT NULL PRIMARY KEY,
  id_odgovora int NOT NULL,
  id_pitanja int NOT NULL
);

ALTER TABLE pitanjeodgovor
ADD CONSTRAINT fkpitanjeodgovorodgovor FOREIGN KEY (id_pitanja)
REFERENCES pitanje(id_pitanja)
ON DELETE NO ACTION
ON UPDATE CASCADE;

ALTER TABLE pitanjeodgovor
ADD CONSTRAINT fkpitanjeodgovorpitanje FOREIGN KEY (id_odgovora)
REFERENCES odgovor(id_odgovora)
ON DELETE NO ACTION
ON UPDATE CASCADE;

INSERT INTO pitanjeodgovor(id_odgovora,id_pitanja)
VALUES (1,1)

INSERT INTO pitanjeodgovor(id_odgovora,id_pitanja)
VALUES (2,2)


CREATE TABLE pitanjetag (
  id_pitanja_taga int IDENTITY (1,1) NOT NULL PRIMARY KEY,
  id_pitanja int NOT NULL,
  id_taga int NOT NULL
);


ALTER TABLE pitanjetag
ADD CONSTRAINT fkpitanjetagtag FOREIGN KEY (id_taga)
REFERENCES tag(id_taga)
ON DELETE NO ACTION
ON UPDATE CASCADE;

ALTER TABLE  pitanjetag
ADD CONSTRAINT fkpitanjetagpitanje FOREIGN KEY (id_pitanja)
REFERENCES pitanje(id_pitanja)
ON DELETE NO ACTION
ON UPDATE CASCADE;



INSERT INTO pitanjetag (id_pitanja,id_taga)
VALUES (1,1);
INSERT INTO pitanjetag (id_pitanja,id_taga)
VALUES (2,2);

CREATE TABLE tag (
  id_taga int IDENTITY (1,1) NOT NULL PRIMARY KEY,
  naziv_taga varchar(50) NOT NULL
);


INSERT INTO tag (naziv_taga)
VALUES ('rekurzija');

INSERT INTO tag (naziv_taga)
VALUES ('for petlja');

INSERT INTO tag (naziv_taga)
VALUES ('petlja');

INSERT INTO tag (naziv_taga)
VALUES ('ispis brojeva');

INSERT INTO tag (naziv_taga)
VALUES ('tipizacija');







