using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTrader.Web.Models
{
    public class CryptoTraderDbContext : IdentityDbContext<AppUser>
    {
        public CryptoTraderDbContext(DbContextOptions<CryptoTraderDbContext> options) : base(options)
        {

        }
    }
}
