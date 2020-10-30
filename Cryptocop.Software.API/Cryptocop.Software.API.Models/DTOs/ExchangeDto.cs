using System;

namespace Cryptocop.Software.API.Models.DTOs
{
    public class ExchangeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string AssetSymbol { get; set; } 
        public float PriceInUsd { get; set; } // (nullable float)
        public DateTime LastTrade { get; set; } // (nullable datetime)
    }
}


/* 
ExchangeDto
• Id (string)
• Name (string)
• Slug (string)
• AssetSymbol (string)
• PriceInUsd (nullable float)
• LastTrade (nullable datetime)
*/