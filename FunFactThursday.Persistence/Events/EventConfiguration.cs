using FunFactThursday.Domain.Events;
using FunFactThursday.Persistence.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFactThursday.Persistence.Events;

internal sealed class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        ConfigureDataStructure(builder);

        ConfigureIndexes(builder);
    }

    private static void ConfigureDataStructure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable(Constants.Tables.Events);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Name);

        builder.Property(x => x.TotalDonations);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Event> builder)
    {
        builder.HasIndex(x => new
        {
            x.Name
        }).IsUnique();
    }
}