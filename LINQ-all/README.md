# LINQ Documentation


## LINQ - Language Integrated Query

- create console project:

- 
    ```
    dotnet new sln -o curso-linq
    cd curso-linq
    ```
    ```
    dotnet new console -o curso-linq
    ```
- add the csproj file in linux
    ```
    dotnet sln add **/*.csproj
    ```
- add the csproj file in windows
    ```
    dotnet sln add (ls -r **/*.csproj)
    ```

- Use it:
    - `using System.Linq`
- Query Expression:

    ```
    var result = from l in list
             where l > 10
             select l;
    ```
- Extension Method:
    ```
    var result = list.Where(x=> x > 10);
    ```

- Example [https://learn.microsoft.com/en-us/dotnet/csharp/linq/]:
    ```cs
    
    // Specify the data source.
    int[] scores = { 97, 92, 81, 60 };

    // Define the query expression.
    IEnumerable<int> scoreQuery =
        from score in scores
        where score > 80
        select score;

    // Execute the query.
    foreach (int i in scoreQuery)
    {
        Console.Write(i + " ");
    }

    // Output: 97 92 81
    ```
## Imperative programming vs Declarative

- declarative example: config files. Dev does not have to iterate, but check into files (example) where is the declaration.
    - documentation required
- Imperative example: a for, is a step by step on how a loop is built

- Example of Declarative programming in C#
    ```cs
    // Declarative
    var listofNumbers = new int[] {1, 2,3 ,4, 5};
    
    var item1 = listofNumbers.FirstOrDefault (p => p==1 ).ToArray();
    Console.Writeln(item1);
    ```

- Example of Imperative programming in C#
    ```cs
    //Imperative
    var listofNumbers = new int[] {1, 2,3 ,4, 5};

    for (int i=0; i < listofNumbers.length; i++ )
    {
        if (listOfNumbers[i] == 1)
            Console.Writeln(listOfNumbers[i]);
    }
    ```


## Nullable config property in .csproj

- With the property: `<Nullable>enable</Nullable>`
    - may get the warning: `CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.`
    - Solution 1:
        ```cs
        public class Book
        {
            public string? Title { get; set; }
            public int PageCount { get; set; }
            public string? Status { get; set; }
            public DateTime PublishedDate { get; set; }
            public string? ThumbnailUrl { get; set; }
            public string? ShortDescription { get; set; }
            public string[]? Authors { get; set; }
            public string[]? Categories { get; set; }
        }
        ```
    - Solution 2:
        ```cs
        public class Book
        {
            public string Title { get; set; } = "";
            public int PageCount { get; set; }
            public string Status { get; set; } = "";
            public DateTime PublishedDate { get; set; }
            public string ThumbnailUrl { get; set; } = "";
            public string ShortDescription { get; set; } = "";
            public string[] Authors { get; set; } = Array.Empty<string>();
            public string[] Categories { get; set; } = Array.Empty<string>();
        }
        
        ```
    - Solution 3:
        - `<Nullable>disable</Nullable>`


## Operadores en Linq

1. basicos, filtran y operaciones especificas
2. agregacion, operaciones 
3. agrupamiento, agrupar datos


### Operador Where

- 










## Misc

- Query Expressions:
    - `return from b in booksCollection where b.PublishedDate.Year > 2000 select b;`
    - `return from b in booksCollection where b.PageCount > 250 && b.Title.ToLower().Contains("in action") select b;`
    
- Extension Method:
- `var animalsLocal = animals.Where(item => vowels.Any(vowel => item.Name.ToLower().StartsWith(vowel.ToString() ) ) );`





