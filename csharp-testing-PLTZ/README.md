# .Net Testing
csharp dotnet testing code reference

## Best Practice

- AAA structure
    - Arrange
    - Act
    - Assert
    - Example:
        ```cs
            [Fact]
            public void IsPalindrome_True()
            { 
                // Arrange
                var strOperations = new StringOperations();

                // Act
                var result = strOperations.IsPalindrome("ama");

                // Assert
                Assert.True(result);
                Assert.NotNull(result);
                Assert.NotEmpty(result);
                Assert.Equal("Hello Jamecho", result);
            }
        ```

## Using Moq 

- In general
    ```cs
    class MyClassTest
    {
        [TestMethod]
        public void MyMethodTest()
        {
            string action = "test";
            Mock<SomeClass> mockSomeClass = new Mock<SomeClass>();

            mockSomeClass.Setup(mock => mock.DoSomething());

            MyClass myClass = new MyClass(mockSomeClass.Object);
            myClass.MyMethod(action);

            // Explicitly verify each expectation...
            mockSomeClass.Verify(mock => mock.DoSomething(), Times.Once());

            // ...or verify everything.
            // mockSomeClass.VerifyAll();
        }
    }
    ```
- Read a File:
    ```cs
        var mockFileReader = new Mock<IFileReaderConector>();
        mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file");
    ```

- Logger
    ```cs
        var mockLogger = new Mock<ILogger<StringOperations>>();
        var strOperations = new StringOperations(mockLogger.Object);
    ```


- F.I.R.S.T. Principles for testing
    - Fast
    - Isolated/Independent
    - Repeatable
    - Self-Validating
    - Thorough


## Code Reports 

### coverlet

- install it (after installation, check the .csproj file)
- use it
    - `[ExcludeFromCodeCoverage]`
    - `dotnet test /p:CollectCoverage=true /p:ExcludeByAttribute="ExcludeFromCodeCoverage"`
- Generate a formated report 
    - `dotnet test /p:CollectCoverage=true /p:CoverletOutpuFormat=cobertura`

### Report Generator

- Install reportGenerator from nuget pm (not a lib only, is a tool)
- To use it
    - `reportgenerator "-reports:coverage.cobertura.xml” "-targetdir:coverage-report" -reporttypes:html;`

### Fine code Coverage

- Install from ManageExtensions in VS
    - View from: View > Other windows > Fine code Coverage
    - config at: Tools > Options



## Naming

- Project => Project.Tests
- Class => ClassTest
- Method => MethodTest

## misc

- Install xunit
    - `dotnet add package xunit` 
- run test available
    - `dotnet test`
- Testing Libs comparison in c# .Net
    - [https://xunit.net/docs/comparisons]
- Mock a specific detail:
    - Moq library
    - `Install-Package Moq -Version 4.16.1`
    - usage: `using moq`
- Coverlet (not a lib, but a console utility in the .Net framework for test reports)
    - `dotnet tool install --global coverlet.console --version 3.2.0`
    - `dotnet add package coverlet.msbuild`
    - site: [https://www.nuget.org/packages/coverlet.console/3.2.0]
    - to use it:
        - `dotnet test /p:CollectCoverage=true`

