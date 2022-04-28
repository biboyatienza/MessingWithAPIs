namespace MessingWithAPIs.Models
{
  // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Market
    {
        public string symbol { get; set; }
        public string currency { get; set; }
        public string product { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public int expires_in_seconds { get; set; }
        public bool disabled { get; set; }
    }
    //https://api.coins.asia/v3/markets
    public class Root
    {
        public IEnumerable<Market> markets { get; set; }
    }
}