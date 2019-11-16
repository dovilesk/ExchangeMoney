namespace Logic
{
    public interface IExchangeMoneyLogic
    {
        decimal Exchange(string currentCurrency, string currencyExchangeTo, decimal amount);
    }
}