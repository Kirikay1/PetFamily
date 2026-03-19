using PetFamily.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Volunteer
{
    internal class Volunteer
    {
        public Guid Id { get; set; }

        public string FIO { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public double experience { get; set; }

        public string Phone { get; set; }

        public List<SocialNetwork> SocialNetworks { get; set; }

        public List<Requisites> Requisites { get; set; }

        public List<Pet> Pets { get; set; }

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
