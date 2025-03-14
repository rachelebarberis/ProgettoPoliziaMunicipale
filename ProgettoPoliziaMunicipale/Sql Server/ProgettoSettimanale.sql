--Un corpo di Polizia Municipale intende creare un database per la gestione delle contravvenzioni ed i relativi pagamenti. 
--Il database dovrà gestire un’anagrafica clienti, una entità per contenere i tipi di violazioni contestate ed un’altra per annotare ed archiviare il verbale. 
--In virtù di quanto sopra creare le seguenti entità. 
USE ProgettoSettimale3BackEnd;
--ANAGRAFICA (idanagrafica, Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc); 
CREATE TABLE Anagrafica (
IdAnagrafica INT IDENTITY(1,1) PRIMARY KEY,
Cognome NVARCHAR(100) NOT NULL,
Nome NVARCHAR(100) NOT NULL,
Indirizzo NVARCHAR(100) NOT NULL,
Citta NVARCHAR(100) NOT NULL,
CAP INT NOT NULL,
CodiceFiscale NVARCHAR(16) NOT NULL UNIQUE
);
--TIPO VIOLAZIONE (idviolazione, descrizione); 
CREATE TABLE Tipo_Violazione (
IdViolazione INT IDENTITY(1,1) PRIMARY KEY,
Descrizione NVARCHAR(1000) NOT NULL,
);
--VERBALE (idverbale, DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti); 
CREATE TABLE Verbale (
IdVerbale INT IDENTITY(1,1) PRIMARY KEY,
DataViolazione DATE NOT NULL,
IndirizzoViolazione NVARCHAR(100) NOT NULL,
NominativoAgente NVARCHAR(100) NOT NULL,
DataTrascrizioneVerbale DATE NOT NULL,
Importo DECIMAL(10,2) NOT NULL,
DecurtamentoPunti INT NOT NULL,
IdAnagrafica INT NOT NULL,
CONSTRAINT FK_Verbale_Anagrafica FOREIGN KEY (IdAnagrafica) REFERENCES Anagrafica(IdAnagrafica),
CONSTRAINT CK_Importo CHECK (Importo > 0),
CONSTRAINT CK_DecurtamentoPunti CHECK (DecurtamentoPunti BETWEEN 0 AND 10),
CONSTRAINT CK_DataVerbale CHECK (DataTrascrizioneVerbale >= DataViolazione)
);


CREATE TABLE Verbale_Violazione (
IdVerbale INT ,
IdViolazione INT,
CONSTRAINT PR_Verbale_Violazione PRIMARY KEY(IdVerbale, IdViolazione),
CONSTRAINT FK_VerbaleViolazione_Verbale  FOREIGN KEY (IdVerbale) REFERENCES Verbale(IdVerbale),
CONSTRAINT FK_VerbaleViolazione_Violazione FOREIGN KEY (IdViolazione) REFERENCES Tipo_Violazione(IdViolazione),
);
--Popolare le tabelle manualmente con dati a piacimento.
--1 Anagrafica
INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale) 
VALUES ('Rossi', 'Mario', 'Via Roma 10', 'Biella', '20100', 'RSSMRA80A01H501Z')
--2 Anagrafica
INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale) 
VALUES ('Barberis', 'Rachele', 'Via Torino 15', 'Andorno', '13811', 'BRBMRA80A01H523I')
--3 Anafragica 
INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale) 
VALUES ('Braghin', 'Silvia', 'Via Pietro Micca 5', 'Biella', '20100', 'BRGMSA79A01H555T')
--4 Anagrafica
INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale) 
VALUES ('Lombardi', 'Alice', 'Via Vittorio Veneto 56', 'Andorno', '13811', 'LOMBRA12A01H778P')
--5 Anagrafica
INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale) 
VALUES ('Pozzato', 'Ettore', 'Via Stefanis 45', 'Biella', '20100', 'PZZTTA80A01G345L')
--6 Anagrafica
INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale) 
VALUES ('Fiore', 'Luisella', 'Via Milano 3', 'Sagliano', '13818', 'FRLSA80A01H0056S')
--7 Anagrafica
INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale) 
VALUES ('Tarantola', 'Cesare', 'Via Milano 89', 'Sagliano', '13818', 'TRNLA80A01H4457K')
--8 Anagrafica
INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale) 
VALUES ('Rocchi', 'Riccardo', 'Via Veneto 1', 'Andorno', '13811', 'RCCHRA80A01H523I')
--9 Anagrafica
INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale) 
VALUES ('Biamino', 'Piero', 'Via Santo 90', 'Biella', '20100', 'BMNPRA80A01H523I')
--10 Anagrafica
INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale) 
VALUES ('Barca', 'Samuel', 'Via Galiera 34', 'Andorno', '13811', 'BRCSMA80A01H523I')
--11 Anagrafica
INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale) 
VALUES ('Trucci', 'Carmela', 'Via Bernardo 3o', 'Palermo', '13900', 'TRCCMA80A01H523I')

SELECT * FROM Anagrafica;
--Popolamento tabella verbale
-- 1 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2024-02-10', 'Via Roma 10', 'Agente Bianchi', '2024-02-11', 150.00, 3, 1);

-- 2 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2024-02-12', 'Via Milano 5', 'Agente Rossi', '2024-02-13', 100.00, 2, 2);

-- 3 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2024-02-14', 'Viale Libertà 45', 'Agente Gialli', '2024-02-15', 180.00, 3, 3);

-- 4 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2024-02-21', 'Via Firenze 25', 'Agente Verdi', '2024-02-22', 190.00, 3, 4);

-- 5 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2024-02-11', 'Corso Italia 22', 'Agente Verdi', '2024-02-12', 200.00, 4, 5);

-- 6 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2024-02-13', 'Piazza Garibaldi', 'Agente Neri', '2024-02-14', 250.00, 5, 6);

-- 7 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2024-02-15', 'Via Torino 9', 'Agente Rossi', '2024-02-16', 130.00, 1, 7);

-- 8 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2024-02-16', 'Via Dante 15', 'Agente Verdi', '2024-02-17', 90.00, 1,8);

-- 9 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2024-02-17', 'Piazza Duomo', 'Agente Bianchi', '2024-02-18', 210.00, 4, 7);

-- 10 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2024-02-18', 'Via Nazionale 30', 'Agente Neri', '2024-02-19', 160.00, 2, 8);

-- 11 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2024-02-19', 'Via Veneto 8', 'Agente Rossi', '2024-02-20', 140.00, 2, 9);

-- 12 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2024-02-20', 'Viale Europa', 'Agente Gialli', '2024-02-21', 120.00, 1, 10);
-- 13 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2009-02-20', 'Corso Giusti', 'Agente Verdi', '2009-02-21', 430.00, 5, 10);
--14 Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica)
VALUES ('2009-02-20', 'Corso Gasparri', 'Agente Verdi', '2009-02-21', 130.00, 1, 11);
SELECT * FROM Verbale;

--Popolamento tabella Tipo_Violazione
--1 Tipo
INSERT INTO Tipo_Violazione (Descrizione)
VALUES ('Eccesso di velocità')
--2 Tipo
INSERT INTO Tipo_Violazione (Descrizione)
VALUES ('Passaggio con semaforo rosso')
--3 Tipo
INSERT INTO Tipo_Violazione (Descrizione)
VALUES ('Mancato utilizzo della cintura di sicurezza')
--4 Tipo
INSERT INTO Tipo_Violazione (Descrizione)
VALUES ('Uso del telefono alla guida');

SELECT * FROM Tipo_Violazione;

--Popolamento tabella molti a molti (Violazioni e verbali)
--1 Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (1, 1);
--1 Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (2, 2); 
--Doppia Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (3, 3); 
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (3, 1);
--1 Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (4, 1);
--Doppia Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (5, 4);
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (5, 3);
--1 Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (6, 2); 
--Doppia Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (7, 3); 
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (7, 4); 
--1 Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (8, 1); 
--Doppia Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (9, 4);
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (9, 2); 
--1 Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (10, 2); 
--1 Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (11, 3);
--1 Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (12, 1); 
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (12, 3); 
--1 Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (13, 3); 
--1 Violazione e verbale
INSERT INTO Verbale_Violazione (IdVerbale, IdViolazione) VALUES (14, 1);

SELECT * FROM Verbale_Violazione;

--1. Conteggio dei verbali trascritti,
SELECT COUNT(*) AS TotaleVerbaliTrascritti FROM Verbale;
--2. Conteggio dei verbali trascritti raggruppati per anagrafe, 
SELECT COUNT(*) AS VerbaliPerPersona FROM Verbale GROUP BY IdAnagrafica;
--3. Conteggio dei verbali trascritti raggruppati per tipo di violazione, 
SELECT TV.Descrizione AS TipoViolazione, COUNT(VV.IdVerbale) AS TotaleVerbaliPerViolazione
FROM Verbale_Violazione VV
JOIN Tipo_Violazione TV ON VV.IdViolazione = TV.IdViolazione
GROUP BY TV.Descrizione;
--4. Totale dei punti decurtati per ogni anagrafe, 
SELECT IdAnagrafica, SUM(DecurtamentoPunti) AS TotalePuntiDecurtati
FROM Verbale
GROUP BY IdAnagrafica
--5. Cognome, Nome, Data violazione, Indirizzo violazione, importo e punti decurtati per tutti gli anagrafici residenti a Palermo, 
SELECT A.Cognome, A.Nome, V.DataViolazione, V.IndirizzoViolazione, V.Importo, V.DecurtamentoPunti
FROM Anagrafica A
JOIN Verbale V ON A.IdAnagrafica = V.IdAnagrafica
WHERE A.Citta = 'Palermo'
--6. Cognome, Nome, Indirizzo, Data violazione, importo e punti decurtati per le violazioni fatte tra il febbraio 2009 e luglio 2009, 
SELECT A.Cognome, A.Nome, A.Indirizzo, V.DataViolazione, V.Importo, V.DecurtamentoPunti
FROM Anagrafica A
JOIN Verbale V ON A.IdAnagrafica = V.IdAnagrafica
WHERE V.DataViolazione BETWEEN '2009-02-01' AND '2009-07-31'
--7. Totale degli importi per ogni anagrafico, 
SELECT IdAnagrafica, SUM(Importo) AS TotaleImporti FROM Verbale GROUP BY IdAnagrafica;
--8. Visualizzazione di tutti gli anagrafici residenti a Palermo, 
SELECT * FROM Anagrafica WHERE Citta = 'Palermo';
--9. Query che visualizzi Data violazione, Importo e decurta mento punti relativi ad una certa data,
SELECT DataViolazione, Importo, DecurtamentoPunti FROM Verbale WHERE DataViolazione = '2024-02-15';
--10. Conteggio delle violazioni contestate raggruppate per Nominativo dell’agente di Polizia, 
SELECT NominativoAgente, COUNT(*) AS NumeroViolazioniPerAgente FROM Verbale GROUP BY NominativoAgente;
--11. Cognome, Nome, Indirizzo, Data violazione, Importo e punti decurtati per tutte le violazioni che superino il decurtamento di 5 punti, 
SELECT a.Cognome, a.Nome, a.Indirizzo, v.DataViolazione, v.Importo, v.DecurtamentoPunti
FROM Verbale v
JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica
WHERE v.DecurtamentoPunti >= 5;
--12. Cognome, Nome, Indirizzo, Data violazione, Importo e punti decurtati per tutte le violazioni che superino l’importo di 400 euro. 
SELECT a.Cognome, a.Nome, a.Indirizzo, v.DataViolazione, v.Importo, v.DecurtamentoPunti
FROM Verbale v
JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica
WHERE v.Importo > 400;

--EXTRA
--Query 13 - Numero di verbali e importo totale delle multe emesse per ogni agente di polizia
SELECT NominativoAgente, COUNT(IdVerbale) AS NumeroVerbali, SUM(Importo) AS TotaleMulte
FROM Verbale
GROUP BY NominativoAgente;
--Query 14 - Media degli importi delle multe per tipo di violazione
SELECT tv.Descrizione AS TipoViolazione, AVG(v.Importo) AS MediaImporto
FROM Verbale v
JOIN Verbale_Violazione vv ON v.IdVerbale = vv.IdVerbale
JOIN Tipo_Violazione tv ON vv.IdViolazione = tv.IdViolazione
GROUP BY tv.Descrizione;
