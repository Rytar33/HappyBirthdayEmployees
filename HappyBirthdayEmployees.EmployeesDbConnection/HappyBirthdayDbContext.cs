using HappyBirthdayEmployees.Models;
using HappyBirthdayEmployees.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HappyBirthdayEmployees.EmployeesDbConnection;

public sealed class HappyBirthdayDbContext : DbContext
{
    public DbSet<Employee> Employee { get; set; }

    public HappyBirthdayDbContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public HappyBirthdayDbContext(DbContextOptions<HappyBirthdayDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=happy_birthday_employees;Username=postgres;Password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>();
        ApplyEnumConverterToString<Employee, Department>(modelBuilder, "Department");
        ApplyEnumConverterToString<Employee, JobPosition>(modelBuilder, "JobPosition");
    }
    /// <summary>
    /// Конвертатор из числового в строковое значение перечеслителя для легко читаемости из базы данных и API
    /// </summary>
    private static void ApplyEnumConverterToString<TEntity, TEnum>(ModelBuilder modelBuilder, string propertyName)
        where TEntity : class
        where TEnum : Enum
    {
        var entity = modelBuilder.Entity<TEntity>();
        var property = entity.Metadata.FindProperty(propertyName);

        if (property != null && property.ClrType == typeof(TEnum))
        {
            property.SetValueConverter(
                new ValueConverter<TEnum, string>(
                    v => v.ToString(),
                    v => (TEnum)Enum.Parse(typeof(TEnum), v)
                )
            );
        }
    }
}