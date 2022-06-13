<div style="color:cornflowerblue">

# DotNet Entity Framework Core Sample

</div>

`Entity Framework (EF) Core` is a lightweight, extensible, open source and cross-platform version of the popular Entity Framework data access technology.

EF Core can serve as an object-relational mapper (O/RM), which:

- Enables .NET developers to work with a database using .NET objects.
- Eliminates the need for most of the data-access code that typically needs to be written.

EF Core supports many database engines, see [Database Providers](https://docs.microsoft.com/ef/core/providers/?tabs=dotnet-core-cli) for details.

Entity Framework development approaches:

- Code First
- Code First - Fluent API
- Database First
- Model First

<div align="center">

![EF Core Development Approach](https://smartwareblog.files.wordpress.com/2012/09/model-workflow.png)

### Entity Framework Development Approach Decision

![EF Core Development Approach Decision](https://www.entityframeworktutorial.net/images/EF5/choose-modeling.png)

</div>

### Entity Framework development approaches in .NET Core

| Feature              | Code First                                                           | Code First - Fluent API                                                                                       | Database First                                              | Model First                                                                                                |
| -------------------- | -------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------- |
| Definition           | Create a database from the model, and then add data to the database. | Create a database from the model, and then add data to the database. ModelBuilder class acts as a Fluent API. | Creating entity & context classes for an existing database. | Create a new model using the Entity Framework Designer and then generate a database schema from the model. |
| Suitable Application | Greenfield / Brownfield                                              | Greenfield                                                                                                    | Brownfield                                                  | Greenfield                                                                                                 |
| Application Size     | Small                                                                | Small                                                                                                         | Large                                                       | Small / Medium                                                                                             |
| Data Intensity       | No                                                                   | No                                                                                                            | Yes                                                         | No                                                                                                         |
| Version Control      | Yes                                                                  | Yes                                                                                                           | No                                                          | Yes                                                                                                        |
| GUI                  | No                                                                   | No                                                                                                            | Yes                                                         | Yes (Slow / Laggy)                                                                                         |
| Code Development     | Ease                                                                 | Ease                                                                                                          | Moderate                                                    | Moderate                                                                                                   |
| DB Maintenance       | Moderate                                                             | Moderate                                                                                                      | Ease                                                        | Bit Hard (Laggy GUI)                                                                                       |
| Query Data           | LINQ                                                                 | LINQ                                                                                                          | LINQ / Stored Procedure                                     | LINQ                                                                                                       |

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

#### Code First Sample - [DotNet Entity Framework Core Code First](./CodeFirst/)

#### Code First Fluent API Sample - [DotNet Entity Framework Core Code First Fluent API](./CodeFirst-FluentApi/)

#### Database First Sample - [DotNet Entity Framework Core Database First](./DatabaseFirst/)

#### Model First Sample - [DotNet Entity Framework Core Model First](./ModelFirst/)

## References

[EntityFrameworkCore](https://docs.microsoft.com/ef/core/)<br/>
[Entity Framework Core Tutorial](https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx)<br/>
[EF Core and EF6](https://docs.microsoft.com/en-us/ef/efcore-and-ef6/)<br/>
[.Net Core MVC](https://docs.microsoft.com/aspnet/core/mvc/overview?view=aspnetcore-6.0)<br/>
[EFCore - Get Started](https://docs.microsoft.com/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0)

### :fire: Happy Coding
