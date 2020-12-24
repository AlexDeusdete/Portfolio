using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrjPortfolio.Data;
using PrjPortfolio.Models;
using PrjPortfolio.Utils;
using SQLitePCL;

namespace PrjPortfolio.Controllers
{
    public class PortfoliosController : Controller
    {
        private readonly PortfolioContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public PortfoliosController(PortfolioContext context,
                                    UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;            
        }

        // GET: Portfolios
        public async Task<IActionResult> Index()
        {
            var portfolioContext = _context.Portfolios.Include(p => p.Person);            
            return View(await portfolioContext.ToListAsync());
        }

        // GET: Portfolios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // GET: Portfolios/Create
        public IActionResult Create()
        {
            ViewData["PersonID"] = new SelectList(_context.People, "ID", "Email");
            return View();
        }

        // POST: Portfolios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PersonID,Title,Description,Person")] Portfolio portfolio)
        {
            portfolio.AspNetUsersID = await _userManager.GetUserIdAsync(await GetCurrentUserAsync());
            portfolio.Person.Email = await _userManager.GetEmailAsync(await GetCurrentUserAsync());

            _context.Add(portfolio);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Edit), new { id = portfolio.ID });
        }

        // GET: Portfolios/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            var userId = await _userManager.GetUserIdAsync(await GetCurrentUserAsync());

            if (userId != portfolio.AspNetUsersID)
            {
                return RedirectToAction(nameof(Details), new { _context.Portfolios.FirstOrDefault(x => x.AspNetUsersID == userId).ID }); 
            }
            return View(portfolio);
        }

        // POST: Portfolios/SaveSocialMedia
        [HttpPost]
        public JsonResult SaveSocialMedia(int personID, string socialMedia, string userName, string accessLink)
        {
            var _socialMedia = (SocialMedia)Enum.Parse(typeof(SocialMedia), socialMedia);
            Person_SocialMedia person_SocialMedia;

            if (_context.People.Find(personID).
                    SocialMedias.Any(x => x.SocialMedia == _socialMedia))
            {
                person_SocialMedia = _context.People.Find(personID).
                                        SocialMedias.First(x => x.SocialMedia == _socialMedia);

                person_SocialMedia.UserName = userName;
                person_SocialMedia.AccessLink = accessLink;
                _context.Update(person_SocialMedia);
                _context.SaveChanges();
            }else
            {
                person_SocialMedia = new Person_SocialMedia()
                {
                    AccessLink = accessLink,
                    PersonID = personID,
                    SocialMedia = _socialMedia,
                    UserName = userName
                };
                _context.Add(person_SocialMedia);
                _context.SaveChanges();
            };
            return Json(new { Result = person_SocialMedia.ID });
        }

        [HttpGet]
        public IActionResult LoadSocialMedia(int personID)
        {
            return ViewComponent("SocialMedia", new { personID });
        }

        // POST: Portfolios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Portfolio portfolio, IFormFile Img)
        {
            if (id != portfolio.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(Img != null)
                    {
                        portfolio.Person.Photo = Img.ToByteArray();
                        portfolio.Person.PhotoName = Path.GetFileName(Img.Name);
                        portfolio.Person.ContentTypeImage = Img.ContentType;

                        if (!TryValidateModel(portfolio))
                        {
                            return View(portfolio);
                        }
                    }


                    _context.Update(portfolio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioExists(portfolio.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id });
            }            
            return View(portfolio);
        }

        // GET: Portfolios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // POST: Portfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portfolio = await _context.Portfolios.FindAsync(id);
            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioExists(int id)
        {
            return _context.Portfolios.Any(e => e.ID == id);
        }

        [HttpGet]
        [ResponseCache(Duration = 3600)]
        public FileResult RenderPhotoById(string type, int id)
        {            
            switch (type)
            {
                case "person":
                    var itemp = _context.People
                        .Where(x => x.ID == id)
                        .Select(s => new { s.Photo, s.ContentTypeImage })
                        .FirstOrDefault();
                    if (itemp.Photo != null)
                    {
                        return File(itemp.Photo, itemp.ContentTypeImage);
                    }
                    break;
                case "portfolio":
                    var itempor = _context.Portfolio_ImagesDB
                        .Where(x => x.PortfolioID == id)
                        .Select(s => new { s.Photo, s.ContentTypeImage })
                        .FirstOrDefault();
                    if (itempor.Photo != null)
                    {
                        return File(itempor.Photo, itempor.ContentTypeImage);
                    }
                    break;
                case "project":
                    var itempro = _context.Portfolio_Projects_Images
                        .Where(x => x.ID == id)
                        .Select(s => new { s.Photo, s.ContentTypeImage })
                        .FirstOrDefault();
                    if (itempro.Photo != null)
                    {
                        return File(itempro.Photo, itempro.ContentTypeImage);
                    }
                    break;
            }

            return File("~/Images/no-picture-taking.png", "Image/png");
        }

        [HttpGet]
        public JsonResult EditEducation(int id)
        {
            var result = _context.Educations.Where(x => x.ID == id).FirstOrDefault();

            return Json(result);
        }

        [HttpGet]
        public JsonResult EditProject(int id)
        {
            var result = _context.Portfolio_ProjectsDB.Where(x => x.ID == id).Select(item => new Portfolio_Projects
            {
                ID = item.ID,
                Name = item.Name,
                GitHub = item.GitHub,
                DateCriation = item.DateCriation,
                Tools = item.Tools,
                Description = item.Description,
            }).FirstOrDefault();

            return Json(result);
        }

        [HttpGet]
        public IActionResult LoadEducation(int personID)
        {
            return ViewComponent("Educations", new { personID });
        }

        [HttpGet]
        public IActionResult LoadProjectImage(int portfolio_ProjectsID)
        {
            return ViewComponent("ProjectImage", new { portfolio_ProjectsID });
        }

        // POST: Portfolios/SaveEducation
        [HttpPost]
        public JsonResult SaveEducation(int id, int personID, string institution, string courseName, string initialDate
                                        , string endDate, string certificateCode, string certificateUrl)
        {            
            Education education;

            if (_context.Educations.Any(x => x.ID == id))
            {
                education = _context.Educations.First(x => x.ID == id);

                education.Institution = institution;
                education.CourseName = courseName;
                education.InitialDate = DateTime.Parse(initialDate, new CultureInfo("pt-BR")); 
                education.EndDate = DateTime.Parse(endDate, new CultureInfo("pt-BR")); 
                education.CertificateCode = certificateCode;
                education.CertificateUrl = certificateUrl;
                _context.Update(education);
                _context.SaveChanges();
            }
            else
            {
                education = new Education()
                {
                    PersonID = personID,
                    Institution = institution,
                    CourseName = courseName,
                    InitialDate = DateTime.Parse(initialDate, new CultureInfo("pt-BR")),
                    EndDate = DateTime.Parse(endDate, new CultureInfo("pt-BR")),
                    CertificateCode = certificateCode,
                    CertificateUrl = certificateUrl
                };
                _context.Add(education);
                _context.SaveChanges();
            };
            return Json(new { Result = education.ID });
        }

        [HttpPost]
        public IActionResult InsertImage(int portfolioID, IFormFile file)
        {
            if (file != null)
            {
                Portfolio_Images img = new Portfolio_Images
                {
                    PortfolioID = portfolioID,
                    Photo = file.ToByteArray(),
                    PhotoName = Path.GetFileName(file.Name),
                    ContentTypeImage = file.ContentType
                };

                if (!TryValidateModel(img))
                {
                    return ViewComponent("PortfolioImage", new { portfolioID });
                }

                _context.Update(img);
                _context.SaveChanges();
            }
            return ViewComponent("PortfolioImage", new { portfolioID });
        }

        [HttpPost]
        public IActionResult InsertImageProject(int portfolio_ProjectsID, IFormFile file)
        {
            if (file != null)
            {
                Portfolio_Projects_Images img = new Portfolio_Projects_Images
                {
                    Portfolio_ProjectsID = portfolio_ProjectsID,
                    Photo = file.ToByteArray(),
                    PhotoName = Path.GetFileName(file.Name),
                    ContentTypeImage = file.ContentType
                };

                if (!TryValidateModel(img))
                {
                    return ViewComponent("ProjectImage", new { portfolio_ProjectsID });
                }

                _context.Update(img);
                _context.SaveChanges();
            }
            return ViewComponent("ProjectImage", new { portfolio_ProjectsID });
        }

        [HttpPost]
        public IActionResult DeleteImageCapa(string type, int id, int idComponent)
        {
            switch (type)
            {
                case "capa":
                    if (_context.Portfolio_ImagesDB.Any(x => x.ID == id))
                    {
                        var img = _context.Portfolio_ImagesDB.Where(x => x.ID == id).FirstOrDefault();

                        _context.Remove(img);
                        _context.SaveChanges();
                    }
                    return ViewComponent("PortfolioImage", new { portfolioID = idComponent });
                case "project":
                    if (_context.Portfolio_Projects_Images.Any(x => x.ID == id))
                    {
                        var img = _context.Portfolio_Projects_Images.Where(x => x.ID == id).FirstOrDefault();

                        _context.Remove(img);
                        _context.SaveChanges();
                    }
                    return ViewComponent("ProjectImage", new { portfolio_ProjectsID = idComponent });
            }

            return ViewComponent("PortfolioImage", new { portfolioID = idComponent });
        }

        [HttpPost]
        public IActionResult CreateProject(string name, int portfolioID)
        {
            var prj = new Portfolio_Projects()
            {
                PortfolioID = portfolioID,
                Name = name
            };

            _context.Add(prj);
            _context.SaveChanges();
            return ViewComponent("Project", new { portfolioID });
        }
        
        [HttpPost]
        public IActionResult DeleteProject(int id, int portfolioID)
        {
            if (_context.Portfolio_ProjectsDB.Any(x => x.ID == id))
            {
                var img = _context.Portfolio_ProjectsDB.Where(x => x.ID == id).FirstOrDefault();

                _context.Remove(img);
                _context.SaveChanges();
            }

            return ViewComponent("Project", new { portfolioID });
        }

        [HttpPut]
        public IActionResult SaveProject(Portfolio_Projects portfolio_Projects)
        {

            if (portfolio_Projects.ID > 0)
            {
                _context.Update(portfolio_Projects);
                _context.SaveChanges();
            };

            return ViewComponent("Project", new { portfolioID = portfolio_Projects.PortfolioID });
        }
    }
}
