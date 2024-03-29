using MassTransit;

namespace FunFactThursday.Persistence.StateMachines;

public class RegistrationState :
    SagaStateMachineInstance
{
    public string CurrentState { get; set; } = null!;

    public DateTime RegistrationDate { get; set; }

    public Guid EventId { get; set; }
    public Guid UserId { get; set; }
    public decimal Payment { get; set; }
    public Guid CorrelationId { get; set; }
}