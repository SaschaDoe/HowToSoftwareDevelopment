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
