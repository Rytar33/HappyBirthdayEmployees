using HappyBirthdayEmployees.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HappyBirthdayEmployees.WebApi.Controllers;

[ApiController]
[Route("Api/[controller]/[action]")]
public class BotController : Controller
{
    [HttpPut]
    public async Task<IActionResult> SetIdChannelTelegram(long idChannel)
    {
        await ChangeIdChannel(idChannel, nameof(ConnectionChannel.TelegramIdChannel));
        return NoContent();
    }
    
    [HttpPut]
    public async Task<IActionResult> SetIdChannelDiscord(ulong idChannel)
    {
        await ChangeIdChannel(idChannel, nameof(ConnectionChannel.DiscordIdChannel));
        return NoContent();
    }

    private static async Task ChangeIdChannel<T>(T idChannel, string propertyName) where T : struct
    {
        var json = await System.IO.File.ReadAllTextAsync("appsettings.json");
        ApplicationSettings appSettings = JsonConvert.DeserializeObject<ApplicationSettings>(json)!;

        var property = typeof(ConnectionChannel).GetProperty(propertyName);
        if (property != null)
        {
            property.SetValue(appSettings.ConnectionStrings, idChannel);
            var serializedSettings = JsonConvert.SerializeObject(appSettings);
            await System.IO.File.WriteAllTextAsync("appsettings.json", serializedSettings);
        }
        else
        {
            throw new NullReferenceException("Property null");
        }
    }
}