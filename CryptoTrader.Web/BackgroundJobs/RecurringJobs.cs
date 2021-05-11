using Hangfire;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTrader.Web.BackgroundJobs
{
    public class RecurringJobs
    {
        [Obsolete]
        public static void ReportingJob()
        {
            Hangfire.RecurringJob.AddOrUpdate("reportjob2", () => Report(), Cron.MinuteInterval(5));
        }

        public static void Report()
        {
            Debug.WriteLine("Cart Curt");
        }
    }
}
