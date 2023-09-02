using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class GameInfoConfiguration : IEntityTypeConfiguration<GameInfo>
{
    public void Configure(EntityTypeBuilder<GameInfo> builder)
    {
        builder.HasKey(x => x.Guid);
        builder.Property(x => x.Guid).ValueGeneratedOnAdd();
        builder.Property(x => x.Width).HasMaxLength(3).IsRequired();
        builder.Property(x => x.Width).HasMaxLength(3).IsRequired();
        builder.Property(x => x.MinesCount).HasMaxLength(3).IsRequired();
        builder.Property(x => x.Completed).IsRequired();
        builder.Property(x => x.Field);
        builder.Property(x => x.OriginField);
        builder.Property(x => x.TurnInfos);
    }
}