using CSharpFunctionalExtensions;
using PetFamily.Domain.Pets;

namespace PetFamily.Domain.Volunteers
{
    internal class Volunteer : Entity
    {
        public Guid Id { get; set; }

        public string FIO { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Description { get; set; } = default!;

        public double experience { get; set; } = default;

        public string Phone { get; set; } = default!;

        public List<SocialNetwork> SocialNetworks { get; set; } = [];

        public List<Requisites> Requisites { get; set; } = [];

        public List<Pet> Pets { get; set; } = [];

        public int GetAdoptedAnimalsCount()
        {
            return 0;
        }

        public int GetAnimalsUnderTreatmentCount()
        {
            return 0;
        }

        public int GetUnadoptedAnimalsCount()
        {
            return 0;
        }
    }
}
