# Software Development Process

## Stakeholder
* Versuche das Ziel des Kunden zu erfahren     
* Versuche zu erfahren wer alle Stakeholder des Produktes sind  
* Versuche zu erfahren welche End Nutzer es gibt und wie diese [denken](https://www.oreilly.com/library/view/97-things-every/9780596809515/ch03.html)
* Der Kunde bestenfalls User sollte die Arbeit der letzten Wochen sehen und kommentieren (Sprint review)
  
## Transparent Arbeiten
* Arbeite immer mit Anforderungen die am besten so offen wie möglich aufgeschrieben werden 
* [Fail-Fast](https://www.agile-academy.com/de/agiles-lexikon/fail-fast-schnell-scheitern/): Arbeite zuerstan den Anforderungen, die dem Kunden viel wert sind, die aber auch ein großes Risiko des Scheiterns beinhalten.
* Checke auf einen Entwicklungsbranch ein nicht direkt auf Master
* Checke oft, also klein ein. -> Single Responsebility
* Checke wenn es nicht zu große Umstände bereitet entweder Refactorings oder Transformations ein
* Kommentiere deinen check in
* Verbinde den check in mit den Anforderungen
* Frage selbständig nach einem Code Review

* Nach einem Sprint sollte eine Retrospektive abgehalten werden 
  * Was lief gut 
  * Was schlecht, 
  * Haben wir unsere letzten Aktionen umgesetzt 
  * Welche neuen Aktionen nehmen wir uns für den nächsten Sprint vor?
* Bewahre die [Ruhe](https://www.oreilly.com/library/view/97-things-every/9780596809515/ch01.html) wenn du Druck von einer Seite bekommst (Deadline)
* Lasse dich nicht zu Verpflichtungen hinreisen, die du nicht einhalten kannst (nenne lieber einen Zeitraum)

## Programmieren
* Programmiere auch "Prototypen" mit diesen best practises (der angebliche Prototyp wird ziemlich oft doch produktiv code)
* Optimiere nicht vorschnell https://de.wikipedia.org/wiki/YAGNI 
  * Abstrahiere nicht zu viel
  * Lass die Anwendung nicht zu konfigurierbar werden
  * Erst muss der code funktionieren, dann lesbar werden, dann auf Performanz überprüft werden
* Gibt es das was du Programmieren sollst schon (mit der [richtigen](http://oss-watch.ac.uk/apps/licdiff/) Lizenz)
* [Boyscout rule](https://en.wikipedia.org/wiki/Scout_Law): Verbessere etwas immer wenn du in den Code gehst und etwas siehst was nicht zu diesen best practises passt.
* Mache dir in der Gruppe vorher Gedanken um die Architektur (Layering, Design Patterns etc...)
* https://en.wikipedia.org/wiki/Code_coverage reicht nicht Ziel ist stattdessen https://de.wikipedia.org/wiki/%C3%84quivalenzklassentest
* Testpyramide: Viele Unit Tests wenige UI Tests
* Schreibe testbaren code mittels TDD 
1. Schreibe einen gut lesbaren Test
2. Versuche ihn zum Kompilieren zu bringen und achte darauf, dass der Test rot wird
3. So schnell wie möglich den Test grün werden lassen https://de.wikipedia.org/wiki/KISS-Prinzip
4. Wiederholen bis eine Anforderung implementiert ist
5. Refactoring
6. Check in im Entwicklungsbranche
7. Um Review beten
8. Ggf verbessern
9. In den main branch mergen
* Vielleicht fragt dich jemand nach einem Code Review: Stelle eher Fragen als zu kritisieren!
* Benutze tools wie Reshaper um Templates und Shortcuts nutzen zu können (und selbst zu erstellen.
* Trainiere durch [Coding Catas](https://en.wikipedia.org/wiki/Kata_(programming)) diese sicher zu benutzen.
* Legacy Code: „Cover and Modify“ statt "Edit and Prey"
