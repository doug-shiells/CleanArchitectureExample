using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CleanArchitectureExample.Application.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CleanArchitectureExample.Persistence.EntityFramework
{
    internal class TransactionFactory : ITransactionFactory
    {
        private readonly CleanArchitectureExampleContext context; 

        public TransactionFactory(CleanArchitectureExampleContext context)
        {
            this.context = context;
        }
        
        public ITransaction BeginTransaction() => new Transaction(context);
    }
}
