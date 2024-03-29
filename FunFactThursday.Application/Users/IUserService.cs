namespace FunFactThursday.Application.Users;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<UserDto> CreateAsync(CreateUserDto createUserDto, CancellationToken cancellationToken);
    Task<UserDto> UpdateAsync(UserDto userDto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
}