using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CleanArchitectureExample.Application.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CleanArchitectureExample.Persistence.EntityFramework
{
    internal class Transaction : ITransaction
    {
        private readonly IDbContextTransaction transaction; 

        public Transaction(CleanArchitectureExampleContext context)
        {
            this.transaction = context.Database.BeginTransaction();
        }

        public void Commit() => transaction.Commit();
        public void Rollback() => transaction.Rollback();
        public void Dispose() => transaction.Dispose();
    }
}
