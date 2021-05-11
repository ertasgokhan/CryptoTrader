﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Binance.API.Csharp.Client.Models.Account
{
    public class DepositHistory
    {
        [JsonProperty("depositList")]
        public IEnumerable<Deposit> DepositList { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}