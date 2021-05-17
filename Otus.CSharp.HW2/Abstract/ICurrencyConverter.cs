using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otus.CSharp.HW2.Abstract
{
    public interface ICurrencyConverter
    {
        ICurrencyAmount ConvertCurrency(ICurrencyAmount amount, string currencyCode);
    }
}
