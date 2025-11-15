TODO:
    
    - add rdlc report to "Verbrauch" - Tab


SELECT Bestellungen.ErfDat, Artikel.Bezeichnung, Bestellungen.Bestellt, Bestellungen.Geliefert, Bestellungen.Offen, Bestellungen.Eingang FROM Artikel INNER JOIN Bestellungen ON Artikel.Id = Bestellungen.ArtikelId WHERE (((Bestellungen.Offen)>0)); 