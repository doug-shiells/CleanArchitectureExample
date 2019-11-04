using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureExample.Application.Persistence
{
    public interface ITransactionFactory 
    {
        ITransaction BeginTransaction();
    }
}
