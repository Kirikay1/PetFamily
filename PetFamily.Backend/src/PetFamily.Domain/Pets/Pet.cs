using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets
{
    public class Pet : Shared.Entity<PetId>
    {
        private readonly List<Requisites> _requisites = [];

        private readonly List<PetPhoto> _photos = [];

        private Pet(PetId id) : base(id)
        {
        }

        private Pet(
            PetId petId,
            string name, 
            string description, 
            Guid speciesId, 
            Guid breedId, 
            string color, 
            string health, 
            string address, 
            int weight, 
            int height, 
            string phone,
            bool isCastration,
            DateOnly birthDate,
            bool isVaccination, 
            PetStatus status) : base(petId)
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
        }

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

        public DateOnly BirthDate { get; private set; } = default;
        public bool IsVaccination { get; private set; } = default;

        public PetStatus Status { get; private set; } = default!;

        public IReadOnlyList<Requisites> Requisites => _requisites;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public IReadOnlyList<PetPhoto> Photos => _photos;

        public static Result<Pet> Create(PetId petId, string name, string description, Guid speciesId, Guid breedId, string color, string health, string address, int weight, int height, string phone, bool isCastration, DateOnly birthDate, bool isVaccination, PetStatus status)
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
            if (!Enum.IsDefined(status))
                return Result.Failure<Pet>("Invalid pet status");
            if (birthDate >= DateOnly.FromDateTime(DateTime.UtcNow))
                return Result.Failure<Pet>("BirthDate must be in the past");

            var pet = new Pet(petId, name, description, speciesId, breedId, color, health, address, weight, height, phone, isCastration, birthDate, isVaccination, status);

            return Result.Success(pet);
        }
    }
}
