using BarManagerA.Models.Requests;
using FluentValidation;

namespace BarManagerA.Host.Validators
{
    public class ClientTableValidator : AbstractValidator<ClientTableRequest>
    {
        public ClientTableValidator()
        {
        RuleFor(x => x.Seats).GreaterThan(0).NotEmpty();
        }
    }
}

    
