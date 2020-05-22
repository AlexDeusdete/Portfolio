using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrjPortfolio.Data;
using PrjPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjPortfolio.Components.Portfolios.ProjectImage
{
    public class ProjectImageViewComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public ProjectImageViewComponent(PortfolioContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int portfolio_ProjectsID)
        {
            return View(await GetItemsAsync(portfolio_ProjectsID));
        }

        private Task<List<Portfolio_Projects_Images>> GetItemsAsync(int portfolio_ProjectsID)
        {
            return _context.Portfolio_Projects_Images.Where(x => x.Portfolio_ProjectsID == portfolio_ProjectsID).ToListAsync();
        }
    }
}
