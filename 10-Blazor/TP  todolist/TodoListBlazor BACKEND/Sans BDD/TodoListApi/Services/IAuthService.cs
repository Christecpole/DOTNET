using TodoListApi.DTOs;

namespace TodoListApi.Services
{
    public interface IAuthService
    {
        string Register(RegisterDto dto);
        string Login(LoginDto dto);
    }
}
