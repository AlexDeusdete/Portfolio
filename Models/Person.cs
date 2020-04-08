using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrjPortfolio.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Name { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string FullName { get; set; }

        [NotMapped]
        public string CompletName
        {
            get
            {
                return Name + " " + FullName;
            }
        }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        [StringLength(200)]
        public string PhotoName { get; set; }

        public ICollection<Person_SocialMedia> SocialMedias { get; set; }
    }
}
