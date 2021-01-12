# How to Software Development - Best practices
Diese Liste beinhaltet best practices von Menschen, die sich profesionelle software entwickler nennen.
Sie ist nicht als Checkliste zu verstehen, welche man immer zur Hand nimmt wenn ein code Review ansteht.
Es ist vielmehr so, dass wir in der software Veränderbarkeit und Nützlichkeit anstreben. Diese Ziele werden wir erreichen wenn, die nachfolgenden Punkte eingehalten werden. 

Zu Veränderbarkeit zählt:
* Lesbarkeit -> Der Code wird viel öfter gelesen als geschrieben. Wenn man ihn nicht versteht wird ihn keiner mehr anfassen wollen
* Testabdeckung -> Will man den Code verändern sollte es Tests geben, die einem bescheinigen, dass das Programm noch fehlerfrei läuft
* Zusammenarbeit -> Es wird oft eingechecked, zusammen programmiert und gereviewed: Es entstehen keine Wissensinseln, also können viele jeden Codebereich ändern

Zu Nützlichkeit zählt:
* Effektifität: Was soll erstellt werden? Diese Frage sollte im Zentrum des Entwicklungsprozesses stehen. Diese Frage wird empirisch beantwortet.
* Funktional: 100% Äquivalenztestabdeckung, lesbare Tests und Tracing von der Anforderung zu den grünen tests bescheinigen eine hohe funktionalität. 
* Effizienz: Sich nicht mit unnötigen aufhalten und mit seiner IDE

## Vorgehen

### Stakeholder
* Versuche das Ziel des Kunden zu erfahren     
* Versuche zu erfahren wer alle Stakeholder des Produktes sind  
* Versuche zu erfahren welche End Nutzer es gibt und wie diese [denken](https://www.oreilly.com/library/view/97-things-every/9780596809515/ch03.html)
* Der Kunde bestenfalls User sollte die Arbeit der letzten Wochen sehen und kommentieren (Sprint review)
  
### Transparent Arbeiten
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

### Programmieren
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


# Was ich vor dem Einchecken oder während des Reviews beachte
## Modellierung
* Versuche Kopplung zu vermeiden
* Es muss in den unteren Methoden exceptions geworfen werden und in den oberen aufgefangen.
* Niemals Fehler weiter werfen (throw in catch statement)
* https://de.wikipedia.org/wiki/Gesetz_von_Demeter
## OOP
* Benutze Polymorphismus statt mit if einen typ abzufragen 
* Wenn OOP dann die [Wirklichkeit](https://de.wikipedia.org/wiki/Fachlichkeit) versuchen zu [analysieren und abzubilden](https://de.wikipedia.org/wiki/Objektorientierte_Analyse_und_Design#Objektorientierte_Analyse) und [Design Patterns](https://en.wikipedia.org/wiki/Software_design_pattern) verwenden.
* Datenkapselung beachten
* Nicht zu tief Vererben
* https://de.wikipedia.org/wiki/Command-Query-Separation
* https://en.wikipedia.org/wiki/SOLID

<details>
  <summary>Single Responsebility</summary>
A function / class should do one thing. Or better: It should have only one reason to change.
  
**Bad**
  
<p>

```c#
public void CheckInPerson(Person person)
{
    Booker.CheckIn(person.ID);
    Payment.CheckCreditCard(person.ID);
    ...
}
```
</details>

<details>
  <summary>Open/Close Principlee</summary>
  
Closed for modifiaction but open for extension
[Example](https://dotnetcoretutorials.com/2019/10/18/solid-in-c-open-closed-principle/)

</details>

<details>
  <summary>Liskov Substitution Principle</summary>
  
If S is a subtype of T, then objects of type T may be replaced with objects of type S (i.e., objects of type S may substitute objects of type T) without altering any of the desirable properties of that program (correctness, task performed, etc.).

**Bad**
  
<p>

```c#
class Rectangle
{
    protected double Width = 0;
    protected double Height = 0;

    public Drawable Render(double area)
    {
        // ...
    }

    public void SetWidth(double width)
    {
        Width = width;
    }

    public void SetHeight(double height)
    {
        Height = height;
    }

    public double GetArea()
    {
        return Width * Height;
    }
}

class Square : Rectangle
{
    public double SetWidth(double width)
    {
        Width = Height = width;
    }

    public double SetHeight(double height)
    {
        Width = Height = height;
    }
}
```

**Good**
  
<p>

```c#
abstract class ShapeBase
{
    protected double Width = 0;
    protected double Height = 0;

    abstract public double GetArea();

    public Drawable Render(double area)
    {
        // ...
    }
}

class Rectangle : ShapeBase
{
    public void SetWidth(double width)
    {
        Width = width;
    }

    public void SetHeight(double height)
    {
        Height = height;
    }

    public double GetArea()
    {
        return Width * Height;
    }
}

class Square : ShapeBase
{
    private double Length = 0;

    public double SetLength(double length)
    {
        Length = length;
    }

    public double GetArea()
    {
        return Math.Pow(Length, 2);
    }
}
```

</details>

<details>
  <summary>Interface Segregation Principle</summary>
Clients should not be forced to depend upon interfaces that they do not use.
  
**Bad**
  
<p>

```c#
public interface IEmployee
{
    void Work();
    void Eat();
}

public class Human : IEmployee
{
    public void Work()
    {
        // ....working
    }

    public void Eat()
    {
        // ...... eating in lunch break
    }
}

public class Robot : IEmployee
{
    public void Work()
    {
        //.... working much more
    }

    public void Eat()
    {
        //.... robot can't eat, but it must implement this method
    }
}
```

**Good**
  
<p>

```c#
public interface IWorkable
{
    void Work();
}

public interface IFeedable
{
    void Eat();
}

public interface IEmployee : IFeedable, IWorkable
{
}

public class Human : IEmployee
{
    public void Work()
    {
        // ....working
    }

    public void Eat()
    {
        //.... eating in lunch break
    }
}

// robot can only work
public class Robot : IWorkable
{
    public void Work()
    {
        // ....working
    }
}
```
</details>


<details>
  <summary>Dependency Inversion Principle</summary>

    High-level modules should not depend on low-level modules. Both should depend on abstractions.
    Abstractions should not depend upon details. Details should depend on abstractions.

  
**Bad**
  
<p>

```c#
public abstract class EmployeeBase
{
    protected virtual void Work()
    {
        // ....working
    }
}

public class Human : EmployeeBase
{
    public override void Work()
    {
        //.... working much more
    }
}

public class Robot : EmployeeBase
{
    public override void Work()
    {
        //.... working much, much more
    }
}

public class Manager
{
    private readonly Robot _robot;
    private readonly Human _human;

    public Manager(Robot robot, Human human)
    {
        _robot = robot;
        _human = human;
    }

    public void Manage()
    {
        _robot.Work();
        _human.Work();
    }
}
```

**Good**
  
<p>

```c#
public interface IEmployee
{
    void Work();
}

public class Human : IEmployee
{
    public void Work()
    {
        // ....working
    }
}

public class Robot : IEmployee
{
    public void Work()
    {
        //.... working much more
    }
}

public class Manager
{
    private readonly IEnumerable<IEmployee> _employees;

    public Manager(IEnumerable<IEmployee> employees)
    {
        _employees = employees;
    }

    public void Manage()
    {
        foreach (var employee in _employees)
        {
            _employee.Work();
        }
    }
}
```
</details>

details>
  <summary>Don’t repeat yourself (DRY)</summary>
[Don't repeat yourself](https://de.wikipedia.org/wiki/Don%E2%80%99t_repeat_yourself) aber nicht übertreiben https://en.wikipedia.org/wiki/Rule_of_three_(computer_programming)
  
**Bad**
  
<p>

```c#
public List<EmployeeData> ShowDeveloperList(Developers developers)
{
    foreach (var developers in developer)
    {
        var expectedSalary = developer.CalculateExpectedSalary();
        var experience = developer.GetExperience();
        var githubLink = developer.GetGithubLink();
        var data = new[] {
            expectedSalary,
            experience,
            githubLink
        };

        Render(data);
    }
}

public List<ManagerData> ShowManagerList(Manager managers)
{
    foreach (var manager in managers)
    {
        var expectedSalary = manager.CalculateExpectedSalary();
        var experience = manager.GetExperience();
        var githubLink = manager.GetGithubLink();
        var data =
        new[] {
            expectedSalary,
            experience,
            githubLink
        };

        render(data);
    }
}
```

**Good**
  
<p>

```c#
public List<EmployeeData> ShowList(Employee employees)
{
    foreach (var employee in employees)
    {
        render(new[] {
            employee.CalculateExpectedSalary(),
            employee.GetExperience(),
            employee.GetGithubLink()
        });
    }
}
```
</details>

* Obere Klassen sollten eine hohe Abstraktion haben. Das "Was" sollte man dort eher als das "Wie" erkennen.  
* Versuche den Code [referenzielle transparent](https://de.wikipedia.org/wiki/Referenzielle_Transparenz) zu halten, um später leichter parallelisieren zu können und um nicht den Überblick zu verlieren.
## Funktional
=> Aus oben genannten Gründen ist es manchmal ratsam deklarativ, [funktional](https://de.wikipedia.org/wiki/Funktionale_Programmierung) statt OOP imperativ zu Programmieren. Man kann beide paradigmen miteinander in C# kombinieren.
* Funktionen sollten in Funktionen mit nebeneffekten und ohne Nebeneffekte getrennt werden
* Funktionen mit Nebeneffekten sollten zwischen denen ohne Nebeneffekten stehen (Dependency Rejection)
* Spreche durch entsprechende Funktionen in der Domänen Sprache
* Unveränderliche Daten: Benutze immer generatoren statt iteratoren
* Keine Rekursion gibt nur stack probleme. Lieber unendliche Sequenzen erstellen und [takeWhile](https://docs.microsoft.com/de-de/dotnet/api/system.linq.enumerable.takewhile?view=net-5.0) benutzen (durch falsche Abbruchbedingung ausgelöster unendlicher Lauf ist bei Beiden nicht zu vermeiden)
## Syntaktisches
* Immer in englisch programmieren 
* Style guide beachten wenn es einen gibt (wie in allen zen-Lab Projekten) sonst [C# Code Conventions](https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)
* Alles sollte von links nach rechts wie Fließtext lesbar sein (kein horizontal alignment, kein GOTO, keine tiefe Verschachtellung, die man von Innen nach links außen lesen muss: AddOne(CastValue(ReadFromConsole())))
* Benennung von Variablen, Methoden, Klassen
* Keine Hardcoded Strings (wenn dann abstrahieren und am Anfang der Klasse oder in einem eigenen Bereich)
* Keine Klassen in Klassen (immer ein File pro Klasse)
* Namespaces sollten mit Verzeichnissen übereinstimmen
* Nicht im Quellcode Kommentieren (lieber sprechende Namen verwenden) außer Externes Framework ist verwirrend in der Benutzung
* Dafür über public class members mit xml kommentieren (um später die doku automatisch erstellen zu können)
* Die Reihenfolge von "Class Members" sollte überall gleich sein 
* Abstraktionslevel in Methoden sollte gleich sein
* Klassen und Methoden sollten nicht zu groß werden (Single Responsebility)
* Linkslesbarkeit und wenige Parameter sind am besten
## Sonstiges
* Datentypen sind nicht unendlich, Mathe setzt dies aber oft voraus. Ist dies in der Anwendung ein Problem? (manchmal besser domänen spezifische typen verwenden)
* Könnten die Daten die verwendet werden sehr groß werden? Können sie überhaupt in den Arbeitsspeicher? Generatoren (also funktionale Programmierung) könnte hier helfen 
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
## Speziell im Review
* Reviewe auch die Changelog-Kommentare
* Reviewe auch die Tests (nach verständlichkeit und Äquivalenzklassenabdeckung)
* Reviewe ggf. passende Doku
* Lasse einen Reviewer allein durch das changeset gehen (und finde so heraus, ob jemand sich auch allein zurechtfindet)

