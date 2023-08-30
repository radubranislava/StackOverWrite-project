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
