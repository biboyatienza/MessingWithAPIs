// See https://aka.ms/new-console-template for more information
using MessingWithAPIs.CoinsPh.Services;

Console.WriteLine("Hello, World!\n\n");

HttpClient httpClient = new HttpClient();

IMarketService marketService = new MarketService(httpClient);
var markets = await marketService.GetMarkets();
var uniqueSymbols = markets.DistinctBy(p => p.product).OrderBy(p => p.product);
Console.WriteLine("Request from MarketService:- \n\n");
foreach (var item in uniqueSymbols)
{
  Console.WriteLine("{0}, ask: {1}", item.product, item.ask);
}