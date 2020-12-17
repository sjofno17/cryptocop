using System;
using Newtonsoft.Json;

namespace Cryptocop.Software.API.Models.DTOs
{
    public class ExchangeDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("assetSymbol")]
        public string AssetSymbol { get; set; } 
        [JsonProperty("priceInUsd")]
        public float PriceInUsd { get; set; } // (nullable float)
        [JsonProperty("lastTrade")]
        public DateTime LastTrade { get; set; } // (nullable datetime)
    }
}
