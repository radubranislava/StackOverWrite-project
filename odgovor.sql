CREATE TABLE odgovor (
  id_odgovora int IDENTITY(1,1)  NOT NULL primary key,
  tekst_odgovora text NOT NULL,
  datum_postavljanja datetime NOT NULL,
  id_korisnika int NOT NULL
) 

alter table odgovor
add constraint fkodgovorkorisnikk foreign key (id_korisnika)
REFERENCES korisnik (id_korisnika)
on delete no action
on update cascade;

INSERT INTO odgovor (tekst_odgovora,datum_postavljanja,id_korisnika)
VALUES ('Rekurzija je koncept u programiranju gde funkcija poziva samu sebe. Primer problema resenog rekurzijom je izracunavanje faktorijela.','2023-08-28 17:30:00',1);

INSERT INTO odgovor (tekst_odgovora,datum_postavljanja,id_korisnika)
VALUES ('Staticka tipizacija zahteva unapred definisane tipove i proverava ih pre izvrsavanja. Dinamicka tipizacija dozvoljava promenu tipova tokom izvrsavanja. Staticka tipizacija pruza vecu sigurnost, dok dinamicka tipizacija donosi vecu fleksibilnost.','2023-08-31 9:30:00',2);





--

CREATE TABLE `odgovor` (
  `id_odgovora` int(11) NOT NULL,
  `tekst_odgovora` text NOT NULL,
  `datum_postavljanja` datetime NOT NULL,
  `id_korisnika` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `odgovor`
--

INSERT INTO `odgovor` (`id_odgovora`, `tekst_odgovora`, `datum_postavljanja`, `id_korisnika`) VALUES
(1, 'Da biste efikasno azurirali vise redova istovremeno u SQL-u, mozete koristiti UPDATE upit sa klauzulom WHERE koja definise uslov za azuriranje. Ovaj pristup vam omogucava da azurirate samo one redove koji zadovoljavaju odredjeni uslov, umesto da azurirate sve redove u tabeli.\r\n\r\nEvo kako bi izgledao osnovni oblik UPDATE upita za azuriranje vise redova:\r\n\r\nUPDATE ime_tabele\r\nSET kolona1 = nova_vrednost1, kolona2 = nova_vrednost2\r\nWHERE uslov;\r\n\r\nNa primer, ako zelite da azurirate sve redove u tabeli \"korisnici\" koji imaju status \"neaktivan\" na status \"aktivan\", upit bi izgledao ovako:\r\n\r\nUPDATE korisnici\r\nSET status = \'aktivan\'\r\nWHERE status = \'neaktivan\';\r\n\r\nOvaj upit bi azurirao sve redove u tabeli \"korisnici\" gde je trenutni status \"neaktivan\", postavljajuci status na \"aktivan\".\r\n\r\nAko zelite da azurirate vise kolona istovremeno, samo dodajte odgovarajuce kolone i nove vrednosti u SET klauzulu.\r\n\r\nPre nego sto izvrsite masovno azuriranje, preporucuje se da testirate upit na manjem uzorku podataka kako biste bili sigurni da radi kako treba. Takodje, uvek imajte na umu da azuriranje moze imati trajne posledice, pa budite pazljivi prilikom koriscenja ovih upita.', '2023-08-01 16:28:36', 3),
(2, 'U Javi mozete koristiti metode isEmpty() i isBlank() za proveru praznina String promenljive.\r\n\r\n    isEmpty(): Ova metoda vraca true ako je String prazan (nema nijedan karakter) i false inace.\r\n\r\n    isBlank(): Ova metoda je dostupna u verzijama Java 11 i kasnijim. Ona vraca true ako je String prazan ili sadrzi samo bele karaktere (kao sto su razmaci) i false inace.\r\n\r\nEvo primera upotrebe ovih metoda:\r\n\r\npublic class ProveraPraznoce {\r\n    public static void main(String[] args) {\r\n        String prazanString = \"\";\r\n        String samoRazmaci = \"   \";\r\n        String nePrazanString = \"Neki tekst\";\r\n\r\n        System.out.println(\"Da li je prazanString prazan? \" + prazanString.isEmpty());\r\n        System.out.println(\"Da li je samoRazmaci prazan? \" + samoRazmaci.isEmpty());\r\n        System.out.println(\"Da li je nePrazanString prazan? \" + nePrazanString.isEmpty());\r\n\r\n        System.out.println(\"Da li je prazanString prazan ili sadrzi samo razmake? \" + prazanString.isBlank());\r\n        System.out.println(\"Da li je samoRazmaci prazan ili sadrzi samo razmake? \" + samoRazmaci.isBlank());\r\n        System.out.println(\"Da li je nePrazanString prazan ili sadrzi samo razmake? \" + nePrazanString.isBlank());\r\n    }\r\n}\r\nOvaj primer ilustruje upotrebu oba metoda za proveru praznina i belina u String promenljivama.', '2023-08-04 18:29:59', 4);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `odgovor`
--
ALTER TABLE `odgovor`
  ADD PRIMARY KEY (`id_odgovora`),
  ADD KEY `FK_korisnik_odgovor` (`id_korisnika`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `odgovor`
--
ALTER TABLE `odgovor`
  MODIFY `id_odgovora` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `odgovor`
--
ALTER TABLE `odgovor`
  ADD CONSTRAINT `odgovor_ibfk_1` FOREIGN KEY (`id_korisnika`) REFERENCES `korisnik` (`id_korisnika`) ON DELETE NO ACTION ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
