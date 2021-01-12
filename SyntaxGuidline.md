#Guidline for Syntax in C# 
(most is helpfull in other languages as well)



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




