using FunFactThursday.Domain.Tickets;
using FunFactThursday.Persistence.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFactThursday.Persistence.Tickets;

internal sealed class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        ConfigureDataStructure(builder);

        ConfigureIndexes(builder);
    }

    private static void ConfigureDataStructure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable(Constants.Tables.Tickets);

        builder.HasKey(ticket => ticket.Id);

        builder.Property(ticket => ticket.Id).ValueGeneratedNever()
            .HasConversion(ticketId => ticketId.Value, value => new TicketId(value));

        builder.Property(ticket => ticket.Title).IsRequired().HasMaxLength(300);

        builder.Property(ticket => ticket.Email).IsRequired().HasMaxLength(100);

        builder.Property(ticket => ticket.Age).IsRequired();

        builder.Property(ticket => ticket.Location).IsRequired().HasMaxLength(300);

        builder.Property(ticket => ticket.TicketNumber).IsRequired().HasMaxLength(300);
        
        builder.Property(ticket => ticket.CreatedOn).IsRequired();

        builder.Property(ticket => ticket.ModifiedOn).IsRequired(false);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasIndex(ticket => ticket.TicketNumber).IsUnique();
    }
}