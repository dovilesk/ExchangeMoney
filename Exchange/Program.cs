using Logic;
using Ninject;
using System;
using System.Reflection;

namespace Exchange
{
    public class Program
    {
        [Inject]
        public static IExchangeMoneyLogic _exchangeMoney { get; set; }

        public static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
           
            try
            {
                Analyzer argumentsAnalyzer = new Analyzer(args);

                if (argumentsAnalyzer.ArgumentsAreCorrect())
                {
                   _exchangeMoney = kernel.Get<IExchangeMoneyLogic>();
                   var result = _exchangeMoney.Exchange(argumentsAnalyzer.CurrentCurrency, argumentsAnalyzer.CurrencyExchangeTo, argumentsAnalyzer.Amount);
                   Console.WriteLine(result);
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("Usage: Exchange <currency pair> <amount to change>");
            }

            Console.ReadLine();
        }

       

    }
}
