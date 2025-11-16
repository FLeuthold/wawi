TODO:
    
    - add rdlc report to "Verbrauch" - Tab - erledigt
    - konsequenter sql abfragen mit primarykey machen und nicht mit "like Modellbezeichnung" oder so ähnlich


SELECT Bestellungen.ErfDat, Artikel.Bezeichnung, Bestellungen.Bestellt, Bestellungen.Geliefert, Bestellungen.Offen, Bestellungen.Eingang FROM Artikel INNER JOIN Bestellungen ON Artikel.Id = Bestellungen.ArtikelId WHERE (((Bestellungen.Offen)>0)); 