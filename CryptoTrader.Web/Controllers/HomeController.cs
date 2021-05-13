using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CryptoTrader.Web.Models;
using Hangfire;
using CryptoTrader.Web.BackgroundJobs;
using Binance.API.Csharp.Client;
using Binance.API.Csharp.Client.Models.Market;
using Binance.API.Csharp.Client.Models.Enums;

namespace CryptoTrader.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Obsolete]
        public IActionResult Index()
        {
            //RecurringJobs.ReportingJob();

            //ApiClient apiClient = new ApiClient("PrX05PfE29cfXV9YyKwj3zrMadaC4jF7dr4UWoKid5RgQ1WsPsNJD8KLP56g3AwF", "fEOFqMgvXj8ew37Qp12ZpfxlFynmxYNEneNtJVPKQWvs3dvt0LkNNEzQ6660ubiT");
            //BinanceClient binanceClient = new BinanceClient(apiClient);

            //List<Candlestick> tempCandlestick = new List<Candlestick>();

            //tempCandlestick = binanceClient.GetCandleSticks("BNBUSDT", TimeInterval.Hours_1, DateTime.Now.AddMonths(-1), DateTime.Now, 1000).Result.ToList();

            //var accountInfos = binanceClient.GetAccountInfo().Result;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
