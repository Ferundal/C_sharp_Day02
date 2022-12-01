using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using d02_ex00.Models;

namespace d02_ex00
{
    public class Exchanger
    {
        private List<ExchangeRate> _exchangeRates;
        
        public Exchanger (string ratesPath)
        {
            var files = Directory.GetFiles(ratesPath);
            _exchangeRates = new List<ExchangeRate>();
            for (int index = 0; index < files.Length; ++index)
            {
                string [] exchangeRatesLines = File.ReadAllLines(files[index]);
                foreach (var exchangeRatesLine in exchangeRatesLines)
                {
                    var exchangeRateText = String.Format($"{Path.GetFileNameWithoutExtension(files[index])}-{exchangeRatesLine}");
                    if(ExchangeRate.TryParse(exchangeRateText, out var exchangeRate))
                        _exchangeRates.Add(exchangeRate);
                }
            }
        }

        public IEnumerable<ExchangeSum> Convert(ExchangeSum exchangeSum)
        {
            foreach (var exchangeRate in _exchangeRates)
            {
                if (exchangeRate.From != exchangeSum.Id)
                    continue;
                var exchangedAmount = (float) exchangeSum.Amount * exchangeRate.Rate;
                yield return new ExchangeSum(exchangeRate.To, (decimal) exchangedAmount);
            }
        }
    }
}