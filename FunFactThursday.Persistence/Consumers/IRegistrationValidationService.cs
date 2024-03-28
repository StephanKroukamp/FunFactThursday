namespace FunFactThursday.Persistence.Consumers;

public interface IRegistrationValidationService
{
    Task ValidateRegistration(string eventId, string memberId, Guid registrationId);
}