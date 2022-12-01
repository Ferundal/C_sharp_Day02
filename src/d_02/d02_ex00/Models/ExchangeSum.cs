using System.Globalization;

namespace d02_ex00.Models
{
    public struct ExchangeSum
    {
        public string Id;
        public decimal Amount;
        private const string Separator = " ";

        public ExchangeSum(string id, decimal amount)
        {
            Id = id;
            Amount = amount;
        }

        public static bool TryParse(string? s, out ExchangeSum exchangeSum)
        {
            var style = NumberStyles.AllowDecimalPoint;
            CultureInfo cultureInfo = new CultureInfo("en-GB");
            exchangeSum = new ExchangeSum();
            string[] pair = s.Split(Separator);
            if (pair.Length != 2)
                return false;
            if (!decimal.TryParse(pair[0], style, cultureInfo, out exchangeSum.Amount))
                return false;
            exchangeSum.Id = pair[1];
            return true;
        }

        public override string ToString()
        {
            CultureInfo cultureInfo = new CultureInfo("en-GB");
            return $"{Amount.ToString("N2", cultureInfo)} {Id}";
        }
    }
}