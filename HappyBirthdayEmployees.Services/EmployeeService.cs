using Microsoft.EntityFrameworkCore;
using HappyBirthdayEmployees.EmployeesDbConnection;
using HappyBirthdayEmployees.Models;
using HappyBirthdayEmployees.Services.Models.Employees;
using HappyBirthdayEmployees.Services.Interfaces;

namespace HappyBirthdayEmployees.Services;

public class EmployeeService : IEmployeeService
{
    public async Task<DetailEmployeeResponse> CreateEmployee(CreateEmployeeRequest createEmployeeRequest)
    {
        await using var db = new HappyBirthdayDbContext();
        var employee = new Employee(createEmployeeRequest.FullName, createEmployeeRequest.DateBorn, createEmployeeRequest.JobPosition, createEmployeeRequest.Department, createEmployeeRequest.IdTelegram, createEmployeeRequest.IdDiscord);
        await db.AddAsync(employee);
        await db.SaveChangesAsync();
        return new DetailEmployeeResponse(employee);
    }

    public async Task<DetailEmployeeResponse> UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest)
    {
        await using var db = new HappyBirthdayDbContext();
        var employee = new Employee(updateEmployeeRequest.FullName,
            updateEmployeeRequest.DateBorn,
            updateEmployeeRequest.JobPosition,
            updateEmployeeRequest.Department,
            updateEmployeeRequest.IdTelegram,
            updateEmployeeRequest.IdDiscord)
        {
            Id = updateEmployeeRequest.Id
        };
        db.Update(employee);
        await db.SaveChangesAsync();
        return new DetailEmployeeResponse(employee);
    }

    public async Task<DetailEmployeeResponse> GetEmployee(Guid idEmployee)
    {
        await using var db = new HappyBirthdayDbContext();
        var employee = await db.Employee.AsNoTracking().FirstOrDefaultAsync(e => e.Id == idEmployee);
        return employee == null 
            ? new DetailEmployeeResponse(false, "Работник не был найден") 
            : new DetailEmployeeResponse(employee);
    }
    


    public async Task<DetailEmployeeResponse> RemoveEmployee(Guid idEmployee)
    {
        await using var db = new HappyBirthdayDbContext();
        var employee = await db.Employee.AsNoTracking().FirstOrDefaultAsync(e => e.Id == idEmployee);
        if (employee == null)
            return new DetailEmployeeResponse(false, "Работник не был найден");
        db.Remove(employee);
        await db.SaveChangesAsync();
        return new DetailEmployeeResponse();
    }
}