using Blocks.EntityFrameworkCore.EntityConfigurations;

namespace Submission.Persistence.EntityConfigurations;

internal class ArticleEntityConfiguration : EntityConfiguration<Article>
{
    public override void Configure(EntityTypeBuilder<Article> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(x => x.Scope)
            .IsRequired()
            .HasMaxLength(2048);

        builder.Property(e => e.Stage)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(e => e.Type)
            .HasConversion<string>()
            .IsRequired();

        builder.HasOne(x => x.Journal)
            .WithMany(x => x.Articles)
            .HasForeignKey(x => x.JournalId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}