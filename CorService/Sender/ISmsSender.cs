using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorService.Sender
{
  public  interface ISmsSender
    {
        void SendSms(string to, string messageText);
         Task<string> SendAuthSmsAsync(string Code, string PhoneNumber);
    }
}
