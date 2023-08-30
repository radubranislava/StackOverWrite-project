CREATE TABLE odgovor (
  id_odgovora int IDENTITY (1,1) NOT NULL PRIMARY KEY,
  tekst_odgovora text NOT NULL,
  datum_postavljanja datetime NOT NULL,
);

INSERT INTO odgovor (tekst_odgovora,datum_postavljanja)
VALUES ('Rekurzija je koncept u programiranju gde funkcija poziva samu sebe. Primer problema resenog rekurzijom je izracunavanje faktorijela.','2023-08-28 17:30:00');

INSERT INTO odgovor (tekst_odgovora,datum_postavljanja)
VALUES ('Staticka tipizacija zahteva unapred definisane tipove i proverava ih pre izvrsavanja. Dinamicka tipizacija dozvoljava promenu tipova tokom izvrsavanja. Staticka tipizacija pruza vecu sigurnost, dok dinamicka tipizacija donosi vecu fleksibilnost.','2023-08-31 9:30:00');

