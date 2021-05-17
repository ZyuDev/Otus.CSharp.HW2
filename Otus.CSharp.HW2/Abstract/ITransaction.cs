using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.CSharp.HW2.Abstract
{
    public interface ITransaction
    {
        DateTimeOffset Date { get; }
        ICurrencyAmount Amount { get; }
    }
}
