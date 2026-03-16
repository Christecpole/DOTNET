using AuthMicroService.Dtos;

namespace AuthMicroService.Services
{
    public interface IAuthService
    {
        LoginResponseDto Authenticate(LoginDto dto);

        LoginResponseDto Register(RegisterDto dto);
    }
}
