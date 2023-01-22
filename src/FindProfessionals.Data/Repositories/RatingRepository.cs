using FindProfessionals.Business.Interfaces.Repository;
using FindProfessionals.Data.Contexts;
using FindProfessionals.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindProfessionals.Data.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly DataDbContext _context;

        public RatingRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<Rating> GetRatingByIdAsync(Guid id)
        {
            return await _context.Ratings.FindAsync(id);
        }

        public async Task<IEnumerable<Rating>> GetRatingsByProfessionalIdAsync(Guid id)
        {
            return await _context.Ratings.AsNoTracking().Where(r => r.ProfessionalId == id).ToListAsync();
        }

        public async Task InsertRatingAsync(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRatingAsync(Rating rating)
        {
            _context.Ratings.Update(rating);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRatingAsync(Guid id)
        {
            _context.Ratings.Remove(new Rating { Id = id });
            await _context.SaveChangesAsync();
        }
    }
}
