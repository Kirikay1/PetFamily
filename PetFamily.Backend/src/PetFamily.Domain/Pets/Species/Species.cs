using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets.Species
{
    public class Species
    {
        private readonly List<Breed> _breeds = [];

        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public IReadOnlyList<Breed> Breeds => _breeds;
    }
}
