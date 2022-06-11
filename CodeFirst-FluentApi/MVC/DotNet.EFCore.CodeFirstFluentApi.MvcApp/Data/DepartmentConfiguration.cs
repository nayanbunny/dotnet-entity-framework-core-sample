using DotNet.EFCore.CodeFirstFluentApi.MvcApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet.EFCore.CodeFirstFluentApi.MvcApp.Data
{
    /// <summary>
    /// DepartmentConfiguration class will hold the Entity Framework Fluent API Configuration for Department Class properties.
    /// Each property mapped with Table, Column Name, Column Type, Indexes, Length and IsRequired etc.
    /// This class also inherits BaseConfiguration.
    /// </summary>
    /// <seealso cref="BaseConfiguration{Department}" />
    public class DepartmentConfiguration : BaseConfiguration<Department>
    {
        /// <summary>
        /// Configures the EntityTypeBuilder for Department class properties.
        /// Properties mapped with Table, Column Name, Column Type, Indexes, Length and IsRequired etc.
        /// </summary>
        /// <param name="builder">The department entity type builder.</param>
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            // Table Name Mapping
            builder.ToTable("Departments");

            // Entity Properties and Columns Mapping
            builder.Property(prop => prop.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
