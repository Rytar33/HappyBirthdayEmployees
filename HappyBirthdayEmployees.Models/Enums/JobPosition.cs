using System.Text.Json.Serialization;

namespace HappyBirthdayEmployees.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum JobPosition
{
    Trainee = 0,
    Director = 1
}