using PrjPortfolio.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrjPortfolio.Models
{
    public class Portfolio_Images
    {
        public int ID { get; set; }
        public int PortfolioID { get; set; }
        [ImageSize(2840, 4260, 1.5)]
        public string PhotoUrl { get; set; }
        public string ContentTypeImage { get; set; }
        [StringLength(150)]
        public string PhotoName { get; set; }
    }
}
