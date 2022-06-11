namespace DotNet.EFCore.CodeFirstFluentApi.RazorApp.Models
{
    /// <summary>
    /// Skill class with properties of Id, Name, IsActive and Employee Skills.
    /// </summary>
    public class Skill : BaseEntity
    {
        /// <summary>
        /// Skill Name Property
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Employee Skills Virtual Property
        /// </summary>
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
