using Otus.CSharp.HW2.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Otus.CSharp.HW2.Concrete
{
    public class BudjetApplication : IBudgetApplication
    {
        private readonly ICurrencyConverter _currencyConverter;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionParser _transactionParser;

        public BudjetApplication(ITransactionRepository transactionRepository, ITransactionParser transactionParser, ICurrencyConverter currencyConverter)
        {
            _currencyConverter = currencyConverter;
            _transactionRepository = transactionRepository;
            _transactionParser = transactionParser;
        }

        public void AddTransaction(string input)
        {

            try
            {
                var transaction = _transactionParser.Parse(input);
                _transactionRepository.AddTransaction(transaction);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Wrong input: {e.Message}");
            }

        }

        public void OutputTransactions()
        {
            foreach (var transaction in _transactionRepository.GetTransactions())
            {
                Console.WriteLine(transaction);
            }
        }

        public void OutputBalanceInCurrency(string currencyCode)
        {
            var totalCurrencyAmount = new CurrencyAmount(currencyCode, 0);
            var amounts = _transactionRepository.GetTransactions()
                .Select(t => t.Amount)
                .Select(a => a.CurrencyCode != currencyCode ? _currencyConverter.ConvertCurrency(a, currencyCode) : a)
                .ToArray();

            var totalBalanceAmount = amounts.Aggregate(totalCurrencyAmount, (t, a) => t += a);

            Console.WriteLine($"Balance: {totalBalanceAmount}");
        }

        public void OutputBalanceInMainCurrencies()
        {
            Console.WriteLine("======================");

            OutputBalanceInCurrency("EUR");
            OutputBalanceInCurrency("USD");
            OutputBalanceInCurrency("RUB");

            Console.WriteLine("======================");

        }
    }
}
