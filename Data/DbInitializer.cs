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

            //Look for any port
            if (context.Portfolios.Any())
                return;

            var person = new Person { Email = "Teste@Teste.com.br", Name = "Teste", FullName = "Testador Maximo", Phone = "11971547128" };
            context.People.Add(person);
            context.SaveChanges();

            var person_SocialMedia = new Person_SocialMedia
            {
                AccessLink = "https://docs.microsoft.com/pt-br/aspnet/core/data/ef-mvc/intro?view=aspnetcore-3.1",
                PersonID = 1,
                SocialMedia = SocialMedia.GitHub,
                UserName = "@teste"
            };
            context.Person_SocialMedias.Add(person_SocialMedia);
            context.SaveChanges();

            var educations = new Education[]
            {
                new Education
                {
                     Institution = "Uninove",
                     CourseName = "Ciencia da Computação",
                     CertificateCode = "ELGASDFIAJD15ASDFASD562333",
                     CertificateUrl = "",
                     Index = 1,
                     PersonID = 1,
                     InitialDate = DateTime.Today.AddYears(-4),
                     EndDate = DateTime.Today
                },
                new Education
                {
                     Institution = "Tranning",
                     CourseName = "Getão de Projetos",
                     CertificateCode = "ELGASDFIAJD15ASDFASD562333",
                     CertificateUrl = "",
                     Index = 2,
                     PersonID = 1,
                     InitialDate = DateTime.Today.AddYears(-1),
                     EndDate = DateTime.Today
                },
                new Education
                {
                     Institution = "Axelios",
                     CourseName = "ITIL 4",
                     CertificateCode = "ELGASDFIAJD15ASDFASD562333",
                     CertificateUrl = "",
                     Index = 3,
                     PersonID = 1,
                     InitialDate = DateTime.Today.AddMonths(-6),
                     EndDate = DateTime.Today
                },
                new Education
                {
                     Institution = "Franco Montoro",
                     CourseName = "Ensino Medio",
                     CertificateCode = "ELGASDFIAJD15ASDFASD562333",
                     CertificateUrl = "",
                     Index = 4,
                     PersonID = 1,
                     InitialDate = DateTime.Today.AddYears(-3),
                     EndDate = DateTime.Today
                }
            };
            foreach (var item in educations)
            {
                context.Educations.Add(item);
            }
            context.SaveChanges();

            var portfolio = new Models.Portfolio
            {
                Active = true,
                DateCriation = DateTime.Now,
                Description = "Protfolio do cara do teste ele testa mesmo em" +
                                "AAAAAAAAAAAEEEEEEEEEEEE",
                FristColor = Color.White,
                SecondColor = Color.Gray,
                PersonID = 1,
                Title = "TESTEEEEEEEEEEEEEE"
            };
            context.Portfolios.Add(portfolio);
            context.SaveChanges();

            var portfolio_Projects = new Portfolio_Projects[]
            {
                new Portfolio_Projects
                {
                    DateCriation = DateTime.Now,
                    GitHub = "https://medium.com/@fulviocanducci/asp-net-mvc-core-e-entity-framework-core-gravando-fotos-em-uma-tabela-do-banco-de-dados-ad9441248c93",
                    Description = "Projeto do teste boladao",
                    Tools = new List<Tool>(){Tool.dotNet, Tool.Xamarin},
                    Name = "Batata",
                    PortfolioID = 1
                },
                new Portfolio_Projects
                {
                    DateCriation = DateTime.Now,
                    GitHub = "https://medium.com/@fulviocanducci/asp-net-mvc-core-e-entity-framework-core-gravando-fotos-em-uma-tabela-do-banco-de-dados-ad9441248c93",
                    Description = "Projeto do teste boladao",
                    Tools = new List<Tool>(){Tool.dotNet},
                    Name = "BBBBBBBBB",
                    PortfolioID = 1
                },
                new Portfolio_Projects
                {
                    DateCriation = DateTime.Now,
                    GitHub = "https://medium.com/@fulviocanducci/asp-net-mvc-core-e-entity-framework-core-gravando-fotos-em-uma-tabela-do-banco-de-dados-ad9441248c93",
                    Description = "Projeto do teste boladao",
                    Tools =  new List<Tool>(){Tool.SQL, Tool.Xamarin},
                    Name = "AAAAAAAAAAA",
                    PortfolioID = 1
                }
            };
            foreach (var item in portfolio_Projects)
            {
                context.Portfolio_ProjectsDB.Add(item);
            }
            context.SaveChanges();
        }
    }
}
