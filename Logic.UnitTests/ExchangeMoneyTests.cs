using Dto;
using Logic;
using NSubstitute;
using NUnit.Framework;
using Repositories;

namespace Logic.UnitTests
{
    [TestFixture]
    public class ExchangeMoneyTests
    {
        private IExchangeRatesRepository _stubExchangeRatesRepository;
        private static object[] exchangeMoneyCases =
        {
            new object[] {  "EUR", "DDK", 1m, 5m },
            new object[] {  "USD", "DDK", 1m, 6m },
            new object[] {  "EUR", "USD", 1m, 1.2m },
            new object[] {  "EUR", "JPY", 1m, 1m },
            new object[] {  "JPY", "USD", 1m, 1.2m }
        };

        [SetUp]
        public void Setup()
        {
            _stubExchangeRatesRepository = Substitute.For<IExchangeRatesRepository>();

            ExchangeRateDto exchangeRateEUR = createExchangeRate("Euro", "EUR", 100, 500m);
            _stubExchangeRatesRepository.getExchangeRateByISO("EUR").Returns(exchangeRateEUR);

            ExchangeRateDto exchangeRateUSD = createExchangeRate("Amerikanske dollar", "USD", 100, 600m);
            _stubExchangeRatesRepository.getExchangeRateByISO("USD").Returns(exchangeRateUSD);

            ExchangeRateDto exchangeRateJPY = createExchangeRate("Japanske yen", "JPY", 100, 500m);
            _stubExchangeRatesRepository.getExchangeRateByISO("JPY").Returns(exchangeRateJPY);

        }

        [Test, TestCaseSource("exchangeMoneyCases")]
        public void ShouldReturnExpectedResults(string exchangeFrom, string exchangeTo, decimal amount, decimal expectedResult)
        {
            ExchangeMoneyLogic exchangeMoney = new ExchangeMoneyLogic(_stubExchangeRatesRepository);

            decimal actualResult = exchangeMoney.Exchange(exchangeFrom, exchangeTo, amount);

            Assert.That(actualResult , Is.EqualTo(expectedResult));
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