using MessingWithAPIs.CoinsPh.Models;
using MessingWithAPIs.Services;

namespace MessingWithAPIs.CoinsPh.Services
{
  public class MarketService : IMarketService
  {
    // const string REST_API = "https://api.coins.asia/v3/markets"; 
    private readonly HttpClient _httpClient;
    public MarketService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<IEnumerable<Market>> GetMarkets()
    {
      try
      {
        MarketAPI marketAPI = new MarketAPI(_httpClient);
        var r = await marketAPI.GetRoot();
        return r.markets;       
      }
      catch (System.Exception)
      {
       throw;
      }
    }
  }
}