namespace DotNet.EFCore.CodeFirstFluentApi.MvcApp.Models
{
    /// <summary>
    /// Department class with properties of Name, Active Status and List of Employees.
    /// </summary>
    public class Department : BaseEntity
    {
        /// <summary>
        /// Department Name Property
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Employees under Deparment Virtual Property
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
