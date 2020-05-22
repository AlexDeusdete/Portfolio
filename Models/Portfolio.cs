using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjPortfolio.Models
{
    public enum Area
    {
        Design, Programação, Contabilidade, Saude, Artesanato
    }
    public class Portfolio
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Título")]
        public string Title { get; set; }
        [Required]
        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        public bool Active { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateCriation { get; set; }
        [Display(Name = "Area de Atuação")]
        public Area Area { get; set; }
        public Int32 FristColorArgb
        {
            get
            {
                return FristColor.ToArgb();
            }
            set
            {
                FristColor = Color.FromArgb(value);
            }
        }
        public Int32 SecondColorArgb
        {
            get
            {
                return SecondColor.ToArgb();
            }
            set
            {
                SecondColor = Color.FromArgb(value);
            }
        }

        //Not Mapped in bank

        [NotMapped]
        [Display(Name = "Cor Principal")]
        public Color FristColor { get; set; }
        [NotMapped]
        public string FristColorHex
        {
            get
            {
                return ColorTranslator.ToHtml(FristColor);
            }
            set
            {
                FristColor = ColorTranslator.FromHtml(value);
            }
        }
        [NotMapped]
        public string SecondColorHex
        {
            get
            {
                return ColorTranslator.ToHtml(SecondColor);
            }
            set
            {
                SecondColor = ColorTranslator.FromHtml(value);
            }
        }
        [NotMapped]
        [Display(Name = "Cor Secundaria")]
        public Color SecondColor { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Portfolio_Projects> Projects { get; set; }
        public virtual ICollection<Portfolio_Images> Images { get; set; }
    }
}
