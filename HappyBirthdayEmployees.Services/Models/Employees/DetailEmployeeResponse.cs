using HappyBirthdayEmployees.Models;

namespace HappyBirthdayEmployees.Services.Models.Employees;

public class DetailEmployeeResponse : BaseResponse<Employee>
{
    public DetailEmployeeResponse(
        bool isSuccess,
        string? errorMessage = null) 
        : base(isSuccess, errorMessage)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }
    public DetailEmployeeResponse(
        Employee employee)
    {
        IsSuccess = true;
        Data = employee;
    }

    public DetailEmployeeResponse(bool isSuccess = true) 
        : base(isSuccess)
    {
        IsSuccess = isSuccess;
    }
}