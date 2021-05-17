using Otus.CSharp.HW2.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.CSharp.HW2.Concrete
{
    public class Income : ITransaction
    {
        public ICurrencyAmount Amount { get; }
        public DateTimeOffset Date { get; }

        public string Source { get; }

        public override string ToString() => $"Зачисление {Amount} от {Source}";
    }
}
