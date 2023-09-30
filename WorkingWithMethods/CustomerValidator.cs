using FluentValidation;
using System;

namespace WorkingWithMethods
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c=>c.FirstName).NotEmpty().When(c=>c.IdentityNumber== "123");
            RuleFor(c=>c.LastName).NotEmpty();
            RuleFor(c=>c.IdentityNumber).NotEmpty();
            RuleFor(c => c.IdentityNumber).Must(BeEven);
        }

        private bool BeEven(string arg)
        {
            return true;
        }
    }

    public class Customer2Validator : AbstractValidator<Customer>
    {
        public Customer2Validator()
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
