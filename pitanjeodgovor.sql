
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
