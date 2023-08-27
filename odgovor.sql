create table korisnik
(
    id_korisnika int IDENTITY(1,1) not null primary key, 
    ime varchar(50) not null, 
    prezime varchar(50) not null,
    email varchar(50) not null, 
    lozinka varchar(50) not null
)
INSERT INTO korisnik (ime,prezime,email,lozinka)
VALUES ('Milica','Ilijev','milicailijev@gmail.com','!milica123!');

INSERT INTO korisnik (ime,prezime,email,lozinka)
VALUES ('Milan','Markovic','milianmarkovc@gmail.com','!milan!123');
