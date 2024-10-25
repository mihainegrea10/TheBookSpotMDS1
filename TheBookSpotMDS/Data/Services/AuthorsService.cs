using Microsoft.EntityFrameworkCore;
using TheBookSpotMDS.Models;

namespace TheBookSpotMDS.Data.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Author author)
        {
               await _context.Authors.AddAsync(author);
               await  _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(n => n.AuthorId == id);
             _context.Authors.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            var result = await _context.Authors.ToListAsync();
            return result;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
          var result = await _context.Authors.FirstOrDefaultAsync(n => n.AuthorId == id);
            return result;
        }

        public async Task<Author> UpdateAsync(int id, Author newAuthor)
        {
            _context.Update(newAuthor);
            await _context.SaveChangesAsync();
            return newAuthor;
        }
    }
}
