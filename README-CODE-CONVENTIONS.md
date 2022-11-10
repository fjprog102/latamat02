## Conventions
- Class Names
DO use PascalCasing for class names and method names.
```

public class ClientActivity
{
    public void ClearStatistics()
    {
        //...
    }
    public void CalculateStatistics()
    {
        //...
    }
}
```

- Variable Names
DO use camelCasing for local variables and method arguments.
```

public class UserLog
{
    public void Add(LogEvent logEvent)
    {
        int itemCount = logEvent.Items.Count;
        // ...
    }
}
```

- No Underscores
DO NOT use Underscores in identifiers.
Exception: you can prefix private static variables with an underscore.
```
// Correct

public DateTime clientAppointment;
public TimeSpan timeLeft;

 
// Avoid
public DateTime client_Appointment;
public TimeSpan time_Left;
 
// Exception

private DateTime _registrationDate;
```

- Type Names
DO use predefined type names instead of system type names like Int16, Single, UInt64, etc
```

// Correct
string firstName;
int lastIndex;
bool isSaved;
 
// Avoid
String firstName;
Int32 lastIndex;
Boolean isSaved;
```

- Noun Class Names
DO use noun or noun phrases to name a class.
```

public class Employee
{
}
public class BusinessLocation
{
}
public class DocumentCollection
{
}
```

- File Names
DO name source files according to their main classes. Exception: file names with partial classes reflect their source or purpose, e.g. designer, generated, etc.
```

// Located in Task.cs
public partial class Task
{
    //...
}
// Located in Task.generated.cs
public partial class Task
{
    //...
}
```

- Namespaces
DO organize namespaces with a clearly defined structure
```
// Examples
namespace Company.Product.Module.SubModule
namespace Product.Module.Component
namespace Product.Layer.Module.Group
```

- Curly Brackets
DO vertically align curly brackets.
```

// Correct
class Program
{
    static void Main(string[] args)
    {
    }
}
```

- Member Variables
DO declare all member variables at the top of a class, with static variables at the very top.
```

// Correct
public class Account
{
    public static string BankName;
    public static decimal Reserves;
 
    public string Number {get; set;}
    public DateTime DateOpened {get; set;}
    public DateTime DateClosed {get; set;}
    public decimal Balance {get; set;}
 
    // Constructor
    public Account()
    {
        // ...
    }
}
```