
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
