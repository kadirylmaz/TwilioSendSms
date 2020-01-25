using FluentValidation.Results;
using SendSms.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SendSms.Validator
{
    public static class ValidationService
    {
        public static List<string> Validate(out bool isValid,SmsMessage model)
        {
            var validator = new SendSmsValidator();

            var validationResult = validator.Validate(model);

            isValid = validationResult.IsValid;

            return AggregateErrors(validationResult);

        }

        private static List<string> AggregateErrors(ValidationResult validationResult)
        {
            var errors = new List<string>();

            if (!validationResult.IsValid)
            {
                Parallel.ForEach(validationResult.Errors, error =>
                {
                    errors.Add(error.ErrorMessage);
                });
            }

            return errors;

        }
    }
}
