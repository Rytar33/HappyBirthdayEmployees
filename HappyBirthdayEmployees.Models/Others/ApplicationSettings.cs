using Newtonsoft.Json;

namespace HappyBirthdayEmployees.Models;

public record ApplicationSettings(
    Logging Logging,
    ConnectionStrings ConnectionStrings,
    ConnectionChannel ConnectionChannel,
    string AllowedHosts);

public record ConnectionChannel(ulong DiscordIdChannel, long TelegramIdChannel);

public record  ConnectionStrings(
    string PostgreSQLConnection,
    string DiscordBotToken,
    string TelegramBotToken);

public record Logging(LogLevel LogLevel);

public record LogLevel(
    string Default,
    [JsonProperty("Microsoft.AspNetCore")] string MicrosoftAspNetCore);