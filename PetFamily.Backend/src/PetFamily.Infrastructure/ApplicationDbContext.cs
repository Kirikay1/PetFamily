using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Pets.Species;
using PetFamily.Domain.Volunteers;
using static CSharpFunctionalExtensions.Result;

namespace PetFamily.Infrastructure
{
    public class ApplicationDbContext(IConfiguration configuration) : DbContext
    {
        private const string DATABASE = "DataBase";

        public DbSet<Pet> Pets => Set<Pet>();
        public DbSet<Volunteer> Volunteers => Set<Volunteer>();
        public DbSet<Breed> Breeds => Set<Breed>();
        public DbSet<Species> Species => Set<Species>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(DATABASE));
            optionsBuilder.UseSnakeCaseNamingConvention();
        }

    }
}
