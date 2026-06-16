using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers
{
    public class Volunteer : Shared.Entity<VolunteerId>
    {
        private readonly List<Pet> _pets = [];

        private Volunteer(VolunteerId id) : base(id)
        {
        }

        private Volunteer(
            VolunteerId volunteerId,
            string fullName,
            string email,
            string description,
            double experience,
            string phone) : base(volunteerId)
        {
            FullName = fullName;
            Email = email;
            Description = description;
            Experience = experience;
            Phone = phone;
        }

        public string FullName { get; private set; } = default!;

        public string Email { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public double Experience { get; private set; } = default;

        public string Phone { get; private set; } = default!;

        public SocialNetworkDetails? SocialNetworkDetails { get; private set; }

        public RequisitesDetails? RequisitesDetails { get; private set; }

        public IReadOnlyList<Pet> Pets => _pets;

        public static Result<Volunteer> Create(VolunteerId volunteerId, string fullName, string email, string description, double experience, string phone)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return Result.Failure<Volunteer>("fullName cannot be empty");
            if (string.IsNullOrWhiteSpace(email))
                return Result.Failure<Volunteer>("email cannot be empty");
            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<Volunteer>("description cannot be empty");
            if (experience < 0)
                return Result.Failure<Volunteer>("experience cannot be negative");
            if (string.IsNullOrWhiteSpace(phone))
                return Result.Failure<Volunteer>("phone cannot be empty");

            return Result.Success(new Volunteer(
                volunteerId, fullName, email, description, experience, phone));


        }
        public int GetAdoptedAnimalsCount()
        {
            return Pets.Count(p => p.Status == PetStatus.FoundHome);
        }

        public int GetAnimalsUnderTreatmentCount()
        {
            return Pets.Count(p => p.Status == PetStatus.NeedsHelp);
        }

        public int GetUnadoptedAnimalsCount()
        {
            return Pets.Count(p => p.Status == PetStatus.LookingForHome);
        }
    }
}
