using Binance.API.Csharp.Client;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTrader.Web.BackgroundJobs
{
    public class RecurringJobs
    {
        private static ApiClient apiClient = new ApiClient("", "");
        private static BinanceClient binanceClient = new BinanceClient(apiClient);

        [Obsolete]
        public static void ReportingJob()
        {
            Hangfire.RecurringJob.AddOrUpdate("reportjob2", () => Report(), Cron.MinuteInterval(31));
        }

        public static void Report()
        {
            Debug.WriteLine("Cart Curt");
        }

        [Obsolete]
        public static void ReadAndWriteCandleStickJob()
        {
            Hangfire.RecurringJob.AddOrUpdate("reportjob3", () => ReadAndWriteCandleStick(), "* * * * *");
        }

        public static void ReadAndWriteCandleStick()
        {
            Task.Delay(6000).Wait();

            binanceClient = new BinanceClient(apiClient);

            //binanceClient.GetCandleSticks()

            string filepath = Directory.GetCurrentDirectory() + @"\CandleStick\" + "asd.txt";

            if (File.Exists(filepath))
                File.Delete(filepath);

            using (StreamWriter sw = File.CreateText(filepath))
            {
                sw.WriteLine(DateTime.Now);
            }
        }
    }
}
