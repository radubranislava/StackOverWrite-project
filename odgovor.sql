CREATE TABLE odgovor (
  id_odgovora int IDENTITY (1,1) NOT NULL PRIMARY KEY,
  tekst_odgovora text NOT NULL,
  datum_postavljanja datetime NOT NULL,
  id_korisnika int NOT NULL
  
);

ALTER TABLE odgovor
ADD CONSTRAINT fkodgovorkorisnik FOREIGN KEY (id_korisnika)
REFERENCES korisnik(id_korisnika)
ON DELETE NO ACTION
ON UPDATE CASCADE;


INSERT INTO odgovor (tekst_odgovora,datum_postavljanja,id_korisnika)
VALUES ('Rekurzija je koncept u programiranju gde funkcija poziva samu sebe. Primer problema resenog rekurzijom je izracunavanje faktorijela.','2023-08-28 17:30:00',1);

INSERT INTO odgovor (tekst_odgovora,datum_postavljanja,id_korisnika)
VALUES ('Staticka tipizacija zahteva unapred definisane tipove i proverava ih pre izvrsavanja. Dinamicka tipizacija dozvoljava promenu tipova tokom izvrsavanja. Staticka tipizacija pruza vecu sigurnost, dok dinamicka tipizacija donosi vecu fleksibilnost.','2023-08-31 9:30:00',2);

