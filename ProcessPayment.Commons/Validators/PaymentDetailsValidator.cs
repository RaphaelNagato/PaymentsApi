using FluentValidation;
using ProcessPayment.Dto;
using System;

namespace ProcessPayment.Commons.Validators
{
    public class PaymentDetailsValidator : AbstractValidator<PaymentDetailsDto>
    {
        public PaymentDetailsValidator()
        {
            RuleFor(x => x.CreditCardNumber).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Credit card number cannot be empty").CreditCard();
            RuleFor(x => x.CardHolder).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Card Holder cannot be empty").Length(3,25)
                .Matches("^[A-Za-z]+[ ]?[A-Za-z]+[ ]?[A-Za-z]+$").WithMessage("Card Holder Name not in correct format.");
            RuleFor(x => x.ExpirationDate).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Expiration Date cannot be empty")
                .Must(IsValidDate).WithMessage("Card is expired");
            RuleFor(x => x.Amount).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Amount cannot be empty")
                .Must(IsValidAmount).WithMessage("Amount must be positive and greater than zero");
            RuleFor(x => x.SecurityCode).Cascade(CascadeMode.Stop).Length(3).Must(code => int.TryParse(code, out _)).When(x => !string.IsNullOrWhiteSpace(x.SecurityCode))
                .WithMessage("Security Code not in correct format");
        }
        private bool IsValidDate(DateTime date)
        {
            if(date <= DateTime.Now)
            {
                return false;
            }
            return true;
        }
        private bool IsValidAmount(decimal amount)
        {
            if(amount <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
