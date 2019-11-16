using Common;
using Dto;
using Repositories;

namespace Logic
{
    public class ExchangeMoneyLogic : IExchangeMoneyLogic
    {
        IExchangeRatesRepository _exchangeRatesRepository;

        public ExchangeMoneyLogic(IExchangeRatesRepository exchangeRatesRepository)
        {
            _exchangeRatesRepository = exchangeRatesRepository;
        }

        public decimal Exchange(string currencyExchangeFrom, string currencyExchangeTo, decimal amount)
        {
            decimal amountWithNewCurrency = 0;

            if (currencyExchangeTo == Currencies.DDK.ToString())
            {
                amountWithNewCurrency = decimal.Multiply(amount, ValueOfOneUnitOfCurrencyToDDK(currencyExchangeFrom));
            }
            else
            {
                amountWithNewCurrency = decimal.Multiply(amount,ValueOfOneUnitExchangeTo(currencyExchangeFrom, currencyExchangeTo));
            }

            return (decimal)System.Math.Round(amountWithNewCurrency, 4);

        }

        private decimal ValueOfOneUnitOfCurrencyToDDK(string currencyExchangeFrom)
        {
            decimal oneUnitValue = 0;

            ExchangeRateDto currencyCurrencyValues = _exchangeRatesRepository.getExchangeRateByISO(currencyExchangeFrom);

            oneUnitValue = decimal.Divide(currencyCurrencyValues.RateOfCurrency, 100);

            return oneUnitValue;
        }

        private decimal ValueOfOneUnitExchangeTo(string currentExchangeFrom, string currencyExchangeTo)
        {
            decimal oneUnitValue = 0;

            oneUnitValue = decimal.Divide(ValueOfOneUnitOfCurrencyToDDK(currencyExchangeTo), ValueOfOneUnitOfCurrencyToDDK(currentExchangeFrom));

            return oneUnitValue;
        }
    }
}
