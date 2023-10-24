## This is a Todo application that features:

- [**Todo.WebApp**] - An ASP.NET Core hosted Blazor WASM front end application
- [**TodoApi**] - An ASP.NET Core REST API backend using minimal APIs
## Prerequisites

### .NET
1. [Install .NET 7](https://dotnet.microsoft.com/en-us/download)

### .SQL2019
1. [Install SQL2019](https://www.microsoft.com/en-us/evalcenter/download-sql-server-2019)

### Database
1.Update SQL Connection string in DefaultConnection in appsettings.json
2. Navigate to the `TodoApi` folder.
    1. Run `update-database` to create the database.
3. Learn more about [dotnet-ef](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

### Running the application

 Below is way to run both applications:
   - **Visual Studio** - Setup multiple startup projects by right clicking on the solution and selecting Properties. Select `TodoApi` and `TodoWebApp` as startup projects.
     
   - <img width="589" alt="image" src="https://github.com/GitHubTirupati/Upelrs/assets/38210277/35bbd0e8-b3de-4468-a014-7a76a8a0dac7">

## Optional

### Using the API standalone
The Todo REST API can run standalone as well. You can run the [TodoApi]) project and make requests to various endpoints using the Swagger UI (or a client of your choice):
<img width="1208" alt="image" src="https://github.com/GitHubTirupati/Upelrs/assets/38210277/ba11ceaa-00df-4b51-81e8-1ec40ee7eb10">


