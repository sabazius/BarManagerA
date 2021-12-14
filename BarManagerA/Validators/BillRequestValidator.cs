using BarManagerA.Models.Requests;
using FluentValidation;

namespace BarManagerA.Host.Validators
{
    public class BillRequestValidator : AbstractValidator<TagRequest>
    {
        public BillRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(10);
        }
    }
}
