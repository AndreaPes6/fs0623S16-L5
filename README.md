CREATE TABLE Anagrafica (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(15),
    Cognome NVARCHAR(15),
    Indirizzo NVARCHAR(50),
    Città NVARCHAR(25),
    Cap NVARCHAR(5),
    CodFisc NVARCHAR(16)
);

CREATE TABLE Verbale (
     ID INT IDENTITY(1,1) PRIMARY KEY,
    IDViolazione INT NOT NULL,
    IDAnagrafica INT NOT NULL,
    DataViolazione DATETIME NOT NULL,
    IndirizzoViolazione NVARCHAR(50) NOT NULL,
    Nominativo_Agente NVARCHAR(25) NOT NULL,
    DataTrascrizioneVerbale DATETIME NOT NULL,
    Importo DECIMAL(18, 2) NOT NULL,
    DecurtamentoPunti INT NOT NULL,
    Contestazione BIT NOT NULL
);

CREATE TABLE TipiViolazione (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Descrizione NVARCHAR(MAX) NOT NULL
);
