using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets.Species;

namespace PetFamily.Domain.Pets
{
    public record PetType
    {
        public PetType(SpeciesId speciesId, Guid breedId)
        {
            SpeciesId = speciesId;
            BreedId = breedId;
        }

        public SpeciesId SpeciesId { get; }
        public Guid BreedId { get; }

        public static Result<PetType> Create(SpeciesId speciesId, Guid breedId)
        {
            if (speciesId == null)
                return Result.Failure<PetType>("SpeciesId cannot be empty");

            if (breedId == Guid.Empty)
                return Result.Failure<PetType>("BreedId cannot be empty");

            return new PetType(speciesId, breedId);
        }

    }
}
