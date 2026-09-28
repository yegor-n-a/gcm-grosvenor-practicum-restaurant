using Application.Models;
using FluentValidation;

namespace Application.Validators
{
    public class DishValidator : AbstractValidator<_Dish>
    {
        public DishValidator()
        {
            RuleFor(x => x.Count)
                .LessThanOrEqualTo(x => x.Constraints.MaxCountAllowed.Value)
                .When(x => x.Constraints != null && x.Constraints.MaxCountAllowed.HasValue)
                .WithMessage(x => $"Count for '{x.Name}' must be less than or equal to {x.Constraints.MaxCountAllowed.Value}.");
        }
    }
}