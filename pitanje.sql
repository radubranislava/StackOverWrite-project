CREATE TABLE pitanje (
  id_pitanja int IDENTITY (1,1) NOT NULL PRIMARY KEY,
  naslov text NOT NULL,
  sadrzaj text NOT NULL,
  datum_postavljanja datetime NOT NULL,
  id_korisnika int NOT NULL
);
ALTER TABLE pitanje
ADD CONSTRAINT fkpitanjekorisnik FOREIGN KEY (id_korisnika)
REFERENCES korisnik(id_korisnika)
ON DELETE NO ACTION
ON UPDATE CASCADE;

INSERT INTO pitanje (naslov,sadrzaj,datum_postavljanja,id_korisnika)
VALUES ('Upotreba rekurzije u programiranju','Kako se rekurzivne funkcije koriste za resavanje problema i pruziti primer jednog problema koji se elegantno resava kroz rekurziju?','2023-08-27 14:30:00',2);

INSERT INTO pitanje (naslov,sadrzaj,datum_postavljanja,id_korisnika)
VALUES ('Staticka i dinamicka tipizacija','Kako se razlikuju staticka i dinamicka tipizacija u programiranju? Koje su glavne prednosti i mane svakog pristupa? Dajte primer kako bi se lakse razumela njihova razlika i uticaj na pisanje koda.','2023-08-29 19:30:00',1);

