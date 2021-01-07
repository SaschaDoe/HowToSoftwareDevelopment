# How to Software Development

## Vorgehen

### Stakeholder
* Versuche das Ziel des Kunden zu erfahren     
* Versuche zu erfahren wer alle Stakeholder des Produktes sind  
* Versuche zu erfahren welche End Nutzer es gibt und wie diese [denken](https://www.oreilly.com/library/view/97-things-every/9780596809515/ch03.html)
  
### Transparent Arbeiten
* Arbeite immer mit Anforderungen die am besten so offen wie möglich aufgeschrieben werden 
* [Fail-Fast](https://www.agile-academy.com/de/agiles-lexikon/fail-fast-schnell-scheitern/): Arbeite an den Anforderungen zu erst die dem Kunden viel Wert sind, die aber auch ein großes Risiko des Scheiterns beinhalten.
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
* Bewahre die [Ruhe](https://www.oreilly.com/library/view/97-things-every/9780596809515/ch01.html) wenn du Druck von einer Seite bekommst (Deadline)
* Lasse dich nicht zu commitments hinreisen, die du nicht einhalten kannst (nenne lieber einen Zeitraum)

### Programmieren
* Programmiere auch "Prototypen" mit diesen best practises (der angebliche Prototyp wird ziemlich oft doch produktiv code)
* Optimiere nicht vorschnell https://de.wikipedia.org/wiki/YAGNI 
  * Abstrahiere nicht zu viel
  * Lass die Anwendung nicht zu konfigurierbar werden
  * Erst muss der code funktionieren, dann lesbar werden, dann auf performance überprüft werden
* Gibt es das was du Programmieren sollst schon (mit der richtigen Lizens)
* Boyscout rule: Verbessere etwas immer wenn du in den Code gehst und etwas siehst was nicht zu diesen best practises passt.
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
* Vielleicht fragt dich jemand nach einem Code Review: Stelle eher Fragen als zu kritisieren!
* Benutze tools wie Reshaper um Templates und Shortcuts nutzen zu können (und selbst zu erstellen.
* Trainiere durch [Coding Catas](https://en.wikipedia.org/wiki/Kata_(programming)) diese sicher zu benutzen.


# Was ich vor dem Einchecken oder während des Reviews beachte
## Modellierung
* Versuche Kopplung zu vermeiden
* Es muss in den unteren Methoden exceptions geworfen werden und in den oberen aufgefangen.
* Niemals Fehler weiter werfen (throw in catch statement)
## OOP
* Benutze Polymorphismus statt mit if einen typ abzufragen 
* Wenn OOP dann die [Wirklichkeit](https://de.wikipedia.org/wiki/Fachlichkeit) versuchen zu [analysieren und abzubilden](https://de.wikipedia.org/wiki/Objektorientierte_Analyse_und_Design#Objektorientierte_Analyse) und [Design Patterns](https://en.wikipedia.org/wiki/Software_design_pattern) verwenden.
* https://de.wikipedia.org/wiki/Gesetz_von_Demeter also datenkapselung beachten
* https://de.wikipedia.org/wiki/Command-Query-Separation
* https://en.wikipedia.org/wiki/SOLID
* [Don't repeat yourself](https://de.wikipedia.org/wiki/Don%E2%80%99t_repeat_yourself) aber nicht übertreiben https://en.wikipedia.org/wiki/Rule_of_three_(computer_programming)
* Obere Klassen sollten eine hohe Abstraktion haben. Das "Was" sollte man dort eher als das "Wie" erkennen.  
* Versuche den Code [referenzielle transparent](https://de.wikipedia.org/wiki/Referenzielle_Transparenz) zu halten, um später leichter paralellisieren zu können und um nicht den Überblick zu verlieren.
## Funktional
=> Aus oben genannten Gründen ist es manchmal ratsam deklarativ, [funktional](https://de.wikipedia.org/wiki/Funktionale_Programmierung) statt OOP imperativ zu Programmieren. Man kann beide paradigmen miteinander in C# kombinieren.
* Funktionen sollten in Funktionen mit nebeneffekten und ohne nebeneffekte getrennt werden
* Funktionen mit nebeneffekten sollten zwischen denen ohne nebeneffekten stehen (Dependency Rejection)
* Spreche durch entsprechende Funktionen in der Domänen Sprache
* Unveränderliche Daten: Benutze immer generatoren statt iteratoren
* Keine Rekursion gibt nur stack probleme. Lieber Sequencen erstellen und takeWhile benutzen (unendlicher lauf natürlich bei beiden nicht vermeidbar)
## Syntaktishes
* Alles sollte von links nach rechts wie fließtext lesbar sein (kein horizontal alignment)
* Bennenung von Variablen, Methoden, Klassen
* Keine Hardcoded Strings (wenn dann abstrahieren und am Anfang der Klasse oder in einem eigenen Bereich)
* Keine Klassen in Klassen (immer ein File pro Klasse)
* Namespaces sollten mit Verzeichnissen übereinstimmen
* Nicht im Quellcode Kommentieren (lieber sprechende namen verwenden) außer Externes Framework ist verwirrend in der benutzung
* Dafür über public class members mit xml kommentieren (um später die doku automatisch erstellen zu können)
* Die Reihenfolde von "Class Members" sollte überall gleich sein 
* Abstraktionslevel in Methoden sollte gleich sein
* Klassen und Methoden sollten nicht zu groß werden (Single Responsebility)
* Linkslesbarkeit und wenige Parameter sind am besten
## Sonstiges
* Datentypen sind nicht unendlich, Mathe setzt dies aber oft vorraus. Ist dies in der Anwendung ein Problem? (manchmal besser domänen spezifische typen verwenden)
* Könnten die Daten die verwendet werden sehr groß werden? Können sie überhaupt in den Arbeitsspeicher? Generatoren (also funktionale programmierung) könnte hier helfen 
## Testing
* Tests sollten ein Ding testen und es auch benennen (so kann ich sehen was schiefläuft falls er rot wird)
* Tests sollten [reliabel](https://de.wikipedia.org/wiki/Reliabilit%C3%A4t) sein
* One Assert per Test sollte die Regel sein aber es gilt eher eine Sache sollte abgetestet werden (die kann auch mal komplexer sein)
* Tests sollten unabhängig voneinander (ausführbar) sein.
* https://de.wikipedia.org/wiki/Model_View_ViewModel für UI benutzen
* Testprojekt Verzeichnis sollte mit Projektverzeichnis übereinstimmen
* Testklassen sollten eine Klasse testen und in regions pro Methode eingeteilt werden
* Kein Programmcode umschreiben für tests (https://github.com/Moq/moq4/wiki/Quickstart benutzen)
* Mocking so wenig wie möglich benutzen durch Aufteilung in [Layered Architecture](https://www.oreilly.com/library/view/software-architecture-patterns/9781491971437/ch01.html)
* Keine Voodoo Sleeps. Lieber mit async arbeiten.
## Speziel im Review
* Reviewe auch die Changelog-Kommentare
* Reviewe auch die Tests (nach verständlichkeit und Äquivalenzklassenabdeckung)
* Reviewe ggf. passende Doku
* Lasse einen Reviewer allein durch das changeset gehen (und finde so heraus, ob jemand sich auch allein zurechtfindet)

