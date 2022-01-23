using BarManagerA.Models.Requests;
using FluentValidation;

namespace BarManagerA.Host.Validators
{
    public class ClientRequestValidator : AbstractValidator<TagRequest>
    {
        public ClientRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.MoneySpend).NotNull().NotEmpty();
            RuleFor(x => x.Discount).NotNull().InclusiveBetween(0, 100);
        }
    }
}
