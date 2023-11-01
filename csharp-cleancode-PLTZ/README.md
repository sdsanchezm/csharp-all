# csharp-cleancode Documentation



# Principles 


## Best practices

- best ways to complkete tasks
- similar structure for easy understanting
- it's proven and verified standard
- solve common scenarios

## Clean Code 

- means: code that follows standars
- can be long-term maintainable
- easy to scale (more users, increase in usage or increase in popularity)
- easier to add new features

- How to achieve it?
    - Keep low coupling 
    - simple and modern syntax 
    - avoid 3rd party libs
    - responsibility distributed
    - Small components

- Technical debt
    - technical issues that needs to be resolved 
    - sometimes is expensive than the development
    - sometimes re-write is the solution
    - how to design and in what tecnology is designed

- Refactoring
    - Improve functionalities by changing it
    - Business Logic must be maintained 
    - must be recurrent
    - this will avoid technical debt


## Naming

- Names must be descriptive (when rteading the code, it should indicate what it is)
- No numbers in a name
- Do not use Hungarian notation
- Variables
    - incorrect
        - `int d`;

        - correct
        - `int daySinceModification;`

- Methods 
    - Incorrect:
        - `public List<Users> getUsers( )`

        - Correct :
        - `public List<Users> GetActiveUsers( )`

- Clases
    - Incorrect:
        - `public class ClassUser2`

    - Correct :
        - `public class User`


## Code Smell 

- feeling that indicates that something is wrong, and potencial errors/problems.
- sometimes these feelings are an indication of issues.

- code smell examples:
    - Variables, methods or classes with poorly descriptive names
    - Methods and classes with many lines that turns into difficult reading. (possible meaning, it can be refactores into little pieces easy to understand)
    - methods that receives many parameters, indicates big business logic
    - "magic numbers" or "burned" is hardcode, makes difficult understanding of the code.

### code smells types

- some code smells, and some levels:

    - Code smells de forma general
    - Code smells a nivel de función
    - Code smells a nivel de clase
    - Code smells a nivel de la aplicación

### Example

- instead of numbers for a menu, use an enum, so names will be read in the code instead of just numbers


## DRY (Don't Repeat Yourself)

- If a piece of code can be re-used, then refactor it, so it can be re-used

### Example DRY

- If 4 functions executes similar processes, find a way to include a parameter, so it turns into a only 1 function.
- 


## KISS (Keep It Simple and Short)

- Basically, Keep things without unnecessary complexity
- Example:
    - reduce nested conditionals (Ifs) into only 1. 
    

## Try Catch

- Special cases in the code
- is implemented where it requries a validation
- performance is affected when catching the exception
- if a validation is made, the performance 
- it's better to control what happen in the code


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

## Comments 

- comments that strts with /// are for documentation purposes (some libs use such syntax)
- do not write unnecessary comments
- no reduntant comments
    - 
        ```cs
        // user class
        public class User    
        ```
- do not keep commented code
- Comments documentation: [https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments]


## Recommendations

- read about best practices
- *Make code Review* (**THIS IS KEY**)
    - Make Refactoring after



## Documentation

- code standard [https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md]
- code smell [https://www.ionos.es/digitalguide/paginas-web/desarrollo-web/code-smell/]


## Exercise 

### Summary to do

- apply good practices to Prorgam.cs, video 5
- apply code smell practices to Prorgam.cs, video 6
- apply DRY practices to Prorgam.cs, video 7
- apply KISS, video 8
- apply try catch, video 8
- apply mejoras, video 11
- apply minimalistm (removing "using"), video 12
- apply comments best practices, video 13

### Code Example in this repo

- Initial Code Folder `initial-code`
- Best practices code Folder ``

#### Actions performed:

-Improving Naming
    - changed TL to TasksList
    - changed the name of the methods

- Code Smelling
    - changed some option names
    - Created an enum and changed the names of the options to point to the enum (avoiding using numbers)

- DRY, Dont repeat Yourself
    - took the printing taks to another method (so it can be re-used)

- KISS, Keep It Simple and Short
    - removed nested ifs
    - changed the for-loop for ForEach-loop

- Try Catch, Exception handling
    - Added try catch when trying to perform the delete operation
    - included a validation when deleting, to avoid the try catch

- Comments
    - Included some comments to certain details to provide context

- Optional:
    - Did not remove namespaces or classes or Program




