# MTCG

##  1. Technical Steps

### 1.1 Design

#### 1.1.1 Rest API Design
 * ___POST HOST/users --header "Content-Type: application/json" -d "{"Username":"user", "Password":"pwd"}"___ <br>
	Mit dieser Funktion & Payload kann man sich einloggen um einen Token für die weiteren Funktionen zu bekommen.
 * ___POST HOST/logout --header "Authorization: 123456"___ <br>
	Mit dieser Funktion kann man einen User aus der Online Liste löschen.
 * ___GET HOST/transaction/packages --header "Authorization: 123456"___ <br>
	Mit dieser Funktion lassen sich die im Shop Verfügbaren Karten Packages anzeigen
 * ___POST HOST/transaction/packages --header "Content-Type: application/json" --header "Authorization: 123456" -d "{"PackId": "1"}"___ <br>
	Mit dieser Funktion lassen sich die im Shop Verfügbaren Karten packages kaufen, falls man genug Münzen besitzt. Hat man nicht genug Münzen, aber will trotzdem ein Package kaufen, dann muss man Werbung sehen um mehr Münzen zu bekommen.
 * ___GET HOST/watchads --header "Authorization: 123456"___ <br>
	Mit dieser Funktion kann man sich Werbung anzeigen lassen um sich mehr Münzen zu besorgen. Bis zum jetzigen Zeitpunkt steht noch nicht fest wann man Münzen kaufen kann ;-)
 * ___GET HOST/cards --header "Authorization: 123456"___ <br>
	Mit dieser Funktion kann man sich alle Karten vom eingeloggten User anzeigen lassen, die Karten im Deck werden besonders angezeigt.
 * ___GET HOST/deck --header "Authorization: 123456"___ <br>
	Mit dieser Funktion kann man sich alle Karten vom eingeloggten User im Deck anzeigen lassen.
 * ___PUT HOST/deck  --header "Content-Type: application/json" --header "Authorization: 123456" -d "[{"DeckCard": "1"},{"DeckCard": "2"},{"DeckCard": "3"},{"DeckCard": "4"}]___ <br>
	Mit Funktion kann der eingeloggte User seine Karten vom Stack auswählen. Der User kann keine Karten auswählen die er nicht besitzt und es wird überprüft ob er auch genug Karten für das Deck ausgewählt hat.
 * ___GET HOST/stats --header "Authorization: 123456"___ <br>
	Mit dieser Funktion kann sich der User seine Statistik von seinem Account ansehen. Diese Statistik enthält: Anzahl der Gewonnen Spiele, Anzahl der Verlorenen Spiele, seinen Score, seine Anzahl von Münzen, seine Anzahl von ausgegebenen Münzen und wie viele Münzen er sich durch das Werbung schauen verdient hat.
 * ___GET HOST/score --header "Authorization: 123456"___ <br>
	Mit dieser Funktion kann man sich alle das Leaderboard von allen Spielern die mindestens einmal Verloren haben anzeigen lassen. Das Mindestens einmal Verloren ist deshalb wichtig um Bots auszusortieren.
 * ___GET HOST/trandings --header "Authorization: 123456"___ <br>
	Mit dieser Funktion kann man sich alle Karten die zum tauschen sind verfügbar sind anzeigen lassen.
 * ___POST HOST/trandings --header "Content-Type: application/json" --header "Authorization: 123456" -d "{"Insert":true,"WantId":6,"GiveId":12,"UserTradeWith":""}"___ <br>
	Mit dieser Funktion kann man einen Trading eintrag erstellen.
 * ___POST HOST/trandings --header "Content-Type: application/json" --header "Authorization: 123456" -d "{"Insert":true,"WantId":6,"GiveId":12,"UserTradeWith":""}"___ <br>
	Mit dieser Funktion kann man ein Trading Deal durchführen.
 * ___DELETE HOST/trandings  --header "Content-Type: application/json" --header "Authorization: 123456" -d "{\"WantedId\":\"6\"}"___ <br>
	Mit dieser Funktion kann man einen Tradingeintrag löschen.
 * ___GET HOST/battle  --header "Authorization: 123456" ___ <br>
	Mit dieser Funktion kann man sich der eingeloggte User in eine Battle Que eintragen & bekommt eine Battleid.
 * ___GET HOST/log  --header "Content-Type: application/json" --header "Authorization: 123456" -d "{"battleid":"6"}"___ <br>
	Mit dieser Funktion kann man sich der eingeloggte User alle Battles anschauen, welche schon durchgeführt worden sind.

### 1.2 Failures & Selected Solutions
Das einzige Problem das ich hatte war, dass ich dem Thread meine Battlelobby nicht mitgeben konnte.
Meine Lösung bestand darin die Battlelobby so gut es ging in die Datenbank zu verschieben.

***
## 2. Unit Tests
 * ___BattleHandler (Klasse)___ <br>
	In dieser Klasse wurde getestet ob der User Genügend Karten im Deck hat (4 Karten).<br>
	Desweiteren wurden die SpellCardEffectivness und die DodgeAttack der Karten geprüft.<br>
	Es ist sehr wichtig für die User expierence und das Spiel gefühl, dass die Battle Logik ohne Fehler ist.
	Deswegen wurden dafür Tests geschrieben.
	<br> Desweiteren sind Unit Tests schwer zu machen, da sehr viele Methoden etwas aus einer Datenbank lesen oder schreiben
	
	
 

***
## 3. Time Spent
Aufwand für das MTC-Projekt ohne dem ersten Projekt: 100 Stunden
***
## 4. Git-Link
[Hier ist der Link zu meinem Git-Repository](https://github.com/Raphiiee/MTCG/tree/development)
