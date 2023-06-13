# Notes

## General Public Note

- **The code in this forlder is for educational purposes only, I a not the author/creator, I use these multiple folders to track the learning process. The owners are their respective creators. **


## Commands

- `dotnet new webapp`
- `dotnet watch`

## from Create a web UI with ASP.NET Core
- link: [https://learn.microsoft.com/en-us/training/modules/create-razor-pages-aspnet-core/]
- [https://learn.microsoft.com/en-us/dotnet/core/tools/#cli-commands](https://learn.microsoft.com/en-us/dotnet/core/tools/#cli-commands)
- `dotnet new page --name PizzaList --namespace ContosoPizza.Pages --output Pages`
- null safety [https://learn.microsoft.com/en-us/training/modules/csharp-null-safety/](https://learn.microsoft.com/en-us/training/modules/csharp-null-safety/)
- Lsit all sdks available/installed `dotnet --list-sdks`
- Create and API basic `dotnet new webapi -f net6.0`
- `dotnet run`

## from "Create a web API with ASP.NET Core controllers"
- Install the certificate: `dotnet dev-certs https --trust` from [https://learn.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-7.0&tabs=visual-studio%2Clinux-ubuntu#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos](https://learn.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-7.0&tabs=visual-studio%2Clinux-ubuntu#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos)
- Install repl `dotnet tool install -g Microsoft.dotnet-httprepl`
	- httprepl https://localhost:{PORT}
	- connect https://localhost:{PORT}
- `dotnet build`
- POST in httprepl https://localhost:{PORT}
	- `post -c "{"name":"Hawaii", "isGlutenFree":false}"`
- GET in httprepl https://localhost:{PORT}
	- `get` and `ls` and `get 1`
- DELETE in httprepl https://localhost:{PORT}
	`delete 3`
- PUT in httprepl https://localhost:{PORT}
	- `put 3 -c  "{"id": 3, "name":"Hawaiian", "isGlutenFree":false}"`
- Persist and retrieve relational data with Entity Framework Core [https://learn.microsoft.com/en-us/training/modules/persist-data-ef-core/](https://learn.microsoft.com/en-us/training/modules/persist-data-ef-core/)
- List packages: `dotnet list package`
- List packages: `dotnet list package --include-transitive`
-  install tools globally `dotnet tool install <name of package>`
- install templates `dotnet new -i <name of package>`
- nuget packages: [https://www.nuget.org/packages?q=newton&frameworks=&tfms=&packagetype=&prerel=true&sortby=relevance](https://www.nuget.org/packages?q=newton&frameworks=&tfms=&packagetype=&prerel=true&sortby=relevance)
- Restore packages: `dotnet restore` (is like npm install in node)
-  creates a Program.cs file in your folder with a basic "Hello World" program already written, along with a C# project file named DotNetDependencies.csproj: `dotnet new console -f net6.0`
	- Same but forced `dotnet new console -f net6.0 --force`
	- then run `dotnet run`
- Example: `dotnet add package Humanizer --version 2.7.9`
- It is recommended to install a specific version to avoid surprices when installing in a new machine.
- the notation will be: `[2.1]`.
	- there is also: `1.0`, `(1.0,)`, `[1.0]`, `(,1.0])`, `(,1.0)`, `[1.0,2.0]`, `(1.0,2.0)`, `[1.0,2.0)` following the same regular math syntax
	- Examples:
		- 
		```
		<!-- Accepts any version 6.1 and later. -->
		<PackageReference Include="ExamplePackage" Version="6.1" />

		<!-- Accepts any 6.x.y version. -->
		<PackageReference Include="ExamplePackage" Version="6.*" />
		<PackageReference Include="ExamplePackage" Version="[6,7)" />
		```
	- optional: `--version=<version number/range>` to find range
- Find outdated packages: `dotnet list package --outdated`
- Find pre-releases: `dotnet list package --outdated --include-prerelease`
- Install a specific version `dotnet add package Humanizer --version 2.11.10`
- Build application without the debigin configuration `dotnet run --configuration Release`
- Adding a package: `dotnet add package Newtonsoft.Json`


## working with Blazor
- composed of reusable web UI components built using C#, HTML, and CSS
- uses:
	- Server side code that handles UI interactions over a WebSocket connection
	- Client side web app that runs directly in the browser via WebAssembly
	- 
- Razor: Razor is based on ASP.NET and designed for creating web apps
- Code goes into `@()` or `@code` and `@functions` for methods and properties
	- Example of function:
	```
	 @foreach (var todo in todos)
	 {
		<li>@todo.title</li>
	 }
	```
- The `@Page` identifies a page, example `@page "/"`
- The `@bind` markup binds a c# variable to an html object
- 2 hosting models *Blazor Server* and *Blazor WebAssembly*
- In Blazor the UI contain components and each one can contain a mix of HTML and C# code.
- components use the *Razor syntax* and the .razor extension
- razor syntax embeed .NET code into webpages, razor can be used in ASP.NET MVC applications, and files will have the `.cshtml` extension.
- Example of a Blazor component:
```
@page "/index"

<h1>Welcome to Blazing Pizza</h1>

<p>@welcomeMessage</p>

@code {
  private string welcomeMessage = "However you like your pizzas, we can deliver them blazing fast!";
}
```
- Adding Entity Framework to work with the DB:
```
	dotnet add package Microsoft.EntityFrameworkCore --version 6.0.8
	dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0.8
	dotnet add package System.Net.Http.Json --version 6.0.0
```
- Data sharing among components
	- Sharing information with other components by using component parameters
	- Share information by using cascading parameters
	- Share information by using AppState
- pass



## Create dotnet aplications from scratch

- application templates:
	- Console app `dotnet new console -f net6.0`
	- Webapi app `dotnet new console -f net6.0`
	- Add a new console project `dotnet new console -f net6.0 -n learning-dotnet-files -o .`
	- Blazor App create: `dotnet new blazorserver -f net6.0`
		- Create a razor component inside of a Blazor app `dotnet new razorcomponent -n Todo -o Pages`
	- To create a blazor app (using the blazorserver template): `dotnet new blazorserver -o BlazingPizzaSite -f net6.0`
		- To create a new component in an existing blazor app: `dotnet new razorcomponent -n PizzaBrowser -o Pages -f net6.0` (`-n` name, `-o` folder `-f` version of dotnet)
	- To create a new blazor server project with no https: `dotnet new blazorserver -o BlazingPizza --no-https true -f net6.0`
	- 

## Folders Organization

- MS learning path: *"Use pages, routing, and layouts to improve Blazor navigation"*
	- [https://learn.microsoft.com/en-us/training/modules/use-pages-routing-layouts-control-blazor-navigation/?WT.mc_id=cloudskillschallenge_150aae80-e46b-4a07-894a-5247fcdfcbad](https://learn.microsoft.com/en-us/training/modules/use-pages-routing-layouts-control-blazor-navigation/?WT.mc_id=cloudskillschallenge_150aae80-e46b-4a07-894a-5247fcdfcbad)
- pass



## Topics from the challenge and folders

1. Write your first C# code
2. Get started with web development using Visual Studio Code
3. Learn the basics of web accessibility
4. Create a web UI with ASP.NET Core
5. Create a web API with ASP.NET Core controllers
6. Publish a web app to Azure with Visual Studio
7. Introduction to .NET
8. Create a new .NET project and work with dependencies
9. Interactively debug .NET apps with the Visual Studio Code debugger
10. Work with files and directories in a .NET app
11. Introduction to Web Development with Blazor
	- code folder: ``
	- documents folder: `11_Introduction_to_Web Development with Blazor`

12. Build a web app with Blazor
	- code folder: ``
	- documents folder: `12_Build_a_web_app_with_Blazor`

13. Interact with data in Blazor web apps
	- code folder: ``
	- documents folder: `13_Interact_with_data_in Blazor web apps`

14. Use pages, routing, and layouts to improve Blazor navigation
	- code folder: ``
	- documents folder: ``

15. Improve how forms and validation work in Blazor web apps
	- code folder: ``
	- documents folder: ``

16. Build rich interactive components with Blazor web apps
	- code folder: `blazorJavascriptIntegration/`
	- document folder: `16_Build_rich_interactive_components`

17. Build reusable components with Blazor
	- code folder: ``
	- documents folder: ``

18. Build Connect Four game with Blazor
	- code folder: ``
	- documents folder: ``

19. Externalize the configuration of an ASP.NET app by using an Azure key vault
	- code folder: ``
	- documents folder: ``

20. Implement logging in a .NET Framework ASP.NET web application
	- code folder: ``
	- documents folder: ``

21. Improve session scalability in a .NET Framework ASP.NET web application by using Azure Cache for Redis
	- code folder: ``
	- documents folder: ``

22. Build a web API with minimal API, ASP.NET Core, and .NET
	- code folder: ``
	- documents folder: ``

23. Use a database with minimal API, Entity Framework Core, and ASP.NET Core
	- code folder: ``
	- documents folder: ``

24. Create a full stack application by using React and minimal API for ASP.NET Core
	- code folder: ``
	- documents folder: ``

25. Build your first microservice with .NET
	- code folder: ``
	- documents folder: ``

26. Deploy a .NET microservice to Kubernetes
	- code folder: ``
	- documents folder: ``

27. Create and deploy a cloud-native ASP.NET Core microservice
	- code folder: ``
	- documents folder: ``

28. Implement resiliency in a cloud-native ASP.NET Core microservice
	- code folder: ``
	- documents folder: ``

29. Instrument a cloud-native ASP.NET Core microservice
	- code folder: ``
	- documents folder: ``

30. Implement feature flags in a cloud-native ASP.NET Core microservices app
	- code folder: ``
	- documents folder: ``

31. Use managed data stores in a cloud-native ASP.NET Core microservices app
	- code folder: ``
	- documents folder: ``

32. Understand API gateways in a cloud-native ASP.NET Core microservices app
	- code folder: ``
	- documents folder: ``

33. Deploy a cloud-native ASP.NET Core microservice with GitHub Actions
	- code folder: ``
	- documents folder: ``
	