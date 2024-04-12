namespace HappyBirthdayEmployees.Services.Models;

public abstract class BaseResponse<TData>
{
    public BaseResponse(
        bool isSuccess,
        string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }
    
    public BaseResponse(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }
    
    public BaseResponse() { }
    public bool IsSuccess { get; init; }
    
    public string? ErrorMessage { get; init; }
    
    public TData? Data { get; init; }
}