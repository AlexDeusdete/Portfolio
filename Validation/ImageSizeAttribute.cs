using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PrjPortfolio.Validation
{
    public class ImageSizeAttribute : ValidationAttribute
    {
        public ImageSizeAttribute(int maxHeight, int maxWidth, double ratio)
        {
            MaxHeight = maxHeight;
            MaxWidth = maxWidth;
            Ratio = ratio;
        }

        public int MaxHeight { get; }
        public int MaxWidth { get; }
        public double Ratio { get; }

        public string GetErrorMessage() => $"A Imagem precisa ter no maximo {MaxHeight} de Altura, {MaxWidth} de Largura e uma razao de {Ratio} .";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            MemoryStream ms = new MemoryStream((byte[])value);
            var img = Image.FromStream(ms);
            double h = img.Height;
            double w = img.Width;

            if (w <= MaxWidth && h <= MaxHeight && Math.Abs((w / h) - Ratio) <= 0.2)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage());
            
        }
    }
}
