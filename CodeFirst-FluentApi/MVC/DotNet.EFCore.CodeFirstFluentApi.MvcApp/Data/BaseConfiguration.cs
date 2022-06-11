using DotNet.EFCore.CodeFirstFluentApi.MvcApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet.EFCore.CodeFirstFluentApi.MvcApp.Data
{
    /// <summary>
    /// BaseEntityConfiguration class will hold the Entity Framework Fluent API Configuration for BaseEntity Class properties.
    /// Each property will have declarations based on DB Schema, Column Types, Indexes, Length and IsRequired etc.
    /// This class also inherits EF Core Entity Type Configuration.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="IEntityTypeConfiguration{TEntity}" />
    public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Configures the EntityTypeBuilder for BaseEntity class properties.
        /// Property will have declarations based on DB Schema, Column Types, Indexes, Length and IsRequired etc.
        /// </summary>
        /// <param name="builder">The base configuration.</param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // Entity Properties and Columns Mapping
            builder.Property(prop => prop.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")  
                .HasDefaultValueSql("(newid())")
                .IsRequired();
            builder.Property(prop => prop.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("bit")
                .HasDefaultValueSql("((0))")
                .IsRequired();
        }
    }
}
