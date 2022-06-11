namespace DotNet.EFCore.CodeFirstFluentApi.RazorApp.Models
{
    /// <summary>
    /// Base Entity
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Unique Identifier Property
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Status Property
        /// </summary>
        public bool? IsActive { get; set; }
    }
}
