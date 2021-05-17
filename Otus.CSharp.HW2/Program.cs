using Microsoft.Extensions.Caching.Memory;
using Otus.CSharp.HW2.Concrete;
using Otus.CSharp.HW2.Repository;
using System;
using System.Diagnostics;
using System.Net.Http;

namespace Otus.CSharp.HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            var currencyConverter = new ExchangeRatesApiConverter(new HttpClient(), new MemoryCache(new MemoryCacheOptions()), "a5cf9da55cb835d0a633a7825b3aa8b5");

            var transactionParser = new TransactionParser();
            // var transactionRepository = new InMemoryTransactionRepository();
            var transactionRepository = new FileTransactionRepository("transactions.txt", transactionParser);

            var budgetApp = new BudjetApplication(transactionRepository, transactionParser, currencyConverter);

            //budgetApp.AddTransaction("Трата -40 EUR Продукты Пятерочка");
            //budgetApp.AddTransaction("Трата -200 EUR Бензин IRBIS");
            //budgetApp.AddTransaction("Трата -50 EUR Кафе Шоколадница");
            //budgetApp.AddTransaction("Зачисление 5000 EUR Зарплата");
            //budgetApp.AddTransaction("Перевод 12.3 EUR Вася Долг");

            budgetApp.OutputTransactions();

            budgetApp.OutputBalanceInCurrency("USD");
            budgetApp.OutputBalanceInCurrency("EUR");
            budgetApp.OutputBalanceInCurrency("RUB");

            Console.Read();
        }
    }
}
