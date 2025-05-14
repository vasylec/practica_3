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


----------------------------------------------------------------------------------------------------------------


GO
CREATE PROCEDURE add_client @nume NVARCHAR(100), @prenume NVARCHAR(100), @idnp NVARCHAR(13), @email NVARCHAR(100), @adresa NVARCHAR(255)
AS
BEGIN
	INSERT INTO Clienti VALUES(@nume, @prenume, @idnp, @email, @adresa, GETDATE());
END

GO

CREATE PROCEDURE add_nr @idnp_client NVARCHAR(13), @telefon NVARCHAR(15)
AS
BEGIN
	INSERT INTO NumereTelefoane VALUES ((SELECT id FROM Clienti WHERE idnp = @idnp_client), @telefon, GETDATE());
END



EXEC add_client 'Cozma', 'Vasile', '20012412902', 'vacozma06@gmail.com', 'bd. Dacia 60/5 71';
EXEC add_client 'Jomir', 'Ghoerghe', '2002500570790', 'vcozma06@gmail.com', 'bd. Stefan cel Mare 632/4 21';
EXEC add_nr '20012412902', '0123456781'

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



