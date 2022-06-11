namespace DotNet.EFCore.CodeFirstFluentApi.MvcApp.Models
{
    /// <summary>
    /// Response View Model class with properties of Departments, Skills, Employees and Employee Skills.
    /// </summary>
    public class ResponseViewModel
    {
        /// <summary>
        /// Departments Property
        /// </summary>
        public List<Department>? Departments { get; set;}
        /// <summary>
        /// Skills Property
        /// </summary>
        public List<Skill>? Skills { get; set; }
        /// <summary>
        /// Employees Property
        /// </summary>
        public List<Employee>? Employees { get; set; }
        /// <summary>
        /// Employee Skills Property
        /// </summary>
        public List<EmployeeSkill>? EmployeeSkills { get; set; }
    }
}
