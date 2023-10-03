using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().When(c => c.IdentityNumber == "123");
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.IdentityNumber).NotEmpty();
            RuleFor(c => c.IdentityNumber).Must(BeEven);
        }

        private bool BeEven(string arg)
        {
            return true;
        }
    }
}
