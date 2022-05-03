using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiApricode.Data.Contracts.Models.Entities;

namespace WebApiApricode.Data.Ef.Configurations
{
    internal class GamesRepositoryConfiguration : IEntityTypeConfiguration<GameEntity>
    {
        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            builder.ToTable("Games")
                .HasKey(g => g.Id);
            builder.HasIndex(g => g.Genres);
            builder.Property(p => p.Title)
                .IsRequired();
        }
    }
}