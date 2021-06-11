using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureExample.Application.Infrastructure
{
    internal class Clock : IClock
    {
        public DateTime Now => DateTime.Now;
    }
}
