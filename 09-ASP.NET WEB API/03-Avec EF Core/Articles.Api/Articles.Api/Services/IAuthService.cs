using Articles.Api.Dtos;

namespace Articles.Api.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto> AuthenticateAsync(LoginDto dto);
    }
}
