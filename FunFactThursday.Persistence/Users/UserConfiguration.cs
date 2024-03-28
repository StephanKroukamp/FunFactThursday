using FunFactThursday.Domain.Users;
using FunFactThursday.Persistence.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FunFactThursday.Persistence.Users;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureDataStructure(builder);

        ConfigureIndexes(builder);
    }

    private static void ConfigureDataStructure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(Constants.Tables.Users);

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id).ValueGeneratedNever();

        builder.Property(user => user.Email).IsRequired().HasMaxLength(300);

        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(100);

        builder.Property(user => user.LastName).IsRequired().HasMaxLength(100);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(user => user.Email).IsUnique();
    }
}