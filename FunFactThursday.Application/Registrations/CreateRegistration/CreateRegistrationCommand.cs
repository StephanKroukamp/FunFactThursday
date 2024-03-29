using MediatR;

namespace FunFactThursday.Application.Registrations.CreateRegistration;

public class CreateRegistrationCommand : IRequest<RegistrationDto>
{
    public decimal Payment { get; set; }
}