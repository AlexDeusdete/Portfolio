﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjPortfolio.Models
{
    public class Portfolio
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool Active { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateCriation { get; set; }
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
        [NotMapped]
        public Color FristColor { get; set; }
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
        [NotMapped]
        public Color SecondColor { get; set; }

        public Person Person { get; set; }
        public ICollection<Portfolio_Projects> Projects { get; set; }
        public ICollection<Portfolio_Images> Images { get; set; }
    }
}
