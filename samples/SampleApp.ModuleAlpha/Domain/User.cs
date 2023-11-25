using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.ModuleAlpha.Domain
{
    public sealed class User
    {
        public string? Name { get; set; }
        public EmailAddress EmailAddress { get; set; }

    }
}
