using Dto;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class ExchangeRatesRepository : IExchangeRatesRepository
    {
        private List<ExchangeRateDto> _rates = new List<ExchangeRateDto>();

        public ExchangeRatesRepository()
        {
            _rates.Add(CreateExchangeRate("Euro", "EUR", 100, 743.94m));
            _rates.Add(CreateExchangeRate("Amerikanske dollar", "USD", 100, 663.11m));
            _rates.Add(CreateExchangeRate("Britiske pund", "GPB", 100, 852.85m));
            _rates.Add(CreateExchangeRate("Svenske kroner", "SEK", 100, 76.10m));
            _rates.Add(CreateExchangeRate("Norske kroner", "NOK", 100, 78.40m));
            _rates.Add(CreateExchangeRate("Schweiziske franc", "CHF", 100, 683.58m));
            _rates.Add(CreateExchangeRate("Japanske yen", "JPY", 100, 5.9740m));
        }

        public List<ExchangeRateDto> getAllExchangeRates()
        {
            return _rates;
        }

        public ExchangeRateDto GetExchangeRateByISO(string ISO)
        {
            return _rates.FirstOrDefault(x => x.ISO == ISO);
        }

        private ExchangeRateDto CreateExchangeRate(string currencyName, string iSO, decimal amountOfDDK, decimal rateOfCurrency)
        {
            var exchangeRate = new ExchangeRateDto();

            exchangeRate.CurrencyName = currencyName;
            exchangeRate.ISO = iSO;
            exchangeRate.AmountOfDDK = amountOfDDK;
            exchangeRate.RateOfCurrency = rateOfCurrency;

            return exchangeRate;
        }
    }
}
