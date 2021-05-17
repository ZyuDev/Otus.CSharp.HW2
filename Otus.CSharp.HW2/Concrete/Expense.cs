using Otus.CSharp.HW2.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.CSharp.HW2.Concrete
{
    public class Expense : ITransaction
    {
        public Expense(ICurrencyAmount amount, DateTimeOffset date, string category, string destination)
        {
            Amount = amount;
            Date = date;
            Category = category;
            Destination = destination;
        }

        public ICurrencyAmount Amount { get; }
        public DateTimeOffset Date { get; }
        public string Category { get; }
        public string Destination { get; }

        public override string ToString() => $"Трата {Amount.Amount} {Amount.CurrencyCode} {Destination} {Category}";
    }
}
