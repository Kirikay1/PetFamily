using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets.Species;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets
{
    public class Pet : Shared.Entity<PetId>
    {
        private Pet(PetId id) : base(id)
        {
        }

        private Pet(
            PetId petId,
            string name,
            PetType petType,
            string description, 
            string color, 
            string health,
            Address address, 
            int weight, 
            int height, 
            string phone,
            bool isCastration,
            DateOnly birthDate,
            bool isVaccination, 
            PetStatus status) : base(petId)
        {
            Name = name;
            SpeciesId = petType.SpeciesId;
            BreedId = petType.BreedId;
            Description = description;
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

        public SpeciesId SpeciesId { get; private set; } = default!;

        public Guid BreedId { get; private set; }

        public PetType PetType => new(SpeciesId, BreedId);

        public string Description { get; private set; } = default!;

        public string Color { get; private set; } = default!;

        public string Health { get; private set; } = default!;
        public Address Address { get; private set; } = default!;

        public int Weight { get; private set; } = default;

        public int Height { get; private set; } = default;
        public string Phone { get; private set; } = default!;

        public bool IsCastration { get; private set; } = default;

        public DateOnly BirthDate { get; private set; } = default;
        public bool IsVaccination { get; private set; } = default;

        public PetStatus Status { get; private set; } = default!;

        public RequisitesDetails? RequisitesDetails { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public PetPhotoDetails? PhotosDetails { get; private set; }

        public static Result<Pet> Create(PetId petId, string name, string description, PetType petType, string color, string health, Address address, int weight, int height, string phone, bool isCastration, DateOnly birthDate, bool isVaccination, PetStatus status)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Pet>("Name cannot be empty");
            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<Pet>("Description cannot be empty");
            if (petType == null)
                return Result.Failure<Pet>("PetType cannot be null");
            if (string.IsNullOrWhiteSpace(color))
                return Result.Failure<Pet>("Color cannot be empty");
            if (string.IsNullOrWhiteSpace(health))
                return Result.Failure<Pet>("Health cannot be empty");
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

            var pet = new Pet(petId, name, petType, description, color, health, address, weight, height, phone, isCastration, birthDate, isVaccination, status);

            return Result.Success(pet);
        }
    }
}
