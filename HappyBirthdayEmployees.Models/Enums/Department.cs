using System.Text.Json.Serialization;

namespace HappyBirthdayEmployees.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Department
{
    Unknown = 0,
    Sales = 1,
    Directors = 2
}