CREATE TABLE [dbo].[Artikel]
(
	[Id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NULL, 
    [Preis] MONEY NULL DEFAULT 0, 
    [reserviert] INT NULL DEFAULT 0, 
    [bestellt] INT NULL DEFAULT 0, 
    [Bestand] INT NULL DEFAULT 0, 
    [Mindestbestand] INT NULL DEFAULT 0, 
    [Bestellvorschlag] AS (-Bestand-bestellt+Mindestbestand+reserviert)
)

CREATE TABLE [dbo].[Drucker]
(
	[Id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [Bezeichnung] VARCHAR(50) NULL
)

CREATE TABLE [dbo].[Bestellungen]
(
	[Id] INT IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [ArtikelId] INT NULL, 
    [bestellt] INT NULL, 
    [geliefert] INT NULL, 
    [offen] INT NULL, 
    [Eingang] INT NULL, 
    [ErfUser] VARCHAR(50) NULL, 
    [ErfDat] DATE NULL, 
    [MutUser] VARCHAR(50) NULL, 
    [MutDat] DATE NULL
)

CREATE TABLE [dbo].[Auftrag]
(
	[Id] INT  IDENTITY (1,1) NOT NULL PRIMARY KEY, 
    [DruckerId] INT NULL, 
    [ArtikelId] INT NULL, 
    [Status] VARCHAR(50) NULL, 
    [ErfUser] VARCHAR(50) NULL, 
    [ErfDat] DATE NULL, 
    [MutUser] VARCHAR(50) NULL, 
    [MutDat] DATE NULL
)
GO

CREATE VIEW [dbo].[View]
	AS SELECT Auftrag.Id, Auftrag.ErfDat, Artikel.[Name], Drucker.Bezeichnung, Auftrag.Status, Auftrag.ErfUser
FROM Drucker
INNER JOIN 
(Artikel 
INNER JOIN Auftrag 
ON Artikel.Id = Auftrag.ArtikelId) 
ON Drucker.Id = Auftrag.DruckerId;

GO
CREATE VIEW [dbo].[ViewBestellvorschlag]
	AS SELECT Artikel.Name, Artikel.Mindestbestand, Artikel.Bestellvorschlag
FROM Artikel
WHERE (((Artikel.Bestellvorschlag)>0));

go

CREATE VIEW [dbo].[ViewWareneingang]
as	SELECT Bestellungen.ErfDat, Artikel.Name, Bestellungen.Bestellt, Bestellungen.Geliefert, Bestellungen.Offen, Bestellungen.Eingang
FROM Artikel INNER JOIN Bestellungen ON Artikel.Id = Bestellungen.ArtikelId
WHERE (((Bestellungen.Offen)>0));

go
