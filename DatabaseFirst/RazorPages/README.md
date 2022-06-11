<div style="color:cornflowerblue">

# DotNet Razor Pages Entity Framework Core - Database First Approach Sample

</div>

In this approach, we create database first then model our entities either manually or using scaffolding. This approach is useful when we work with an existing databases.

Razor Pages can make coding page-focused scenarios easier and more productive than using controllers and views.

Language : `C#` <br/>
.Net Version : `>=6.0`

### **Dependency Framework/NuGet Packages**

- Microsoft.AspNetCore.App>=6.0
- Microsoft.NETCore.App>=6.0
- Microsoft.EntityFrameworkCore.Tools>=6.0
- Microsoft.EntityFrameworkCore.SqlServer>=6.0
- Microsoft.VisualStudio.Web.CodeGeneration.Design>=6.0

### **Pre-Requisites**

- Visual Studio IDE
- Microsoft SQL Server
- Azure Data Studio / SQL Server Management Studio (SSMS) / SSDT for Visual Studio

## **Execution Steps**

1. Execute `efcore-dbfirst-approach.sql` script from `Scripts` folder on `SQL Server` to setup `Database` with sample data.
2. Get connection string from SQL Database and update in `appsettings.json`.
   - `Integrated Security = True` for Windows Authentication.
   - `User Id={Username}; Password={Password}` for Standard Security.
   <pre><code style="color:#00aaaa">"ConnectionStrings": {
       "DefaultConnection": "Server={ServerName};Database={DatabaseName};Integrated Security=True"
   }</code></pre>
3. Run `DotNet.EFCore.DatabaseFirst.RazorApp` project. Check `CRUD (Create-Read-Update-Delete)` operations against database using `Entity Framework Core`.

## **Implementation Steps**

1. Skeleton `Code Structure` as per requirements.
2. Add dependent `NuGet Packages`.
   - `Microsoft.EntityFrameworkCore.Tools`
   - `Microsoft.EntityFrameworkCore.SqlServer`
3. Have existing database ready and get connection string.
4. Update SQL Connection String in `appsettings.json`.
   - `Integrated Security = True` for Windows Authentication.
   - `User Id={Username}; Password={Password}` for Standard Security.
   <pre><code style="color:#00aaaa">"ConnectionStrings": {
       "DefaultConnection": "{SQL Connection String}"
   }</code></pre>
5. Launch `Package Manager Console`. Choose project with EF NuGet Packages Installed (E.g., `DotNet.EFCore.DatabaseFirst.RazorApp`) as `Default` and `Startup` Project.
   <pre><code style="color:#00aaaa">Visual Studio IDE --> Tools --> NuGet Package Manager --> Package Manager Console</code></pre>
6. Scaffold Database Context using `Scaffold-DbContext` command. This will create `Models`, `DbContext` in specified output directory as per existing `database schema`.
   <pre><code style="color:#00aaaa">Scaffold-DbContext "{SQL Connection String}" Microsoft.EntityFrameworkCore.SqlServer -OutputDir {Folder Name}</code></pre>
7. `[OPTIONAL]` Move `Context` file to separate directory if required. If moved, update according `namespace` references in dependent files.
8. Update `OnConfiguring` method in DbContext for getting connection string from JSON config file or some secure vault like Azure Key Vault etc.
9. Register DbContext in Application Builder Services Collection before performing Application Build either in `Program.cs` or `Startup.cs`.
   <pre><code style="color:#00aaaa">builder.Services.AddDbContext<{Db Context Name}>();</code></pre>
10. Now `DbContext` can be injected in `Page .cs file (page.cshml.cs)` and can be used to access database.
11. Create `Razor Page` under `Pages` with folder organization with either `Razor Page with Entity Framework Core (CRUD)` or `Razor Page Empty`.
12. [OPTIONAL] Implement either `Repository/Unit of Work(UoW)/Factory Pattern etc`., to separte operations based on entity using injected `DbContext`.
13. Pass transactional data to `Pages` using `Models`.
14. Run `DotNet.EFCore.DatabaseFirst.RazorApp` project. Check `CRUD (Create-Read-Update-Delete)` operations against database using `Entity Framework Core`.

## References

[EntityFrameworkCore](https://docs.microsoft.com/en-us/ef/core/)<br/>
[.Net Core Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-6.0&tabs=visual-studio)<br/>
[EF Core - Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-6.0&tabs=visual-studio)<br/>
[EFCore - Get Started](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0)<br/>
[EFCore - Model from DB](https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx)

### :fire: Happy Coding
