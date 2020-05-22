using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrjPortfolio.Models
{
    public enum Language
    {
        dotNet, Delphi, JavaScript, Python, SQL
    }
    public class Portfolio_Projects
    {
        public int ID { get; set; }
        public int PortfolioID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Name { get; set; }     
        [DataType(DataType.Url)]
        public string GitHub { get; set; }
        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Display(Name = "Linguagem")]
        public Language Language { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Criação")]
        public DateTime DateCriation { get; set; }

        public virtual ICollection<Portfolio_Projects_Images> Images { get; set; }
    }
}
