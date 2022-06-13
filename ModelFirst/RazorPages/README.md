<div style="color:cornflowerblue">

# DotNet Razor Pages Entity Framework Core - Model First Approach Sample

</div>

> [`ADO.Net Entity Data Model/Designer` supports in `.Net Framework` but not in `.Net/EF Core`.](https://docs.microsoft.com/en-us/answers/questions/363546/adonet-entity-data-model.html)

To port an `EF6 Model` `EDMX-Based Model` to `EF Core`, regenerate a new code-based model using `Scaffold-DbContext`.

#### [EF - Model First Approach Sample](https://www.entityframeworktutorial.net/model-first-with-entity-framework.aspx)

#### [Port EF6 EDMX to EFCore](https://docs.microsoft.com/ef/efcore-and-ef6/porting/port-edmx)

In this approach, (`EF Core`) we model our entities and database context as code-based similar to Code-First. Then either using Migrations or DB Initializer, we create the database.

Razor Pages can make coding page-focused scenarios easier and more productive than using controllers and views.

Language : `C#` <br/>
.Net Version : `>=6.0`

### **Dependency NuGet Packages**

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

1. Have SQL Server ready with either existing or no database and get/make connection string.
2. Update SQL Connection String in `appsettings.json`.
   - `Integrated Security = True` for Windows Authentication.
   - `User Id={Username}; Password={Password}` for Standard Security.
   <pre><code style="color:#00aaaa">"ConnectionStrings": {
       "DefaultConnection": "Server={ServerName};Database={DatabaseName};Integrated Security=True"
   }</code></pre>
3. Run `DotNet.EFCore.ModelFirst.RazorApp` project. Check `CRUD (Create-Read-Update-Delete)` operations against database using `Entity Framework Core`.

## **Implementation Steps**

1. Skeleton `Code Structure` as per requirements.
2. Add dependent `NuGet Packages`.
   - `Microsoft.EntityFrameworkCore.Tools`
   - `Microsoft.EntityFrameworkCore.SqlServer`
3. Have SQL Server ready with either existing or no database and get/make connection string.
4. Update SQL Connection String in `appsettings.json`.
   - `Integrated Security = True` for Windows Authentication.
   - `User Id={Username}; Password={Password}` for Standard Security.
   <pre><code style="color:#00aaaa">"ConnectionStrings": {
       "DefaultConnection": "{SQL Connection String}"
   }</code></pre>
5. Create `Models` and `Database Context`. Update `OnConfiguring` method in DbContext for getting connection string from JSON config file or some secure vault like Azure Key Vault etc.

6. Launch `Package Manager Console`. Choose project with EF NuGet Packages Installed (E.g., `DotNet.EFCore.ModelFirst.RazorApp`) as `Default` and `Startup` Project.

   <pre><code style="color:#00aaaa">Visual Studio IDE --> Tools --> NuGet Package Manager --> Package Manager Console</code></pre>

7. Create `Database` and `Tables` using `Entity Framework Core` or `Entity Framework`.

   - `Automated Migration`
     - DB Initializer - C# code to ensure database creation and its data.
     - Enable Migration with Automatic MigrationsEnabled (Entity Framework).
   - `Code Migration`
     - Migration commands to migrate database to latest version. (E.g., `Add-Migration`, `Update-Database` etc.)

8. Create `DB Initializer` with a method injected with `DB Context`. Then add required entities and data to the context and save changes.
   <pre><code style="color:#00aaaa">public static class MyDbInitializer
   {
        public static void Initialize(MyDbContext context)
        {
            // Ensuring Database context exists when Database exists or newly created.
            context.Database.EnsureCreated();
   
            if (context.Employees.Any())
                return; // Db has been seeded
   
            // Employees Sample Data
            var employees = new Employee[]
            {
               Name = "Arjun", Email = "arjun@abc.com", Phone = 9876543210, IsActive = true }
            };
            
            // Adding Entities sample data to Context
            context.Employees.AddRange(employees);
   
            // Saving Changes to DB Context
            context.SaveChanges();
        }
    }</code></pre>

9. `[OPTIONAL]` **Entity Framework Option** - Enable Automatic Migrations using below command. Once executed, it will create an internal sealed Configuration class derived from `DbMigrationConfiguration` in the `Migrations` folder.
   <pre><code style="color:#00aaaa">Enable-Migrations –EnableAutomaticMigration:$true</code></pre>

   Set the database initializer in the context class to <pre><code style="color:#00aaaa">MigrateDatabaseToLatestVersion.
   Database.SetInitializer(new MigrateDatabaseToLatestVersion<{DBContext Name}, EF6Console.Migrations.Configuration>());</code></pre>

10. Commands for Code Migration (either 8 or this step).

    Entity Framework Commands
    <pre><code style="color:#00aaaa">[OPTIONAL] Enable-Migrations
    Add-Migration {MigrationName}
    Update-Database -Verbose</code></pre>

    Entity Framework Core Commands
    <pre><code style="color:#00aaaa">[OPTIONAL] EntityFrameworkCore\Enable-Migrations
    EntityFrameworkCore\Add-Migration {MigrationName}
    EntityFrameworkCore\Update-Database -Verbose</code></pre>

11. Register DbContext and DB Initializer in Application Builder Services Collection before performing Application Build either in `Program.cs` or `Startup.cs`.
    <pre><code style="color:#00aaaa">builder.Services.AddDbContext<{DB Context Name}>();
    MyDbInitializer.Initialize(new {DB Context Name}());</code></pre>
12. Now `DbContext` can be injected in `Page .cs file (page.cshml.cs)` and can be used to access database.
13. Create Razor Page under Pages with Folder Organization with either `Razor Page with Entity Framework Core (CRUD)` or `Razor Page Empty`.
14. [OPTIONAL] Implement either `Repository/Unit of Work(UoW)/Factory Pattern etc`., to separte operations based on entity using injected `DbContext`.
15. Pass transactional data to `Pages` using `Models`.
16. Run `DotNet.EFCore.ModelFirst.RazorApp` project. Check `CRUD (Create-Read-Update-Delete)` operations against database using `Entity Framework Core`.

## References

[EntityFrameworkCore](https://docs.microsoft.com/en-us/ef/core/)<br/>
[.Net Core Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-6.0&tabs=visual-studio)<br/>
[EF Core - Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-6.0&tabs=visual-studio)<br/>
[EFCore - Get Started](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0)<br/>
[EF - Model First](https://docs.microsoft.com/en-us/ef/ef6/modeling/designer/workflows/model-first)

### :fire: Happy Coding
