using System;
using System.Collections.Generic;
using System.Text;

namespace SendSms.Models
{
    public class GenericApiResponse
    {
        public GenericApiResponse(object response)
        {
            this.Response = response;
        }
        public object Response { get; set; }
    }
}
