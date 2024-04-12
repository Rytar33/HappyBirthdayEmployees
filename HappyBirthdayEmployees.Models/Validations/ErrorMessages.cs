namespace HappyBirthdayEmployees.Models.Validations;

/// <summary>
/// Сообления об ошибках
/// </summary>
public static class ErrorMessages
{
    /// <summary>
    /// Сообщение о том, что оба поля, не могут иметь значение одновременно
    /// </summary>
    public const string TwoPropertyHasValue = "{0} и {1} не могут иметь значение одновременно";

    /// <summary>
    /// Сообщение о том, что оба поля, не могут одновременно не иметь значение
    /// </summary>
    public const string TwoPropertyNull = "{0} должен иметь значение, если {1} не имеет значение";
    /// <summary>
    /// Сообщение об ошибке формата - только буквы
    /// </summary>
    public const string OnlyLetters = "{0} должен содержать только буквы";

    /// <summary>
    /// Сообщение об ошибке даты
    /// </summary>
    public const string FutureDate = "{0} не может быть в будущем";

    /// <summary>
    /// Сообщение об ошибке даты рождения
    /// </summary>
    public const string OldDate = "{0} слишком старая дата";

    /// <summary>
    /// Сообщение об исключении null
    /// </summary>
    public const string IsNull = "{0} отсутствует значение";

    /// <summary>
    /// Сообщение об исключении empty
    /// </summary>
    public const string IsEmpty = "{0} пустой";
}
