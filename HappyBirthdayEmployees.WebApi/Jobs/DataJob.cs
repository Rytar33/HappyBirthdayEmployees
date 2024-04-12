using HappyBirthdayEmployees.Services;
using HappyBirthdayEmployees.Services.Interfaces;
using Quartz;

namespace HappyBirthdayEmployees.WebApi.Jobs;

public class DataJob : IJob
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public DataJob(IServiceScopeFactory serviceScopeFactory)
        => _serviceScopeFactory = serviceScopeFactory;
    
    public async Task Execute(IJobExecutionContext context)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var senderCongratulations = scope.ServiceProvider.GetService<ISendingCongratulationsService>();
        await senderCongratulations!.SendingCongratulations()!;
    }
}