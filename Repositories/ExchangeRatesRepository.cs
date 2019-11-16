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
            _rates.Add(createExchangeRate("Euro", "EUR", 100, 743.94m));
            _rates.Add(createExchangeRate("Amerikanske dollar", "USD", 100, 663.11m));
            _rates.Add(createExchangeRate("Britiske pund", "GPB", 100, 852.85m));
            _rates.Add(createExchangeRate("Svenske kroner", "SEK", 100, 76.10m));
            _rates.Add(createExchangeRate("Norske kroner", "NOK", 100, 78.40m));
            _rates.Add(createExchangeRate("Schweiziske franc", "CHF", 100, 683.58m));
            _rates.Add(createExchangeRate("Japanske yen", "JPY", 100, 5.9740m));
        }

        public List<ExchangeRateDto> getAllExchangeRates()
        {
            return _rates;
        }

        public ExchangeRateDto getExchangeRateByISO(string ISO)
        {
            return _rates.FirstOrDefault(x => x.ISO == ISO);
        }

        private ExchangeRateDto createExchangeRate(string currencyName, string iSO, decimal amountOfDDK, decimal rateOfCurrency)
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
