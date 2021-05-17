using Otus.CSharp.HW2.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.CSharp.HW2.Concrete
{
    public class Transfer : ITransaction
    {
        public ICurrencyAmount Amount { get; }
        public DateTimeOffset Date { get; }

        public string Destination { get; }
        public string Message { get; }

        public override string ToString() => $"Перевод {Amount} на имя {Destination} с сообщением {Message}";
    }
}
