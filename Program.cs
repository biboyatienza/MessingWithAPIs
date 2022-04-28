// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using MessingWithAPIs.Models;
using System.Globalization;

Console.WriteLine("Hello, World!");

HttpClient client = new HttpClient();

// var cultureInfo = new CultureInfo("en-US");
// // cultureInfo.NumberFormat.CurrencySymbol = "P";

// CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
// CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


const string REST_API = "https://api.coins.asia/v3/markets"; 
//List<Market> markets;

HttpResponseMessage response = await client.GetAsync(REST_API);
if (response.IsSuccessStatusCode)
{
    // markets = await response.Content.ReadAsStringAsync() <Market>();
    Console.WriteLine("Request Message Information:- \n\n" + response.RequestMessage + "\n");
    Console.WriteLine("Response Message Header \n\n" + response.Content.Headers + "\n");
    // Get the response
    var marketsJsonString = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Your response data is: " + marketsJsonString);

    // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
    var deserialized = JsonSerializer.Deserialize<Root>(marketsJsonString);
    // Do something with it
    Console.WriteLine("Your deserialized response data is: " + deserialized.markets);
    
    // foreach (var item in deserialized.markets)
    // {
    //   Console.WriteLine("{0}, ask: {1}", item.symbol, item.ask);
    // }

    var uniqueSymbols = deserialized.markets.DistinctBy(p => p.product).OrderBy(p => p.product);
    foreach (var item in uniqueSymbols)
    {
      Console.WriteLine("{0}, ask: {1}", item.product, item.ask);
    }

}

