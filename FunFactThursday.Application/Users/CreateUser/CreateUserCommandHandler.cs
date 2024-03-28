using FunFactThursday.Domain.common;
using FunFactThursday.Domain.Users;
using MediatR;

namespace FunFactThursday.Application.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.IsEmailUniqueAsync(request.CreateUserDto.Email, cancellationToken))
        {
            throw new Exception("Email already exists");
        }
        
        var user = User.Create(
            new UserId(Guid.NewGuid()),
            request.CreateUserDto.Email,
            request.CreateUserDto.FirstName,
            request.CreateUserDto.LastName
        );
        
        _userRepository.Add(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return user.MapToUserDto();
    }
}