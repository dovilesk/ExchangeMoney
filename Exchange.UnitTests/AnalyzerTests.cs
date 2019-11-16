using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.UnitTests
{
    [TestFixture]
    public class AnalyzerTests
    {
      
        [TestCase(new string[] { "Exchange", "EUR/EUR", "1"}, true)]
        [TestCase(new string[] { "Exchange", "EUR/DDK", "1" }, false)]
        public void CurrencyPairHasTheSameISOCurrency_shoudReturnExpectedResults(string[] args, bool expectedResult)
        {
            //Arrange
            Analyzer analyzer = new Analyzer(args);
            //Act
            bool actualResult = analyzer.CurrencyPairHasTheSameISOCurrency();
            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(new string[] { "Exchange", "EUR/123", "1" }, true)]
        [TestCase(new string[] { "Exchange", "EUR/DDK", "1" }, false)]
        public void CurrencyPairContainsUnknownCurrency_shoudReturnExpectedResults(string[] args, bool expectedResult)
        {
            //Arrange
            Analyzer analyzer = new Analyzer(args);
            //Act
            bool actualResult = analyzer.CurrencyPairContainsUnknownCurrency();
            //Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
