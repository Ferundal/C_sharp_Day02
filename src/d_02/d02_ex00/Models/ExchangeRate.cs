using System;
using System.Globalization;
using System.Security;

namespace d02_ex00.Models
{
    public struct ExchangeRate
    {
        public string From;
        public string To;
        public float Rate;
        private const string FromToSeparator = "-";
        private const string DescriptionRateSeparator = ":";

        public ExchangeRate(string from, string to, float exchangeRate)
        {
            From = from;
            To = to;
            Rate = exchangeRate;
        }

        public static bool TryParse(string? s, out ExchangeRate exchangeRate)
        {
            exchangeRate = new ExchangeRate();
            string[] descriptionRatePair = s.Split(DescriptionRateSeparator);
            if (descriptionRatePair.Length != 2)
                return false;
            if (!float.TryParse(descriptionRatePair[1], out exchangeRate.Rate))
                return false;
                
            string [] fromToPair = descriptionRatePair[0].Split(FromToSeparator);
            if (fromToPair.Length != 2)
                return false;
            exchangeRate.From = fromToPair[0];
            exchangeRate.To = fromToPair[1];
            return true;
        }
        
        public override string ToString()
        {
            return $"{From}{FromToSeparator}{To}" +
                   $"{DescriptionRateSeparator}" +
                   $"{Rate}";
        }


    }
}