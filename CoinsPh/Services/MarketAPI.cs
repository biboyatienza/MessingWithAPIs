using MessingWithAPIs.CoinsPh.Models;
using MessingWithAPIs.Services.Common;

namespace MessingWithAPIs.Services
{
  public class MarketAPI : ClientAPI
  {
    public MarketAPI(HttpClient httpClient) : base("https://api.coins.asia", httpClient){}
    public async Task<Root> GetRoot()
    {
      try
      {
        return await GetAsync<Root>("v3/markets");
      }
      catch (System.Exception)
      {
        throw;
      }
    }
  }
}