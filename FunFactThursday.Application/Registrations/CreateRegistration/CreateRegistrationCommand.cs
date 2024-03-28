using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace FunFactThursday.Application.Registrations.CreateRegistration;

public class CreateRegistrationCommand : IRequest<RegistrationDto>
{
    public string EventId { get; set; } = null!;

    public string MemberId { get; set; } = null!;

    public decimal Payment { get; set; }
}