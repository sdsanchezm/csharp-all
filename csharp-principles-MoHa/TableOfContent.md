# chsarp-principles Notes

## Table of Contents

- [chsarp-principles Notes](#chsarp-principles-notes)
  - [Table of Contents](#table-of-contents)
  - [Core concepts](#core-concepts)
    - [C# app](#c-app)
    - [namespaces](#namespaces)
    - [VS Community](#vs-community)
    - [Variables and constants](#variables-and-constants)
    - [Primitive Types:](#primitive-types)
    - [Non-Primitive Types](#non-primitive-types)
    - [Overflowing](#overflowing)
    - [Scope](#scope)
  - [Reference Types and Value Types](#reference-types-and-value-types)
    - [String Templates](#string-templates)
    - [Type conversion](#type-conversion)
  - [Operators](#operators)
    - [Arithmetic](#arithmetic)
    - [Logical](#logical)
    - [Assignment](#assignment)
    - [Logical](#logical)
    - [Bitwise Operators](#bitwise-operators)
  - [Classes](#classes)
    - [Type of classes](#type-of-classes)
    - [create a class](#create-a-class)
    - [create an object](#create-an-object)
    - [structs](#structs)
    - [enums](#enums)
  - [Types ](#types-)
  - [Arrays](#arrays)
    - [Lists](#lists)
  - [Loops and control Flows](#loops-and-control-flows)
  - [DateTime](#datetime)
    - [Timespans](#timespans)
  - [Strings and Text](#strings-and-text)
  - [Lambda Functions](#lambda-functions)
  - [Local functions](#local-functions)
  - [Tuples](#tuples)
  - [null conditional operator](#null-conditional-operator)
  - [Anonymous Functions (Anonymous methods)](#anonymous-functions-anonymous-methods)
      - [Stringbuilder](#stringbuilder)
  - [SystemIO ](#systemio-)
    - [File and FileInfo](#file-and-fileinfo)
  - [Directory and DirectoryInfo](#directory-and-directoryinfo)
  - [Path](#path)
  - [Procedural Programming](#procedural-programming)
  - [Implicit using ](#implicit-using-)
  - [csproj file](#csproj-file)
  - [Achronyms](#achronyms)
  - [VS shortcuts](#vs-shortcuts)
  - [Exercises](#exercises)
    - [Exercises](#exercises)
      - [Array exercises](#array-exercises)
      - [Control Flow Exercises](#control-flow-exercises)
      - [Control Flow Loops](#control-flow-loops)
      - [Working with text](#working-with-text)
      - [Working with Text (Exercises)](#working-with-text-exercises)
      - [Working with Files](#working-with-files)


## Core concepts

### C# app

- is full of classes responsible for process data, many other functyions

### namespaces

- is a container for related classes
- namepsaces working with security, for databases, etc
- a dll (dinamyc linked library) or a .exe groups multiple namespaces


### VS Community

- a Solution can have 1 or more projects
- view solution explorer: view > solution explorer
- 4 items
    - Properties
        - aseemblyInfo.cs
    - references
    - App.config
    - Program.cs
        - it the file where the code is written

### Variables and constants

- `int number;`
- `int Number = 1;`
- `const float Pi = 3.14f;` // this is a constant
- C# is case sensitive
- can't start with a number
- has to be 1 word
- a reserved work can be used as a name but with a @, example: `@int`
- use meaningful names
- Naming conventions:
    - Camel case: firstName // used in local variables
    - Pascal Case: FirstName // used in constants
    - Hungarian Notation: strFirstName // not used in c#

### Primitive Types:

- byte (1 byte, Byte)
- short (2 bytes, Int16)
- int (4 bytes, Int32)
- long (8 bytes, Int64)
- float (4 bytes, Single)
- double (8 byte, Double) // this is the default for floating point numbers
- decimal (16 bytes, Decimal)
- char (char, 2 Byte)
- bool (1 byte, 1)

-Example of declarations of decimals and floats:
    - `float number = 1.2f;`
    - `decimal number = 1.2m;`

- the compiler treats floating points as double, so they need to be declared like: `float x = 20.96f` to be treated as float

### Non-Primitive Types

- String
- Array
- Enum
- Class

### Overflowing

- when a variable is assigned and surpace theit capacity, example:
- `byte number = 255;` when a byte has only 254, so if print number, it will be `0`
- Solution:
    ```csharp
    checked 
    {
        byute number = 25;
        number + number + 1;
    }
    ```

### Scope

- 
    ```cs
            // scoope testing
            {
                byte a = 1;
                Console.WriteLine(a);
                //Console.WriteLine(b); // not accessible here
                //Console.WriteLine(c); // not accessible here
                    {
                    byte b = 2;
                    Console.WriteLine(a);
                    Console.WriteLine(b);
                    //Console.WriteLine(c); // not accessible here
                    {
                        byte c = 3;
                        Console.WriteLine(a);
                        Console.WriteLine(b);
                        Console.WriteLine(c);
                    }
                }
            }
    ```

## Reference Types and Value Types

- Primitive Types: 
    - int
    - char
    - float
    - bool
- Non-Primitive Types:
    - Classes
    - Structures
    - Arrays (map to System.Array class)
    - Strings (map to System.String class)

- in C# there are 2 main types, from which we create new types:
    - Structures
        - Like all primitive types
        - customer Structures
    - Classes
        - Arrays
        - Strings
        - Custom Classes
    - these 2 treat memory differently
    - Structures are Value Types
        - Allocated in Stack
        - Memory allocation is automatic
        - if it's out of scope, immediately removed
    - Classes are Reference Types
        - Need to allocate memory for these objects
        - Memory allocated on heap
        - Garbage collector by CLR ()

- Examples:
    ```cs
    class Person
    {
        public int Age;
    }
    class Program
    {
        public static void Main(string[] args)
        {
            var a = 12;
            var b = a;
            b++;
            // a and b are independent, because they are different positions in memory, point to different mem address
            // this is different from the logic of classes, classes are reference, so they point to the same memory address
            Console.WriteLine("a: {0} - b: {1}", a, b); // a: 12 - b: 13 


            var array1 = new int[3]{ 2, 4, 5};

            var array2 = array1;

            array2[0] = 99;

            // here, array1 is also modified because they point ot the same memory
            Console.WriteLine("first element: {0}", array1[0]); // 99

            // Another example
            var number = 1;
            Increment1(number);
            // here number is not changing because is value type
            Console.WriteLine("number: {0}", number); // number: 1

            var person1 = new Person();
            person1.Age = 40;
            MakeOld1(person1);
            // here age value is chaning because is by reference
            Console.WriteLine("person1.age: {0}", person1.Age); // person1.Age: 50

        }

        public static void Increment1(int number)
        {
            number += 10;
        }

        public static void MakeOld1(Person person)
        {
            person.Age += 10;
        }
    }
    ```


- 
    ```cs
        int count = 10;
        float price1 = 2.34f;
        char character = 'A';
        string lastname = "Sanc";
        bool isWorking = false;

        Console.WriteLine(count);
        Console.WriteLine(price1);
        Console.WriteLine(character);
        Console.WriteLine(lastname);
        Console.WriteLine(isWorking);
    ```

    - `var` makes declaration easier, detects the data type

    ```cs
            var count3 = 10; // System.Int32
            var price3 = 2.34f; // System.Single
            var character3 = 'A'; // System.Char
            var lastname3 = "Sanc"; // System.String
            var isWorking3 = false; // System.boolean

            Console.WriteLine(count3);
            Console.WriteLine(price3);
            Console.WriteLine(character3);
            Console.WriteLine(lastname3);
            Console.WriteLine(isWorking3);
    ```


### String Templates

- 
    ```cs
    // string templates (format string)
        Console.WriteLine("{0} - {1}", byte.MinValue, byte.MaxValue);
        Console.WriteLine("{0} - {1}", float.MinValue, float.MaxValue); 
    ```

### Type conversion

- some methods
    `ToByte()`
    `ToInt16()`
    `ToInt32()`
    `ToInt64()`

    - implicit conversion (if there is no data lost,, the compiler do it automatically)
        ```cs
        int b = 1;
        float f = i;
        ```

- Casting (explicit conversion):

    ```cs
    int i = 1;
    byte b = (byte) i;
    ```
    - data loss casting:
        ```cs
        var number = "1234";
        int i = (int) number;
        ```



## Operators

### Arithmetic

- add
- substract
- multiply
- divide
- increment
    - a++ (incremented by 1)
    - in `int b = ++a` a is first incremented and then assigned
    ```cs
                int a = 1;
            int b = a++; // first assign, then increments
            Console.WriteLine("==");
            Console.WriteLine("a: {0} ", a); // 2
            Console.WriteLine("b: {0} ", b); // 1
            
            b = ++a; // first increment, then assign
            Console.WriteLine("==");
            Console.WriteLine("a: {0} ", a); // 3 
            Console.WriteLine("b: {0} ", b); // 3
            var x = 10;
            var y = 3;
            Console.WriteLine((float)x / (float)y); // with casting 3.333
            Console.WriteLine(x / y); // with no casting 3
            Console.WriteLine(x > y);
    ```


### Logical

- `==`
- `!=`
- `>`
- `>=`
- `<`
- `<=`

### Assignment

- `=`
- `+=`
- `-=`
- `*=`
- `/=`

### Logical

- `&&`
- `||`
- `!`

### Bitwise Operators

- `&`
- `|`


## Classes

### Type of classes

- Instance methods
    - need to isntantiate a class to use the method

- Static Methods
    - no need to instantiate the class


### create a class
- 
    ```cs
    public class Person 
    {
        public string Name;
    }
    ```

-
    ```cs
    public class calculator
    {
        public int sum1 ( int a, int b )
        {
            return a + b;
        }
    }
    ```


### create an object

- 
    ```cs
    Person person = new Person();
    ```
    - the `new` operator (keyword), allocates memory automatically and also it manage the deallocation of the memory
    - with the `static` keyword



### structs

- they're like classes but is better to use classes
    -
    ```cs
        // struct definition
        public struct RgbColor 
        {
            public int Red;
            public int Green;
            public int Blue;
        }
    ```

### enums

- Enums works like integers
- to define them:
    ```cs
        public enum ShipingMethods1 : byte
        {
            RegularMail = 1,
            RegisteredMail = 2,
            Express = 3
        }
    ```
- call them:
    ```cs
        class Program
    {
        static void Main(string[] args)
        {
            var method1 = ShipingMethods1.Express;
            Console.WriteLine((int)method1); // 3

            var method2 = 3;
            Console.WriteLine((ShipingMethods1)method2); // Express

            // can be converted to strings
            Console.WriteLine(method1.ToString());

            // tring to enums
            var method3 = "Email";
            var ShippingMethod2 = (ShipingMethods1)Enum.Parse(typeof(ShipingMethods1), method3);
        }

        public enum ShipingMethods1 : byte
        {
            RegularMail = 1,
            RegisteredMail = 2,
            Express = 3
        }
    }
    ```



## Types 


## Arrays

- Documentation here: [https://learn.microsoft.com/en-us/dotnet/api/system.array?view=net-7.0]
- 
    ```cs
            // fixed size
            int[] array1 = new int[3];
            var array1_v2 = new int[3];

            // initialize
            int[] array2 = new int[3] { 21, 24, 26 };
            var array2_v2 = new int[3] { 21, 24, 26 };

            // initialize 3
            int[] array3 = new int[3];
            var array_v2 = new int[3];
            array3[0] = 88;
            array3[1] = 80;
            array3[2] = 81;

            // all arrays initialize in 0
            // all boolean variables are initialzied in false
            var arrayBools1 = new bool[3] { true, true, false };
            var arrayBools_v2 = new bool[3];
            arrayBools_v2[1] = true;

            // array of strings
            var arrayStrings1 = new string[3] { "amparo", "jamecho", "tiche" };
            var arrayStrings1_v2 = new string[3];
            arrayStrings1_v2[0] = "pow";
    ```

- the methods accessible from the class, like sort, (Array.Sort()) means that they are static
- if the methods are available in only instances, means that they are accessible from the instance
- documentation here: https://learn.microsoft.com/en-us/dotnet/api/system.array?view=net-7.0

### Lists

- Is a DataStructure, similar to Arrays, but can store objects of similar type, but the size is dynamic.

- `var numbers = new List<int>();`
- `var numbers = new List<int>(){};`
- Methods for lists:
    - Add()
    - AddRange()
    - Remove()
    - RemoveAt()
    - IndexOf()
    - Contains()
    - Count

    ```cs
            static void Main(string[] args)
        {
            var numbers = new List<int>() { 1,2,3,4,5};
            numbers.Add(1); // add 1 at the end of the list
            numbers.AddRange(new int[3] {5,6,1}); // add  at the end of the list
            foreach(var number in numbers )
            {
                Console.Write("  {0}", number);
            }
            Console.WriteLine();

            numbers.IndexOf(4); // returns the index of the element
            numbers.LastIndexOf(5); // returns the last inedx

            Console.WriteLine("Count: " + numbers.Count());

            numbers.Remove(1);
            foreach(var n in numbers)
            {
                Console.Write("  {0}", n);
            }
            Console.WriteLine();

            for (var i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == 1)
                {
                    numbers.Remove(numbers[i]);
                }
            }

            PrintArray.prinArrayHere(numbers);

            numbers.Clear(); //clears the list

            PrintArray.prinArrayHere(numbers);
        }
    ```

- When ide refers to a "IEnumerable" and array or a list can be used;


## Loops and control Flows

- 3 types of conditionals in C#
    - if/else
    - switch/case
    - ternary operator

- avoid multiple if statements, it's smelling code
- switch/case:
    ```cs
    switch(role)
    {
        case Role.Admin:
            ...
            break;
        case Role.Moderator:
            ...
            break;
        default:
            ...
            break;
    }
    ```
- C#8 swtch case:

    ```cs
    int value = 1;

    var state = (value) switch
    {
        (0) => "Zero",
        (1) => "One",
        (2) => "Two",
        _ => "Invalid option",
    };
    
    ```

    -
    ```cs
    namespace Loops
    {
        class Program
        {
            static void Main(string[] args)
            {

                Console.WriteLine("======================for");

                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write("  {0}", i);
                    }
                    Console.WriteLine();
                }


                Console.WriteLine("======================foreach");

                var name1 = "jamecho";

                for (int i = 0; i < name1.Length; i++)
                {
                    Console.Write("  {0}", name1[i]);
                }
                Console.WriteLine();

                foreach (var letter in name1)
                {
                    Console.Write(letter);
                }
                Console.WriteLine();

                Console.WriteLine("======================while");

                var j = 0;
                while(j < 10)
                {
                    if(j % 2 == 0)
                        Console.Write(" {0}", j);

                    //Console.WriteLine();
                    j++;
                }
                Console.WriteLine();

                while (true)
                {
                    Console.WriteLine("write your name: ");
                    var input1 = Console.ReadLine();

                    if(input1 != null)
                    {
                        Console.WriteLine(input1);
                        break;
                    }
                    else if (String.IsNullOrWhiteSpace(input1))
                    {
                        Console.WriteLine("asd");
                    }
                    else
                    {
                        Console.WriteLine("empty!");
                        break;
                    }
                }

                Console.WriteLine("======================random");

                var random1 = new Random();
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(random1.Next(1,20));
                }
                Console.WriteLine();


                var passwordSize = 10;
                var buffer = new char[passwordSize];

                for (int i = 0;i < passwordSize; i++)
                {
                    buffer[i] = (char)('a' + random1.Next(0, 26));
                }
                    //Console.Write((char)('a' + random1.Next(0,26)));
                    var pass1 = new string(buffer);
                Console.WriteLine(buffer);
            }
        }
    }
    ```



## DateTime

- Documentation at: [https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings]
- 
    ```cs
            var dateTime1 = new DateTime(2015, 1, 1);
            var now1 = DateTime.Now;
            var today1= DateTime.Today;
            Console.WriteLine("DateTime.Now: {0}", now1);
            Console.WriteLine("day: {0}", now1.Day);
            Console.WriteLine("DateTime.Today: {0}", today1);
            Console.WriteLine("year: {0}", today1.Year);
    ```

### Timespans

- 
        ```cs
            var dateTime1 = new DateTime(2015, 1, 1);
            var now1 = DateTime.Now;
            var today1= DateTime.Today;
            Console.WriteLine("DateTime.Now: {0}", now1);
            Console.WriteLine("day: {0}", now1.Day);
            Console.WriteLine("DateTime.Today: {0}", today1);
            Console.WriteLine("year: {0}", today1.Year);
        
            var tomorrow1 = now1.AddDays(1);
            var yesterday1 = now1.AddDays(-1);

            Console.WriteLine(tomorrow1.ToLongDateString() );
            Console.WriteLine(tomorrow1.ToShortDateString() );
            Console.WriteLine(tomorrow1.ToLongTimeString() );
            Console.WriteLine(tomorrow1.ToShortTimeString() );
            Console.WriteLine(tomorrow1.ToString("yyyy-MM-dd HH:mm") );

            // documentation at: https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings

            Console.WriteLine("======================TimeSpan");

            var timeSpan1 = new TimeSpan(1, 2, 3); // 1 hour 2 min 3 secs
            var timeSpan2 = new TimeSpan(1, 0, 0);
            var timeSpan3 = new TimeSpan(1, 2, 3);
            var timeSpan4 = TimeSpan.FromHours(1);

            var start1 = DateTime.Now;
            var end1 = DateTime.Now.AddMinutes(2);
            var duration1 = end1 - start1;

            Console.WriteLine("duration " + duration1);
            Console.WriteLine("duration " + duration1.Minutes + " mins");

            // properties

            Console.WriteLine("total Minutes: " + timeSpan1.TotalMinutes);
            Console.WriteLine("total Seconds: " + timeSpan1.TotalSeconds);
            Console.WriteLine("total miliSeconds: " + timeSpan1.TotalMilliseconds);

            // Add 
            Console.WriteLine("======================TimeSpan - Add");
            Console.WriteLine("original: " + timeSpan1);
            Console.WriteLine("plus: " + TimeSpan.FromMinutes(2));
            Console.WriteLine("add: " + timeSpan1.Add(TimeSpan.FromMinutes(2)));

            // substract
            Console.WriteLine("======================TimeSpan - Substract");
            Console.WriteLine("original: " + timeSpan1);
            Console.WriteLine("minus: " + TimeSpan.FromMinutes(2));
            Console.WriteLine("substracted: " + timeSpan1.Subtract(TimeSpan.FromMinutes(2)));

            // to sing
            Console.WriteLine("toString" + timeSpan1.ToString());

            // parse
            Console.WriteLine("toString" + TimeSpan.Parse("01:02:03"));
        ```


## Strings and Text

-
```cs
            // Strings
            string firstName = "asd";
            string lastName = "qwe";
            string name1 = firstName + " " + lastName;
            string name2 = string.Format("{0} {1}", firstName, lastName);

            var numbers2 = new int[3] { 44, 45, 56 };
            string list1 = string.Join(",", numbers2);
            Console.WriteLine(list1);

            // strings are inmmutable
            // \n new line
            // \t tab
            // \\ backslash
            // \' quotation mark
            // \" double quotation mark
            string path1 = "c:\\projects\\projects\\folder";

            // Verbatim strings, no need to use the backslash using the at character
            string path2 = @"c:\projects\projects\folder";

            var text1 = @"this is
a new path1
line";

            Console.WriteLine(text1);

            // int is a class in .NET
            // string is a class in .NET
            // car is a class in .NET
```

- Documentation at [https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings]
- `Console.WriteLine("price: {0}", price2.ToString("C"));`
    - the "C" can also be 'd' or 'D', and much more accoring to the documentation

- Templates: 
    ```cs
        var string5 = "this is a test";
        Console.WriteLine($"---------------{string5}-------------");
    ```

## Lambda Functions

- it's used only when the code is only a line
    ```cs
    public static int sum3Numbers(int x, int y, int z) => 
            (
                (x + y + z)
            );
    ```
    - to use them:
        - 
        ```cs
            Console.WriteLine($"1 + 2 + 3 = : {sum3Numbers(1,2,3)}");
        ```

## Local functions

- functions inside functions/methods:
    ```cs
    static void Main(string args)
    {
        int Sum1( int x, int y)
        {
            return x + y;
        }
        Sum1(2,3);
    }
    ```
- Long numbers (digital separator):
    - `public const long Billions = 100_000_000_000;`

## Tuples

-
    ```cs
    var named = (first: "one", second: "two");
    (bool binaryResult, double dcalculation) = Tuples.CalculationTuple();
    ```

## null conditional operator

- 
    ```cs
    DataTime? datetime = new DateTime();
    var YearOfDate = datetime?.Year;
    Console.WriteLine(YearOfDate);
    var YearOfDateConditional = date?.Year ?? 0;
    ```



## Anonymous Functions (Anonymous methods)

- 
    ```cs
    Action<int> printNumber = delegate (int num) {
        Console.WriteLine(num);
    };
    printNumber(10); // prints 10

    ```

#### Stringbuilder

- class defined in the system, represemnts immutable strings
- is not optimizes for searching (methods from strings, like indexOf, StartsWith, LAstindexOf, etc)
- it has multiple methods like:
    - `Append()`
    - `Insert()`
    - `Remove()`
    - `Replace()`
    - `Clear()`

- theuy can be created like this:
    ```cs
        var builder2 = new StringBuilder("Another String here");

            builder2
                .AppendLine()
                .Append('-', 10)
                .Replace('-', '_')
                .AppendLine();
    ```


## SystemIO 

### File and FileInfo

- Documentation [https://learn.microsoft.com/en-us/dotnet/api/system.io.fileinfo?view=net-7.0]

- File provides static methods
- FileInfo provides instance methods
- some methods:
    - Create()
    - Copy()
    - Delete()
    - Exists()
    - GetAttributes()
    - Move()
    - ReadAllText()

## Directory and DirectoryInfo

- Directory provides *static* methods
- DirectoryInfo provides *instance* methods
- some methods:
    - CreateDirectory()
    - Delete()
    - Exist()
    - GetCurrentDirectory()
    - GetFiles()
    - Move()
    - GetLogicalDrives()

## Path

- String that contain the working path or any other
- methods
    - GetDirectoryName()
    - GetFileName()
    - GetExtension()
    - GetTempPath()


## Procedural Programming

- The idea is separate, in static methods and functions the logic, so the code is much more readable
- Each fuinction/method is responsible for 1 thing
- Another paradigm is OOP, procedural is different (is based on calls of procedures)
- First rule: should always separate that run on the console than the code that implements logic.
    - Example 1:
    ```cs
    public static string ReverseName(string name) {} // this should return a string
    return new string(array); // returning here
    ```
    - to access it:
        - with in the same class:
            `ReverseName("asd asd asd")`
        - In another class: (using public class and static method)
            `AnotherClass.ReverseName("asd asd asd")`
    - Example 2:
        ```cs
        public static List<int> GetUniqueNumbers(List<int> numbers) {} // this should return a List of Integers
        ```
    
## Implicit using 

- the program can be created without namespace and class, and no need to use using statements, by enabling ImplicitUsings in the csproj file.
    - `<ImplicitUsings>enable</ImplicitUsings>`
    - `<OutputType>Exe</OutputType>`

    - full csproj:
        ```
        <Project Sdk="Microsoft.NET.Sdk">
        <PropertyGroup>
            <OutputType>Exe</OutputType>
            <TargetFramework>net6.0</TargetFramework>
            <ImplicitUsings>enable</ImplicitUsings>
            <Nullable>enable</Nullable>
        </PropertyGroup>

        </Project>

        ```


## csproj file

- Documentation [https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/advanced]
- 


## Achronyms

- CLR, Common Language Runtime
- IL code, Intermediate Lang code
- Jit, just in time compilation
- assembly: a single unit of deployment of .NET applications


## VS shortcuts

- `Ctrl + Shift + B` // compile
- `cw [tab]` Console.WriteLine
- `Ctrl + b` compile
- `tab twice` top get a snippet
- `Ctrl + Alt + click` : Add a secondary caret
- `Ctrl + Alt + double-click `: Add a secondary word selection
- `Ctrl + Alt + click + drag` : Add a secondary selection
- `Shift + Alt + .` : Add the next matching text as a selection
- `Shift + Alt + ;` : Add all matching text as selections
- `Shift + Alt + ,` : Remove last selected occurrence
- `Shift + Alt + /` : Skip next matching occurrence
- `Alt + click` : Add a box selection
- `Esc or click` : Clear all selections


## Exercises

1. Array section
2. Control Flow (conditionals) Section 1
3. Control Flow (loops) Section 2
4. Working with Text (Live coding)
5. Working with Text (Exercises)
6. Working with files


### Exercises

- Note: for all these exercises, ignore input validation unless otherwise directed. Assume the user enters a value in the format that the program expects. For example, if the program expects the user to enter a number, don't worry about validating if the input is a number or not. When testing your program, simply enter a number.

#### 1 Array exercises

1. When you post a message on Facebook, depending on the number of people who like your post, Facebook displays different information.

    - If no one likes your post, it doesn't display anything.
    - If only one person likes your post, it displays: [Friend's Name] likes your post.
    - If two people like your post, it displays: [Friend 1] and [Friend 2] like your post.
    - If more than two people like your post, it displays: [Friend 1], [Friend 2] and [Number of Other People] others like your post.
    - Write a program and continuously ask the user to enter different names, until the user presses Enter (without supplying a name). Depending on the number of names provided, display a message based on the above pattern.

2. Write a program and ask the user to enter their name. Use an array to reverse the name and then store the result in a new string. Display the reversed name on the console.

3. Write a program and ask the user to enter 5 numbers. If a number has been previously entered, display an error message and ask the user to re-try. Once the user successfully enters 5 unique numbers, sort them and display the result on the console.

4. Write a program and ask the user to continuously enter a number or type "Quit" to exit. The list of numbers may include duplicates. Display the unique numbers that the user has entered.

5. Write a program and ask the user to supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10). If the list is empty or includes less than 5 numbers, display "Invalid List" and ask the user to re-try; otherwise, display the 3 smallest numbers in the list.

#### 2 Control Flow Exercises

1. Write a program and ask the user to enter a number. The number should be between 1 to 10. If the user enters a valid number, display "Valid" on the console. Otherwise, display "Invalid". (This logic is used a lot in applications where values entered into input boxes need to be validated.)
2. Write a program which takes two numbers from the console and displays the maximum of the two.
3. Write a program and ask the user to enter the width and height of an image. Then tell if the image is landscape or portrait.
4. Your job is to write a program for a speed camera. For simplicity, ignore the details such as camera, sensors, etc and focus purely on the logic. Write a program that asks the user to enter the speed limit. Once set, the program asks for the speed of a car. If the user enters a value less than the speed limit, program should display Ok on the console. If the value is above the speed limit, the program should calculate the number of demerit points. For every 5km/hr above the speed limit, 1 demerit points should be incurred and displayed on the console. If the number of demerit points is above 12, the program should display License Suspended.

#### 3 Control Flow Loops

1. Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder. Display the count on the console.
2. Write a program and continuously ask the user to enter a number or "ok" to exit. Calculate the sum of all the previously entered numbers and display it on the console.
3. Write a program and ask the user to enter a number. Compute the factorial of the number and print it on the console. For example, if the user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1 and display it as 5! = 120.
4. Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the number. If the user guesses the number, display “You won"; otherwise, display “You lost". (To make sure the program is behaving correctly, you can display the secret number on the console first.)
5. Write a program and ask the user to enter a series of numbers separated by comma. Find the maximum of the numbers and display it on the console. For example, if the user enters “5, 3, 8, 1, 4", the program should display 8.

#### 4 Working with text

1. Write a program and ask the user to enter a few numbers separated by a hyphen. Work out if the numbers are consecutive. For example, if the input is "5-6-7-8-9" or "20-19-18-17-16", display a message: "Consecutive"; otherwise, display "Not Consecutive".

2. Write a program and ask the user to enter a few numbers separated by a hyphen. If the user simply presses Enter, without supplying an input, exit immediately; otherwise, check to see if there are duplicates. If so, display "Duplicate" on the console.

3. Write a program and ask the user to enter a time value in the 24-hour time format (e.g. 19:00). A valid time should be between 00:00 and 23:59. If the time is valid, display "Ok"; otherwise, display "Invalid Time". If the user doesn't provide any values, consider it as invalid time.

4. Write a program and ask the user to enter a few words separated by a space. Use the words to create a variable name with PascalCase. For example, if the user types: "number of students", display "NumberOfStudents". Make sure that the program is not dependent on the input. So, if the user types "NUMBER OF STUDENTS", the program should still display "NumberOfStudents".

5. Write a program and ask the user to enter an English word. Count the number of vowels (a, e, o, u, i) in the word. So, if the user enters "inadequate", the program should display 6 on the console.

#### 5 Working with Text (Exercises)

- Note: For all these exercises, ignore input validation unless otherwise specified. Assume the user provides input in the format that the program expects.

1. Write a program and ask the user to enter a few numbers separated by a hyphen. Work out if the numbers are consecutive. For example, if the input is "5-6-7-8-9" or "20-19-18-17-16", display a message: "Consecutive"; otherwise, display "Not Consecutive".

2. Write a program and ask the user to enter a few numbers separated by a hyphen. If the user simply presses Enter, without supplying an input, exit immediately; otherwise, check to see if there are duplicates. If so, display "Duplicate" on the console.

3. Write a program and ask the user to enter a time value in the 24-hour time format (e.g. 19:00). A valid time should be between 00:00 and 23:59. If the time is valid, display "Ok"; otherwise, display "Invalid Time". If the user doesn't provide any values, consider it as invalid time.

4. Write a program and ask the user to enter a few words separated by a space. Use the words to create a variable name with PascalCase. For example, if the user types: "number of students", display "NumberOfStudents". Make sure that the program is not dependent on the input. So, if the user types "NUMBER OF STUDENTS", the program should still display "NumberOfStudents".

5. Write a program and ask the user to enter an English word. Count the number of vowels (a, e, o, u, i) in the word. So, if the user enters "inadequate", the program should display 6 on the console.

#### 6 Working with Files

1. Write a program that reads a text file and displays the number of words.
2. Write a program that reads a text file and displays the longest word in the file.


## Table of Contents

- [chsarp-principles Notes](#chsarp-principles-notes)
  - [Table of Contents](#table-of-contents)
  - [Core concepts](#core-concepts)
    - [C# app](#c-app)
    - [namespaces](#namespaces)
    - [VS Community](#vs-community)
    - [Variables and constants](#variables-and-constants)
    - [Primitive Types:](#primitive-types)
    - [Non-Primitive Types](#non-primitive-types)
    - [Overflowing](#overflowing)
    - [Scope](#scope)
  - [Reference Types and Value Types](#reference-types-and-value-types)
    - [String Templates](#string-templates)
    - [Type conversion](#type-conversion)
  - [Operators](#operators)
    - [Arithmetic](#arithmetic)
    - [Logical](#logical)
    - [Assignment](#assignment)
    - [Logical](#logical)
    - [Bitwise Operators](#bitwise-operators)
  - [Classes](#classes)
    - [Type of classes](#type-of-classes)
    - [create a class](#create-a-class)
    - [create an object](#create-an-object)
    - [structs](#structs)
    - [enums](#enums)
  - [Types ](#types-)
  - [Arrays](#arrays)
    - [Lists](#lists)
  - [Loops and control Flows](#loops-and-control-flows)
  - [DateTime](#datetime)
    - [Timespans](#timespans)
  - [Strings and Text](#strings-and-text)
  - [Lambda Functions](#lambda-functions)
  - [Local functions](#local-functions)
  - [Tuples](#tuples)
  - [null conditional operator](#null-conditional-operator)
  - [Anonymous Functions (Anonymous methods)](#anonymous-functions-anonymous-methods)
      - [Stringbuilder](#stringbuilder)
  - [SystemIO ](#systemio-)
    - [File and FileInfo](#file-and-fileinfo)
  - [Directory and DirectoryInfo](#directory-and-directoryinfo)
  - [Path](#path)
  - [Procedural Programming](#procedural-programming)
  - [Implicit using ](#implicit-using-)
  - [csproj file](#csproj-file)
  - [Achronyms](#achronyms)
  - [VS shortcuts](#vs-shortcuts)
  - [Exercises](#exercises)
    - [Exercises](#exercises)
      - [1 Array exercises](#1-array-exercises)
      - [2 Control Flow Exercises](#2-control-flow-exercises)
      - [3 Control Flow Loops](#3-control-flow-loops)
      - [4 Working with text](#4-working-with-text)
      - [5 Working with Text (Exercises)](#5-working-with-text-exercises)
      - [6 Working with Files](#6-working-with-files)
