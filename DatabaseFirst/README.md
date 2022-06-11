<div style="color:cornflowerblue">

# DotNet Entity Framework Core - Database First Approach Sample

</div>

In this approach, we create database first then model our entities either manually or using scaffolding. This approach is useful when we work with an existing databases.

Language : `C#` <br/>
.Net Version : `>=6.0`

### **Pre-requisites**

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
[EFCore - Model from DB](https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx)<br/>
[EF Core - Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-6.0&tabs=visual-studio)

### :fire: Happy Coding
