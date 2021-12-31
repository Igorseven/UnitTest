using FluentValidation;
using UnitTest.Domain.Entities;
using UnitTest.Domain.Enums;
using UnitTest.Domain.Extentions;

namespace UnitTest.Domain.Validations.EntitiesValidation
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleOfProperty();
        }

        private void RuleOfProperty()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(p => p.Name).Length(3, 30).WithMessage(Message.MoreExpected.Description().FormatMessage("Name", "3 to 30"));

            RuleFor(p => p.Description).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(p => p.Description).Length(3, 80).WithMessage(Message.MoreExpected
                .Description().FormatMessage("Description", "3 to 80"));

            RuleFor(p => p.Price).NotEmpty().WithMessage(Message.Required.Description());
            RuleFor(p => p.Price).GreaterThan(0).WithMessage(Message.ValueExpected
                .Description().FormatMessage("Price", "0,00"));
        }
    }
}
