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
        CSharp, Delphi, JavaScript, Python, SQL
    }
    public class Portfolio_Projects
    {
        public int ID { get; set; }
        public int PortfolioID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]       
        [DataType(DataType.Url)]
        public string GitHub { get; set; }
        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        public Language Language { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateCriation { get; set; }

        public virtual ICollection<Portfolio_Projects_Images> Images { get; set; }
    }
}
