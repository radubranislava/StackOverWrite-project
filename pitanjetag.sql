CREATE TABLE pitanjetag (
  id_pitanja_taga int identity(1,1) NOT NULL primary key,
  id_pitanja int  NOT NULL,
  id_taga int  NOT NULL
) 


alter table pitanjetag
add constraint fkpitanjetagtag foreign key (id_taga)
REFERENCES tag(id_taga)

alter table pitanjetag
add constraint fkpitanjetagpitanje foreign key (id_pitanja)
REFERENCES pitanje(id_pitanja)
INSERT INTO pitanjetag (id_pitanja,id_taga)
VALUES (1,1);
INSERT INTO pitanjetag (id_pitanja,id_taga)
VALUES (2,2);

