using System.ComponentModel.DataAnnotations.Schema;
using HappyBirthdayEmployees.Models.Enums;
using HappyBirthdayEmployees.Models.Validations;
using HappyBirthdayEmployees.Models.Validations.Validators;

namespace HappyBirthdayEmployees.Models;

/// <summary>
/// Сущность работник
/// </summary>
[Table("employee")]
public class Employee : BaseEntity
{
    public Employee(
        string fullName,
        DateTime dateBorn,
        JobPosition jobPosition,
        Department department,
        long? idTelegram,
        ulong? idDiscord)
    {
        FullName = fullName;
        DateBorn = dateBorn;
        JobPosition = jobPosition;
        Department = department;
        IdTelegram = idTelegram;
        IdDiscord = idDiscord;
        new EmployeeValidator().ValidateWithErrors(this);
    }
    
    public Employee() { }
    
    [Column("full_name")]
    public string FullName { get; init; }
    
    [Column("date_born")]
    public DateTime DateBorn { get; init; }
    
    [Column("job_position")]
    public JobPosition JobPosition { get; init; }
    
    [Column("department")]
    public Department Department { get; init; }
    
    [Column("id_telegram")]
    public long? IdTelegram { get; init; }
    
    [Column("id_discord")]
    public ulong? IdDiscord { get; init; }
}