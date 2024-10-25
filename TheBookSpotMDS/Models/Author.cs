using System.ComponentModel.DataAnnotations;

namespace TheBookSpotMDS.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="Profile picture is required!")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Author's full name is required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required!")]
        public string Bio { get; set; }
        public List<Author_Book> Authors_Books { get; set; }

    }
}
