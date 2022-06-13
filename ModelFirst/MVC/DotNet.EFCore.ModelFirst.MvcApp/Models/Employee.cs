namespace DotNet.EFCore.ModelFirst.MvcApp.Models
{
    /// <summary>
    /// Employee class with Name, Email, Phone, Department, Active Status and Employee Skills properties.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Unique Identifier Property
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Employee Name Property
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Employee Email Property
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Employee Phone Property
        /// </summary>
        public long? Phone { get; set; }
        /// <summary>
        /// Employee Department Identifier Property
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Employee Status Property
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Employee Department Virtual Property
        /// </summary>
        public virtual Department Department { get; set; } = null!;
        /// <summary>
        /// Employee Skills Virtual Property
        /// </summary>
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
