using Microsoft.EntityFrameworkCore;
using PrjPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjPortfolio.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Person_SocialMedia> Person_SocialMedias { get; set; }
        public DbSet<Models.Portfolio> Portfolios { get; set; }
        public DbSet<Portfolio_Images> Portfolio_ImagesDB { get; set; }
        public DbSet<Portfolio_Projects> Portfolio_ProjectsDB { get; set; }

    }
}
