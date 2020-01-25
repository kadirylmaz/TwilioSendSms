using SendSms.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SendSms.Services
{
    public class SmsService : ISmsService
    {
        public async Task<MessageResource> Send(SmsMessage smsMessage)
        {
            var messageBody = ConstructMessageBody(smsMessage);

            var result = await MessageResource.CreateAsync(
                    from: new PhoneNumber(smsMessage.NumberFrom),
                    to: new PhoneNumber(smsMessage.NumberTo),
                    body: messageBody);

            return result;
        }

        private string ConstructMessageBody(SmsMessage smsMessage)
        {
            return $"{smsMessage.Greeting} {smsMessage.NameTo}, {smsMessage.Body} {smsMessage.Signature}";
        }
    }
}
