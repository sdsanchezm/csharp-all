# Notes

- The information is for learning purposes only, no other reason or process will be performed. I did not create the tools, code, or any other piece of tech in this specific repo.

## General Public Note

- **The code in this forlder is for educational purposes only, I a not the author/creator, I use these multiple folders to track the learning process. The owners are their respective creators. **

## Blazor

- Razor is an ASP.NET programming syntax, which helps you mix HTML syntax with C# code.
- The formatting of HTML and CSS, using the Razor template language.
- the components of the web pages can be managed with C# code that runs on a server or in the browser using a web standard technology called WebAssembly.
- WebAssembly is a standard technology available in every modern browser that allows code to run, similar to JavaScript, in a browser.
- Example:
```
<div>@product.Name</div>

@code {
  Product product = new Product{ Name = "Blazor" }
}
```
- Swagger implements the OpenAPI specification.
	- This format describes your routes but also what data they accept and produce.
	- Swagger UI is a collection of tools that render the OpenAPI specification as a website and let you interact with your API via the website.
	- asd


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

## From EF Core

- EF Core is a lightweight, extensible, open source, and cross-platform data access technology for .NET applications.
- EF Core supports a large number of popular databases, including:
	- SQLite
	- MySQL
	- PostgreSQL
	- Oracle
	- Microsoft SQL Server

- Query data (like GET):
	- `var pizzas = await db.Pizzas.ToListAsync();`
	- Another example (code in the repo)
	```
	app.MapGet("/pizza/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));
	```

- Insert Data (like POST):
	- 
	```
	await db.pizzas.AddAsync(
    new Pizza { ID = 1, Name = "Pepperoni", Description = "The classic pepperoni pizza" });
	```
	- Another Example of create an item (code in a folder):
	```
	app.MapPost("/pizza", async (PizzaDb db, Pizza pizza) =>
	{
	    await db.Pizzas.AddAsync(pizza);
	    await db.SaveChangesAsync();
	    return Results.Created($"/pizza/{pizza.Id}", pizza);
	});
	```

- Delete data:
	- 
	```
	var pizza = await db.pizzas.FindAsync(id);
	if (pizza is null)
	{
		//Handle error
	}
	db.pizzas.Remove(pizza);
	```
	- Another Example (code in the repo)
	```
	app.MapDelete("/pizza/{id}", async (PizzaDb db, int id) =>
	{
	   var pizza = await db.Pizzas.FindAsync(id);
	   if (pizza is null)
	   {
	      return Results.NotFound();
	   }
	   db.Pizzas.Remove(pizza);
	   await db.SaveChangesAsync();
	   return Results.Ok();
	});
	```

- Update Data:
	- 
	```
	int id = 1;
	var updatepizza = new Pizza { Name = "Pineapple", Description = "Ummmm?" })
	var pizza = await db.pizzas.FindAsync(id);
	if (pizza is null)
	{
		//Handle error
	}
	pizza.Item = updatepizza.Item;
	pizza.IsComplete = updatepizza.IsComplete;
	await db.SaveChangesAsync();
	```
	- Another Example (code in the repo)
	```
	app.MapPut("/pizza/{id}", async (PizzaDb db, Pizza updatepizza, int id) =>
	{
	      var pizza = await db.Pizzas.FindAsync(id);
	      if (pizza is null) return Results.NotFound();
	      pizza.Name = updatepizza.Name;
	      pizza.Description = updatepizza.Description;
	      await db.SaveChangesAsync();
	      return Results.NoContent();
	});
	```



- DbContext represents a connection or session that's used to query and save instances of entities in a database.
- To use it, add `using Microsoft.EntityFrameworkCore;` at the top of files
- First: create a migration:
	- `dotnet ef migrations add InitialCreate`
	- Before, might need to install `dotnet-ef`
		- `dotnet tool install --global dotnet-ef`
- To undo/remove a migration
	- `dotnet ef migrations add InitialCreate`
- Second: Run the update database command:
	- `dotnet ef database update`


## publish web app in azure from visual studio

- In vs create a project from the `ASP.NET Core Web App` workload
- Run with `F5`
- In Azure:
	+ Create an account
	+ Create the Resour ce Group
	+ Create the Web App
	+ Download the publish profile
	+ in VS log into the MS account
	+ import the publish profile (is a file from azure, named `<AppName>.PublishSettings`)
	+ then, the publish option will show up in VS
	


## Planning the app and some API design considerations

- Ask questions:
	- How will the user be working with these features?
	- What layout do I need?
	- What's the user's interaction flow?
- General logic:
	- CRUD (how users are gonna Read, Create, Delete and Update Records)
- Describe an API:
- 
```
GET    /pizzas
GET    /pizzas/1
POST   /pizzas
PUT    /pizzas/1
PATCH  /pizzas/1
DELETE /pizzas/1
```
- This in the package.json in npm `"proxy": "http://localhost:5000"` allows to proxy and reduce the way reactJs work with the server when fetching apis
	- Instead of `https://localhost:3000/pizzas` it will be `/api/pizzas`
- CORS is a protocol that allows a back end to accept requests from domains other than the one it's currently running on.


### Cors in C#
- code in C#:
```
// 1) define a unique string
readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// 2) define allowed domains, in this case "http://example.com" and "*" = all
//    domains, for testing purposes only.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
      builder =>
      {
          builder.WithOrigins(
            "http://example.com", "*");
      });
});
// 3) use the capability
app.UseCors(MyAllowSpecificOrigins);
```
### npm mocking api considerations

- the package `json-server` allows to mock an api from a file
	- `npx json-server --watch --port 5000 db.json`
- The command `"proxy": "http://localhost:5000",`  in `package.json` allows to short the address to fetch in javasript (in React specifically).
- Then `npm start` to start

### api in dotnet

- clone the project where the api is stored 
	- `git clone https://github.com/MicrosoftDocs/minimal-api-work-with-databases`
- into the folder, run:
	- `dotnet ef database update`
	- (if ef [entity framework]) is not installed, then:
	- `dotnet tool install -g dotnet-ef`
* Lastly, to run:
	- `dotnet run` to run



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



## Create dotnet aplications and adding some packages from terminal

- application templates:
	- Console app `dotnet new console -f net6.0`
	- Webapi app `dotnet new console -f net6.0`
	- Add a new console project `dotnet new console -f net6.0 -n learning-dotnet-files -o .`
	- Blazor App create: `dotnet new blazorserver -f net6.0`
		- Create a razor component inside of a Blazor app `dotnet new razorcomponent -n Todo -o Pages`
	- To create a blazor app (using the blazorserver template): `dotnet new blazorserver -o BlazingPizzaSite -f net6.0`
		- To create a new component in an existing blazor app: `dotnet new razorcomponent -n PizzaBrowser -o Pages -f net6.0` (`-n` name, `-o` folder `-f` version of dotnet)
	- To create a new blazor server project with no https: 
		- `dotnet new blazorserver -o BlazingPizza --no-https true -f net6.0`
	- To create an API with minimal API:
		- `dotnet new web -o MegaStoreWhatever -f net6.0`
	- To install Swagger (Swashbuckle):
		- `dotnet add package Swashbuckle.AspNetCore --version 6.1.4`
		- `dotnet add package Swashbuckle.AspNetCore --version 6.2.3`
	- To install EF (Entity Framework):
		- `dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0`
	- To install EF to work with SQLite
		- `dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0`
	- To install EF Core Tools (globally)
		- `dotnet tool install --global dotnet-ef`
	- To install EF Design:
		- `dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0`


## Microservices

- A microservices architecture is an approach in which a large application is split up into a set of smaller services.
- Modern cloud applications need to be fast, agile, massively scalable, and reliable. putting an application into a container without following a design pattern is like getting into a vehicle and hoping to find way to a new city without a map (or GPS-enabled phone).
- Microservices enable an approach to software development and deployment that is perfectly suited to the agility, scale, and reliability requirements of modern cloud applications.
- Get docker from [https://www.docker.com/products/docker-desktop/](https://www.docker.com/products/docker-desktop/)
- Each service runs in its own process and communicates with other processes using protocols such as:
	+ HTTP/HTTPS
	+ WebSockets
	+ AMQP.
- Microservices are designed based on business needs, rather than purely tech.

### Docker

- Docker is a project for automating deployment of applications as portable, self-sufficient containers that can run in the cloud or on-premises
- In short, containers offer the benefits of isolation, portability, agility, scalability, and control across the whole application-lifecycle workflow
- An image is a static representation of the app or service and its configuration and dependencies
- Docker file is a set of instructions that builds up a Docker image with the exact software you need in it to run an application, including the application itself
- Containerization is an approach to software development in which an application or service, its dependencies, and its configuration (abstracted as deployment manifest files) are packaged together as a container image
- The benefits of microservices are that each one encapsulates simpler customer-requirement functionality, which can be scaled out or in, tested, deployed, and managed independently. 
- Links:
	+ [https://github.com/docker/docker](https://github.com/docker/docker)
	+ [https://www.docker.com/](https://www.docker.com/)
- Kestrel is a cross-platform web server for ASP.NET Core that runs on Windows, Linux, and macOS
- Microsoft publishes an image called mcr.microsoft.com/dotnet/core/aspnet that already contains the ASP.NET Core runtime
- Dockerfile example:
```
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY backend.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .
ENTRYPOINT ["dotnet", "backend.dll"]
```
	- Explanation of the instructions:
		- Pull the mcr.microsoft.com/dotnet/sdk:6.0 image and name the image build
		- Set the working directory within the image to /sr
		- Copy the file named backend.csproj found locally to the /src directory that you created
		+ Calls dotnet restore on the project
		+ Copy everything in the local working directory to the image
		+ Calls dotnet publish on the project

- Docker tutorial from Microsoft:
	+ [https://dotnet.microsoft.com/en-us/learn/aspnet/microservice-tutorial/install-docker](https://dotnet.microsoft.com/en-us/learn/aspnet/microservice-tutorial/install-docker)

#### docker commands:

- `docker build -t pizzabackend .` (including the dot for the directory)
- `docker run -it --rm -p 5200:80 --name pizzabackendcontainer pizzabackend`
- `docker images`
- Notes:
	- `-it` is short for `--interactive` + `--tty` when docker runs with this flag, it takes you straight inside the container
	- containers started in detached mode exit when the `root` process used to run the container exits, unless you also specify the `--rm` option.
	- set the `--rm` flag, Docker also removes the anonymous volumes associated with the container when the container is removed. This is similar to running docker rm -v my-container. Only volumes that are specified without a name are removed [https://docs.docker.com/engine/reference/run/#clean-up---rm]
	- `-p` Publish all exposed ports to the host interfaces
	
#### docker compose

- Example of a `docker-composer.yml` file:
	+ code:
	```
	version: '3.4'

	services: 

	  frontend:
	    image: pizzafrontend
	    build:
	      context: frontend
	      dockerfile: Dockerfile
	    environment: 
	      - backendUrl=http://backend
	    ports:
	      - "5902:80"
	    depends_on: 
	      - backend
	  backend:
	    image: pizzabackend
	    build: 
	      context: backend
	      dockerfile: Dockerfile
	    ports: 
	      - "5000:80"
	```
	- 2 parts in this code:
		- First, it creates the frontend website, naming it pizzafrontend. The code tells Docker to build it, pointing to the Dockerfile found in the frontend folder.
			+ then the code sets an environment variable for the website:
				* `backendUrl=http://backend`
			+ then this code opens a port and declares it depends on the backend service.
		- Second, the backend service gets created (named pizzabackend)
			+ it's built from the same Dockerfile created above
			+ the last command specifies which port to open
	- Commands:
		+ `docker compose build`
		+ `docker compose up`
* kubernetes support declarative configuration management meaning, the services you define in the configuration files will be retained at all costs

## Kubernetes

- is a portable, extensible open-source platform for managing and orchestrating containerized workloads.
- *Orchestration:* automatically deploys and manages containerized apps and *management:* process of organizing, adding, removing, or updating a significant number of containers
- Example 1 of kubernetes yml file
	+ code:
	```
	version: '3.4'

	services: 

	  frontend:
	    image: pizzafrontend
	    build:
	      context: frontend
	      dockerfile: Dockerfile
	    environment: 
	      - backendUrl=http://backend
	    ports:
	      - "5902:80"
	    depends_on: 
	      - backend
	  backend:
	    image: pizzabackend
	    build: 
	      context: backend
	      dockerfile: Dockerfile
	    ports: 
	      - "5900:80"
	    
	```
* Example 2:
	- code
	```
	---
	apiVersion: apps/v1
	kind: Deployment
	metadata:
	  name: pizzabackend
	spec:
	  replicas: 1
	  template:
	    metadata:
	      labels:
	        app: pizzabackend
	    spec:
	      containers:
	      - name: pizzabackend
	        image: [YOUR DOCKER USER NAME]/pizzabackend:latest
	        ports:
	        - containerPort: 80
	        env:
	        - name: ASPNETCORE_URLS
	          value: http://*:80
	  selector:
	    matchLabels:
	      app: pizzabackend
	---
	apiVersion: v1
	kind: Service
	metadata:
	  name: pizzabackend
	spec:
	  type: ClusterIP
	  ports:
	  - port: 80
	  selector:
	    app: pizzabackend
	```
	- Explanation:
		- The **first** portion defines a deployment spec for the container that will be deployed into Kubernetes
		- It specifies there will be one replica, where to find the container image, which ports to open on the container, and sets some environment variables
		- This first portion also defines labels and names that the container and spec can be referenced by

		- The **second** portion then defines that the container will run as a Kubernetes ClusterIP
		- this type of service doesn't expose an external IP address
		- It's only accessible from other services running from within the same Kubernetes cluster
	* run:
		- `kubectl apply -f backend-deploy.yml`
	* view progress
		- `kubectl get pods`

+ Example 3 of a yml file:
	* code
	```
	---
	apiVersion: apps/v1
	kind: Deployment
	metadata:
	  name: pizzafrontend
	spec:
	  replicas: 1
	  template:
	    metadata:
	      labels:
	        app: pizzafrontend
	    spec:
	      containers:
	      - name: pizzafrontend
	        image: [YOUR DOCKER USER NAME]/pizzafrontend:latest
	        ports:
	        - containerPort: 80
	        env:
	        - name: ASPNETCORE_URLS
	          value: http://*:80
	        - name: backendUrl
	          value: http://pizzabackend
	  selector:
	    matchLabels:
	      app: pizzafrontend
	---
	apiVersion: v1
	kind: Service
	metadata:
	  name: pizzafrontend
	spec:
	  type: LoadBalancer
	  ports:
	  - port: 80
	  selector:
	    app: pizzafrontend
	```
	- Then `kubectl apply -f frontend-deploy.yml`
	
### kubernetes scale

- scale `kubectl scale --replicas=5 deployment/pizzabackend`
- Verify instances `kubectl get pods`
- scale instances back down `kubectl scale --replicas=1 deployment/pizzabackend`
	

### kubernetes commands

- Build containers: `docker-compose build`
- Run the app and attahc containers `docker-compose up`
- Sign in to docker hub `docker login`
- rename iamges:
	- docker tag pizzafrontend [DOCKER USER NAME]/pizzafrontend
	- docker tag pizzabackend [DOCKER USER NAME]/pizzabackend
- push:
	- docker push [DOCKER USER NAME]/pizzafrontend
	- docker push [DOCKER USER NAME]/pizzabackend

- kubernetes resiliency proving, even if deleted, it will maintain 
	+ `kubectl get pods`
	+ `kubectl delete pod pizzafrontend-5b6cc765c4-hjpx4`
	+ `kubectl get pods`
	

## Azure Key vault and details of creating Azure objects from Cloud PS

- Defining resources in azure powershell
	+ `$useralias = "<your-initials-with-suffix>"`
		* - example: `$useralias = "sstemp1"`
	+ `$serveradminpassword = "<your-password>"`
		* * - example: `$serveradminpassword = "DeineMutter100@"`
	+ `$resourcegroupname = "learn-f7150f2-f986-4416-b521-f183188ab672"`
- Defining additional resources in azure:
	```
	$location = "eastus"
	$webappplanname = (-join($useralias,"-webappplan"))
	$webappname = (-join($useralias,"-webapp"))
	$serveradminname = "ServerAdmin"
	$servername = (-join($useralias, "-workshop-server"))
	$dbname = "eShop"
	```
- To create a new Azure App Service plan for hosting the web app, run the following PowerShell command:
	```
	New-AzAppServicePlan `
	    -Name $webappplanname `
	    -ResourceGroup $resourcegroupname `
	    -Location $location
	```
- To create a web app by using the App Service plan, run the following PowerShell command:
	```
	New-AzWebApp `
	    -Name $webappname `
	    -AppServicePlan $webappplanname `
	    -ResourceGroup $resourcegroupname `
	    -Location $location
	```
- To assign a managed identity to the web app, run the following PowerShell command. You'll require this identity later.
	```
	Set-AzWebApp `
	    -AssignIdentity $true `
	    -Name $webappname `
	    -ResourceGroupName $resourcegroupname
	```
- To create a new Azure SQL Database instance, run the following PowerShell command:
	```
	New-AzSqlServer `
	    -ServerName $servername `
	    -ResourceGroupName $resourcegroupname `
	    -Location $location `
	    -SqlAdministratorCredentials $(New-Object `
	        -TypeName System.Management.Automation.PSCredential `
	        -ArgumentList $serveradminname, `
	        $(ConvertTo-SecureString `
	        -String $serveradminpassword `
	        -AsPlainText -Force))
	```
- To open the SQL Database instance firewall to allow access to services hosted in Azure, run the following PowerShell command:
	```
	New-AzSqlServerFirewallRule `
	    -ResourceGroupName $resourcegroupname `
	    -ServerName $servername `
	    -FirewallRuleName "AllowedIPs" `
	    -StartIpAddress "0.0.0.0" `
	    -EndIpAddress "0.0.0.0"
	```
- To create a database in SQL Database, run the following PowerShell command. The database will be populated later, when you migrate the web app.
	```
	New-AzSqlDatabase  `
	    -ResourceGroupName $resourcegroupname `
	    -ServerName $servername `
	    -DatabaseName $dbName `
	    -RequestedServiceObjectiveName "S0"
	```
### ConfigurationManager and ConfigurationBuilder class

- **ConfigurationManager** approach that's used by many traditional .NET Framework and ASP.NET web apps allows an administrator to store configuration information as a series of keys and values in a config file.
- **ConfigurationBuilder** object is designed to enable you to retrieve configuration information from a variety of sources.
- some ConfigurationBuilder configuration are:
	+ **Microsoft.Configuration.ConfigurationBuilders.Environment**: Adds settings from the environment variables of the current process
	- **Microsoft.Configuration.ConfigurationBuilders.UserSecrets**: Adds user secrets contained in an XML file external to the code base
	- **Microsoft.Configuration.ConfigurationBuilders.Azure**: Pulls items from key vault
	- **Microsoft.Configuration.ConfigurationBuilders.KeyPerFile**: File based, where the name of the file is the key, and the contents are the value
	- **Microsoft.Configuration.ConfigurationBuilders.Json**: Pulls key/value pairs from JSON files
*  can also create your own custom ConfigurationBuilder class
*  the use depends of the use

### Configuration of ConfigurationBuilder

- `secrets.xml` file, located in `(%APPDATA%\Microsoft\UserSecrets<userSecretsId>\secrets.xml in Windows)`
	```
	<configuration>
	  <configSections>
	    <section name="configBuilders" type="System.Configuration.ConfigurationBuildersSection, System.Configuration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" restartOnExternalChanges="false" requirePermission="false" />
	    ...
	  </configSections>
	  <configBuilders>
	    <builders>
	      <add name="Environment" type="Microsoft.Configuration.ConfigurationBuilders.EnvironmentConfigBuilder, Microsoft.Configuration.ConfigurationBuilders.Environment, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
	      <add name="Secrets" userSecretsId="c96e0578-6490-4a2d-b6c5-cb2b0baaeae8" type="Microsoft.Configuration.ConfigurationBuilders.UserSecretsConfigBuilder, Microsoft.Configuration.ConfigurationBuilders.UserSecrets, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
	    </builders>
	  </configBuilders>
	  <appSettings configBuilders="Environment,Secrets">
	    <add key="MySecretData" value="" />
	    <add key="MyEnvironmentData" value="" />
	  </appSettings>
	  ...
	<configuration>
	```
- the order can be adjusted
- the MySecretData and MyEnvironmentData can be retried based on the `configBuilders="Environment,Secrets`  config.

### Key Vault commands

- Key Vault definition to be created:
	```
	$vaultname = (-join("shopvault", $useralias))
	```
- Create the Key Vault in azure:
	```
	New-AzKeyVault `
	    -Name $vaultname `
	    -ResourceGroupName $resourcegroupname `
	    -location $location
	```
- Retrieve principal service id of the web app:
	```
	$appId=(Get-AzWebApp `
	    -ResourceGroupName $resourcegroupname `
	    -Name $webappname).Identity.PrincipalId
	```
- Set the access policy of the key vault to allow the web app, which you identify by using the service principal, to access the key vault:
	```
	Set-AzKeyVaultAccessPolicy `
	    -VaultName $vaultname `
	    -ResourceGroupName $resourcegroupname `
	    -ObjectId $appId `
	    -PermissionsToSecrets Get
	```
	- here, the "-BypassObjectIdValidation" could be added
- Generate the connection string for the SQL Server database by using the PowerShell variables created earlier:
	```
	$connectionstringplaintext = `
	    (-join("Server=tcp:", $servername, ".database.windows.net,1433;Database=", `
	    $dbname, ";User ID=", $serveradminname, ";Password=", $serveradminpassword, `
	    ";Encrypt=true;Connection Timeout=30;"))
	```
- convert connection string into secure String
	```
	$connectionstring = ConvertTo-SecureString $connectionstringplaintext `
	    -AsPlainText `
	    -Force
	```

- [#pending]


## Improve session scalability using Azure Cache for Redis

- [#pending]
- create variables
	```
	$useralias = "ssalias1"
	$serveradminpassword = "ElEscarabaju100@"
	$resourcegroupname = "sstemp3"
	```
- then
	```
	$location = "eastus"
	$webappplanname = (-join($useralias,"-webappplan"))
	$webappname = (-join($useralias,"-webapp"))
	$serveradminname = "ServerAdmin"
	$servername = (-join($useralias, "-workshop-server"))
	$dbname = "eShop"
	```
- To create a new service plan (**OPTIONAL**)
```
	New-AzAppServicePlan `
	    -Name $webappplanname `
	    -ResourceGroup $resourcegroupname `
	    -Location $location
```

- Run the following PowerShell command to create a web app by using the App Service plan:
	```
	New-AzWebApp `
    	-Name $webappname `
    	-AppServicePlan $webappplanname `
    	-ResourceGroup $resourcegroupname `
    	-Location $location
	```

- Run the following PowerShell command to assign a managed identity to the web app. You'll need this identity later.
	```
	Set-AzWebApp `
    	-AssignIdentity $true `
    	-Name $webappname `
    	-ResourceGroupName $resourcegroupname
   	```

- Run the following PowerShell command to create a new Azure SQL Database server:
	```
	`New-AzSqlServer `
    	-ServerName $servername `
    	-ResourceGroupName $resourcegroupname `
    	-Location $location `
    	-SqlAdministratorCredentials $(New-Object `
        	-TypeName System.Management.Automation.PSCredential `
        	-ArgumentList $serveradminname, `
        	$(ConvertTo-SecureString `
        	-String $serveradminpassword `
        	-AsPlainText -Force))`
	```

- the following PowerShell command to open the SQL Database server firewall to allow access to services hosted in Azure:
```
New-AzSqlServerFirewallRule `
    -ResourceGroupName $resourcegroupname `
    -ServerName $servername `
    -FirewallRuleName "AllowedIPs" `
    -StartIpAddress "0.0.0.0" `
    -EndIpAddress "0.0.0.0"
```


- Run the following PowerShell command to create a database on the SQL Database server. The database will be populated later, when you migrate the web app.

```
New-AzSqlDatabase  `
    -ResourceGroupName $resourcegroupname `
    -ServerName $servername `
    -DatabaseName $dbName `
    -RequestedServiceObjectiveName "S0"
```
- new azure cache for redis instance name
```
$rediscachename = (-join($useralias, "-workshop-cache"))
```
- Create the azure cache for redis instance
```
az redis create `
    --location $location `
    --name $rediscachename `
    --resource-group $resourcegroupname `
    --sku Basic `
    --vm-size c0
```
- check provisioning state 
```
(Get-AzRedisCache `
    -ResourceGroupName $resourcegroupname `
    -Name $rediscachename).ProvisioningState
```
- retrieve primary access key for cache and record (use it later)
```
$rediskey = (Get-AzRedisCacheKey `
    -Name $rediscachename `
    -ResourceGroup $resourcegroupname).PrimaryKey
```
- to use the feature in the code, the package `Microsoft.Web.RedisSessionStateProvider` should be installed using nuGet.
- the web.config file look like this
```
<sessionState mode="Custom" customProvider="MySessionStateStore">
  <providers>
    <!-- For more details check https://github.com/Azure/aspnet-redis-providers/wiki -->
    <!-- Either use 'connectionString' OR 'settingsClassName' and 'settingsMethodName' OR use 'host','port','accessKey','ssl','connectionTimeoutInMilliseconds' and 'operationTimeoutInMilliseconds'. -->
    <!-- 'throwOnError','retryTimeoutInMilliseconds','databaseId' and 'applicationName' can be used with both options. -->
    <add name="MySessionStateStore" type="Microsoft.Web.Redis.RedisSessionStateProvider" host="" accessKey="" ssl="true" />
  </providers>
</sessionState>
```
- amend the entry for MySessionStateStore. replace <youralias> with the value of the $useralias in PS. Replace <primarykey> with the value of the $rediskey (the var got before)

```
<sessionState mode="Custom" customProvider="MySessionStateStore">
  <providers>
    <add name="MySessionStateStore" 
         type="Microsoft.Web.Redis.RedisSessionStateProvider" 
         host="<youralias>-workshop-cache.redis.cache.windows.net" 
         accessKey="<primarykey>"
         ssl="true" />
  </providers>
</sessionState>
```
- comment `<sessionState mode="InProc" />` in the same file `Web.Config`
- In a SQL Server database, this line: `-- USE [Microsoft.eShopOnContainers.Services.CatalogDb]` is only for a local environment, so it must be commented.
- Sometimes is required to configura a firewall rule
	```
	New-AzSqlServerFirewallRule -ResourceGroupName $resourcegroupname -ServerName $servername -FirewallRuleName "AllowDesktop" -StartIpAddress YourIPAddress -EndIpAddress YourIPAddress
	```
- few more steps ins the 21_* document


## Create and deploy a cloud-native ASP.NET Core microservice

- [#pending]

### Commands

- deletes the resource group that contains the AKS and Container Registry resources
	+ `az group delete --name eshop-learn-rg --yes`



## Implement resiliency in a cloud-native ASP.NET Core microservice

- [#pending]
- To remove all the resources created
	+ `az group delete --name eshop-learn-rg --yes`

## Instrument a cloud-native ASP.NET Core microservice

- [#pending]
- install AzureCli:
	+ `winget install -e --id Microsoft.AzureCLI`
	+ Verify: `az --version` 
	+ documentation [https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows?tabs=winget#run-the-azure-cli](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows?tabs=winget#run-the-azure-cli)
	+ 

### Commands

- login from console:
	```
	az login --use-device-code
	```
- enabling addons for a AKS cluster
	```
	az aks enable-addons \
	    --addons monitoring \
	    --name eshop-learn-aks \
	    --resource-group eshop-learn-rg \
	    --query provisioningState
	```
- temporarily set the workiong directory:
	```
	pushd ../../src/Services/Catalog/Catalog.API/
	```
- install prometheus package
	```
	dotnet add package prometheus-net.AspNetCore --version 6.0.0
	```
- deployment.yaml file:
	```
	apiVersion: apps/v1
	kind: Deployment
	metadata:
	  name: catalog
	  labels:
	    app: eshop
	    service: catalog
	spec:
	  replicas: 1
	  selector:
	    matchLabels:
	      service: catalog
	  template:
	    metadata:
	      annotations:
	        prometheus.io/scrape: "true"
	        prometheus.io/path: /metrics
	        prometheus.io/port: "80"
	      labels:
	        app: eshop
	        service: catalog
	    spec:
	      # YAML omitted for brevity
	```
- Delete the resource group to avoid charges in azure
	```
	az group delete --name eshop-learn-rg --yes
	```
- 

## Implement_feature flags cloudNative ASP.NET Core microservices app

- in vscode, Ctrl+Shift+p and then "Dev Containers: Clone Repository in Container Volume", it will automatically create a docker container
- select a repo to be cloned by vscode
- Login into azure `az login --use-device-code`
- Verify `az account show -o table`
- 



## ms learning path

- MS learning path: *"Use pages, routing, and layouts to improve Blazor navigation"*
	- [https://learn.microsoft.com/en-us/training/modules/use-pages-routing-layouts-control-blazor-navigation/?WT.mc_id=cloudskillschallenge_150aae80-e46b-4a07-894a-5247fcdfcbad](https://learn.microsoft.com/en-us/training/modules/use-pages-routing-layouts-control-blazor-navigation/?WT.mc_id=cloudskillschallenge_150aae80-e46b-4a07-894a-5247fcdfcbad)


## Topics from the challenge and folders

1. Write your first C# code

2. Get started with web development using Visual Studio Code

3. Learn the basics of web accessibility

4. Create a web UI with ASP.NET Core

5. Create a web API with ASP.NET Core controllers


6. Publish a web app to Azure with Visual Studio
	- code folder: `publish_web_azure_w_visual_studio`
	- documents folder: `6_publish_web_azure_w_visual_studio`

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
	- code folder: `blazorUnit18_ConnectFourGame`
	- documents folder: `18_Build_Connect_Four_game_with_Blazor`

19. Externalize the configuration of an ASP.NET app by using an Azure key vault
	- code folder: ``
	- documents folder: `19_Externalizing_Config_w_ASPNET_Azure_key_vault`

20. Implement logging in a .NET Framework ASP.NET web application
	- code folder: ``
	- documents folder: ``

21. Improve session scalability in a .NET Framework ASP.NET web application by using Azure Cache for Redis
	- code folder: ``
	- documents folder: `21_sessionScalability_ASPNET_webapp_usingAzueCacheRedis`

22. Build a web API with minimal API, ASP.NET Core, and .NET
	- code folder: `minimalAPI_unit22`
	- documents folder: `22_Build_API_w_minimal_API_ASPNET_Core_and_NET`

23. Use a database with minimal API, Entity Framework Core, and ASP.NET Core
	- code folder: ``
	- documents folder: `23_db_w_minimal_API_Entity_Framework_ASP_NETCore`

24. Create a full stack application by using React and minimal API for ASP.NET Core
	- code folder: `minimalAPI_n_React_unit24`
	- documents folder: `24_full_stack_app_w_React_n_minimal_API_ASPNETCore`

25. Build your first microservice with .NET
	- code folder: `microServices1`
	- documents folder: `25_Build_your_first_Microservice_w_dotNET`

26. Deploy a .NET microservice to Kubernetes
	- code folder: `microServices_kubernetes`
	- documents folder: `26_Deploy_NET_microservice_Kubernetes`

27. Create and deploy a cloud-native ASP.NET Core microservice
	- code folder: ``
	- documents folder: `27_Create_and_deploy_cloud-native_ASPNET_Core_microservice`

28. Implement resiliency in a cloud-native ASP.NET Core microservice
	- code folder: ``
	- documents folder: `28_Implement_resiliency__cloudNative_ASPNET_Core_microservice`

29. Instrument a cloud-native ASP.NET Core microservice
	- code folder: ``
	- documents folder: `29_Instrument_cloudNative_ASPNETCore_microservice`

30. Implement feature flags in a cloud-native ASP.NET Core microservices app
	- code folder: ``
	- documents folder: `30_Implement_flags_cloudNative_ASPNET_Core_microservices_app`

31. Use managed data stores in a cloud-native ASP.NET Core microservices app
	- code folder: ``
	- documents folder: ``

32. Understand API gateways in a cloud-native ASP.NET Core microservices app
	- code folder: ``
	- documents folder: ``

33. Deploy a cloud-native ASP.NET Core microservice with GitHub Actions
	- code folder: ``
	- documents folder: ``
	

# References

## Azure

	- [https://learn.microsoft.com/en-us/cli/azure/account?view=azure-cli-latest#az-account-set](https://learn.microsoft.com/en-us/cli/azure/account?view=azure-cli-latest#az-account-set)