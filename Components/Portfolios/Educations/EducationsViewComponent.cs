using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrjPortfolio.Data;
using PrjPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjPortfolio.Components.Portfolios.Educations
{
    public class EducationsViewComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public EducationsViewComponent(PortfolioContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int personID)
        {
            return View(await GetItemsAsync(personID));
        }

        private Task<List<Education>> GetItemsAsync(int personID)
        {
            return _context.Educations.Where(x => x.PersonID == personID).ToListAsync();
        }
    }
}
