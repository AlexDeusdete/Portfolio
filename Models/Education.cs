using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrjPortfolio.Models
{
    public class Education
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        [StringLength(50)]
        [Display(Name = "Instituição")]
        public string Institution { get; set; }
        [StringLength(100)]
        [Display(Name = "Curso")]
        public string CourseName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Inicial")]
        public DateTime InitialDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Final")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Codigo do Certificado")]
        [StringLength(50)]
        public string CertificateCode { get; set; }
        [Display(Name = "URL do Certificado")]
        [DataType(DataType.Url)]
        [StringLength(500)]
        public string CertificateUrl { get; set; }
        public int Index { get; set; }
    }
}
