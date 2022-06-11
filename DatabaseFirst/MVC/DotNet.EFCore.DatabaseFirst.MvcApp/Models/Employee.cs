using System;
using System.Collections.Generic;

namespace DotNet.EFCore.DatabaseFirst.MvcApp.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeSkills = new HashSet<EmployeeSkill>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public long? Phone { get; set; }
        public Guid DepartmentId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
