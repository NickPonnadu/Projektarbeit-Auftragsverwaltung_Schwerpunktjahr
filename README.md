# Projektarbeit-Auftragsverwaltung_Schwerpunktjahr

E-Mail-Validierung nach RFC 5322
Diese Validierung prüft, ob eine gegebene E-Mail-Adresse den RFC 5322-Standards entspricht, der die Spezifikation für gültige E-Mail-Adressen darstellt. Hier sind einige Beispiele für gültige und ungültige E-Mail-Adressen und eine Beschreibung, wie sie von der Validierung behandelt werden:

RegEx E Mail Validierung: (?<=\s)("?)[\w\-+][\w\-+]*(\.[\w\-+]+)*\1@([\w\-]{1,10}(\.[\w\-]{1,10})*(\.[\w\-]{1,3})|\[([1-9]|([1-9]\d)|(1\d{2})|(2[0-4]\d)|25[0-5])(\.(25[0-5]|([1-9]?\d)|(1\d{2})|(2[0-4]\d))){3}(?![\.\d])\])$


Gültige E-Mail-Adressen
1. Einfache E-Mail-Adresse:
Beispiel: user@example.com
Beschreibung: Dies ist eine einfache und gültige E-Mail-Adresse ohne besondere Merkmale. Sie enthält einen Benutzernamen (user) und eine Domäne (example.com).

2. E-Mail-Adresse mit Subdomain:
Beispiel: user@sub.example.com
Beschreibung: Diese E-Mail-Adresse enthält eine Subdomain (sub) in der Domäne (example.com) und entspricht den RFC 5322-Standards.

3. E-Mail-Adresse mit Sonderzeichen:
Beispiel: user123+456@example.co.uk
Beschreibung: Diese E-Mail-Adresse enthält Sonderzeichen im Benutzernamen und entspricht den RFC 5322-Standards.

4. E-Mail-Adresse mit zitiertem lokalem Teil:
Beispiel: "user.name"@example.com
Beschreibung: Der lokale Teil der E-Mail-Adresse ("user.name") ist in Anführungszeichen gesetzt, was nach RFC 5322 zulässig ist.

5. E-Mail-Adresse mit IP-Adressen-Domäne:
Beispiel: user@[192.168.1.1]
Beschreibung: Die E-Mail-Adresse verwendet eine IP-Adresse (192.168.1.1) als Domäne, was nach RFC 5322 ebenfalls zulässig ist.

Ungültige E-Mail-Adressen
1. Fehlendes "@"-Symbol:
Beispiel: userexample.com
Beschreibung: Diese E-Mail-Adresse ist ungültig, da das "@"-Symbol fehlt, das Benutzername und Domäne trennt.

2. Mehrere "@"-Symbole:
Beispiel: user@example@com
Beschreibung: Mehrere "@"-Symbole in einer E-Mail-Adresse sind ungültig und werden von der Validierung abgelehnt.

3. Führender Punkt (dot):
Beispiel: .user@example.com
Beschreibung: Ein führender Punkt im lokalen Teil der E-Mail-Adresse ist ungültig.

4. Endender Punkt (dot):
Beispiel: user.@example.com
Beschreibung: Ein endender Punkt im lokalen Teil der E-Mail-Adresse ist ebenfalls ungültig.

5. Aufeinanderfolgende Punkte (dots):
Beispiel: user..name@example.com
Beschreibung: Aufeinanderfolgende Punkte im lokalen Teil der E-Mail-Adresse sind nicht erlaubt.

6. Sonderzeichen in der Domäne:
Beispiel: user@exa$mple.com
Beschreibung: Sonderzeichen im Domänenteil der E-Mail-Adresse sind ungültig.

7. Domäne mit zu vielen Teilen:
Beispiel: user@example.com.invalid
Beschreibung: Eine Domäne mit zu vielen Teilen (mehr als zwei) ist ungültig.

8. Zu langes Label in der Domäne:
Beispiel: user@exaaaaaaaaaaaaaaaaaaaaaaaaample.com
Beschreibung: Ein einzelnes Label in der Domäne, das zu lang ist, wird von der Validierung als ungültig angesehen.

Diese E-Mail-Validierung nach RFC 5322 bietet eine klare Unterscheidung zwischen gültigen und ungültigen E-Mail-Adressen und hilft dabei, E-Mails gemäß den Standards zu überprüfen. Dies ist wichtig, um sicherzustellen, dass E-Mail-Adressen in Anwendungen korrekt verarbeitet werden und keine unerwarteten Probleme auftreten.
