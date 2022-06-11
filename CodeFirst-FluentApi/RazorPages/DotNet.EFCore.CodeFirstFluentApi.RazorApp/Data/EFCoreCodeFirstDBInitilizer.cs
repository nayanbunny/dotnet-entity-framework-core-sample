using DotNet.EFCore.CodeFirstFluentApi.RazorApp.Models;

namespace DotNet.EFCore.CodeFirstFluentApi.RazorApp.Data
{
    /// <summary>
    /// Entity Framework Core Code First Database Initializer
    /// </summary>
    public static class EFCoreCodeFirstDbInitializer
    {
        /// <summary>
        /// Initialize method to create database, tables and sample data.
        /// </summary>
        /// <param name="context">The DB Context</param>
        public static void Initialize(EFCoreCodeFirstDatabaseContext context)
        {
            // Ensuring Database context exists when Database exists or newly created.
            context.Database.EnsureCreated();

            if (context.Departments.Any())
                return; // Db has been seeded

            // Departments Sample Data
            var departments = new Department[]
            {
                new Department { Id = new Guid("5A573A17-B74F-4F74-A8E1-D0184F4B0C90"), Name = "Engineering", IsActive = true },
                new Department { Id = new Guid("FBF88BF4-8D2B-46D4-9E52-C5B0E7E97279"), Name = "Designing", IsActive = true },
                new Department { Id = new Guid("0684877A-4DB5-4E64-9728-C44ACE259CFA"), Name = "Finance", IsActive = false },
            };

            // Skills Sample Data
            var skills = new Skill[]
            {
                new Skill { Id = new Guid("69D0E326-2520-486C-99E2-385A34803579"), Name = "Designing", IsActive = true },
                new Skill { Id = new Guid("D765CBE3-0A1C-4A28-9F2E-56B36A50E8D2"), Name = "Management", IsActive = true },
                new Skill { Id = new Guid("3760C414-D917-467F-A482-9ED3887639DE"), Name = "Programming", IsActive = true },
                new Skill { Id = new Guid("C64489F0-2EE7-444F-A9FC-AD18550D8B6C"), Name = "Testing", IsActive = true },
                new Skill { Id = new Guid("3873D6CA-2B0C-44FC-B548-BDF22354E638"), Name = "Machine Assembly", IsActive = true },
                new Skill { Id = new Guid("0DE189F1-A036-40D8-AEA4-C0704C04EBE7"), Name = "Training", IsActive = false },
                new Skill { Id = new Guid("D811546C-B66B-46D3-9E23-F7441B4CD094"), Name = "Workflow", IsActive = false }
            };

            // Employees Sample Data
            var employees = new Employee[]
            {
                new Employee { Id = new Guid("43DF727E-B8F7-4B9B-98C3-187E32844EC9"), Name = "John", Email = "john@abc.com", Phone = 8765432109, DepartmentId = new Guid("FBF88BF4-8D2B-46D4-9E52-C5B0E7E97279"), IsActive = true },
                new Employee { Id = new Guid("367DE4BD-A143-4196-8BAA-288705CD8963"), Name = "Arjun", Email = "arjun@abc.com", Phone = 9876543210, DepartmentId = new Guid("5A573A17-B74F-4F74-A8E1-D0184F4B0C90"), IsActive = true },
                new Employee { Id = new Guid("170528A9-3D66-4038-A16D-E6D10DE12824"), Name = "Ram", Email = "ram@abc.com", Phone = 7654321098, DepartmentId = new Guid("0684877A-4DB5-4E64-9728-C44ACE259CFA"), IsActive = false },
                new Employee { Id = new Guid("9B5C0AFD-9E08-4724-88F1-ECF47BC8BBB9"), Name = "Siri", Email = "siri@abc.com", Phone = 9123456780, DepartmentId = new Guid("5A573A17-B74F-4F74-A8E1-D0184F4B0C90"), IsActive = true }
            };

            // Employee Skills Sample Data
            var employeeSkills = new EmployeeSkill[]
            {
                new EmployeeSkill { Id = new Guid("137E00EF-C9E4-4938-8E51-3938A954B2D2"), EmployeeId = new Guid("170528A9-3D66-4038-A16D-E6D10DE12824"), SkillId = new Guid("D811546C-B66B-46D3-9E23-F7441B4CD094") },
                new EmployeeSkill { Id = new Guid("A91B0E9D-4A18-4BA6-8D97-4C10AE43DAE8"), EmployeeId = new Guid("367DE4BD-A143-4196-8BAA-288705CD8963"), SkillId = new Guid("0DE189F1-A036-40D8-AEA4-C0704C04EBE7") },
                new EmployeeSkill { Id = new Guid("5953C3F5-E8AC-4007-9372-5B979F78F0AD"), EmployeeId = new Guid("9B5C0AFD-9E08-4724-88F1-ECF47BC8BBB9"), SkillId = new Guid("C64489F0-2EE7-444F-A9FC-AD18550D8B6C") },
                new EmployeeSkill { Id = new Guid("4710C4F0-8259-4DC4-9D45-8701214CCB88"), EmployeeId = new Guid("170528A9-3D66-4038-A16D-E6D10DE12824"), SkillId = new Guid("D765CBE3-0A1C-4A28-9F2E-56B36A50E8D2") },
                new EmployeeSkill { Id = new Guid("468DC805-C4EF-4287-B591-C70BE4C2F5D7"), EmployeeId = new Guid("43DF727E-B8F7-4B9B-98C3-187E32844EC9"), SkillId = new Guid("69D0E326-2520-486C-99E2-385A34803579") },
                new EmployeeSkill { Id = new Guid("ACD58021-9F5C-41AF-B9E9-C79AC37A11AD"), EmployeeId = new Guid("9B5C0AFD-9E08-4724-88F1-ECF47BC8BBB9"), SkillId = new Guid("3760C414-D917-467F-A482-9ED3887639DE") },
                new EmployeeSkill { Id = new Guid("5A63768A-6740-4929-9E40-E6CC246B3A25"), EmployeeId = new Guid("367DE4BD-A143-4196-8BAA-288705CD8963"), SkillId = new Guid("3760C414-D917-467F-A482-9ED3887639DE") },
                new EmployeeSkill { Id = new Guid("B0571C42-B526-47E0-B061-EC07880B7EFA"), EmployeeId = new Guid("367DE4BD-A143-4196-8BAA-288705CD8963"), SkillId = new Guid("D765CBE3-0A1C-4A28-9F2E-56B36A50E8D2") }
            };
            
            // Adding Entities sample data to Context
            context.Departments.AddRange(departments);
            context.Skills.AddRange(skills);
            context.Employees.AddRange(employees);
            context.EmployeeSkills.AddRange(employeeSkills);

            // Saving Changes to DB Context
            context.SaveChanges();
        }
    }
}
