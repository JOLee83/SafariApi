using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SafariApi.Models;

namespace SafariApi
{
  public partial class SeenAnimalsContext : DbContext
  {
    public SeenAnimalsContext()
    {
    }

    public SeenAnimalsContext(DbContextOptions<SeenAnimalsContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        optionsBuilder.UseNpgsql("server=localhost;database=SafariDb;userid=postgres;password=xiixvii");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<SeenAnimals>().HasData(
          new SeenAnimals { Id = -1, Species = "Lion", CountOfTimesSeen = 1, LocationOfLastSeen = "Field" },
          new SeenAnimals { Id = -2, Species = "Zebra", CountOfTimesSeen = 8, LocationOfLastSeen = "Field" },
          new SeenAnimals { Id = -3, Species = "Elephant", CountOfTimesSeen = 7, LocationOfLastSeen = "Lake" },
          new SeenAnimals { Id = -4, Species = "Hyena", CountOfTimesSeen = 42, LocationOfLastSeen = "Cavern" }
      );
    }
    public DbSet<SeenAnimals> SeenAnimals { get; set; }
  }
}
