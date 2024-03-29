namespace FunFactThursday.Application.Users;

public class CreateUserDto
{
    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}