namespace PetFamily.Domain.Pets.Species
{
    public class Species
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public List<Breed> Breeds { get; set; } = [];
    }
}
