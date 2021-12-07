using BarManagerA.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarManagerA.Host.Validators
{
    public class ProductsRequestValidator : AbstractValidator<ProductsRequest>

    {
        public ProductsRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Num).GreaterThan(0).LessThan(100);
        }
    }
}
