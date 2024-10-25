using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TheBookSpotMDS.Models
{
    public class Library
    {

        [Key]
        public int LibraryId { get; set; }

        [Display(Name = "Name")]
        public string LibraryName { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        public List<Book> Books { get; set; }

    }
}
