# C# factory sample

Follow the `open close` principle, this example shows how functionality can be easily extended through the use of reflection,

The requirement is to create a calculator that supports basic math operations such as: addition (+), subtraction (-), multiplication (*) and division (/), but if we want to add a new operation i.g. modulus (%) the changes we will have to make in the code will be minor.

### Implemntation
The idea is to define a group of classes based on an interface, and then our factory will scan that group and find the desired class according to the `type` that is sent as an argument, and then it creates an instance.

The following `AddOperation` class implements `ICalc` interface

```C#
public class AddOperation : ICalc
{
    public double Calc(double x, double y)
    {
        return x + y;
    }

    public string GetSign()
    {
        return "+";
    }

    public string GetName()
    {
        return "Addition";
    }
}
```

The `GetOperation` method of the factory gets a type and returns an object

```C#
public class OperationFactory: IOperationFactory
{
    public ICalc GetOperation(string type)
    {
        ICalc operation = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => typeof(ICalc).IsAssignableFrom(p) && p.IsClass && !p.IsInterface && !p.IsAbstract)
            .Select(t => (ICalc)Activator.CreateInstance(t))
            .FirstOrDefault(x => x.GetSign() == type);

        if (operation == null)
        {
            throw new Exception("Operation not suported");
        }

        return operation;
    }
}
```

Next, if we wants to add the new operation, we just add it as the following and thats it!

```C#
public class ModOperation : ICalc
{
    public double Calc(double x, double y)
    {
        return x % y;
    }

    public string GetSign()
    {
        return "%";
    }

    public string GetName()
    {
        return "Modulus";
    }
}
```
