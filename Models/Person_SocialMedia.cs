using System.ComponentModel.DataAnnotations;

namespace PrjPortfolio.Models
{
    public enum SocialMedia
    {
        GitHub, Linkedin, Facebook, Twitter
    }
    public class Person_SocialMedia
    {
        public int ID { get; set; }

        public int PersonID { get; set; }

        [Required]
        public SocialMedia? SocialMedia { get; set; }

        [StringLength(50)]
        [Required]
        public string UserName { get; set; }

        [StringLength(250)]
        [DataType(DataType.Url)]
        [Required]
        public string AccessLink { get; set; }

        public virtual Person Person { get; set; }
    }
}
