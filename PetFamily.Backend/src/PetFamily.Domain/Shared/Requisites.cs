namespace PetFamily.Domain.Shared
{
    public class Requisites
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;
    }
}
