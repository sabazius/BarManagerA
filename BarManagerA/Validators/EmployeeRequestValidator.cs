using BarManagerA.Models.Requests;
using FluentValidation;

namespace BarManagerA.Host.Validators
{
    public class EmployeeRequestValidator : AbstractValidator<EmployeeRequest>
    {
        public EmployeeRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(10);

            RuleFor(x => x.ClientTable).GreaterThan(0);
            

        }
    }
}
