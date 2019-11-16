using Logic;
using Ninject.Modules;
using Repositories;

namespace Exchange
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IExchangeMoneyLogic>().To<ExchangeMoneyLogic>();
            Bind<IExchangeRatesRepository>().To<ExchangeRatesRepository>();
        }
    }
}
