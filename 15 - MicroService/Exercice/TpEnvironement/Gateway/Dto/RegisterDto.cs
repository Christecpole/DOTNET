using System.ComponentModel.DataAnnotations;

namespace AuthMicroService.Dtos;

public class RegisterDto
{
    [Required(ErrorMessage ="Le Username est obligatoire") ]
    public required string Username { get; set; }

    [Required(ErrorMessage ="Le mot de passe est obligatoire")]
    public required string Password { get; set; }
}