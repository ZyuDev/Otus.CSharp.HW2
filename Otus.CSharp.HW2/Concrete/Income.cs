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

        public Income(ICurrencyAmount amount, DateTimeOffset date, string source)
        {
            Amount = amount;
            Date = date;
            Source = source;
        }

        public override string ToString() => $"Зачисление {Amount.Amount} {Amount.CurrencyCode} {Source}";
    }
}
