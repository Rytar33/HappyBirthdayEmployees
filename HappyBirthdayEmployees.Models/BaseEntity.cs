using System.ComponentModel.DataAnnotations.Schema;

namespace HappyBirthdayEmployees.Models;

/// <summary>
/// ������� ����� ���������
/// </summary>
public abstract class BaseEntity
{
    [Column("id")]
    public Guid Id { get; init; }
}