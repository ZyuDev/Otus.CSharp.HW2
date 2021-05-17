using Otus.CSharp.HW2.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Otus.CSharp.HW2.Repository
{
    public class FileTransactionRepository : ITransactionRepository
    {
        private readonly List<ITransaction> _transactions = new List<ITransaction>();
        private readonly string _path;
        private readonly ITransactionParser _parser;

        public FileTransactionRepository(string path, ITransactionParser parser)
        {
            _path = path;
            _parser = parser;

            ReadDataFromFile();
        }

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);

            using (StreamWriter file = new StreamWriter(_path, append: true))
            {
                file.WriteLine(transaction.ToString());
            }

        }

        public ITransaction[] GetTransactions()
        {
            return _transactions.ToArray();
        }

        private void ReadDataFromFile()
        {
            _transactions.Clear();

            if (!File.Exists(_path))
            {
                var fs = File.Create(_path);
                fs.Close();
            }

            var lines = File.ReadAllLines(_path);

            foreach (var line in lines)
            {
                try
                {
                    var transaction = _parser.Parse(line);
                    _transactions.Add(transaction);
                }
                catch (Exception e)
                {
                    Trace.WriteLine($"Parse error: {line}. Message: {e.Message}");
                }
            }
        }
    }
}
