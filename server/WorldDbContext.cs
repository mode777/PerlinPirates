using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.Entities;

namespace WorldServer
{
    public class WorldDbContext : DbContext
    {
        public WorldDbContext(DbContextOptions<WorldDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WorldEntity>(e =>
            {
                e.ToTable("entity");

                e.HasKey(x => new { x.ChunkX, x.ChunkY, x.X, x.Y });
                e.HasIndex(x => new { x.ChunkX, x.ChunkY });
            });
        }
        

    }
}
