namespace Submission.Persistence.EntityConfigurations;

internal class JournalEntityConfiguration : IEntityTypeConfiguration<Journal>
{
    public void Configure(EntityTypeBuilder<Journal> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnOrder(0)
            .IsRequired();
        
        builder.Property(x => x.Name)
            .HasMaxLength(64)
            .IsRequired();
        
        builder.Property(x => x.Abbreviation)
            .HasMaxLength(8)
            .IsRequired();
    }
}