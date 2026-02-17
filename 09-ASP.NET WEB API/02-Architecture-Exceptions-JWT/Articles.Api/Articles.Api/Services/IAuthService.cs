using Articles.Api.Dtos;

namespace Articles.Api.Services
{
    public interface IAuthService
    {
        LoginResponseDto Authenticate(LoginDto dto);
    }
}
