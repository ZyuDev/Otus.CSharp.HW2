using NUnit.Framework;
using Otus.CSharp.HW2.Concrete;
using System;

namespace Otus.CSharp.HW2.UnitTests
{
    public class Tests
    {
        private TransactionParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new TransactionParser();
        }

        [Test]
        public void Parse_Expense_ReturnExpenseTransaction()
        {

            var result = _parser.Parse("����� -40 EUR �������� ���������");

            Assert.AreEqual(-40M, result.Amount.Amount);
            Assert.AreEqual("EUR", result.Amount.CurrencyCode);

        }

        [Test]
        public void Parse_Income_ReturnIncomeTransaction()
        {

            var result = (Income)_parser.Parse("���������� 5000 EUR ��������");

            Assert.AreEqual(5000M, result.Amount.Amount);
            Assert.AreEqual("EUR", result.Amount.CurrencyCode);
            Assert.AreEqual("��������", result.Source);

        }

        [Test]
        public void Parse_Transfer_ReturnTransferTransaction()
        {
            var result = (Transfer)_parser.Parse("������� 12 EUR ���� ����");

            Assert.AreEqual(12M, result.Amount.Amount);
            Assert.AreEqual("EUR", result.Amount.CurrencyCode);
            Assert.AreEqual("����", result.Destination);
            Assert.AreEqual("����", result.Message);
        }

        [Test]
        public void Parse_AmountWithDot_ReturnTransaction()
        {
            var result = (Transfer)_parser.Parse("������� 12.3 EUR ���� ����");

            Assert.AreEqual(12.3M, result.Amount.Amount);
        }

        [Test]
        public void Parse_EmptyString_ThrowAgrumetnException()
        {
            Assert.Throws<ArgumentException>(()=>_parser.Parse(""));
        }

        [Test]
        public void Parse_IncomeShortString_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _parser.Parse("���������� 5000 EUR"));
        }

        [Test]
        public void Parse_TransferShortString_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _parser.Parse("������� 12.3 EUR ����"));
        }

    }
}