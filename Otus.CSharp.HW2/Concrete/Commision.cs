using Otus.CSharp.HW2.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.CSharp.HW2.Concrete
{
    public class Comission : ITransaction // декоратор
    {
        public ITransaction OriginalTransaction { get; }
        public ICurrencyAmount Amount { get; }
        public DateTimeOffset Date { get; }

        public override string ToString() => $"Комиссия в размере {Amount} за транзакцию: {OriginalTransaction}";
    }
}
