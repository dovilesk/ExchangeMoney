using Common;
using System;

namespace Exchange
{
    public class Analyzer
    {
        private string _currentCurrency;
        private string _currencyExchangeTo;
        private decimal _amount;

        public string CurrentCurrency { get { return _currentCurrency; } private set { _currentCurrency = value; } }
        public string CurrencyExchangeTo { get { return _currencyExchangeTo; } private set { _currencyExchangeTo = value; } }
        public decimal Amount { get { return _amount; } private set { _amount = value; } }

        public Analyzer(string[] args)
        {
            if (HasParameters(args) && CurrencyPairFormatIsCorrect(args[1])) {
                _currentCurrency = GetCurrentCurrency(args[1]);
                _currencyExchangeTo = GetCurrencyExchangeTo(args[1]);
                _amount = GetAmount(args[2]);

                CurrentCurrency = _currentCurrency;
                CurrencyExchangeTo = _currencyExchangeTo;
                Amount = _amount;
            }
        }

        public bool CurrencyPairHasTheSameISOCurrency()
        {
            if (_currentCurrency == _currencyExchangeTo)
            {
                return true;
            }

            return false;
        }

        public bool CurrencyPairContainsUnknownCurrency()
        {
            if (Enum.IsDefined(typeof(Currencies), _currentCurrency) && Enum.IsDefined(typeof(Currencies), _currencyExchangeTo))
            {
                return false;
            }

            return true;
        }

        private string GetCurrentCurrency(string currencies)
        {
            return currencies.Split("/")[0].ToUpper(); 
        }

        private string GetCurrencyExchangeTo(string currencies)
        {
            return currencies.Split("/")[1].ToUpper(); ;
        }

        private decimal GetAmount(string amount)
        {
            decimal amountInDouble = 0;

            try
            {
                amountInDouble = Decimal.Parse(amount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong amount format. Amount should be decimal. Now was " + amount);
            }

            return amountInDouble;
        }

        private bool HasParameters(string[] args) {

            switch (args.Length) {
                case 0:
                    Console.WriteLine("Please, enter parameters");
                    throw new ArgumentException();
                case 3:
                    return true;
                default:
                    Console.WriteLine("Wrong number of parameters");
                    throw new ArgumentException();
            }
        }

        private bool CurrencyPairFormatIsCorrect(string currencies)
        {
            if (currencies.Contains("/") && currencies.Split("/")[0].Length > 0 && currencies.Split("/")[1].Length > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Wrong currency pair format. Should be for example EUR/DDK. Now was " + currencies);
                throw new ArgumentException();
            }
        }

        public bool ArgumentsAreCorrect() {
            if (CurrencyPairContainsUnknownCurrency())
            {
                Console.WriteLine("Currency pair contains an unknown currency");
                throw new ArgumentException();
            }
            else if (CurrencyPairHasTheSameISOCurrency())
            {
                Console.WriteLine(CurrentCurrency);
                throw new ArgumentException();
            }

            return true;
        }
    }
}
