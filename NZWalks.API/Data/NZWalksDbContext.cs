using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) :  base(dbContextOptions) { }


        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> images { get; set; }

        // for seed data in DB 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // for seed data in DB for [Difficulties] table

            var Difficulties = new List<Difficulty>
            {
                new Difficulty
                {
                    Id=Guid.Parse("da6b05c0-2ab1-4275-a184-3ab2164c0970"),
                    Name="Easy"
                },
                 new Difficulty
                {
                    Id=Guid.Parse("06ac1c97-bf44-4b00-9d71-e1a430e33dd6"),
                    Name="Mediam"
                },
                  new Difficulty
                {
                    Id=Guid.Parse("1267e9c6-c2a8-41cc-a713-8a16cadeddae"),
                    Name="Hard"
                }
                
            };

            modelBuilder.Entity<Difficulty>().HasData(Difficulties);


            // for Define region data also

            var regions = new List<Region> {

            new Region{
                Name="India",
                Code="Ind",
                Id=Guid.Parse($"{Guid.NewGuid().ToString()}"),
                RegionImageUrl="https://cdn.countryflags.com/thumbs/india/flag-square-250.png"

            },
            new Region{
                Name="USA",
                Code="US",
                Id=Guid.Parse($"{Guid.NewGuid().ToString()}"),
                RegionImageUrl="https://cdn.countryflags.com/thumbs/hawaii/flag-square-250.png"

            },
            new Region{
                Name="Europe",
                Code="Eur",
                Id=Guid.Parse($"{Guid.NewGuid().ToString()}"),
                RegionImageUrl="Europe"

            }
            };

            modelBuilder.Entity<Region>().HasData(regions);

        }


    }
}
