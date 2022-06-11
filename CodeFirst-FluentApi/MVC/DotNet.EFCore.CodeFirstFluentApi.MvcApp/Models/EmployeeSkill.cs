namespace DotNet.EFCore.CodeFirstFluentApi.MvcApp.Models
{
    /// <summary>
    /// Employee Skill Class with Employee Id and its associated skill mapping properties.
    /// </summary>
    public class EmployeeSkill
    {
        /// <summary>
        /// Unique Identifier Property
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Employee Identifier Property
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Skill Identifier Property
        /// </summary>
        public Guid SkillId { get; set; }

        /// <summary>
        /// Employee Virtual Property
        /// </summary>
        public virtual Employee Employee { get; set; } = null!;
        /// <summary>
        /// Skill Virtual Property
        /// </summary>
        public virtual Skill Skill { get; set; } = null!;
    }
}
