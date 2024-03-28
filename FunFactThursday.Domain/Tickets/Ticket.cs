using FunFactThursday.Domain.common;

namespace FunFactThursday.Domain.Tickets;

public class Ticket : Entity<TicketId>, IAuditable
{
    private Ticket(
        TicketId id,
        string title,
        string email,
        int age,
        string location,
        string ticketNumber)
        : base(id)
    {
        Title = title;
        Email = email;
        Age = age;
        Location = location;
        TicketNumber = ticketNumber;
    }
    
    public string Title { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string Location { get; set; }
    public string TicketNumber { get; set; }
    public DateTimeOffset CreatedOn { get; private set; }
    public DateTimeOffset? ModifiedOn { get; private set; }
    
    public static Ticket Create(
        TicketId id,
        string title,
        string email,
        int age,
        string location)
    {
        var ticketNumber = StringGenerator.Generate();
        
        var ticket = new Ticket(id, title, email, age, location, ticketNumber);

        return ticket;
    }
}