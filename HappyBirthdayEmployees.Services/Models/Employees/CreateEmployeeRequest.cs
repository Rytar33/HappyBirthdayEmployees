using System.ComponentModel.DataAnnotations.Schema;
using HappyBirthdayEmployees.Models.Enums;

namespace HappyBirthdayEmployees.Services.Models.Employees;

public class CreateEmployeeRequest
{
    public CreateEmployeeRequest(
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
    }

    public CreateEmployeeRequest() { }
    
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