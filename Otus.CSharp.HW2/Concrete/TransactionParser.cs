﻿using Otus.CSharp.HW2.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otus.CSharp.HW2.Concrete
{
    public class TransactionParser : ITransactionParser
    {
        public ITransaction Parse(string input)
        {
            var date = DateTimeOffset.Now;
            var splits = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var typeCode = splits[0];
            var currencyAmount = new CurrencyAmount(splits[2], decimal.Parse(splits[1]));
            switch (typeCode)
            {
                case "Трата":
                    return new Expense(currencyAmount, date, splits[3], splits[4]);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
