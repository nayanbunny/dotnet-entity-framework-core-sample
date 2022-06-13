namespace DotNet.EFCore.ModelFirst.MvcApp.Models
{
    /// <summary>
    /// Department class with properties of Name, Active Status and List of Employees.
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Unique Identifier Property
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Department Name Property
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Department Status Property
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Employees under Deparment Virtual Property
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
