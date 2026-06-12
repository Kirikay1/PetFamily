namespace PetFamily.Domain.Pets.Species
{
    public class Breed
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = default!;
    }
}
