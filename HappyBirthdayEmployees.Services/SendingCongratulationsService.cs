using HappyBirthdayEmployees.EmployeesDbConnection;
using HappyBirthdayEmployees.ExportTools;
using HappyBirthdayEmployees.Models;
using HappyBirthdayEmployees.Models.Enums;
using HappyBirthdayEmployees.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace HappyBirthdayEmployees.Services;

public class SendingCongratulationsService : ISendingCongratulationsService
{
    private async Task<List<Employee>> GetWhoCongratulations()
    {
        var dateTimeToday = DateTime.Today;
        await using var db = new HappyBirthdayDbContext();
        return await db.Employee
            .Where(e => 
            e.DateBorn.Month == dateTimeToday.Month 
            & e.DateBorn.Day == dateTimeToday.Day)
            .ToListAsync();
    }

    public async Task SendingCongratulations()
    {
        var employees = await GetWhoCongratulations();
        foreach (var employee in employees)
        {
            var textCongratulation = GetCongratulationText(employee);

            if (employee.IdDiscord != null)
                await DiscordBot.Program
                    .SendCongratulationMessage(
                    (ulong)employee.IdDiscord,
                    ImageExportService.ExportFullPathImage("wwwroot/images/for-congratulations", employee.JobPosition),
                    textCongratulation.ToString());
            if (employee.IdTelegram != null)
                await TelegramBot.Program
                    .SendCongratulationMessage(
                    (long)employee.IdTelegram,
                    "wwwroot/images/for-congratulations",
                    textCongratulation.ToString());
        }

        static string GetCongratulationText(Employee employee)
        {
            var textCongratulation = new StringBuilder($"Многоуважаемый {employee.FullName}! " +
                $"Сегодня в этот замечательный день, вам исполняется {DateTime.Today.Year - employee.DateBorn.Year} года, " +
                $"пусть этот день пройдёт у вас самым лучшим образом.");

            textCongratulation.Append(employee.JobPosition switch
            {
                JobPosition.Trainee => " Чтобы ваша стажировка прошла наилучшим образом, и вы смогли вступить в наши ряды!",
                JobPosition.Director => " Чтобы у вас были самые послушные подчинённые, и крепкие нервы!",
                _ => ""
            });
            textCongratulation.Append(employee.Department switch
            {
                Department.Sales => " Чтобы продажи у вас были идеальными!",
                Department.Directors => " Всего хорошего!",
                _ => ""
            });
            return textCongratulation.ToString();
        }
    }
}