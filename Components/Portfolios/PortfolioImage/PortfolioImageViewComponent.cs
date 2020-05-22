using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrjPortfolio.Data;
using PrjPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjPortfolio.Components.Portfolios.PortfolioImage
{
    public class PortfolioImageViewComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public PortfolioImageViewComponent(PortfolioContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int portfolioID)
        {
            return View(await GetItemsAsync(portfolioID));
        }

        private Task<List<Portfolio_Images>> GetItemsAsync(int portfolioID)
        {
            return _context.Portfolio_ImagesDB.Where(x => x.PortfolioID == portfolioID).ToListAsync();
        }
    }
}
