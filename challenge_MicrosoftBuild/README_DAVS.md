# Notes


A Models folder was added to the project.

The model folder contains a Pizza class that represents a pizza.

A Data folder was added to the project.

The data folder contains a PizzaContext class that represents the database context. It inherits from the DbContext class from Entity Framework Core. Entity Framework Core is an object-relational mapper (ORM) that makes it easier to work with databases.

A Services folder was added to the project.
The services folder contains a PizzaService class that exposes methods to list and add pizzas.
The PizzaService class uses the PizzaContext class to read and write pizzas to the database.
The class is registered for dependency injection in Program.cs (line 10).
Entity Framework Core generated a few things, too:

A Migrations folder was generated.
The migrations folder contains code to create the database schema.
The SQLite database file ContosoPizza.db was generated.
If you have the SQLite extension installed (or you're using GitHub Codespaces), you can view the database by right-clicking the file and selecting Open Database. The database schema is shown in the SQLite Explorer tab of the Explorer pane.

# Commands

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



## Create dotnet aplications from scratch

- application templates:
	- Console app `dotnet new console -f net6.0`
	- Webapi app `dotnet new console -f net6.0`
	- Add a new console project `dotnet new console -f net6.0 -n learning-dotnet-files -o .`
	- Blazor App create: `dotnet new blazorserver -f net6.0`
		- Create a razor component inside of a Blazor app `dotnet new razorcomponent -n Todo -o Pages`
	



