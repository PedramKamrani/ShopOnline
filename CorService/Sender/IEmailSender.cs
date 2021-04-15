using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorService.Sender
{
   public interface IEmailSender
    {
       Task SendEmail(string to, string subject, string body);
    }
}
