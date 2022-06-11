using DotNet.EFCore.DatabaseFirst.Library.Constants;
using DotNet.EFCore.DatabaseFirst.MvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EFCore.DatabaseFirst.MvcApp.Data
{
    public partial class EFCoreDBFirstDatabaseContext : DbContext
    {
        public EFCoreDBFirstDatabaseContext()
        {
        }

        public EFCoreDBFirstDatabaseContext(DbContextOptions<EFCoreDBFirstDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().AddJsonFile(WebConstants.ConfigurationFileName, false, true);
                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString(WebConstants.ConnectionName);
                
                optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Departments");
            });

            modelBuilder.Entity<EmployeeSkill>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeSkills_Employees");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeSkills_Skills");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
