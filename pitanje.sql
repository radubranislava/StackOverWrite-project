CREATE TABLE pitanje (
  id_pitanja int identity(1,1) NOT NULL primary key,
  naslov text NOT NULL,
  sadrzaj text NOT NULL,
  datum_postavljanja datetime NOT NULL,
 id_korisnika int NOT NULL
) 

alter table pitanje
add constraint fkpitanjekorisnik foreign key (id_korisnika)
REFERENCES korisnik (id_korisnika)
on delete no action
on update cascade;

INSERT INTO pitanje (naslov,sadrzaj,datum_postavljanja,id_korisnika)
VALUES ('Upotreba rekurzije u programiranju','Kako se rekurzivne funkcije koriste za resavanje problema i pruziti primer jednog problema koji se elegantno resava kroz rekurziju?','2023-08-27 14:30:00',2);

INSERT INTO pitanje (naslov,sadrzaj,datum_postavljanja,id_korisnika)
VALUES ('Staticka i dinamicka tipizacija','Kako se razlikuju staticka i dinamicka tipizacija u programiranju? Koje su glavne prednosti i mane svakog pristupa? Dajte primer kako bi se lakse razumela njihova razlika i uticaj na pisanje koda.','2023-08-29 19:30:00',1);

