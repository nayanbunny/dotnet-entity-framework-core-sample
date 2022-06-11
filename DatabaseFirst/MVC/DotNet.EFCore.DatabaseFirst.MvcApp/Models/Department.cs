using System;
using System.Collections.Generic;

namespace DotNet.EFCore.DatabaseFirst.MvcApp.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
