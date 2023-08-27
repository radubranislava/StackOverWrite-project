CREATE TABLE pitanjeodgovor(
  id_pitanja_odgovora int identity(1,1) NOT NULL primary key,
  id_odgovora int NOT NULL,
  id_pitanja int NOT NULL
)

alter table pitanjeodgovor
add constraint fkpitanjeodgovorodgovor foreign key (id_pitanja)
REFERENCES pitanje(id_pitanja)


alter table pitanjeodgovor
add constraint fkpitanjeodgovorpitanje foreign key (id_odgovora)
REFERENCES odgovor(id_odgovora)

INSERT INTO pitanjeodgovor(id_odgovora,id_pitanja)
VALUES (1,1)

INSERT INTO pitanjeodgovor(id_odgovora,id_pitanja)
VALUES (2,2)

