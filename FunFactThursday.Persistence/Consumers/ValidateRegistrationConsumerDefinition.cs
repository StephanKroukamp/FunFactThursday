using MassTransit;

namespace FunFactThursday.Persistence.Consumers;

public class ValidateRegistrationConsumerDefinition :
    ConsumerDefinition<ValidateRegistrationConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<ValidateRegistrationConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.UseMessageRetry(r => r.Intervals(10, 50, 100, 1000, 1000, 1000, 1000, 1000));

        endpointConfigurator.UseEntityFrameworkOutbox<FunFactThursdayDbContext>(context);
    }
}