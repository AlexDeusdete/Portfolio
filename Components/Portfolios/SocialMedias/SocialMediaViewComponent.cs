using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrjPortfolio.Data;
using PrjPortfolio.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjPortfolio.Components.Portfolios.SocialMedias
{
    public class SocialMediaViewComponent : ViewComponent
    {
        private readonly PortfolioContext _context;

        public SocialMediaViewComponent(PortfolioContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int personID)
        {
            return View(await GetItemsAsync(personID));
        }

        private Task<List<Person_SocialMedia>> GetItemsAsync(int personID)
        {
            return _context.Person_SocialMedias.Where(x => x.PersonID == personID).ToListAsync();
        }
    }
}
