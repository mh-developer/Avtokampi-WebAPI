DROP TABLE IF EXISTS users;
CREATE TABLE IF NOT EXISTS users (
  "uid" SERIAL PRIMARY KEY NOT NULL,
  "username" varchar(25) NOT NULL,
  "password" varchar(200) NOT NULL,
  "email" varchar(100) NOT NULL,
  "name" varchar(100) NOT NULL
);

INSERT INTO users("uid", "username", "password", "email", "name") VALUES (1, 'username1', '0b14d501a594442a01c6859541bcb3e8164d183d32937b851835442f69d5c94e', 'my@email.com', 'User');
INSERT INTO users("uid", "username", "password", "email", "name") VALUES (2, 'username2', '6cf615d5bcaac778352a8f1f3360d23f02f34ec182e259897fd6ce485d7870d4', 'my@email2.com', 'User2');


DROP TABLE IF EXISTS kampi;
CREATE TABLE IF NOT EXISTS kampi (
  "id" SERIAL PRIMARY KEY NOT NULL,
  "naziv" varchar(25) NOT NULL,
  "opis" TEXT NOT NULL,
  "cena" int NOT NULL,
  "kraj" varchar(100) NOT NULL,
  "slika" bytea NOT NULL,
  "user_id" int NOT NULL
);

ALTER TABLE kampi
    ADD CONSTRAINT "fk_user_id_kampi"
    FOREIGN KEY ("user_id")
    REFERENCES "users"("uid");

DROP TABLE IF EXISTS rezervacije;
CREATE TABLE IF NOT EXISTS rezervacije (
  "id" SERIAL PRIMARY KEY NOT NULL,
  "user_id" int NOT NULL,
  "kamp_id" int NOT NULL,
  "od" varchar(100) NOT NULL,
  "do" varchar(100) NOT NULL,
  "cena" int NOT NULL
);

ALTER TABLE rezervacije
    ADD CONSTRAINT "fk_user_id_rezervacije"
    FOREIGN KEY ("user_id")
    REFERENCES "users"("uid");

ALTER TABLE rezervacije
    ADD CONSTRAINT "fk_kamp_id_rezervacije"
    FOREIGN KEY ("kamp_id")
    REFERENCES "kampi"("id");

DROP TABLE IF EXISTS mnenja;
CREATE TABLE IF NOT EXISTS mnenja (
  "id" SERIAL PRIMARY KEY NOT NULL,
  "user_id" int NOT NULL,
  "kamp_id" int NOT NULL,
  "mnenje" VARCHAR(255) NOT NULL
);

ALTER TABLE mnenja
    ADD CONSTRAINT "fk_user_id_mnenja"
    FOREIGN KEY ("user_id")
    REFERENCES "users"("uid");

ALTER TABLE mnenja
    ADD CONSTRAINT "fk_kamp_id_mnenja"
    FOREIGN KEY ("kamp_id")
    REFERENCES "kampi"("id");

INSERT INTO kampi("id", "naziv", "opis", "cena", "kraj", "slika", "user_id") VALUES 
(1, 'KAMP NJIVICE',
'Kamp Njivice je uvrščen med NaJboljše hrvaške kampe 
      se nahaja ob morju
      obdan je s hrastovim gozdom, zaradi česar je v njem idealna senca
      na novo urejene parcele tudi do 120m2
      elektrika in voda na vsaki parceli
      edinstvene mobilne hišice ob samem morju
      Cabana bar&more prelep lounge bar na plaži',
50,
'otok Krk', 
'../img/njivice.jpg', 1), 
(2, 'KAMP STRAŠKO',
  'Doživite neverjetne sončne zahode, uživajte v kino večerih, 
      preizkusite okusne dalmatinske kulinarične specialitete 
      ali enostavno uživajte v neokrnjeni naravi otoka Paga!
      Kamp se nahaja ob morju v čudovitem zalivu, razprostira 
      se na 57 ha gozda dalmatinskega hrasta in olive ter je s tem eden 
      izmed največjih in vodilnih kampov na Jadranu ter na Hrvaškem.',
  80,
  'otok Pag',
  '../img/strasko.jpg', 1),
(3, 'KAMP STELLA',
  'Če bi radi bili v središču dogajanja, ki obsega vse od teniškega turnirja 
        ATP do nešteto priložnosti za zabavo in dejavnosti, je Stella Maris najboljši kamp za vas. 
        Tukaj bodo tudi otroci lahko vsak dan počeli nekaj drugega. Kamp je bil preurejen leta 2018 
        in ima nov večji bazen, restavracijo in območje recepcije, otroška igrišča, urejene parcele 
        in mobilne hišice: vse samo nekaj korakov od plaže',
  40,
  'Umag',
  '../img/umag.jpg', 1),
(4, 'KAMP TIHA',
  'Kamp Tiha Šilo se nahaja na vzhodni strani otoka Krk, na samotnem polotoku v kraju Šilo do katerega
  lahko pridete po cesti preko kraja Malinska ali pa po novi lokalni cesti Omišalj - Čižići - Klimno - Šilo.
  V kampu Tiha lahko kampirate na urejenih parcelah, omogočajo pa tudi najem mobilnih hišic.',
  80,
  'Šilo, Krk',
  '../img/1.jpg', 1),
(5, 'KAMP ZATON',
  'Kamp Zaton je eden najboljših hrvaških kampov in se nahaja 16 km severno od Zadra oz. 1,5 km zahodno on kraja Nin. 
  Gre za moderno urejen kamp z 1,5 km dolgo mivkasto in peščeno plažo. V kampu Zaton omogočajo kampiranje na urejenih parcelah, 
  najem mobilnih hišic in glamping šotorov. V sklopu naselja omogočajo tudi najem številnih apartmajev.',
  90,
  'Zadar',
  '../img/2.jpg', 1),
(6, 'KAMP JURE',
'Kamp Tiha Šilo se nahaja na vzhodni strani otoka Krk, na samotnem polotoku v kraju Šilo do katerega
lahko pridete po cesti preko kraja Malinska ali pa po novi lokalni cesti Omišalj - Čižići - Klimno - Šilo.
V kampu Tiha lahko kampirate na urejenih parcelah, omogočajo pa tudi najem mobilnih hišic.',
20,
'Šilo, Krk',
'../img/3.jpg', 1);