using PrjPortfolio.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrjPortfolio.Models
{
    public class Portfolio_Projects_Images
    {
        public int ID { get; set; }
        public int Portfolio_ProjectsID { get; set; }
        [ImageSize(250, 784, 3.1)]
        public string PhotoUrl { get; set; }
        public string ContentTypeImage { get; set; }
        [StringLength(150)]
        public string PhotoName { get; set; }
    }
}
