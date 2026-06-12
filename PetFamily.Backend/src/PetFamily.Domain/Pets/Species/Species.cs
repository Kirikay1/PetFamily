using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets.Species
{
    public class Species : Shared.Entity<SpeciesId>
    {
        private readonly List<Breed> _breeds = [];

        private Species(SpeciesId id) : base(id)
        {
        }

        private Species(SpeciesId id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; private set; } = default!;

        public IReadOnlyList<Breed> Breeds => _breeds;

        public static Result<Species> Create(SpeciesId id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Species>("Species name cannot be empty.");
            var species = new Species(id, name);
            return Result.Success(species);
        }
    }
}
