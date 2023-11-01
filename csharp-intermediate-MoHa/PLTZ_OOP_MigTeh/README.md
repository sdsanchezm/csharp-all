# Pl OOP MigTeh

## Access modifiers

- [https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers]
- public: The type or member can be accessed by any other code in the same assembly or another assembly that references it. The accessibility level of public members of a type is controlled by the accessibility level of the type itself.
- **private**: The type or member can be accessed only by code in the same class or struct.
    - privates are small methods, like internal tools
- protected: The type or member can be accessed only by code in the same class, or in a class that is derived from that class.
- internal: The type or member can be accessed by any code in the same assembly, but not from another assembly. In other words, internal types or members can be accessed from code that is part of the same compilation.
- protected internal: The type or member can be accessed by any code in the assembly in which it's declared, or from within a derived class in another assembly.
- private protected: The type or member can be accessed by types derived from the class that are declared within its containing assembly.

- [**IMPORTANT**] the base-class should contain only the properties that all sub-classes have.

## Constructors

- from the MS documentation [https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors]
    - Instance fields are set to 0. This is typically done by the runtime.
    - Field initializers run. The field initializers in the most derived type run.
    - Base type field initializers run. Field initializers starting with the direct base through each base type to System.Object.
    - Base instance constructors run. Any instance constructors, starting with Object.Object through each base class to the direct base class.
    - The instance constructor runs. The instance constructor for the type runs.
    - Object initializers run. If the expression includes any object initializers, those run after the instance constructor runs. Object initializers run in the textual order.

## get and set

- `{get; set;}`
- >The set keyword defines an accessor method in a property or indexer that assigns a value to the property or the indexer element
    - [https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/set]
- >The get keyword defines an accessor method in a property or indexer that returns the property value or the indexer element.
    [https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/get]

- Example
    ```cs
    class TimePeriod
    {
        private double _seconds;

        public double Seconds
        {
            get { return _seconds; }
            set { _seconds = value; }
        }
    }
    ```

## Records

- `public record UserGeneralRecord(int id, string name, bool isActive);`
    - 
        ```cs
        var record1 = new UserGeneralRecord(id: 2, name: "jara", isActive: false);
        var record2 = new UserGeneralRecord(id: 2, name: "jara", isActive: false);
        Console.WriteLine(record1 == record2); // True
        ```
- Las clases funcionan como referencia, si comparamos 2 objetos iguales, no van a ser los mismos por que son dos elementos differentes en memoria.
- Registro, funciona por valor, dos instancias de un registro con los mismos valores, seran iguales.


## 1. Encapsulation Methods

- Example with properties (get and set)
    ```cs
            private string _name;
            public string name 
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value.Trim();
                }
            
            }
    ```

- Example 2
    ```cs
        public string SecretIdentity
        {
            get
            {
                return $"{name} ({SecretIdentity})";
            }
        }
    ```

## 2. Inheritance 

- example
    ```cs
    internal class UserStudent : UserGeneral
    {

        public string StudentActivity(string action)
        {
            return $"{name} has completed: {action}";
        }
    }
    ```

## 3. Abstraction

- The abstract modifier indicates that the thing being modified has a missing or incomplete implementation.
    - [https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract]
- Cannot create an abstract method if the class (in which is defined) is not abstract.
- when inheriting an abstract class, an implementation must be completed, otherwise will get an error
    - here, the parent modifier should be `abstract`
    - here, the child modifier should be `override`
- abstract forces us to implement in the inherited class
    - the inherited class must implement the method, using the `override` keyword

```cs

    internal abstract class UserAdmin
    {
        public abstract string name { get; set; }
        public abstract string SaveTheWorld();
    }
```

```cs
    public override string SaveTheWorld()
    {
        //throw new NotImplementedException();
        return $"{SecretIdentityUsername} is {username} and has saved the world!";
    }
```


## 4. Polymorphism

- Documentation: [https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/polymorphism]
    - >At run time, objects of a derived class may be treated as objects of a base class in places such as method parameters and collections or arrays. When this polymorphism occurs, the object's declared type is no longer identical to its run-time type. (source: above)
    - >Base classes may define and implement virtual methods, and derived classes can override them, which means they provide their own definition and implementation. At run-time, when client code calls the method, the CLR looks up the run-time type of the object, and invokes that override of the virtual method. (source: above)

- Here, the **parent** class keyword should be `virtual`
- here the **child** class keyword is `override`

- Example:
    ```cs
        public virtual string SaveMars() 
        {
            return $"{name} has saved Mars!";
        }
    ```
    ```cs
        public override string SaveMars()
        {
            //return base.SaveMars();
            return $"{name} ({SecretIdentityUsername}) has saved Mars from UserGeneral!";
        }
    ```

### Summary Abstract vs Virtual

- **Virtual** methods have an implementation and provide the derived classes with the option of overriding it. 
- **Abstract** methods do not provide an implementation and force the derived classes to override the method.
- So, **abstract** methods have no actual code in them, and (non-abstract) subclasses HAVE TO override the method. 
- **Virtual** methods can have code, which is usually a default implementation of something, and any subclasses CAN override the method using the `override` modifier and provide a custom implementation



### Interfaces

- Documentation [https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface]
    - >An interface defines a contract. Any class or struct that implements that contract must provide an implementation of the members defined in the interface. An interface may define a default implementation for members. (Source Above)
    - >It may also define static members in order to provide a single implementation for common functionality. Beginning with C# 11, an interface may define static abstract or static virtual members to declare that an implementing type must provide the declared members. (Source Above)
    - >Typically, static virtual methods declare that an implementation must define a set of overloaded operators. (Source Above)
- Named with an I at the beggining
- a generic, could be: `IList<T>`
- is a good way to lower the coupling
- The accessor method `get` and `set`, are required to implement interfaces correctly, otherwise the IDE will say "does not implement interface member"
- Example:
    - 
    ```cs
    namespace classes1.Interfaces
    {
        internal interface IUser
        {
            int userid { get; set; }
            string name { get; set; }
            string SecretIdentityUsername { get; set; }

        }
    }
    ```
    ```cs
    namespace classes1
    {
        internal class PrintInterface
        {
            public void PrintInterfaceIUser(IUser user)
            {
                Console.WriteLine($"userid: {user.userid}");
                Console.WriteLine($"secret Identity: {user.SecretIdentityUsername}");
                Console.WriteLine($"name: {user.name}");
            }
        }

    }
    ```

    ```cs
            
            var printInfo = new PrintInterface();
            printInfo.PrintInterfaceIUser(student1);
            printInfo.PrintInterfaceIUser(person1);
    ```

- Interfaces allows to implement multiple interfaces
- Interface allows to implement since C# 8
- Is the default method used in dependency injection











