using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Pets
{
    public record PetPhoto
    {
        private PetPhoto(string pathToStorage, bool isMainPhoto)
        {
            PathToStorage = pathToStorage;
            IsMainPhoto = isMainPhoto;
        }

        public string PathToStorage { get; }

        public bool IsMainPhoto { get; }

        public static Result<PetPhoto> Create(string pathToStorage, bool isMainPhoto)
        {
            if (string.IsNullOrWhiteSpace(pathToStorage))
                return Result.Failure<PetPhoto>("PathToStorage cannot be empty");

            return new PetPhoto(pathToStorage, isMainPhoto);
        }
    }
}
