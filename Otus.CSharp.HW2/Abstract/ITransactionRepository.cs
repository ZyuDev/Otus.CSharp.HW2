using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.CSharp.HW2.Abstract
{
    public interface ITransactionRepository
    {
        void AddTransaction(ITransaction transaction);
        ITransaction[] GetTransactions();
    }
}
