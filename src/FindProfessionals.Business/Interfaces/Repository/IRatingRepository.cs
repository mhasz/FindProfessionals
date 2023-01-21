using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Repository
{
    public interface IRatingRepository
    {
        Task<Rating> GetRatingByIdAsync(Guid id);
        Task<IEnumerable<Rating>> GetRatingsByProfessionalIdAsync(Guid id);
        Task<Rating> InsertRatingAsync(Rating rating);
        Task<Rating> UpdateRatingAsync(Rating rating);
        Task<Rating> DeleteRatingAsync(Guid id);
    }
}
