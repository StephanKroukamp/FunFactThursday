using FunFactThursday.Domain.Registrations;
using FunFactThursday.Persistence.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFactThursday.Persistence.Registrations;

internal sealed class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        ConfigureDataStructure(builder);

        ConfigureRelationships(builder);
        
        ConfigureIndexes(builder);
    }

    private static void ConfigureDataStructure(EntityTypeBuilder<Registration> builder)
    {
        builder.ToTable(Constants.Tables.Registrations);

        builder.HasKey(registration => registration.Id);

        builder.Property(registration => registration.Id).ValueGeneratedNever();

        builder.Property(x => x.RegistrationDate);
        builder.Property(x => x.UserId).HasMaxLength(64);
        builder.Property(x => x.EventId).HasMaxLength(64);
        builder.Property(x => x.Payment);
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Registration> builder)
    {
        builder
            .HasOne(registration => registration.User)
            .WithMany(user => user.Registrations)
            .HasForeignKey(registration => registration.UserId);
        
        builder
            .HasOne(registration => registration.Event)
            .WithMany(@event => @event.Registrations)
            .HasForeignKey(registration => registration.EventId);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Registration> builder)
    {
        builder.HasIndex(x => new
        {
            x.UserId,
            x.EventId
        }).IsUnique();
    }
}