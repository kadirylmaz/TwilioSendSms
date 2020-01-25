using FluentValidation;
using SendSms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SendSms.Validator
{
    public class SendSmsValidator:AbstractValidator<SmsMessage>
    {
        public SendSmsValidator()
        {
            RuleFor(x => x.NumberFrom).Must(BeValidTRMobilePhoneNumber).WithMessage("Plesea specify a valid TR mobile phone number to send the SMS from");

            RuleFor(x => x.NumberTo).Must(BeValidTRMobilePhoneNumber)
                .WithMessage("Please specify a valid TR mobile phone number to send the SMS to.");
            RuleFor(x => x.Greeting).NotNull().WithMessage("Please specify the SMS greeting");
            RuleFor(x => x.NameTo).NotNull().WithMessage("Please specify the receivers name.");
            RuleFor(x => x.Body).NotNull().WithMessage("Please specify the SMS message body.");
            RuleFor(x => x.Signature).NotNull().WithMessage("Please specify the SMS signature");
        }

        private bool BeValidTRMobilePhoneNumber(string mobilePhoneNumber)
        {
            if (!String.IsNullOrEmpty(mobilePhoneNumber) && mobilePhoneNumber.StartsWith("+90", StringComparison.CurrentCulture) && mobilePhoneNumber.Length == 13)
                return true;

            return false;           
        }
    }
}
