using Blocks.EntityFrameworkCore.EntityConfigurations;

namespace Submission.Persistence.EntityConfigurations;

internal class JournalEntityConfiguration : EntityConfiguration<Journal>
{
    public override void Configure(EntityTypeBuilder<Journal> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.Name)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(x => x.Abbreviation)
            .HasMaxLength(8)
            .IsRequired();
    }
}