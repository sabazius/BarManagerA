using BarManagerA.Models.Requests;
using FluentValidation;

namespace BarManagerA.Host.Validators
{
    public class TagRequestValidator : AbstractValidator<TagRequest>
    {
        public TagRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(10);
        }
    }
}
