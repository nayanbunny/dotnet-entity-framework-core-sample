using DotNet.EFCore.CodeFirstFluentApi.MvcApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet.EFCore.CodeFirstFluentApi.MvcApp.Data
{
    /// <summary>
    /// EmployeeConfiguration class will hold the Entity Framework Fluent API Configuration for Employee Class properties.
    /// Each property mapped with Table, Column Name, Column Type, Indexes, Length and IsRequired etc.
    /// This class also inherits BaseConfiguration.
    /// </summary>
    /// <seealso cref="BaseConfiguration{Employee}" />
    public class EmployeeConfiguration : BaseConfiguration<Employee>
    {
        /// <summary>
        /// Configures the EntityTypeBuilder for Employee class properties.
        /// Properties mapped with Table, Column Name, Column Type, Indexes, Length and IsRequired etc.
        /// </summary>
        /// <param name="builder">The Employee entity type builder.</param>
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Table Name Mapping
            builder.ToTable("Employees");

            // Entity Properties and Columns Mapping
            builder.Property(prop => prop.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(prop => prop.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);
            builder.Property(prop => prop.Phone)
                .HasColumnName("Phone")
                .HasColumnType("bigint");

            // Entity Property and Relational Mapping
            builder.HasOne(d => d.Department)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Departments");
        }
    }
}
