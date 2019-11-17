# ExchangeMoney

Domain
The problem domain is a FX Exchange, where an amount in one currency is exchanged to another amount in another currency. This is commonly done using an ISO currency pair, e.g. EUR/DKK, where EUR is the main currency and DKK is money currency. Each currency pair is associated with an exchange rate, where 1 of the main currency can be exchanged to given amount in the money currency. For instance: EUR/DKK 7,4394, would denote that 1 EUR can be exchange with 7,4394 DKK.

Task
Using the exchange rates below, denoting the amount Danish kroner (DKK) required to purchase 100 in the mentioned currency,  make a command line tool that is able to take a ISO currency pair and an  amount, and write the exchanged amount to the console.
It is expected that a currency pair can contain any combination of the mentioned currencies (including DKK), e.g. EUR/USD. 
If a currency pair has the same ISO currency as both main and money, then the passed amount should be returned. 
If a currency pair contains an unknown currency, then an appropriate error message should be written to console.

Implemented with C#, Unit Testing, .NET Core Console App, TDD
