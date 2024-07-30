using Server.Domain.Entities;

namespace Server.Application.Repositories;

public interface IJwtProvider
{
    string GenerateToken(AppUser user);
}
