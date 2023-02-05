using FindProfessionals.Domain.Entities;

namespace FindProfessionals.Business.Interfaces.Service
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
