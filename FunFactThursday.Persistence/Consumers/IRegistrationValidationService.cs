namespace FunFactThursday.Persistence.Consumers;

public interface IRegistrationValidationService
{
    Task ValidateRegistration(Guid eventId, Guid userId, Guid registrationId);
}