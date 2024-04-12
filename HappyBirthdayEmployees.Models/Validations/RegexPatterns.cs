using System.Text.RegularExpressions;

namespace HappyBirthdayEmployees.Models.Validations;

/// <summary>
/// Паттерн для проверки строк
/// </summary>
public static class RegexPatterns
{
    /// <summary>
    /// ФИО
    /// </summary>
    public static readonly Regex LfmPattern = new(@"^[А-ЯA-Z][а-яА-Яa-zA-Z]{0,49}\s[А-ЯA-Z][а-яА-Яa-zA-Z]{0,49}\s?[А-ЯA-Z]?[а-яА-Яa-zA-Z]{0,49}$");
}
