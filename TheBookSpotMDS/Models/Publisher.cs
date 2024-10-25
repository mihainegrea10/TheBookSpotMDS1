using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TheBookSpotMDS.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }
        public List<Book> Books { get; set; }
    }
}
