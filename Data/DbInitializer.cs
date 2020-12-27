using PrjPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace PrjPortfolio.Data
{
    public class DbInitializer
    {
        public static void Initialize(PortfolioContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
