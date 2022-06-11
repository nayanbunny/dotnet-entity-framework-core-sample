using System;
using System.Collections.Generic;

namespace DotNet.EFCore.DatabaseFirst.MvcApp.Models
{
    public partial class Skill
    {
        public Skill()
        {
            EmployeeSkills = new HashSet<EmployeeSkill>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
