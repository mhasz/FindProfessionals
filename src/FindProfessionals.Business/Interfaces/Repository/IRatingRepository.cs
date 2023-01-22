using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface IRatingRepository
    {
        Task<Rating> GetRatingByIdAsync(Guid id);
        Task<IEnumerable<Rating>> GetRatingsByProfessionalIdAsync(Guid id);
        Task InsertRatingAsync(Rating rating);
        Task UpdateRatingAsync(Rating rating);
        Task DeleteRatingAsync(Guid id);
    }
}
