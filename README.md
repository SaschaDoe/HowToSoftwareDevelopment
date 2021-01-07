# How to Software Development

## Vorgehen

### Stakeholder
* Versuche das Ziel des Kunden zu erfahren     
* Versuche zu erfahren wer alle Stakeholder des Produktes sind  
* Versuche zu erfahren welche End Nutzer es gibt und wie diese denken
  
### Transparent Arbeiten
* Arbeite immer mit Anforderungen die am besten so offen wie möglich aufgeschrieben werden  
* Checke auf einen entwicklungsbranch ein
* Checke oft, also klein ein. -> Single Responsebility
* Checke wenn es nicht zu große Umstände bereitet entweder Refactorings von Transformations trennen
* Kommentiere deinen check in
* Verbinde den check in mit den Anforderungen
* Frage selbständig nach einem Code Review
* Der Kunde sollte die Arbeit der letzten Wochen sehen und kommentieren (Sprint review)
* Nach einem Sprint sollte eine Retrospektive abgehalten werden 
  * Was lief gut 
  * Was schlecht, 
  * Haben wir unsere letzten Aktionen umgesetzt 
  * Welche neuen aktionen?


### Programmieren
* Optimiere nicht vorschnell https://de.wikipedia.org/wiki/YAGNI
* Mache dir in der Gruppe vorher Gedanken um die Architektur (Layering, Design Patterns etc...)
* https://en.wikipedia.org/wiki/Code_coverage reicht nicht Ziel ist stattdessen https://de.wikipedia.org/wiki/%C3%84quivalenzklassentest
* Testpyramide: Viele Unit Tests wenige UI Tests
* Schreibe testbaren code mittels TDD 
1. Schreibe einen gut lesbaren Test
2. Versuche ihn zum Kompilieren zu bringen und achte darauf dass er rot wird
3. So schnell wie möglich den test grün werden lassen https://de.wikipedia.org/wiki/KISS-Prinzip
4. Wiederholen bis ein requirement erreicht ist
5. Refectoring
6. Check in im Entwicklungsbranche
7. Um Review beten
8. Ggf verbessern
9. In den main branch mergen

## Was ich vor dem Einchecken oder während des Reviews beachte  
* https://de.wikipedia.org/wiki/Gesetz_von_Demeter also datenkapselung beachten
* Bennenung von Variablen, Methoden, Klassen
* https://de.wikipedia.org/wiki/Command-Query-Separation
* https://en.wikipedia.org/wiki/SOLID
* [Don't repeat yourself](https://de.wikipedia.org/wiki/Don%E2%80%99t_repeat_yourself) aber nicht übertreiben https://en.wikipedia.org/wiki/Rule_of_three_(computer_programming)
* Obere Klassen sollten eine hohe Abstraktion haben. Das "Was" sollte man dort eher als das "Wie" erkenne.
=> Aus oben genannten Gründen ist es manchmal ratsam deklarativ, [funktional](https://de.wikipedia.org/wiki/Funktionale_Programmierung) zu Programmieren. Man kann beide paradigmen miteinander in C# kombinieren
* Funktionen sollten in Funktionen mit nebeneffekten und ohne nebeneffekte getrennt werden
* Funktionen mit nebeneffekten sollten zwischen denen ohne nebeneffekten stehen (Dependency Rejection)
### Syntaktishes
* Keine Hardcoded Strings (wenn dann abstrahieren und am Anfang der Klasse oder in einem eigenen Bereich)
* Keine Klassen in Klassen (immer ein File pro Klasse)
* Namespaces sollten mit Verzeichnissen übereinstimmen
* Nicht im Quellcode Kommentieren (lieber sprechende namen verwenden) außer Externes Framework ist verwirrend in der benutzung
* Dafür über public class members mit xml kommentieren (um später die doku automatisch erstellen zu können)
* Die Reihenfolde von "Class Members" sollte überall gleich sein 
* Abstraktionslevel in Methoden sollte gleich sein
* Klassen und Methoden sollten nicht zu groß werden (Single Responsebility)
* Linkslesbarkeit und wenige Parameter sind am besten
* Objektorientierung oder Funktionales Programmieren beachten (TODO)
* https://de.wikipedia.org/wiki/Model_View_ViewModel für UI benutzen
* Testprojekt Verzeichnis sollte mit Projektverzeichnis übereinstimmen
* Testklassen sollten eine Klasse testen und in regions pro Methode eingeteilt werden
* Kein Programmcode umschreiben für tests (https://github.com/Moq/moq4/wiki/Quickstart benutzen)
* Mocking so wenig wie möglich benutzen durch Aufteilung in [Layered Architecture](https://www.oreilly.com/library/view/software-architecture-patterns/9781491971437/ch01.html)
* Reviewe auch die Changelog Kommentare
* Reviewe auch die Tests (nach verständlichkeit und Äquivalenzklassenabdeckung)
* Reviewe ggf. passende Doku
* Lasse einen Reviewer allein durch das changeset gehen (und finde so heraus, ob jemand sich auch allein zurechtfindet)

