namespace PetFamily.Domain.Pets
{
    public record PetPhotoDetails
    {
        private readonly List<PetPhoto> _photos = [];

        public IReadOnlyList<PetPhoto> Photos => _photos;
    }
}
