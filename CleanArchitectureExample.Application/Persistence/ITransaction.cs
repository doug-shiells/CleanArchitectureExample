using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureExample.Application.Persistence
{
    public interface ITransaction : IDisposable
    {
        /// <summary>
        ///     Commits all changes made to the database in the current transaction.
        /// </summary>
        void Commit();

        /// <summary>
        ///     Discards all changes made to the database in the current transaction.
        /// </summary>
        void Rollback();
    }
}
