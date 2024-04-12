using HappyBirthdayEmployees.EmployeesDbConnection;
using HappyBirthdayEmployees.Services;
using HappyBirthdayEmployees.Services.Interfaces;
using HappyBirthdayEmployees.WebApi.Jobs;
using Microsoft.EntityFrameworkCore;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("PostgreSQLConnection") 
                 ?? throw new InvalidOperationException();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HappyBirthdayDbContext>(options =>
    options.UseNpgsql(connection));
builder.Services.AddQuartz(options =>
{
    var jobKey = new JobKey(nameof(JobFactory));
    options
        .AddJob<DataJob>(jobKey)
        .AddTrigger(
            trigger => trigger.ForJob(jobKey).WithSimpleSchedule(
                schedule => schedule.WithIntervalInHours(24).RepeatForever())
            .StartNow());
    options.UseMicrosoftDependencyInjectionJobFactory();
    
});
builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
});
builder.Services.AddTransient<JobFactory>();
builder.Services.AddScoped<IJob, DataJob>();
builder.Services.AddScoped<ISendingCongratulationsService, SendingCongratulationsService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();

app.Run();