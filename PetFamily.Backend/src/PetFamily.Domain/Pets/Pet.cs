using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets
{
    public class Pet
    {
        private Pet(string name, string description, Guid speciesId, Guid breedId, string color, string health, string address, int weight, int height, string phone, bool isCastration, DateTime birthDate, bool isVaccination, string status, IReadOnlyList<Requisites> requisites, IReadOnlyList<PetPhoto> photos)
        {
            Name = name;
            Description = description;
            SpeciesId = speciesId;
            BreedId = breedId;
            Color = color;
            Health = health;
            Address = address;
            Weight = weight;
            Height = height;
            Phone = phone;
            IsCastration = isCastration;
            BirthDate = birthDate;
            IsVaccination = isVaccination;
            Status = status;
            Requisites = requisites;
            Photos = photos;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; } = default!;

        public Guid SpeciesId { get; private set; }

        public string Description { get; private set; } = default!;

        public Guid BreedId { get; private set; }

        public string Color { get; private set; } = default!;

        public string Health { get; private set; } = default!;
        public string Address { get; private set; } = default!;

        public int Weight { get; private set; } = default;

        public int Height { get; private set; } = default;
        public string Phone { get; private set; } = default!;

        public bool IsCastration { get; private set; } = default;

        public DateTime BirthDate { get; private set; } = default;
        public bool IsVaccination { get; private set; } = default;

        public string Status { get; private set; } = default!;

        public IReadOnlyList<Requisites> Requisites { get; private set; } = new List<Requisites>();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public IReadOnlyList<PetPhoto> Photos { get; private set; } = new List<PetPhoto>();

        public static Result<Pet> Create(string name, string description, Guid speciesId, Guid breedId, string color, string health, string address, int weight, int height, string phone, bool isCastration, DateTime birthDate, bool isVaccination, string status, IReadOnlyList<Requisites> requisites, IReadOnlyList<PetPhoto> photos)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Pet>("Name cannot be empty");
            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<Pet>("Description cannot be empty");
            if (speciesId == Guid.Empty)
                return Result.Failure<Pet>("SpeciesId cannot be empty");
            if (breedId == Guid.Empty)
                return Result.Failure<Pet>("Breed cannot be empty");
            if (string.IsNullOrWhiteSpace(color))
                return Result.Failure<Pet>("Color cannot be empty");
            if (string.IsNullOrWhiteSpace(health))
                return Result.Failure<Pet>("Health cannot be empty");
            if (string.IsNullOrWhiteSpace(address))
                return Result.Failure<Pet>("Address cannot be empty");
            if (weight <= 0)
                return Result.Failure<Pet>("Weight must be greater than zero");
            if (height <= 0)
                return Result.Failure<Pet>("Height must be greater than zero");
            if (string.IsNullOrWhiteSpace(phone))
                return Result.Failure<Pet>("Phone cannot be empty");
            if (string.IsNullOrWhiteSpace(status))
                return Result.Failure<Pet>("Status cannot be empty");
            if (birthDate >= DateTime.UtcNow)
                return Result.Failure<Pet>("BirthDate must be in the past");
            if (requisites == null || requisites.Count == 0)
                return Result.Failure<Pet>("Requisites cannot be empty");
            if (photos == null || photos.Count == 0)
                return Result.Failure<Pet>("Photos cannot be empty");

            return new Pet(name, description, speciesId, breedId, color, health, address, weight, height, phone, isCastration, birthDate, isVaccination, status, requisites, photos);
        }
    }
}
