using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheBookSpotMDS.Data;

namespace TheBookSpotMDS.Controllers
{
    public class LibrariesController : Controller
    {

        private readonly AppDbContext _context;
        public LibrariesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allLibraries = await _context.Libraries.ToListAsync();
            return View(allLibraries);
        }
    }
}
