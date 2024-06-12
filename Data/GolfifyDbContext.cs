using Microsoft.EntityFrameworkCore;
using Golfify.Core;
using Golfify.Core.Models;

namespace Golfify.API.Data
{
    public class GolfifyDbContext : DbContext
    {
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Player> Players { get; set; }

        public GolfifyDbContext(DbContextOptions<GolfifyDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Course>();

            modelBuilder.Entity<Round>()
                .OwnsMany(r => r.Courses, a =>
                {
                    a.WithOwner().HasForeignKey("RoundId");
                    a.Property<int>("Id");
                    a.HasKey("Id");
                });
        }
    }
}
