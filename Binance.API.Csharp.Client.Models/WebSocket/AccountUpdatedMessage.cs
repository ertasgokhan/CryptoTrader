﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Binance.API.Csharp.Client.Models.WebSocket
{
    public class AccountUpdatedMessage
    {
        [JsonProperty("e")]
        public string EventType { get; set; }

        [JsonProperty("E")]
        public long EventTime { get; set; }

        [JsonProperty("m")]
        public int MakerCommission { get; set; }

        [JsonProperty("t")]
        public int TakerCommission { get; set; }

        [JsonProperty("b")]
        public int BuyerCommission { get; set; }

        [JsonProperty("s")]
        public int SellerCommission { get; set; }

        [JsonProperty("t")]
        public bool CanTrade { get; set; }

        [JsonProperty("w")]
        public bool CanWithdraw { get; set; }

        [JsonProperty("d")]
        public bool CanDeposit { get; set; }

        [JsonProperty("B")]
        public IEnumerable<Balance> Balances { get; set; }
    }
}
