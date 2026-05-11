using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers
{
    public class Volunteer
    {
        public Guid Id { get; private set; }

        public string FullName { get; private set; } = default!;

        public string Email { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public double Experience { get; private set; } = default;

        public string Phone { get; private set; } = default!;

        public IReadOnlyList<SocialNetwork> SocialNetworks { get; private set; } = new List<SocialNetwork>();

        public IReadOnlyList<Requisites> Requisites { get; private set; } = new List<Requisites>();

        public IReadOnlyList<Pet> Pets { get; private set; } = new List<Pet>();

        private Volunteer(
            string fullName,
            string email,
            string description,
            double experience,
            string phone,
            IReadOnlyList<SocialNetwork> socialNetworks,
            IReadOnlyList<Requisites> requisites)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            Description = description;
            Experience = experience;
            Phone = phone;
            SocialNetworks = socialNetworks;
            Requisites = requisites;
        }

        public static Result<Volunteer> Create(string fullName, string email, string description, double experience, string phone, IReadOnlyList<SocialNetwork> socialNetworks, IReadOnlyList<Requisites> requisites)
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
            if (socialNetworks == null || socialNetworks.Count == 0)
                return Result.Failure<Volunteer>("SocialNetworks cannot be empty");
            if (requisites == null || requisites.Count == 0)
                return Result.Failure<Volunteer>("Requisites cannot be empty");

            return Result.Success(new Volunteer(
           fullName, email, description, experience, phone, socialNetworks, requisites));


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
