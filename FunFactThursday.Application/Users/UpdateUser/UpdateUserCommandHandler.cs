using FunFactThursday.Domain.common;
using FunFactThursday.Domain.Users;
using MediatR;

namespace FunFactThursday.Application.Users.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserDto.UserId, cancellationToken)
                   ?? throw new Exception("Not Found");

        await UpdateEmailAsync(request, user, cancellationToken);

        UpdateFirstName(request, user);

        UpdateLastName(request, user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.MapToUserDto();
    }

    private static void UpdateLastName(UpdateUserCommand request, User user)
    {
        if (user.LastName != request.UserDto.LastName)
        {
            user.LastName = request.UserDto.LastName;
        }
    }

    private static void UpdateFirstName(UpdateUserCommand request, User user)
    {
        if (user.FirstName != request.UserDto.FirstName)
        {
            user.FirstName = request.UserDto.FirstName;
        }
    }

    private async Task UpdateEmailAsync(UpdateUserCommand request, User user,
        CancellationToken cancellationToken)
    {
        if (user.Email != request.UserDto.Email)
        {
            if (!await _userRepository.IsEmailUniqueAsync(request.UserDto.Email, cancellationToken))
            {
                throw new Exception("Email already exists");
            }

            user.Email = request.UserDto.Email;
        }
    }
}