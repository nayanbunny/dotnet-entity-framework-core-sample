using DotNet.EFCore.CodeFirstFluentApi.MvcApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet.EFCore.CodeFirstFluentApi.MvcApp.Data
{
    /// <summary>
    /// SkillConfiguration class will hold the Entity Framework Fluent API Configuration for Skill Class properties.
    /// Each property mapped with Table, Column Name, Column Type, Indexes, Length and IsRequired etc.
    /// This class also inherits BaseConfiguration.
    /// </summary>
    /// <seealso cref="BaseConfiguration{Skill}" />
    public class SkillConfiguration : BaseConfiguration<Skill>
    {
        /// <summary>
        /// Configures the EntityTypeBuilder for Skill class properties.
        /// Properties mapped with Table, Column Name, Column Type, Indexes, Length and IsRequired etc.
        /// </summary>
        /// <param name="builder">The Skill entity type builder.</param>
        public override void Configure(EntityTypeBuilder<Skill> builder)
        {
            // Table Name Mapping
            builder.ToTable("Skills");

            // Entity Properties and Columns Mapping
            builder.Property(prop => prop.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
