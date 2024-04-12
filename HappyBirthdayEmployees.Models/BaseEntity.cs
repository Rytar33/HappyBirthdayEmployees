using System.ComponentModel.DataAnnotations.Schema;

namespace HappyBirthdayEmployees.Models;

/// <summary>
/// Базовый класс сущностей
/// </summary>
public abstract class BaseEntity
{
    [Column("id")]
    public Guid Id { get; init; }
}