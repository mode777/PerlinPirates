using Microsoft.EntityFrameworkCore;
using WorldServer.Entities;
using WorldServer.ValueObjects;

namespace WorldServer.Database
{
    public class WorldContext : DbContext
    {
        public WorldContext(DbContextOptions<WorldContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorldEntity>(w =>
            {

                w.HasDiscriminator<string>("type")
                    .HasValue<PlayerEntity>("player")
                    .HasValue<GameEntity<City>>("city");

                w.Property(x => x.Id).HasMaxLength(128);
                w.HasKey(x => x.Id);

                w.HasIndex(x => new { x.ChunkX, x.ChunkY });

                w.Property<string>("Json")
                    .HasField("_json")
                    .UsePropertyAccessMode(PropertyAccessMode.Field);
                
            });

            modelBuilder.Entity<PlayerEntity>(p =>
            {
                p.Ignore(x => x.Hitbox);
                p.Ignore(x => x.PixelX);
                p.Ignore(x => x.PixelY);
                p.Ignore(x => x.Payload);
            });
        }

    }

}

