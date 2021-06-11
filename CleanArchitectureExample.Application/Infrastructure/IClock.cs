using System;

namespace CleanArchitectureExample.Application.Infrastructure
{
    internal interface IClock
    {
        DateTime Now { get; }
    }
}