using FunFactThursday.Domain.common;
using FunFactThursday.Domain.Users;

namespace FunFactThursday.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);

        return users
            .Select(x => x.MapToUserDto())
            .ToList();
    }
    
    public async Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken)
                   ?? throw new Exception("Not Found");

        return user.MapToUserDto();
    }
    
    public async Task<UserDto> CreateAsync(CreateUserDto createUserDto, CancellationToken cancellationToken)
    {
        if (!await _userRepository.IsEmailUniqueAsync(createUserDto.Email, cancellationToken))
        {
            throw new Exception("Email already exists");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = createUserDto.Email,
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName
        };

        _userRepository.Create(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.MapToUserDto();
    }
    
    public async Task<UserDto> UpdateAsync(UserDto userDto, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(userDto.Id, cancellationToken)
                   ?? throw new Exception("Not Found");

        await UpdateEmailAsync(userDto, user, cancellationToken);
        UpdateFirstName(userDto, user);
        UpdateLastName(userDto, user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.MapToUserDto();
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken)
                   ?? throw new Exception("Not Found");

        _userRepository.Delete(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
    
    private static void UpdateLastName(UserDto userDto, User user)
    {
        if (user.LastName != userDto.LastName)
        {
            user.LastName = userDto.LastName;
        }
    }

    private static void UpdateFirstName(UserDto userDto, User user)
    {
        if (user.FirstName != userDto.FirstName)
        {
            user.FirstName = userDto.FirstName;
        }
    }

    private async Task UpdateEmailAsync(UserDto userDto, User user,
        CancellationToken cancellationToken)
    {
        if (user.Email != userDto.Email)
        {
            if (!await _userRepository.IsEmailUniqueAsync(userDto.Email, cancellationToken))
            {
                throw new Exception("Email already exists");
            }

            user.Email = userDto.Email;
        }
    }
}