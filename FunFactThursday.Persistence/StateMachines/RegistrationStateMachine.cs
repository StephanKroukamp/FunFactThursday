using FunFactThursday.Domain.Contracts;
using MassTransit;

namespace FunFactThursday.Persistence.StateMachines;

public class RegistrationStateMachine :
    MassTransitStateMachine<RegistrationState>
{
    public RegistrationStateMachine()
    {
        InstanceState(x => x.CurrentState);

        Event(() => RegistrationSubmitted, x => x.CorrelateById(m => m.Message.RegistrationId));

        Initially(
            When(RegistrationSubmitted)
                .Then(context =>
                {
                    context.Saga.RegistrationDate = context.Message.RegistrationDate;
                    context.Saga.EventId = context.Message.EventId;
                    context.Saga.UserId = context.Message.UserId;
                    context.Saga.Payment = context.Message.Payment;
                })
                .TransitionTo(Registered)
                .Publish(context => new SendRegistrationEmail
                {
                    RegistrationId = context.Saga.CorrelationId,
                    RegistrationDate = context.Saga.RegistrationDate,
                    EventId = context.Saga.EventId,
                    UserId = context.Saga.UserId
                })
                .If(context => context.Saga.Payment < 50m && context.GetRetryAttempt() == 0,
                    fail => fail.Then(_ =>
                        throw new ApplicationException(
                            "Really less than 50?")))
                .Publish(context => new AddEventAttendee
                {
                    RegistrationId = context.Saga.CorrelationId,
                    EventId = context.Saga.EventId,
                    UserId = context.Saga.UserId
                })
        );
    }

    //
    // ReSharper disable MemberCanBePrivate.Global
    public State Registered { get; } = null!;
    public Event<RegistrationSubmitted> RegistrationSubmitted { get; } = null!;
}