using HappyBirthdayEmployees.Services;
using HappyBirthdayEmployees.Services.Models.Employees;
using Microsoft.AspNetCore.Mvc;

namespace HappyBirthdayEmployees.WebApi.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class EmployeeController : Controller
{
    [Route("{id:guid}")]
    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var response = await new EmployeeService().GetEmployee(id);
        return response.IsSuccess
            ? Ok(response.Data)
            : NotFound(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeRequest employee)
    {
        var response = await new EmployeeService().CreateEmployee(employee);
        return response.IsSuccess
            ? Created($"Api/Employee/{response.Data!.Id}", response.Data)
            : BadRequest(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateEmployeeRequest employee)
    {
        var response = await new EmployeeService().UpdateEmployee(employee);
        return response.IsSuccess
            ? Ok(response.Data)
            : NotFound(response);
    }

    [Route("{id:guid}")]
    [HttpDelete]
    public async Task<IActionResult> Remove([FromRoute] Guid id)
    {
        var response = await new EmployeeService().RemoveEmployee(id);
        return response.IsSuccess
            ? NoContent()
            : BadRequest(response);
    }
}