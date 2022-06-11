<div style="color:cornflowerblue">

# DotNet Entity Framework Core - Code First Approach Sample

</div>

In this approach, we model our entities and database context. Then either using Migrations or DB Initializer, we create the database.

Language : `C#` <br/>
.Net Version : `>=6.0`

### **Pre-Requisites**

- Visual Studio IDE
- Microsoft SQL Server
- Azure Data Studio / SQL Server Management Studio (SSMS) / SSDT for Visual Studio
  <br/>

## **Scenario**

- Database with tables:
  - Departments (Departments data like Name, IsActive)
  - Employees (Employee data like Name, Email, Phone, DepartmentId, IsActive)
  - Skills (Skills data like Name, IsActive)
  - EmployeeSkills (Relation Mapping between Employee and Skill)
- Each Employee belongs to a department and can have multiple skills.

## **Execution & Implementation Steps**

#### MVC Sample - [DotNet MVC Entity Framework Core](./MVC/)

#### Razor Pages Sample - [DotNet Razor Pages Entity Framework Core](./RazorPages/)

## References

[EntityFrameworkCore](https://docs.microsoft.com/en-us/ef/core/)<br/>
[.Net Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-6.0)<br/>
[.Net Core Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-6.0&tabs=visual-studio)<br/>
[EFCore - Get Started](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0)<br/>
[EFCore - MVC](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application)<br/>
[EF Core - Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-6.0&tabs=visual-studio)<br/>
[EF - Code First](https://www.c-sharpcorner.com/article/code-first-approach-in-asp-net-core-mvc-with-ef-core-migration/)

### :fire: Happy Coding
