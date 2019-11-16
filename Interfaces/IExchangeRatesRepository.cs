using System.Collections.Generic;
using Dto;

namespace Repositories
{
    public interface IExchangeRatesRepository
    {
        List<ExchangeRateDto> getAllExchangeRates();
        ExchangeRateDto GetExchangeRateByISO(string ISO);
    }
}