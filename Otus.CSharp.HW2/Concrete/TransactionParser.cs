using Otus.CSharp.HW2.Abstract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Otus.CSharp.HW2.Concrete
{
    public class TransactionParser : ITransactionParser
    {
        public const string KeywordExpense = "Трата";
        public const string KeywordIncome = "Зачисление";
        public const string KeywordTransfer = "Перевод";

        public ITransaction Parse(string input)
        {
           

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(nameof(input), "Input is empty");
            }

            var date = DateTimeOffset.Now;
            var splits = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var typeCode = splits[0];

            var wordsMinCount = typeCode == KeywordIncome ? 4 : 5;
            if (splits.Length < wordsMinCount)
            {
                throw new ArgumentException(nameof(input), $"Wrong format. Should be {wordsMinCount} words in expression.");
            }

            var amount = decimal.Parse(splits[1], NumberStyles.Any, CultureInfo.InvariantCulture);
            var currencyAmount = new CurrencyAmount(splits[2], amount);
            switch (typeCode)
            {
                case KeywordExpense:
                    return new Expense(currencyAmount, date, splits[3], splits[4]);
                case KeywordIncome:
                    return new Income(currencyAmount, date, splits[3]);
                case KeywordTransfer:
                    return new Transfer(currencyAmount, date, splits[3], splits[4]);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
