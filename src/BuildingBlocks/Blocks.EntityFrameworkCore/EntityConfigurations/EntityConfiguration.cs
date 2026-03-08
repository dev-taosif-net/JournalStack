using Blocks.Domain.Entities;

namespace Blocks.EntityFrameworkCore.EntityConfigurations;

public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd()
            .HasColumnOrder(1)
            .IsRequired();
    }
}