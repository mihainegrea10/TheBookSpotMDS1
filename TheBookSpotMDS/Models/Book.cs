using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TheBookSpotMDS.Data.Enums;

namespace TheBookSpotMDS.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Display(Name = "Book Title")]
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Book cover")]
        public string ImageURL { get; set; }
        public double Price { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        public BookCategory BookCategory { get; set; }
        public List<Author_Book> Authors_Books { get; set; }


        public int LibraryId { get; set; }
        public Library Library { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

    }
}
