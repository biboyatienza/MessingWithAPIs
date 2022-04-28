using System.Net;
using System.Net.Http.Json;

namespace MessingWithAPIs.Services.Common
{
  public abstract class ClientAPI
  {
    protected readonly HttpClient _httpClient;
    private readonly string _baseRoute;

    public ClientAPI(string baseRoute, HttpClient httpClient)
    {
      _baseRoute = baseRoute;
      _httpClient = httpClient;
    }

    protected async Task<TReturn> GetAsync<TReturn>(string relativeUri)
    {
      HttpResponseMessage response = await _httpClient.GetAsync($"{_baseRoute}/{relativeUri}");
      if (response.StatusCode == HttpStatusCode.NoContent) return default(TReturn);
      if(response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<TReturn>();

      string errorMessage = await response.Content.ReadAsStringAsync();
      Console.WriteLine(errorMessage);
      throw new Exception(errorMessage);
    }

    protected async Task<TReturn> PostAsync<TReturn, TRequest>(string relativeUri, TRequest request)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TRequest>($"{_baseRoute}/{relativeUri}", request);
        if (response.StatusCode == HttpStatusCode.NoContent) return default(TReturn);
        if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<TReturn>();

        string errorMessage = await response.Content.ReadAsStringAsync();
        Console.WriteLine(errorMessage);
        throw new Exception(errorMessage);
    }
  }
}