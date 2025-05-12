CREATE DATABASE db_telecom

USE db_telecom

GO


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
)

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
    clientID INT,
    abonamentID INT,
    dataActivare DATE,
    activ BIT DEFAULT 1,
    FOREIGN KEY (ClientID) REFERENCES Clienti(id),
    FOREIGN KEY (AbonamentID) REFERENCES Abonamente(id)
);

CREATE TABLE Facturi (
    id INT IDENTITY(1,1) PRIMARY KEY,
    serviciuID INT,
    dataEmitere DATE,
    suma DECIMAL(10,2),
    scadenta DATE,
    platita BIT DEFAULT 0,
    FOREIGN KEY (ServiciuID) REFERENCES Servicii(id)
);

CREATE TABLE Plati (
    id INT IDENTITY(1,1) PRIMARY KEY,
    facturaID INT,
    dataPlata DATE,
    sumaPlatita DECIMAL(10,2),
    metodaPlata VARCHAR(50),
    FOREIGN KEY (FacturaID) REFERENCES Facturi(id)
);

CREATE TABLE Apeluri (
    id INT IDENTITY(1,1) PRIMARY KEY,
    clientID INT FOREIGN KEY REFERENCES Clienti(id),
    nrApelat VARCHAR(15),
    dataApel DATETIME,
    durataSecunde INT,
    tipApel nvarchar(15) NOT NULL CHECK (tipApel IN ('National', 'International', 'Roaming')),
);




----------------------------------------------------------------------------------------------------------------

GO
CREATE PROCEDURE add_client @telefon NVARCHAR(15), @nume NVARCHAR(100), @prenume NVARCHAR(100), @idnp NVARCHAR(13), @email NVARCHAR(100), @adresa NVARCHAR(255)
AS
BEGIN
	IF(@idnp IN (SELECT idnp FROM Clienti))
	BEGIN
		INSERT INTO NumereTelefoane VALUES((SELECT id FROM Clienti WHERE idnp = @idnp) , @telefon);
	END
	ELSE
	BEGIN
		INSERT INTO Clienti VALUES(@nume, @prenume, @idnp, @email, @adresa, GETDATE());
		INSERT INTO NumereTelefoane VALUES((SELECT id FROM Clienti WHERE idnp = @idnp) , @telefon);
	END
END


DROP PROCEDURE add_client


EXEC add_client '060000024', 'Cozma', 'Vasile', '20012412902', 'vacozma06@gmail.com', 'bd. Dacia 60/5 71';
EXEC add_client '060000002', 'Cozma', 'Vasile', '2002500570790', 'vcozma06@gmail.com', 'bd. Dacia 60/5 71';

SELECT * FROM Clienti
SELECT * FROM NumereTelefoane

----------------------------------------------------------------------------------------------------------------

GO
CREATE PROCEDURE delete_by_nr @telefon NVARCHAR(15)
AS
DELETE FROM Clienti
WHERE telefon = @telefon;

EXEC delete_by_nr '060000000'

GO
CREATE PROCEDURE get_nr_by_name @nume NVARCHAR(100), @prenume NVARCHAR(100)
AS
SELECT * FROM Clienti
WHERE nume = @nume AND prenume = @prenume

EXEC get_nr_by_name 'Cozma', 'Vasile'




SELECT * FROM Clienti



