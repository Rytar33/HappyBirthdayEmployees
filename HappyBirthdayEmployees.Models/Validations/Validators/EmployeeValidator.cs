using FluentValidation;

namespace HappyBirthdayEmployees.Models.Validations.Validators;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        // FullName
        RuleFor(e => e.FullName)
            .NotNull().WithMessage(employee 
            => string.Format(ErrorMessages.IsNull, nameof(employee.FullName)))
            .NotEmpty().WithMessage(employee 
            => string.Format(ErrorMessages.IsEmpty, nameof(employee.FullName)))
            .Matches(RegexPatterns.LfmPattern).WithMessage(employee 
            => string.Format(ErrorMessages.OnlyLetters, nameof(employee.FullName)));

        // DateBorn
        RuleFor(e => e.DateBorn)
            .NotEmpty().WithMessage(employee =>
            string.Format(ErrorMessages.IsEmpty, nameof(employee.DateBorn)))
            .GreaterThan(DateTime.Now.AddYears(-120)).WithMessage(employee 
            => string.Format(ErrorMessages.OldDate, nameof(employee.DateBorn)))
            .LessThan(DateTime.Now).WithMessage(employee 
            => string.Format(ErrorMessages.FutureDate, nameof(employee.DateBorn)));

        // Null two id
        RuleFor(e => e.IdDiscord)
            .NotNull().When(x => x.IdTelegram == null)
            .WithMessage(employee 
            => string.Format(ErrorMessages.TwoPropertyNull, nameof(employee.IdDiscord), nameof(employee.IdTelegram)));
        RuleFor(e => e.IdTelegram)
            .NotNull().When(e => e.IdDiscord == null)
            .WithMessage(employee
            => string.Format(ErrorMessages.TwoPropertyNull, nameof(employee.IdTelegram), nameof(employee.IdDiscord)));

        // Has value two id
        RuleFor(e => e)
            .Must(employee => !(employee.IdDiscord.HasValue & employee.IdTelegram.HasValue))
            .WithMessage(employee
            => string.Format(ErrorMessages.TwoPropertyHasValue, nameof(employee.IdDiscord), nameof(employee.IdTelegram)));
    }
}
