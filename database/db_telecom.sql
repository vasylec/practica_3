CREATE DATABASE db_telecom


USE db_telecom

GO

CREATE TABLE Angajati (
	id INT IDENTITY(1,1) PRIMARY KEY,
	nume NVARCHAR(100) NOT NULL,
    prenume NVARCHAR(100) NOT NULL,
    idnp NVARCHAR(13) NOT NULL UNIQUE,
    email NVARCHAR(100) NOT NULL UNIQUE,
    adresa NVARCHAR(255) NOT NULL,
	functie NVARCHAR(255) NOT NULL,
		
	username NVARCHAR(100) NOT NULL,
	parola NVARCHAR(100) NOT NULL CHECK(LEN(parola) >= 8),
);


ALTER TABLE Clienti
ADD localitate NVARCHAR(10) NOT NULL DEFAULT 'Urban',
    CONSTRAINT CHK_Localitate_2 CHECK (localitate IN ('Urban', 'Rural'));


CREATE TABLE Clienti (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nume NVARCHAR(100) NOT NULL,
    prenume NVARCHAR(100) NOT NULL,
    idnp NVARCHAR(13) NOT NULL UNIQUE,
    email NVARCHAR(100) NOT NULL UNIQUE,
    adresa NVARCHAR(255) NOT NULL,
    dataInregistrare DATE NOT NULL
);

CREATE TABLE NumereTelefoane (
	id INT IDENTITY(1,1) PRIMARY KEY,
	clientId INT FOREIGN KEY REFERENCES Clienti(id),
	telefon NVARCHAR(15) UNIQUE,
	dataInregistrare DATE NOT NULL,
	nrFix BIT NOT NULL
);

CREATE TABLE Abonamente (
    id INT IDENTITY(1,1) PRIMARY KEY,
    numeAbonament VARCHAR(100),
    pretLunar DECIMAL(10,2),
    internetGB INT,
    minuteNationale INT,
	minuteInternationale INT,
    sms INT,
    descriere TEXT
);

CREATE TABLE Servicii (
    id INT IDENTITY(1,1) PRIMARY KEY,
    clientID INT FOREIGN KEY REFERENCES Clienti(id),
    abonamentID INT FOREIGN KEY REFERENCES Abonamente(id),
    dataActivare DATE,
    activ BIT DEFAULT 1,
);

CREATE TABLE Facturi (
    id INT IDENTITY(1,1) PRIMARY KEY,
    serviciuID INT FOREIGN KEY REFERENCES Servicii(id),
    dataEmitere DATE,
    suma DECIMAL(10,2),
    scadenta DATE,
    platita BIT DEFAULT 0,
);

CREATE TABLE Apeluri (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nrSursa NVARCHAR(15) NOT NULL,
    nrDestinatie NVARCHAR(15) NOT NULL,
    dataApel DATETIME NOT NULL,
    durataSecunde INT NOT NULL,
    tipApel NVARCHAR(15) NOT NULL,
    

    CONSTRAINT FK_nrSursa FOREIGN KEY (nrSursa) REFERENCES NumereTelefoane(telefon),
    CONSTRAINT FK_nrDestinatie FOREIGN KEY (nrDestinatie) REFERENCES NumereTelefoane(telefon),
    CONSTRAINT CHK_tipApel CHECK (tipApel IN ('National', 'International', 'Roaming')),
    CONSTRAINT CHK_nrDifera CHECK (nrSursa <> nrDestinatie)
);
INSERT INTO Apeluri VALUES ('0123456781', '0777777777', '2025-05-01',50 , 'Roaming')

SELECT * FROM NumereTelefoane
----------------------------------------------------------------------------------------------------------------
GO



GO
CREATE PROCEDURE add_client @nume NVARCHAR(100), @prenume NVARCHAR(100), @idnp NVARCHAR(13), @email NVARCHAR(100), @adresa NVARCHAR(255)
AS
BEGIN
	INSERT INTO Clienti VALUES(@nume, @prenume, @idnp, @email, @adresa, GETDATE());
END

GO

CREATE PROCEDURE add_nr @idnp_client NVARCHAR(13), @telefon NVARCHAR(15), @fix BIT
AS
BEGIN
	INSERT INTO NumereTelefoane VALUES ((SELECT id FROM Clienti WHERE idnp = @idnp_client), @telefon, GETDATE(), @fix);
END

GO
CREATE PROCEDURE add_nr 
    @idnp_client NVARCHAR(13), 
    @telefon NVARCHAR(15), 
    @fix BIT
AS
BEGIN
    DECLARE @id_client INT;

    SELECT @id_client = id 
    FROM Clienti 
    WHERE idnp = @idnp_client;

    IF @id_client IS NULL
    BEGIN
        THROW 50001, 'Clientul cu IDNP-ul specificat nu există.', 1;
        RETURN;
    END

    INSERT INTO NumereTelefoane 
    VALUES (@id_client, @telefon, GETDATE(), @fix);
END








EXEC add_client 'Cozma', 'Vasile', '20012412902', 'vacozma06@gmail.com', 'bd. Dacia 60/5 71';
EXEC add_client 'Jomir', 'Ghoerghe', '2002500570790', 'vcozma06@gmail.com', 'bd. Stefan cel Mare 632/4 21';


EXEC add_nr '1234567890123', '0123156021', '0'

SELECT * FROM NumereTelefoane




SELECT * FROM Clienti
SELECT * FROM NumereTelefoane

DELETE Clienti
WHERE id = 15

----------------------------------------------------------------------------------------------------------------

GO
CREATE PROCEDURE delete_nr @telefon NVARCHAR(15)
AS
DELETE FROM NumereTelefoane
WHERE telefon = @telefon;


SELECT * FROM NumereTelefoane




GO
CREATE PROCEDURE get_nr_by_name @nume NVARCHAR(100), @prenume NVARCHAR(100)
AS
SELECT * FROM Clienti
WHERE nume = @nume AND prenume = @prenume

EXEC get_nr_by_name 'Cozma', 'Vasile'


SELECT * FROM NumereTelefoane



SELECT * FROM vw_luckyNumbers





GO
CREATE VIEW vw_luckyNumbers
AS
SELECT c.id AS clientId, c.Nume, c.Prenume, n.telefon, n.nrFix
FROM NumereTelefoane n
INNER JOIN Clienti c ON n.clientId = c.id
WHERE
    LEN(n.telefon) >= 6 AND
    ISNUMERIC(n.telefon) = 1 AND
    (
        CAST(SUBSTRING(n.telefon, 1, 1) AS INT) +
        CAST(SUBSTRING(n.telefon, 2, 1) AS INT) +
        CAST(SUBSTRING(n.telefon, 3, 1) AS INT)
    )
    =
    (
        CAST(SUBSTRING(n.telefon, LEN(n.telefon)-2, 1) AS INT) +
        CAST(SUBSTRING(n.telefon, LEN(n.telefon)-1, 1) AS INT) +
        CAST(SUBSTRING(n.telefon, LEN(n.telefon), 1) AS INT)
    );





GO
CREATE PROCEDURE select_Tel_By_Name @nume NVARCHAR(100), @prenume NVARCHAR(100)
AS
SELECT NumereTelefoane.id,clientId, Nume, Prenume, telefon, NumereTelefoane.dataInregistrare, nrFix  FROM NumereTelefoane
INNER JOIN Clienti ON Clienti.id = clientId
WHERE Nume = @nume and Prenume = @prenume



use db_telecom
EXEC select_Tel_By_Name 'Cozma', 'Vasile'


GO
CREATE PROCEDURE select_NameAdress_By_Tel @telefon NVARCHAR(15)
AS
SELECT clientId, Nume, Prenume, adresa, telefon FROM NumereTelefoane
INNER JOIN Clienti ON Clienti.id = clientId
WHERE telefon = @telefon

EXEC select_NameAdress_By_Tel '0700000000'

SELECT * FROM NumereTelefoane


SELECT * FROM NumereTelefoane
WHERE YEAR(dataInregistrare) > 2020




UPDATE NumereTelefoane
SET dataInregistrare = '2020-03-20'
WHERE nrFix = 1



GO
CREATE PROCEDURE select_Clienti_By_Luna @luna INT, @anul INT
AS
SELECT 
    C.id AS ClientId,
    C.nume,
    NT.telefon,
    SUM(A.durataSecunde) AS TotalDurataSecunde
FROM Apeluri A
JOIN NumereTelefoane NT ON A.nrSursa = NT.telefon
JOIN Clienti C ON NT.clientId = C.id
WHERE NT.nrFix = 1 
  AND MONTH(A.dataApel) = @luna
  AND YEAR(A.dataApel) = @anul
GROUP BY C.id, C.nume, NT.telefon
ORDER BY TotalDurataSecunde DESC;






GO
CREATE VIEW evidenta_telFix
AS
 SELECT 
     C.nume AS Nume,
     C.prenume AS Prenume,
     C.adresa AS Adresa,
     NT.telefon AS Telefon,
     CASE 
         WHEN C.localitate = 'Urban' THEN 'Urban'
         WHEN C.localitate = 'Rural' THEN 'Rural'
         ELSE 'Necunoscut'
     END AS TipLocalitate
 FROM Clienti C
 JOIN NumereTelefoane NT ON C.id = NT.clientId
 WHERE NT.nrFix = 1



 SELECT * FROM evidenta_telFix
 ORDER BY TipLocalitate, nume





-- Populare tabel Clienti
INSERT INTO Clienti (nume, prenume, idnp, email, adresa, dataInregistrare)
VALUES
('Popescu', 'Ion', '1980203123456', 'ion1@email.com', 'Str. Lalelelor 12', '2024-01-01'),
('Ionescu', 'Maria', '2950506123456', 'maria2@email.com', 'Str. Libertății 5', '2023-11-02'),
('Radu', 'Andrei', '1991231123456', 'andrei3@email.com', 'Str. Unirii 45', '2024-05-03'),
('Georgescu', 'Elena', '2900412123456', 'elena4@email.com', 'Str. Victoriei 11', '2023-12-04'),
('Dumitru', 'Cristian', '1800101123456', 'cristi5@email.com', 'Str. Florilor 7', '2024-01-05'),
('Nistor', 'Ana', '2950318123456', 'ana6@email.com', 'Str. Sperantei 9', '2024-02-06'),
('Barbu', 'Mihai', '1990722123456', 'mihai7@email.com', 'Str. Independentei 6', '2024-03-07'),
('Stoica', 'Irina', '2921015123456', 'irina8@email.com', 'Str. Aviatorilor 17', '2024-04-08'),
('Marin', 'Diana', '2990201123456', 'diana9@email.com', 'Str. Horea 22', '2024-04-09'),
('Petrescu', 'Alin', '1980610123456', 'alin10@email.com', 'Str. Luminitei 3', '2024-05-10'),
('Ilie', 'Simona', '2940912123456', 'simona11@email.com', 'Str. Stadionului 1', '2024-05-11'),
('Sandu', 'Victor', '1970415123456', 'victor12@email.com', 'Str. Nufarului 8', '2024-05-12'),
('Matei', 'Laura', '2910601123456', 'laura13@email.com', 'Str. Zorilor 10', '2024-05-13'),
('Florea', 'George', '1960502123456', 'george14@email.com', 'Str. Albinelor 14', '2024-05-14'),
('Enache', 'Raluca', '2981220123456', 'raluca15@email.com', 'Str. Crinului 12', '2024-05-15'),
('Lazar', 'Stefan', '1990304123456', 'stefan16@email.com', 'Str. Teiului 13', '2024-05-16'),
('Tudor', 'Gabriela', '2930812123456', 'gabriela17@email.com', 'Str. Ciresului 16', '2024-05-17'),
('Costache', 'Emil', '1950203123456', 'emil18@email.com', 'Str. Baciului 21', '2024-05-18'),
('Dragomir', 'Monica', '2950618123456', 'monica19@email.com', 'Str. Papusii 11', '2024-05-19'),
('Lupu', 'Daniela', '2930516123456', 'daniela20@email.com', 'Str. Rozelor 4', '2024-05-20');



-- Populare tabel NumereTelefoane
DECLARE @i INT = 1
WHILE @i <= 20
BEGIN
    INSERT INTO NumereTelefoane (clientId, telefon, dataInregistrare, nrFix)
    VALUES 
        (@i, CONCAT('021400', FORMAT(@i, 'D4')), '2024-05-01', 1); -- fix

    INSERT INTO NumereTelefoane (clientId, telefon, dataInregistrare, nrFix)
    VALUES 
        (@i, CONCAT('07', FORMAT(30 + @i, 'D2'), FORMAT(@i * 111, 'D6')), '2024-05-01', 0); -- mobil

    SET @i = @i + 1
END

SELECT * FROM Apeluri
-- Creăm o listă temporară cu toate numerele
SELECT telefon INTO #numere FROM NumereTelefoane;

-- Selectăm primele 20 de combinații nrSursa <> nrDestinatie
WITH combinatii AS (
    SELECT TOP 20 
        s.telefon AS nrSursa, 
        d.telefon AS nrDestinatie
    FROM #numere s
    CROSS JOIN #numere d
    WHERE s.telefon <> d.telefon
)
INSERT INTO Apeluri (nrSursa, nrDestinatie, dataApel, durataSecunde, tipApel)
SELECT 
    nrSursa,
    nrDestinatie,
    DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 30, '2025-03-01'), -- date random în mai 2025
    60 + ABS(CHECKSUM(NEWID())) % 300, -- durată între 60 și 360 secunde
    CASE ABS(CHECKSUM(NEWID())) % 3 
        WHEN 0 THEN 'National' 
        WHEN 1 THEN 'International' 
        ELSE 'Roaming' 
    END
FROM combinatii;

DROP TABLE #numere;







WITH Numerotare AS (
    SELECT id, ROW_NUMBER() OVER (ORDER BY id) AS rn
    FROM Clienti
)
UPDATE A
SET localitate = CASE WHEN N.rn % 2 = 0 THEN 'Urban' ELSE 'Rural' END
FROM Clienti A
JOIN Numerotare N ON A.id = N.id;




SELECT * FROM evidenta_telFix




CREATE VIEW evidenta_telFix AS
SELECT 
    c.localitate,
    COUNT(DISTINCT c.id) AS nrAbonatiFix
FROM 
    Clienti c
JOIN 
    NumereTelefoane nt ON c.id = nt.clientId
WHERE 
    nt.nrFix = 1
GROUP BY 
    c.localitate;



	SELECT * FROM Clienti
































