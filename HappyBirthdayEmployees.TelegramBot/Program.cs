using HappyBirthdayEmployees.Models;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using File = System.IO.File;

namespace HappyBirthdayEmployees.TelegramBot;

public class Program
{
    private static ITelegramBotClient _botClient;
    
    private static ReceiverOptions _receiverOptions;

    private readonly static long _idChannel;
    static Program()
    {
        _receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = 
            [
                UpdateType.Message,
                UpdateType.ChannelPost
            ],
            ThrowPendingUpdates = false
        };

        using var cts = new CancellationTokenSource();
        ApplicationSettings appSettings = JsonConvert.DeserializeObject<ApplicationSettings>(File.ReadAllText("appsettings.json"))!;
        _botClient = new TelegramBotClient(appSettings.ConnectionStrings.TelegramBotToken);
        _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token);
        _idChannel = appSettings.ConnectionChannel.TelegramIdChannel;
    }
    static async Task Main()
    {
        await Task.Delay(-1);
    }

    private async static Task ErrorHandler(ITelegramBotClient client, Exception exc, CancellationToken cancellationToken)
    {
        Console.WriteLine(exc.Message);
    }

    private async static Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        try
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    {
                        Console.WriteLine($"Id {update.Message?.From?.Id} username {update.Message?.From?.Username} chatId {update.Message?.Chat.Username}");
                        return;
                    }
                case UpdateType.ChannelPost:
                    {
                        Console.WriteLine($"Id {update.ChannelPost?.Chat.Id}");
                        return;
                    }
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
    
    public static async Task SendCongratulationMessage(long idTelegramClient, string? sourceImage, string textCongratulation)
    {
        var chatMember = await _botClient.GetChatMemberAsync(_idChannel, idTelegramClient);
        await _botClient.SendTextMessageAsync(_idChannel, $"@{chatMember.User.Username}, {textCongratulation}");
        await _botClient.SendPhotoAsync(_idChannel, new InputFileUrl("https://i.pinimg.com/564x/9e/64/b4/9e64b45d4bd260ec1d8fe4b396917393.jpg"));
    }
}