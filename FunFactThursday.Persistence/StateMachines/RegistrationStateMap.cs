using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFactThursday.Persistence.StateMachines;

public class RegistrationStateMap :
    SagaClassMap<RegistrationState>
{
    protected override void Configure(EntityTypeBuilder<RegistrationState> entity, ModelBuilder model)
    {
        entity.Property(x => x.CurrentState);

        entity.Property(x => x.RegistrationDate);
        entity.Property(x => x.EventId);
        entity.Property(x => x.UserId);
        entity.Property(x => x.Payment);
    }
}