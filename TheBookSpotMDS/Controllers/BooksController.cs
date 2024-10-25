using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheBookSpotMDS.Data;

namespace TheBookSpotMDS.Controllers
{
    public class BooksController : Controller
    {

        private readonly AppDbContext _context;
        public BooksController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allBooks = await _context.Books.Include(n => n.Library).OrderBy(n => n.Title).ToListAsync();
            return View(allBooks);

        }
    }
}
