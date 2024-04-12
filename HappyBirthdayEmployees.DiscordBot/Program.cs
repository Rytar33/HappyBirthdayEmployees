using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using HappyBirthdayEmployees.Models;

namespace HappyBirthdayEmployees.DiscordBot;

public class Program
{
    private static DiscordSocketClient _socketClient;

    /// <summary>
    /// Иденнтификатор канала, куда будет отправляться поздравления
    /// </summary>
    private readonly static ulong _channelId;

    static Program()
    {
        _socketClient = new DiscordSocketClient();
        _socketClient.MessageReceived += SocketClientOnMessageReceived;
        _socketClient.Log += Log;
        ApplicationSettings appSettings = JsonConvert.DeserializeObject<ApplicationSettings>(File.ReadAllText("appsettings.json"))!;
        _socketClient.LoginAsync(TokenType.Bot, appSettings.ConnectionStrings.DiscordBotToken);
        _socketClient.StartAsync();
        _channelId = appSettings.ConnectionChannel.DiscordIdChannel;
    } 
    static async Task Main()
    {
        await Task.Delay(-1);
    }
    private static Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
    private static Task SocketClientOnMessageReceived(SocketMessage msg)
    {
        try
        {
            if (!msg.Author.IsBot)
            {
                Console.WriteLine($"User: {msg.Author.Username} Channel: {msg.Channel.Name} Message: {msg.Content}");
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        return Task.CompletedTask;
    }
    
    /// <summary>
    /// Отправка сообщений о поздравлении пользователю
    /// </summary>
    public static async Task SendCongratulationMessage(ulong idDiscordClient, string? sourceImage, string textCongratulation)
    {
        var channel = await _socketClient.GetChannelAsync(_channelId) as IMessageChannel;
        if (sourceImage != null)
            await channel?.SendFileAsync(sourceImage, $"{MentionUtils.MentionUser(idDiscordClient)}, {textCongratulation}")!;
        else
            await channel?.SendMessageAsync($"{MentionUtils.MentionUser(idDiscordClient)}, {textCongratulation}")!;
    }
}