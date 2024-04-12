using HappyBirthdayEmployees.Services.Models.Employees;

namespace HappyBirthdayEmployees.Services.Interfaces;

public interface IEmployeeService
{
    Task<DetailEmployeeResponse> CreateEmployee(CreateEmployeeRequest createEmployeeRequest);

    Task<DetailEmployeeResponse> UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest);

    Task<DetailEmployeeResponse> GetEmployee(Guid idEmployee);

    Task<DetailEmployeeResponse> RemoveEmployee(Guid idEmployee);
}
