INSERT INTO Abonamente VALUES
('Smart Start 5', 100, 5, 200, 20, 100, 'Abonament entry-level, cu minute si net inclus la pret mic.'),
('Talk & Net', 200, 15, 400, 60, 300, 'Echilibru între convorbiri nationale si date mobile'),
('Family Share', 400, 30, 1200, 80, 600, 'Plan pentru mai multe numere pe acelasi abonament'),
('Unlimited Max', 800, 50, -1, -1, -1, 'Apeluri, SMS si internet nelimitat.'),
('Roaming Plus', 2000, 20, 0, 600, 800, 'Destinat celor care calatoresc des în afara tarii.')

INSERT INTO Clienti (nume, prenume, idnp, email, adresa, dataInregistrare) VALUES
('Popescu', 'Ion', '1234567890123', 'ion.popescu@email.com', 'Str. Lalelelor 10', '2024-11-01'),
('Ionescu', 'Maria', '2234567890123', 'maria.ionescu@email.com', 'Str. Florilor 15', '2024-12-05'),
('Georgescu', 'Andrei', '3234567890123', 'andrei.geo@email.com', 'Bd. Libertatii 45', '2025-01-10'),
('Dumitrescu', 'Ana', '4234567890123', 'ana.dumi@email.com', 'Str. Mihai Viteazu 8', '2025-01-15'),
('Stan', 'Radu', '5234567890123', 'radu.stan@email.com', 'Str. Sperantei 23', '2025-02-01'),
('Marin', 'Elena', '6234567890123', 'elena.marin@email.com', 'Bd. Unirii 34', '2025-02-20'),
('Enache', 'Cristian', '7234567890123', 'cristi.enache@email.com', 'Str. Salcâmilor 12', '2025-03-01'),
('Tudor', 'Bianca', '8234567890123', 'bianca.tudor@email.com', 'Str. Zorilor 7', '2025-03-05'),
('Ilie', 'Vlad', '9234567890123', 'vlad.ilie@email.com', 'Str. Parcului 16', '2025-03-10'),
('Mihai', 'Laura', '0234567890123', 'laura.mihai@email.com', 'Str. Castanilor 5', '2025-03-20');


INSERT INTO Servicii (clientID, abonamentID, dataActivare, activ) VALUES
(1, 1, '2025-03-01', 1),
(2, 2, '2025-03-03', 1),
(3, 3, '2025-03-04', 1),
(4, 4, '2025-03-05', 1),
(5, 5, '2025-03-06', 1),
(6, 1, '2025-03-07', 1),
(7, 1, '2025-03-08', 1),
(8, 2, '2025-03-09', 1),
(9, 3, '2025-03-10', 1),
(10, 4, '2025-03-11', 1);

INSERT INTO NumereTelefoane (clientId, telefon, dataInregistrare, nrFix) VALUES
(1, '0711111111', '2025-03-01', 0),
(2, '0722222222', '2025-03-02', 0),
(3, '0733333333', '2025-03-03', 0),
(4, '0744444444', '2025-03-04', 0),
(5, '0755555555', '2025-03-05', 0),
(6, '0766666666', '2025-03-06', 0),
(7, '0777777777', '2025-03-07', 0),
(8, '0788888888', '2025-03-08', 0),
(9, '0799999999', '2025-03-09', 0),
(10, '0700000000', '2025-03-10', 0),
(1, '022123456', '2025-01-05', 1),
(4, '0244123456', '2025-04-01', 1),
(5, '0244567891', '2025-02-03', 1);


SELECT 
    telefon,
    CASE nrFix 
        WHEN 1 THEN 'DA' 
        WHEN 0 THEN 'NU' 
        ELSE 'Necunoscut' 
    END AS EsteFix
FROM NumereTelefoane;



INSERT INTO Apeluri VALUES ('0755555555', '022123456', GETDATE(), 25, 'National')




INSERT INTO Facturi (serviciuID, dataEmitere, suma, scadenta, platita) VALUES
(1, '2025-04-01', 5.00, '2025-04-15', 1),
(2, '2025-04-01', 15.00, '2025-04-15', 0),
(3, '2025-04-01', 25.00, '2025-04-15', 0),
(4, '2025-04-01', 5.00, '2025-04-15', 1),
(5, '2025-04-01', 15.00, '2025-04-15', 1),
(6, '2025-04-01', 25.00, '2025-04-15', 0),
(7, '2025-04-01', 5.00, '2025-04-15', 1),
(8, '2025-04-01', 15.00, '2025-04-15', 0),
(9, '2025-04-01', 25.00, '2025-04-15', 1),
(10, '2025-04-01', 5.00, '2025-04-15', 0);





SELECT * FROM Angajati




INSERT INTO Angajati VALUES
('Cozma', 'Vasile', '1234567890123', 'vcozma06@gmail.com', 'Stefan cel Mare 14/2 56', 'Administrator', 'Admin', '12345678')


INSERT INTO Angajati VALUES
('Cioban', 'Nicolae', '1234567890120', 'cioban@gmail.com', 'Dacia 15/8 36', 'Operator', 'colea', '87654321')



SELECT * FROM Angajati

