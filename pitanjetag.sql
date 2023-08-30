
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
