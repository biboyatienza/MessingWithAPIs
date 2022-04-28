using MessingWithAPIs.CoinsPh.Models;

namespace MessingWithAPIs.CoinsPh.Services
{
  public interface IMarketService
  {
    Task<IEnumerable<Market>> GetMarkets();
  }
}