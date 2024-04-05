# Entity Framework
This file documents how Entity Framework Core is  used.


## Running migrations and other DOTNET-EF commands.
Assuming your are in the root of the solution:
`cd src/Api` to go into the Api project.

From here you can run migrations: `dotnet ef migrations add Initial --project ..\Infrastructure\`.

You can also update and drop the database: `dotnet ef database update/drop --project ..\Infrastructure\`.

The reason why you can to do it like this, it that the Api.csproj is the startup project, and therefore the EntityFrameworkCore.Design package is installed in that project, 
where the other EFCore packages are installed in the Infrastructure project.
