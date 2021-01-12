
# Consider while coding or reviewing

## Names
<details>
  <summary>Call things by real name</summary>
  
**Bad**

<p>

```c#
public class Orders
{
    private List<int> _ns;

    public void GetNums(List<int> number)
    {
        _ns = number;
    }
}
```
**Good**

```c#
public class Order
{
    private List<int> _numbers;
    
    public void SetNumbers(List<int> numbers)
    {
        _numbers = numbers;
    }
}
```
</details>
<details>
  <summary>Dense language (short but with much information)</summary>
  
**Bad**

<p>

```c#
public class Order
{
    private List<int> _orderNumbers;
    
    public void SetOrderNumbers(List<int> orderNumbers)
    {
        _orderNumbers = orderNumbers;
    }
}
```
**Good**

```c#
public class Order
{
    public List<int> Numbers {get; set;}
}
```
</details>

## Structure
<details>
  <summary>Avoid  coupling</summary>
  
  [Couplig](https://en.wikipedia.org/wiki/Coupling_(computer_programming))

</details>

<details>
  <summary>Avoid deep nesting</summary>
  
**Bad**

<p>

```c#
public long Fibonacci(int n)
{
    if (n < 50)
    {
        if (n != 0)
        {
            if (n != 1)
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
            else
            {
                return 1;
            }
        }
        else
        {
            return 0;
        }
    }
    else
    {
        throw new System.Exception("Not supported");
    }
}
```
**Good**

```c#
public long Fibonacci(int n)
{
    if (n == 0)
    {
        return 0;
    }

    if (n == 1)
    {
        return 1;
    }

    if (n > 50)
    {
        throw new System.Exception("Not supported");
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
```
</details>


<details>
  <summary>Avoid hard coded variable annotations inside the code</summary>
  
**Bad**

<p>

```c#
if (user == "admin"){

}
```
**Good**

```c#
const string ADMIN = "Admin"
if (user == ADMIN){
}
```

**Better**
```c#

if (user == UserRoles.Admin.Name) //EnumClass
{
}
```
</details>

<details>
  <summary>Check NULLS at the outside of your code. Better to avoid them beorehand</summary>
  
**Bad**

<p>

```c#
public void CheckInPerson(Person person)
{
    Booker.CheckIn(person.ID);
}
```
**Good**

```c#
public void CheckInPerson(Person person)
{
    if(person == null)
    {
      throw new ArgumentNullException();
    }
    Booker.CheckIn(person.ID);
}
```

**Better**
```c#

public void CheckInPerson(Person person = new Person())
{
    Booker.CheckIn(person.ID);
}
```
</details>


<details>
  <summary>Avoid Side Effects with Layered Architecture</summary>
There are functions with side effects (A side effect could be writing to a file or DB or modifying some global variable).
It is better to seperate them from pure functions. And seperate them to the outside of the architecture (their are the parts
  of the software which is most likely to change).
  
**Bad**
  
<p>

```c#
public void CheckInPerson(Person person)
{
    Booker.CheckIn(person.ID);
    Console.WriteLine(person.ID);
    ...
}
```
</details>

<details>
  <summary>Don't use Singleton Pattern</summary>

    * They are generally used as a global instance.But there hiding dependencies instead of exposing them through interfaces.  
    * Faking them out in tests is not easy  
    * They carry state around for the lifetime of the application (so ordered tests should be nessecary)  

</details>

<details>
  <summary>Avoid more then one parameter</summary>
  
**Bad**
  
<p>

```c#
public void CreateMenu(string title, string body, string buttonText, bool cancellable)
{
    // ...
}
```

**Good**

```c#
public class MenuConfig
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string ButtonText { get; set; }
    public bool Cancellable { get; set; }
}

var config = new MenuConfig
{
    Title = "Foo",
    Body = "Bar",
    ButtonText = "Baz",
    Cancellable = true
};

public void CreateMenu(MenuConfig config)
{
    // ...
}
```
</details>


<details>
  <summary>Use encapsulation</summary>
  
**Bad**
  
<p>

```c#
public class Save
{
    public int Treasure;
}
```

**Good**
  
<p>

```c#
public class Save
{
    public int Treasure {get; }
    public Save(int treasure){
      Treasure = treasure;
    }
}
```

</details>

<details>
  <summary>Use method chaining</summary>
  
[Fluent API](https://de.wikipedia.org/wiki/Fluent_Interface)


</details>


<details>
  <summary>Prefer composition over inheritance</summary>
  
Inheritance couples the code strongly and you can't read it very well.

Only use inheritance when you can reuse much code. Then the code doublication outnumbers the readablility.


</details>


## Design Principles

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

<details>
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

<details>
  <summary>Command Querry Seperation</summary>
[CQS](https://de.wikipedia.org/wiki/Command-Query-Separation)

  </details>
  
  <details>
  <summary>Referential transparency</summary>
[referential transparency](https://en.wikipedia.org/wiki/Referential_transparency)

  </details>


</details>
<details>
  <summary>OOP</summary>
Try to [analyse](https://en.wikipedia.org/wiki/Object-oriented_analysis_and_design) and depict [reality](https://de.wikipedia.org/wiki/Fachlichkeit). Additionally some problems can be solved by [Design Patterns](https://en.wikipedia.org/wiki/Software_design_pattern) verwenden.

  Advantages:  
  * Good structure of classes that you no from the domain
  Disadvantages:  
  * Hard to parallise
  * Many bugs through null values and state changes
  * You must use (non domain) design patterns with many classes
  * Not declarive
  
  See: [FizzBuzzEnterprise](https://github.com/EnterpriseQualityCoding/FizzBuzzEnterpriseEdition)
  </details>

<details>
  <summary>Functional Programming</summary>
You can programm functional, means with another declarative [paradigm](https://en.wikipedia.org/wiki/Programming_paradigm) in C#. 

  Advantages:  
  * Declarative and dense at highest level
  * Easy to parallise
  * Easy to test (many single functions without side effects)
  * Design Patterns are single liners
 
  Disadvantages:  
  * Sometimes performance
  * High learning curve: Many programmers don't know how to use expressions
  
  </details>


## Concurrency

<details>
  <summary>Use Async await</summary>
  Asynchronus calls are not easy to understand. You should plan this with other team members.
 
 ### Summary of Asynchronous Programming Guidelines

|        Name       |                    Description                    |           Exceptions          |
|-------------------|---------------------------------------------------|-------------------------------|
| Avoid async void  | Prefer async Task methods over async void methods | Event handlers                |
| Async all the way | Don't mix blocking and async code                 | Console main method           |
| Configure context | Use `ConfigureAwait(false)` when you can          | Methods that require con­text  |

### The Async Way of Doing Things

|              To Do This ...              |    Instead of This ...     |       Use This       |
|------------------------------------------|----------------------------|----------------------|
| Retrieve the result of a background task | `Task.Wait or Task.Result` | `await`              |
| Wait for any task to complete            | `Task.WaitAny`             | `await Task.WhenAny` |
| Retrieve the results of multiple tasks   | `Task.WaitAll`             | `await Task.WhenAll` |
| Wait a period of time                    | `Thread.Sleep`             | `await Task.Delay`   |

### Know Your Tools

There's a lot to learn about async and await, and it's natural to get a little
disoriented. Here's a quick reference of solutions to common problems.

**Solutions to Common Async Problems**

|                     Problem                     |                                      Solution                                     |
|-------------------------------------------------|-----------------------------------------------------------------------------------|
| Create a task to execute code                   | `Task.Run` or `TaskFactory.StartNew` (not the `Task` constructor or `Task.Start`) |
| Create a task wrapper for an operation or event | `TaskFactory.FromAsync` or `TaskCompletionSource<T>`                              |
| Support cancellation                            | `CancellationTokenSource` and `CancellationToken`                                 |
| Report progress                                 | `IProgress<T>` and `Progress<T>`                                                  |
| Handle streams of data                          | TPL Dataflow or Reactive Extensions                                               |
| Synchronize access to a shared resource         | `SemaphoreSlim`                                                                   |
| Asynchronously initialize a resource            | `AsyncLazy<T>`                                                                    |
| Async-ready producer/consumer structures        | TPL Dataflow or `AsyncCollection<T>`                                              |

### Async and Await Guidelines

Read the [Task-based Asynchronous Pattern (TAP) document](http://www.microsoft.com/download/en/details.aspx?id=19957).
It is extremely well-written, and includes guidance on API design and the proper
use of async/await (including cancellation and progress reporting).

There are many new await-friendly techniques that should be used instead of the
old blocking techniques. If you have any of these Old examples in your new async
code, you're Doing It Wrong(TM):

|        Old         |                 New                  |                          Description                          |
|--------------------|--------------------------------------|---------------------------------------------------------------|
| `task.Wait`        | `await task`                         | Wait/await for a task to complete                             |
| `task.Result`      | `await task`                         | Get the result of a completed task                            |
| `Task.WaitAny`     | `await Task.WhenAny`                 | Wait/await for one of a collection of tasks to complete       |
| `Task.WaitAll`     | `await Task.WhenAll`                 | Wait/await for every one of a collection of tasks to complete |
| `Thread.Sleep`     | `await Task.Delay`                   | Wait/await for a period of time                               |
| `Task` constructor | `Task.Run` or `TaskFactory.StartNew` | Create a code-based task                                      |
 
 </details> 
 
## Comments


<details>
  <summary>Don't comment out, remove instead</summary>
  
**Bad**
  
<p>

```c#
// Todo: remove
// public void CreateMenu(string title, string body, string buttonText, bool cancellable)
// {
//      
// }
```

</details>

