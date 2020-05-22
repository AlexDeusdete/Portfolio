using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrjPortfolio.Data;
using PrjPortfolio.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjPortfolio.Components.Portfolios.Project
{
    public class ProjectViewComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public ProjectViewComponent(PortfolioContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int portfolioID)
        {
            return View(await GetItemsAsync(portfolioID));
        }

        private Task<List<Portfolio_Projects>> GetItemsAsync(int portfolioID)
        {
            return _context.Portfolio_ProjectsDB.Where(x => x.PortfolioID == portfolioID).ToListAsync();
        }
    }
}

