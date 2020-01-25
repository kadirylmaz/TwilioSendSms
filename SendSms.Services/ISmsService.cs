using SendSms.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace SendSms.Services
{
    public interface ISmsService
    {
        Task<MessageResource> Send(SmsMessage smsMessage);
    }
}
