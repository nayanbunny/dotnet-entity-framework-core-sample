namespace DotNet.EFCore.CodeFirst.MvcApp.Models
{
    /// <summary>
    /// Skill class with properties of Id, Name, IsActive and Employee Skills.
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Unique Identitifer Property
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Skill Name Property
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Skill Status Property
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Employee Skills Virtual Property
        /// </summary>
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
