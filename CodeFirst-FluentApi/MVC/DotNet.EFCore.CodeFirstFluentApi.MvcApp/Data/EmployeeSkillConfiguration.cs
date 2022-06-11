using DotNet.EFCore.CodeFirstFluentApi.MvcApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet.EFCore.CodeFirstFluentApi.MvcApp.Data
{
    /// <summary>
    /// EmployeeSkillConfiguration class will hold the Entity Framework Fluent API Configuration for EmployeeSkill Class properties.
    /// Each property mapped with Table, Column Name, Column Type, Indexes, Length and IsRequired etc.
    /// This class also inherits IEntityTypeConfiguration.
    /// </summary>
    /// <seealso cref="IEntityTypeConfiguration{EmployeeSkill}" />
    public class EmployeeSkillConfiguration : IEntityTypeConfiguration<EmployeeSkill>
    {
        /// <summary>
        /// Configures the EntityTypeBuilder for EmployeeSkill class properties.
        /// Properties mapped with Table, Column Name, Column Type, Indexes, Length and IsRequired etc.
        /// </summary>
        /// <param name="builder">The EmployeeSkill entity type builder.</param>
        public void Configure(EntityTypeBuilder<EmployeeSkill> builder)
        {
            // Table Name Mapping
            builder.ToTable("EmployeeSkills");

            // Entity Properties and Columns Mapping
            builder.Property(prop => prop.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("(newid())")
                .IsRequired();

            // Entity Property and Relational Mapping
            builder.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeSkills)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSkills_Employees");
            builder.HasOne(d => d.Skill)
                .WithMany(p => p.EmployeeSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSkills_Skills");
        }
    }
}
