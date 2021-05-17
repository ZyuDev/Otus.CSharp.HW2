using Otus.CSharp.HW2.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Otus.CSharp.HW2.Repository
{
    public class InMemoryTransactionRepository : ITransactionRepository
    {
        private readonly List<ITransaction> _transactions = new List<ITransaction>();

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public ITransaction[] GetTransactions()
        {
            return _transactions.ToArray();
        }
    }
}
